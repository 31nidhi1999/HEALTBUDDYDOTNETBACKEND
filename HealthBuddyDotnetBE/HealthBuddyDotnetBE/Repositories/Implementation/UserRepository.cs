using HealthBuddyDotnetBE.Contexts;
using HealthBuddyDotnetBE.Repositories.Declaration;

namespace HealthBuddyDotnetBE.Repositories.Implementation
{
    public class UserRepository:IUserRepository
    {
        public HealhBuddyContext healhBuddyContext;

        public UserRepository(HealhBuddyContext healhBuddyContext)
        {
            this.healhBuddyContext = healhBuddyContext;
        }
    }
}
