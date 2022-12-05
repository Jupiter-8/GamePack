using GamePack.Domain.Entities;

namespace GamePack.Services.Interfaces
{
    public interface IGameService
    {
        public Game AddGame(string title, string exePath, string base64Icon, int categoryId, int userId);
        public List<Game> GetGamesForUser(int userId);
    }
}
