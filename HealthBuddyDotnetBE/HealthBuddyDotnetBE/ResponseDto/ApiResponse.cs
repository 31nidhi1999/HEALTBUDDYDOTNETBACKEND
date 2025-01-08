using System;
using NodaTime;
namespace HealthBuddyDotnetBE.ResponseDto
{


    
        public class ApiResponse
        {
            public DateTime TimeStamp { get; set; }
            public string Message { get; set; }

            public ApiResponse(string message)
            {
                this.Message = message;
                this.TimeStamp = DateTime.Now;
            }

        }
    }


