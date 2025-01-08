namespace HealthBuddyDotnetBE.Exceptions.CustomException
{
    public class ResourceNotFoundException:Exception
    {
        public ResourceNotFoundException(string resource, long Id):base(resource +" not found with Id: "+Id) { }

        public ResourceNotFoundException(string resource):base(resource +" not found") { }
    }
}
