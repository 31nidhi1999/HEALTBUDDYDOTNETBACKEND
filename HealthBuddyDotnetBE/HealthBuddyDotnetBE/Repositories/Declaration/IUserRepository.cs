using HealthBuddyDotnetBE.Entities;

namespace HealthBuddyDotnetBE.Repositories.Declaration
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(long userID);
        User GetUserById(long userId);
        List<User> GetAllUsers();
        User GetUserByName(string name);
    }
}
