using GamePack.DataAccess;
using GamePack.Domain.Entities;
using GamePack.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamePack.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;

        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User SignIn(string username, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Username.Equals(username) && x.Password.Equals(password));
            return user;
        }
    }
}
