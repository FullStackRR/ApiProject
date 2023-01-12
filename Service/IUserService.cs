using DataLayer;

namespace Service
{
    public interface IUserService
    {
        Task<User>? GetUser(string email, string password);
        Task<User> Post(User user);
        Task UpdateUser(int id, User theUser);
    }
}