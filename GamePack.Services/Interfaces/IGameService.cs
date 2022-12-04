using GamePack.Domain.Entities;

namespace GamePack.Services.Interfaces
{
    public interface IGameService
    {
        public Game AddGame(string title, string exePath, int categoryId, int userId);
        public List<Game> GetGamesForUser(int userId);
    }
}
