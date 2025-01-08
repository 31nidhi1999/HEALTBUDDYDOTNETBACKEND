using HealthBuddyDotnetBE.Contexts;
using HealthBuddyDotnetBE.Entities;
using HealthBuddyDotnetBE.Repositories.Declaration;

namespace HealthBuddyDotnetBE.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        public HealhBuddyContext healhBuddyContext;

        public UserRepository(HealhBuddyContext healhBuddyContext)
        {
            this.healhBuddyContext = healhBuddyContext;
        }

        public void AddUser(User user)
        {
            var user1=healhBuddyContext.Users.Add(user);
            healhBuddyContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            healhBuddyContext.Users.Update(user);
            healhBuddyContext.SaveChanges();
        }

        public void DeleteUser(long userId)
        {
            healhBuddyContext.Users.Remove(healhBuddyContext.Users.Find(userId));
            healhBuddyContext.SaveChanges();

        }

        public User GetUserById(long userId)
        {
            return healhBuddyContext.Users.Find(userId);
        }
        public User GetUserByName(string name)
        {
            return healhBuddyContext.Users.FirstOrDefault(u => u.UserName == name);
        }

        public List<User> GetAllUsers()
        {
            return healhBuddyContext.Users.ToList();
        }
    }
}
