using System.ComponentModel.DataAnnotations;

namespace HealthBuddyDotnetBE.RequestDto
{
   
        public class DoctorReqDto
        {
            [Required]
            public string Name { get; set; }

            [Required]
            public string Specialization { get; set; }

            [Required]
            [Range(3, 20, ErrorMessage = "Experience must be between 3 and 20.")]
            public int Experience { get; set; }

            [Required]
            [EmailAddress(ErrorMessage = "Please enter a valid email.")]
            public string Email { get; set; }

            [Required]
            [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[#@$*]).{5,20}$",
                ErrorMessage = "Password must be 5-20 characters long, contain at least one digit, one lowercase letter, one uppercase letter, and one special character (#@$*).")]
            public string Password { get; set; }

            [Required]
            [RegularExpression("^(\\+91[\\-\\s]?)?[0]?(91)?[789]\\d{9}",
                ErrorMessage = "Please enter a valid contact number.")]
            public string Contact { get; set; }
        }
    }
