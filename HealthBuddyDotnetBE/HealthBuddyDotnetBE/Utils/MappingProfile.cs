using AutoMapper;
using Health.Entity;
using HealthBuddyDotnetBE.Entities;
using HealthBuddyDotnetBE.RequestDto;
using HealthBuddyDotnetBE.ResponseDto;
using NodaTime;

namespace HealthBuddyDotnetBE.Utils
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<DoctorReqDto, Doctor>();
            CreateMap<Doctor, DoctorResDto>();

            CreateMap<Hospital, HospitalResDto>();
            CreateMap<HospitalReqDto, Hospital>();

            CreateMap<PatientReqDto, Patient>();
            CreateMap<Patient, PatientResDto>();

            this.CreateMap<AppointmentReqDto, Appointment>();
            CreateMap<Appointment, AppointmentResDto>();

            CreateMap<TimeSpan, TimeSlot>();
            CreateMap<DateTime, LocalDate>();



        }

    }
}
