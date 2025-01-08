using global::Health.Entity;
using HealthBuddyDotnetBE.Entities;
namespace HealthBuddyDotnetBE.ResponseDto
{
        public class PatientResDto
        {
            public long Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public Gender Gender { get; set; }
            public string Symptoms { get; set; }
          
        }
    }



