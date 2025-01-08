using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper; 
using HealthBuddyDotnetBE.Repositories.Declaration; 
using HealthBuddyDotnetBE.Exceptions;
using HealthBuddyDotnetBE.ResponseDto;
using HealthBuddyDotnetBE.Exceptions.CustomException;
using HealthBuddyDotnetBE.Services.Declaration;
using HealthBuddyDotnetBE.RequestDto;//.Health.ReqDto;
using HealthBuddyDotnetBE.Entities;
using HealthBuddyDotnetBE.Repositories.Implementation;
using HealthBuddyDotnetBE.RequestDto;
namespace Health.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUserRepository _userRepository; 
        private readonly IMapper _mapper;

        // Constructor to inject dependencies
        public PatientService(IPatientRepository patientRepository, IUserRepository userRepository, IMapper mapper) {
            _patientRepository = patientRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public List<PatientResDto> GetAllPatients()
        {
            var patients = _patientRepository.GetAllPatients(); 
            return patients.Select(patient => _mapper.Map<PatientResDto>(patient)).ToList();
        }

        public PatientResDto GetPatientById(long patientId)
        {
            var patient = _patientRepository.GetPatientById(patientId)
            ?? throw new ResourceNotFoundException("Patient", patientId);

            return _mapper.Map<PatientResDto>(patient);
        }

        public ApiResponse AddPatient(PatientReqDto patientDto)
        {
            if (patientDto == null)
            {
                throw new ArgumentNullException(nameof(patientDto));
            }

            Patient patient = _mapper.Map<Patient>(patientDto);

            patient.User = new User();
            patient.User.UserName = patientDto.Email;
            patient.User.Password = patientDto.Password;
       

            User user = new User(patient.User.UserName, patient.User.Password, UserRole.ROLE_PATIENT, true);

            var existingUser = _userRepository.GetUserByName(patient.User.UserName);
            if (existingUser != null)
            {
                throw new ApiException("User " + patient.User.UserName + " already exists");
            }

            _userRepository.AddUser(user);
            patient.User = user;
            long id = _patientRepository.AddPatient(patient);
            return new ApiResponse("Patient is added with id: " + id);
        }


        public ApiResponse InactivatePatient(long patientId)
        {
            var patient = _patientRepository.GetPatientById(patientId);
            if (patient == null)
                throw new ResourceNotFoundException($"Patient with ID {patientId} not found."); // **This part: Changed generic exception to a custom exception**

            patient.User.IsActive = false; // **This part: Updated User's IsActive property**
            _patientRepository.UpdatePatient(patient);
            return new ApiResponse("Patient inactivated successfully.");
        }

        public ApiResponse ActivatePatient(long patientId)
        {
            var patient = _patientRepository.GetPatientById(patientId);
            if (patient == null)
                throw new ResourceNotFoundException($"Patient with ID {patientId} not found."); // **This part: Changed generic exception to a custom exception**

            patient.User.IsActive = true; // **This part: Updated User's IsActive property**
            _patientRepository.UpdatePatient(patient);
            return new ApiResponse("Patient activated successfully.");
        }

      /*  public ApiResponse UpdatePatient(PatientResDto patientResDto)
        {
            Doctor doctor = _mapper<Doctor>(patientResDto);
            User user = _userRepository.GetUserById(patientResDto.)
        }*/
    }
}
