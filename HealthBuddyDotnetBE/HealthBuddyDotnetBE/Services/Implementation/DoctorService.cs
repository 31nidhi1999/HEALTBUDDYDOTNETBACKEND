using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper; // This part: Using AutoMapper for object mapping
using HealthBuddyDotnetBE.Contexts;
using HealthBuddyDotnetBE.Entities;
using HealthBuddyDotnetBE.Exceptions.CustomException;
using HealthBuddyDotnetBE.Repositories.Declaration;
using HealthBuddyDotnetBE.Repositories.Implementation;
using HealthBuddyDotnetBE.RequestDto;
using HealthBuddyDotnetBE.ResponseDto;
using HealthBuddyDotnetBE.Services.Declaration;
using Microsoft.EntityFrameworkCore;

namespace Health.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUserRepository _userRepository; // This part: User repository for managing user-related operations
        private readonly IMapper _mapper; // This part: AutoMapper for mapping between DTOs and entities
        private HealhBuddyContext _context;

        // Constructor to inject dependencies
        public DoctorService(HealhBuddyContext context,IDoctorRepository doctorRepository, IUserRepository userRepository, IMapper mapper) // This part: Added user repository and mapper to constructor
        {
            _doctorRepository = doctorRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _context = context;
        }

        public ApiResponse AddDoctor(DoctorReqDto doctorReqDto)
        {
           Doctor doctor = _mapper.Map<Doctor>(doctorReqDto);
            doctor.User = new User();
            doctor.User.UserName =doctorReqDto.Email;
            doctor.User.Password =doctorReqDto.Password;
            
            var user = new User(doctor.User.UserName, doctor.User.Password, UserRole.ROLE_DOCTOR, true);
            if (_userRepository.GetUserByName(doctor.User.UserName) != null) {
                throw new ApiException("User" + doctor.User.UserName + "is already exist");
            }
           
            _userRepository.AddUser(user);
            doctor.User = user;
           long id =  _doctorRepository.AddDoctor(doctor);
            return new ApiResponse("Doctor is added with id: " + id);

        }

        public List<DoctorResDto> GetDoctorsByHospital(long hospId)
        {
            List<Doctor> doctors = _doctorRepository.GetDoctorsByHospitalId(hospId);
           List<DoctorResDto> res = new List<DoctorResDto>();
            foreach (Doctor doctor in doctors)
            {
                res.Add(_mapper.Map<DoctorResDto>(doctor));
            }
            return res;
               
        }

        public DoctorResDto GetDoctorById(long doctorId)
        {
            var doctor = _doctorRepository.GetDoctorById(doctorId)
                ?? throw new ResourceNotFoundException("Doctor",doctorId);
       

            return _mapper.Map<DoctorResDto>(doctor);
        }

        public List<DoctorResDto> GetAllDoctors()
        {
            var doctors = _doctorRepository.GetAllDoctors();

            return doctors
                .Select(d => _mapper.Map<DoctorResDto>(d)).ToList(); 
        }

        public ApiResponse UpdateDoctor(long doctorId, DoctorReqDto doctorReqDto)
        {
            Doctor doctor = _doctorRepository.GetDoctorById(doctorId)
                ?? throw new ResourceNotFoundException("doctor",doctorId);

            long id = doctor.UserId;

            User user  = _userRepository.GetUserById(doctor.UserId);

           

            doctor.Specialization=doctorReqDto.Specialization;
            doctor.Email=doctorReqDto.Email;
            user.UserName = doctorReqDto.Email;

            doctor.Experience=doctorReqDto.Experience;
            doctor.Name=doctorReqDto.Name;
            user.Password=doctorReqDto.Password;
            doctor.Contact=doctorReqDto.Contact;
            _doctorRepository.UpdateDoctor(doctor);
            return new ApiResponse("Doctor updated successfully.");
        }

        public ApiResponse InactivateDoctor(long doctorId)
        {
            var doctor = _doctorRepository.GetDoctorById(doctorId)
                ?? throw new ResourceNotFoundException("Doctor",doctorId);
            doctor.User.IsActive = false; // This part: Managing activation state of the associated User entity
            _doctorRepository.UpdateDoctor(doctor);
            return new ApiResponse( "Doctor inactivated successfully." );
        }


        public List<DoctorResDto> GetAllActiveDoctors()
        {

            List<DoctorResDto> activeDoctors = (from doctor in _context.Doctors
                                                join user in _context.Users on doctor.UserId equals user.Id
                                                where user.IsActive
                                                select new DoctorResDto
                                                {
                                                    Id = doctor.Id,
                                                    Name = doctor.Name,
                                                    Email = user.UserName,
                                                    Specialization = doctor.Specialization,
                                                    Experience = doctor.Experience
                                                }).ToList();
            return activeDoctors;
        }

        public ApiResponse ActivateDoctor(long doctorId)
        {
            var doctor = _doctorRepository.GetDoctorById(doctorId)
                ?? throw new ResourceNotFoundException("Doctor",doctorId);
         
            doctor.User.IsActive = true; 
            _doctorRepository.UpdateDoctor(doctor);
            return new ApiResponse( "Doctor activated successfully." );
        }
    }
}
