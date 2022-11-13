using GamePack.Domain.Entities;

namespace GamePack.Services.Interfaces
{
    public interface IUserService
    {
        public User SignIn(string username, string password);
    }
}
