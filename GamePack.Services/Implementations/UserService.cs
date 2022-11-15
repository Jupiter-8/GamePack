using GamePack.DataAccess;
using GamePack.Domain.Entities;
using GamePack.Services.Interfaces;

namespace GamePack.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;

        public UserService(AppDbContext dbContext)
            => _dbContext = dbContext;

        public User? SignIn(string username, string password)
            => _dbContext.Users.FirstOrDefault(x => x.Username.Equals(username) && x.Password.Equals(password));

        public User SignUp(string username, string password)
        {
            var user = new User(username, password, "path");
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user;
        }

        public bool CheckIfUserExists(string username)
            => _dbContext.Users.Any(x => x.Username == username);
    }
}
