using GamePack.Domain.Entities;

namespace GamePack.Services.Interfaces
{
    public interface IUserService
    {
        public User? SignIn(string username, string password);
        public User SignUp(string username, string password);
        public bool CheckIfUserExists(string username);
        public void DeleteUser(User user);
    }
}
