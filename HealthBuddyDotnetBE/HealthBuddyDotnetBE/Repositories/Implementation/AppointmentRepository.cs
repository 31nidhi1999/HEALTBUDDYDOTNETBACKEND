using HealthBuddyDotnetBE.Contexts;
using HealthBuddyDotnetBE.Repositories.Declaration;

namespace HealthBuddyDotnetBE.Repositories.Implementation
{
    public class AppointmentRepository:IAppointmentRepository
    {
        private HealhBuddyContext healthBuddyContext;

        public AppointmentRepository(HealhBuddyContext healthBuddyContext)
        {
            this.healthBuddyContext = healthBuddyContext;
        }


    }
}
