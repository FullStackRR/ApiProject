using DataLayer;
namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUsersData _data;

        public UserService(IUsersData data)
        {
            this._data = data;
        }
        public async Task<User?> GetUser(string email, string password)
        {
             return await _data.GetUser(email, password);
        }

        public Task<User> Post(User user)
        {
            return _data.Post(user);
        }

        public void UpdateUser(int id, User theUser)
        {
            _data.updateUser(id, theUser);
        }
    }
}