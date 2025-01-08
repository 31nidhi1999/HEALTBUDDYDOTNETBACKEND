using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper; // For AutoMapper integration
using Health.Entity;
using HealthBuddyDotnetBE.Entities;
using HealthBuddyDotnetBE.Exceptions.CustomException;
using HealthBuddyDotnetBE.Repositories.Declaration;
using HealthBuddyDotnetBE.RequestDto;//.Health.ReqDto;
using HealthBuddyDotnetBE.ResponseDto;
using HealthBuddyDotnetBE.Services.Declaration;

namespace Health.Service
{
    public class HospitalService : IHospitalService
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper; // AutoMapper instance

        // Constructor to inject dependencies
        public HospitalService(IHospitalRepository hospitalRepository, IDoctorRepository doctorRepository, IMapper mapper)
        {
            _hospitalRepository = hospitalRepository;
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public List<HospitalResDto> GetAllHospitals()
        {
            var hospitals = _hospitalRepository.GetAllHospitals()
            ?? throw new ResourceNotFoundException("No hospitals found.");

            return hospitals.Select(h => _mapper.Map<HospitalResDto>(h)).ToList();
        }

        public ApiResponse AddHospital(HospitalReqDto hospitalReqDto)
        {
            var hospital = _mapper.Map<Hospital>(hospitalReqDto);
            long id = _hospitalRepository.AddHospital(hospital);
            return new ApiResponse("Hospital is added with id: " + id);
        }

        public ApiResponse AddDoctor(long hospId, long doctorId)
        {
            var hospital = _hospitalRepository.GetHospitalById(hospId)
                ?? throw new ResourceNotFoundException("Hospital not found.");

            Doctor doctor = _doctorRepository.GetDoctorById(doctorId)
                ?? throw new ResourceNotFoundException("Doctor not found.");


            if (hospital.Doctors == null) 
            { 
                hospital.Doctors = new List<Doctor>();
            }

            if (doctor.Hospitals == null) { 
                doctor.Hospitals = new List<Hospital>();
            }

            hospital.Doctors.Add(doctor);
           // doctor.Hospitals.Add(hospital);
            _hospitalRepository.UpdateHospital(hospital);
            return new ApiResponse( "Doctor "+doctor.Id+" Hospital "+hospital.Id+" added successfully.");
        }

        public string ActivateHospital(long hospId)
        {
            var hospital = _hospitalRepository.GetHospitalById(hospId)
                ?? throw new ResourceNotFoundException("Hospital not found.");

            hospital.IsActive = true;
            _hospitalRepository.UpdateHospital(hospital);
            return "Hospital activated successfully.";
        }

        public string InActivateHospital(long hospId)
        {
            var hospital = _hospitalRepository.GetHospitalById(hospId)
                ?? throw new ResourceNotFoundException("Hospital not found.");

            hospital.IsActive = false;
            _hospitalRepository.UpdateHospital(hospital);
            return "Hospital deactivated successfully.";
        }

        public ApiResponse RemoveDoctor(long hospId, long doctorId)
        {
            var hospital = _hospitalRepository.GetHospitalById(hospId)
                ?? throw new ResourceNotFoundException("Hospital not found.");
            
            var doctor = hospital.Doctors.FirstOrDefault(d => d.Id == doctorId)
                ?? throw new ResourceNotFoundException("Doctor not found in the hospital.");

            if (hospital.Doctors.Remove(doctor)) {
                return new ApiResponse("Doctor removed successfully.");
            }
            return new ApiResponse("Doctor Doctor not available in hospital to remove");

        }

        public List<HospitalResDto> GetActiveHospitals()
        {
            return _hospitalRepository.GetAllHospitals()
                .Where(h=>h.IsActive==true)
                .Select(h=>_mapper.Map<HospitalResDto>(h))
                .ToList();
                
        }

        public ApiResponse UpdateHospital(long hospId, HospitalReqDto hospitalReqDto)
        {
            var hospital = _hospitalRepository.GetHospitalById(hospId)
                ?? throw new ResourceNotFoundException("Hospital not found.");

            _mapper.Map(hospitalReqDto, hospital);
            _hospitalRepository.UpdateHospital(hospital);
            return new ApiResponse ( "Hospital updated successfully." );
        }
    }
}
