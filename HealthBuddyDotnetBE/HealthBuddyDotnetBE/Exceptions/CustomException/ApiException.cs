using System;
namespace HealthBuddyDotnetBE.Exceptions.CustomException
{
    
    public class ApiException:Exception
    {
            public ApiException(string message):base(message) {}
    }
}
