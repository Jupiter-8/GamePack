using GamePack.Domain.Entities;

namespace GamePack.Services.Interfaces
{
    public interface IGameService
    {
        public Game AddGame(string title, string exePath, string base64Icon, int categoryId, int userId);
        public void UpdateGame(Game game);
        public List<Game> GetGamesForUser(int userId);
    }
}
