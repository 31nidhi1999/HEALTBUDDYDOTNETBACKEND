using HealthBuddyDotnetBE.Contexts;
using HealthBuddyDotnetBE.Repositories.Declaration;

namespace HealthBuddyDotnetBE.Repositories.Implementation
{
    public class PatientRepository:IPatientRepository
    {
        public HealhBuddyContext healhBuddyContext;

        public PatientRepository(HealhBuddyContext healhBuddyContext)
        {
            this.healhBuddyContext = healhBuddyContext;
        }
    }
}
