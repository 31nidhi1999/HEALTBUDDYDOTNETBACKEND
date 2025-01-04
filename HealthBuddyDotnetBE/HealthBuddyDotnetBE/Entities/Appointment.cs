using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HealthBuddyDotnetBE.Entities;
using Microsoft.EntityFrameworkCore;
using NodaTime;

namespace Health.Entity
{
    public class Appointment : BaseEntity
    {
        public DateTime AppointmentDate { get; set; }

        [EnumDataType(typeof(AppointmentStatus))]
        [MaxLength(50)]
        public AppointmentStatus Status { get; set; }

        //many to one relationship with Doctor
        [ForeignKey("Doctor")]
        public long DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        //many to one relationship with Hospital
        [ForeignKey("Hospital")]
        public long HospitalId { get; set; }
        public Hospital Hospital { get; set; }

        //one to one relationship with TimeSlot
        [ForeignKey("TimeSlot")]
        public long TimeSlotId { get; set; }
        public TimeSlot TimeSlot { get; set; }

        //m
        [ForeignKey("Patient")]
        public long PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
