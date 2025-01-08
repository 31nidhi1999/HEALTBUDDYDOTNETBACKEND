
using System;
using global::Health.Entity;
using HealthBuddyDotnetBE.Entities;
using HealthBuddyDotnetBE.Exceptions.CustomException;
using NodaTime;
namespace HealthBuddyDotnetBE.ResponseDto
{

        public class AppointmentResDto
        {
            public long Id { get; set; }
            public LocalDate AppointmentDate { get; set; }
            public AppointmentStatus Status { get; set; }
            public string DoctorName { get; set; }
            public string HospitalName { get; set; }
            public TimeSpan StartTime { get; set; }
            public string PatientName { get; set; }

            public override string ToString()
            {
                return $"AppointmentResDto [Id={Id}, AppointmentDate={AppointmentDate}, Status={Status}, DoctorName={DoctorName}, HospitalName={HospitalName}, StartTime={StartTime}, PatientName={PatientName}]";
            }

        internal int CompareTo(TimeSpan startTime)
        {
            throw new ApiException("TimeSlot not found");
        }
    }
    }


