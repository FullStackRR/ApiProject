
namespace DataLayer
{
    public interface IUsersData
    {
        Task<User?> GetUser(string email, string password);
        Task<User> Post(User user);
        Task updateUser(int id, User theUser);
    }
}