using GamePack.DataAccess;
using GamePack.Domain.Entities;
using GamePack.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamePack.Services.Implementations
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _dbContext;

        public GameService(AppDbContext dbContext)
            => _dbContext = dbContext;

        public Game AddGame(string title, string exePath, string base64Icon, int categoryId, int userId)
        {
            var game = new Game(title, base64Icon, exePath, categoryId, userId);
            _dbContext.Games.Add(game);
            _dbContext.SaveChanges();

            return game;
        }

        public void UpdateGame(Game game)
        {
            _dbContext.Games.Update(game);
            _dbContext.SaveChanges();
        }

        public void DeleteGame(Game game)
        {
            _dbContext.Remove(game);
            _dbContext.SaveChanges();
        }

        public List<Game> GetGamesForUser(int userId) 
            => _dbContext.Games
                .Where(x => x.UserId == userId)
                .Include(x => x.Category)
                .ToList();
    }
}
