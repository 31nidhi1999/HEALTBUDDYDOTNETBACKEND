using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper; // this part - AutoMapper is used for mapping DTOs
using Health.Entity;
using HealthBuddyDotnetBE.Contexts;
using HealthBuddyDotnetBE.Entities;
using HealthBuddyDotnetBE.Exceptions.CustomException;
using HealthBuddyDotnetBE.Repositories.Declaration;
using HealthBuddyDotnetBE.Repositories.Implementation;
using HealthBuddyDotnetBE.RequestDto;
using HealthBuddyDotnetBE.ResponseDto;
using HealthBuddyDotnetBE.Services.Declaration;
using NodaTime;
//using HealthBuddyDotnetBE.Exceptions; // this part - Custom exception classes

namespace Health.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IHospitalRepository _hospitalRepository;
        private readonly IPatientRepository _patientRepository;
        private ITimeSlotRepository _timeSlotRepository;
        private HealhBuddyContext healthBuddyContext;
        private readonly IMapper _mapper; // this part - Added AutoMapper

        // Constructor for dependency injection
        public AppointmentService(
            IAppointmentRepository appointmentRepository,
            IDoctorRepository doctorRepository,
            IHospitalRepository hospitalRepository,
            IPatientRepository patientRepository,
            HealhBuddyContext context,
            IMapper mapper) // this part - Added IMapper to constructor
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
            _hospitalRepository = hospitalRepository;
            _patientRepository = patientRepository;
            _mapper = mapper; // this part
            this.healthBuddyContext = context;
        }

        public AppointmentResDto BookAppointment(AppointmentReqDto appointment)
        {
            TimeSlot timeSlot = new TimeSlot();
            var doctor = _doctorRepository.GetDoctorById(appointment.DoctorId)
                 ?? throw new ResourceNotFoundException("Doctor", appointment.DoctorId);

            var hospital = _hospitalRepository.GetHospitalById(appointment.HospitalId)
                ?? throw new ResourceNotFoundException("Hospital", appointment.HospitalId);

            var patient = _patientRepository.GetPatientById(appointment.PatientId)
              ?? throw new ResourceNotFoundException("Patient", appointment.PatientId);

           var  _healthBuddyContext = healthBuddyContext ?? throw new ArgumentNullException(nameof(healthBuddyContext));


            timeSlot.StartTime = TimeSpan.Parse(timeSlot.StartTime.ToString());
            healthBuddyContext.TimeSlots.Add(timeSlot);

            List<AppointmentResDto> bookedTimeSlot = _appointmentRepository
    
            .findBookedTimeSlotByDoctorandDate(doctor.Id, appointment.AppointmentDate)
                .Select(appointment => new AppointmentResDto { StartTime = appointment.TimeSlot.StartTime }).ToList();

            if (bookedTimeSlot.Any(t => t.CompareTo(timeSlot.StartTime) == 0)) 
            { throw new ApiException("Time slot not available"); }

            var appointment1 =_mapper.Map<Appointment>(appointment);
            appointment1.TimeSlot.StartTime = timeSlot.StartTime;
            appointment1.AppointmentDate = appointment.AppointmentDate;

           
            appointment1.PatientId =patient.Id;
            appointment1.DoctorId = doctor.Id;
            appointment1.HospitalId = hospital.Id;  
            //appointment1.Hospital.Id = hospital.Id;
            appointment1.Status = AppointmentStatus.PENDING;

            var appointment2 = _mapper.Map<AppointmentResDto>(appointment1);
            appointment2.PatientName=patient.FirstName + " " + patient.LastName;
            appointment2.DoctorName=doctor.Name;
            appointment2.HospitalName=hospital.Name;
            appointment2.StartTime = timeSlot.StartTime;

            return appointment2;

        }

        public List<AppointmentResDto> GetAllAppointments()
        {
            var appointments = _appointmentRepository.GetAllAppointment();
            return _mapper.Map<List<AppointmentResDto>>(appointments); // this part - AutoMapper for mapping list
        }

        public List<AppointmentResDto> GetAppointmentsByDoctorId(long doctorId)
        {
            var doctor = _doctorRepository.GetDoctorById(doctorId)
                ?? throw new ResourceNotFoundException("Doctor",doctorId);

            return _appointmentRepository.FindByDoctor(doctor).Select(a => {
                var resDto = _mapper.Map<Appointment, AppointmentResDto>(a);
                resDto.DoctorName = a.Doctor.Name;
                resDto.PatientName = $"{a.Patient.FirstName} {a.Patient.LastName}";
                resDto.HospitalName = a.Hospital.Name;
                resDto.StartTime=a.TimeSlot.StartTime;
                return resDto;
            }).ToList();
        }

        public List<AppointmentResDto> GetAppointmentsByHospitalId(long hospId)
        {
            var hospital = _hospitalRepository.GetHospitalById(hospId)
                ?? throw new ResourceNotFoundException("Hospital",hospId);

            return _appointmentRepository.FindByHopital(hospital).Select(a =>{
                var resDto = _mapper.Map<AppointmentResDto>(a);
                resDto.DoctorName = a.Doctor.Name;
                resDto.PatientName = $"{a.Patient.FirstName} {a.Patient.LastName}";
                resDto.HospitalName = a.Hospital.Name;
                resDto.StartTime = a.TimeSlot.StartTime;
                return resDto;
            }).ToList();
            
        }

        public AppointmentResDto GetAppointment(long id)
        {
            var appointment = _appointmentRepository.GetAppointmentById(id)
                ?? throw new ResourceNotFoundException("Appointment", id);

            var resDto = _mapper.Map<AppointmentResDto>(appointment);

            resDto.DoctorName = appointment.Doctor.Name;
            resDto.PatientName = $"{appointment.Patient.FirstName} {appointment.Patient.LastName}";
            resDto.HospitalName = appointment.Hospital.Name;
            resDto.StartTime = appointment.TimeSlot.StartTime;

            return resDto;

        }

        public string CancelAppointment(long appointId)
        {
            var appointment = _appointmentRepository.GetAppointmentById(appointId)
                ?? throw new ResourceNotFoundException("Appointment", appointId);


           appointment.Status = AppointmentStatus.CANCELLED;
            _appointmentRepository.Update(appointment);

            return "Appointment cancelled successfully.";
        }

        public string CompleteAppointment(long appointId)
        {
            var appointment = _appointmentRepository.GetAppointmentById(appointId)
                ?? throw new ResourceNotFoundException("Appointment", appointId);

            appointment.Status =AppointmentStatus.COMPLETED ;
            _appointmentRepository.Update(appointment);

            return "Appointment completed successfully.";
        }

        public List<AppointmentResDto> GetAppointmentsByPatientId(long patientId)
        {
            var patient = _patientRepository.GetPatientById(patientId)
                ?? throw new ResourceNotFoundException("Patient",patientId);
           
           return _appointmentRepository.FindByPatient(patient).Select(a =>
           {
               var resDto = _mapper.Map<Appointment, AppointmentResDto>(a);
               resDto.DoctorName = a.Doctor.Name;
               resDto.PatientName = $"{a.Patient.FirstName} {a.Patient.LastName}";
               resDto.HospitalName = a.Hospital.Name;
               resDto.StartTime = a.TimeSlot.StartTime;
               return resDto;
           }).ToList();
        }
    }
}
