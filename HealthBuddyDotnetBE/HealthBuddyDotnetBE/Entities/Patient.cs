using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Health.Entity;

namespace HealthBuddyDotnetBE.Entities
{
    [Table("Patient")]
    public class Patient : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Address { get; set; }
        public int Age { get; set; }

        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        public string Symptoms { get; set; }

        //one to one relationship with User.cs
        [ForeignKey("UserId")]
        public long UserId { get; set; }
        public User User { get; set; }

        //one patient can have multiple appointments
        public IList<Appointment> Appointments { get; set; }
    }
}
