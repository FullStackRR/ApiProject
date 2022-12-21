
namespace DataLayer
{
    public interface IUsersData
    {
        Task<User?> GetUser(string email, string password);
        Task<User> Post(User user);
        void updateUser(int id, User theUser);
    }
}