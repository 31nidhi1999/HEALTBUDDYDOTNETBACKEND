
using System.ComponentModel.DataAnnotations;
using global::Health.Entity;
using HealthBuddyDotnetBE.Entities;
namespace HealthBuddyDotnetBE.RequestDto
{
  
        public class PatientReqDto
        {
            [Required(ErrorMessage = "First name cannot be blank.")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Last name cannot be blank.")]
            public string LastName { get; set; }

            [EmailAddress(ErrorMessage = "Invalid email format.")]
            public string Email { get; set; }

            [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[#@$*]).{5,20}$",
                ErrorMessage = "Password must be 5-20 characters long, contain at least one digit, one lowercase letter, one uppercase letter, and one special character (#@$*).")]
            public string Password { get; set; }

            public string Address { get; set; }

            [Range(0, 100, ErrorMessage = "Age must be between 0 and 100.")]
            public int? Age { get; set; }

            public Gender Gender { get; set; }

            public string Symptoms { get; set; }
           
        }
    

}
