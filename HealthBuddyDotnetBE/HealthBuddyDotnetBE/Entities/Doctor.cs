
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Health.Entity;

namespace HealthBuddyDotnetBE.Entities
{
    [Table("Doctor")]
    public class Doctor : BaseEntity
    {
        public string Name { get; set; }
        public string Specialization { get; set; }
        public int Experience { get; set; }

        [Required]
        [EmailAddress]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        public string Contact { get; set; }

        //Many to Many relationship with Hospital.cs
        [ForeignKey("DoctorId")]
        [InverseProperty("Doctors")]
        public List<Hospital> Hospitals { get; set; }

        [ForeignKey("DoctorId")]
        [InverseProperty("Doctor")]
        // one to many relationship with Appointment.cs
        public ISet<Appointment> Appointments { get; set; }

        //one to one relationship with User.cs
        [ForeignKey("UserId")]
        public long UserId { get; set; }
        public User User { get; set; }
    }
}

