using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json;

namespace DataLayer
{
    public class UsersData : IUsersData
    {
        _213836612_web_apiContext _dbContext;
        public UsersData(_213836612_web_apiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User?> GetUser(string email, string password)
        {
            var list =await (from u in _dbContext.Users
                        where u.Email == email && u.Password == password
                        select u).ToListAsync();
            return list.FirstOrDefault();

        }

        public async Task<User> Post(User user)
        {
           await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async void updateUser(int id, User updated)
        {
            var userToUpdate = _dbContext.Users.Find(id);
            if (userToUpdate == null)
                return;
            User u = userToUpdate;
            _dbContext.Entry(u).CurrentValues.SetValues(updated);
          _dbContext.SaveChanges();

        }
    }
}