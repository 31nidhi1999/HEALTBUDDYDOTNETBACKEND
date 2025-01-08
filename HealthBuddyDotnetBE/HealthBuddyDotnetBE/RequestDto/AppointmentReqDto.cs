using System.Diagnostics.CodeAnalysis;
using NodaTime;

namespace HealthBuddyDotnetBE.RequestDto

{ 
        public class AppointmentReqDto
        {
            [NotNull]
            public DateTime AppointmentDate { get; set; }
        // public AppointmentStatus Status { get; set; }

        [NotNull]   
            public long DoctorId { get; set; }

        [NotNull]
            public long HospitalId { get; set; }

        [NotNull]   
            public TimeSpan TimeSlot { get; set; }

        [NotNull]
            public long PatientId { get; set; }

            public override string ToString()
            {
                return $"AppointmentDate: {AppointmentDate}, DoctorId: {DoctorId}, HospitalId: {HospitalId}, TimeSlot: {TimeSlot}, PatientId: {PatientId}";
            }
        }
    }



