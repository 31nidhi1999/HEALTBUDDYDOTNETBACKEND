using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
namespace HealthBuddyDotnetBE.RequestDto
{

        public class HospitalReqDto
        {

            [NotNull]
            public string Name { get; set; }

            [NotNull]
            public string Location { get; set; }

            [NotNull]
            
            public string Contact { get; set; }
        }
    
}
