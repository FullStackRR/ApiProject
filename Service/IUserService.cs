using DataLayer;

namespace Service
{
    public interface IUserService
    {
        Task<User>? GetUser(string email, string password);
        Task<User> Post(User user);
        void UpdateUser(int id, User theUser);
    }
}