using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthBuddyDotnetBE.Entities
{
    [Table("users")]
    public class User : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [EnumDataType(typeof(UserRole))]
        public UserRole Role { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
