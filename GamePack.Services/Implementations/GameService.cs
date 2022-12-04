using GamePack.DataAccess;
using GamePack.Domain.Entities;
using GamePack.Services.Interfaces;

namespace GamePack.Services.Implementations
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _dbContext;

        public GameService(AppDbContext dbContext)
            => _dbContext = dbContext;

        public Game AddGame(string title, string exePath, int categoryId, int userId)
        {
            var game = new Game(title, "IconPath", exePath, categoryId, userId);
            _dbContext.Games.Add(game);
            _dbContext.SaveChanges();

            return game;
        }

        public List<Game> GetGamesForUser(int userId) => _dbContext.Games.Where(x => x.UserId == userId).ToList();
    }
}
