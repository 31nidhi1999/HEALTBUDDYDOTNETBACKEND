using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthBuddyDotnetBE.Entities
{
    [Table("TimeSlot")]
    public class TimeSlot : BaseEntity
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }



        // [ForeignKey("DoctorId")]
        // public Doctor Doctor { get; set; }

        // [ForeignKey("HospitalId")]
        // public Hospital Hospital { get; set; }
    }
}
