namespace GamePack.Domain.Entities
{
    public class Game
    {
        public Game(string title, DateTime dateAdded, DateTime lastRun, string iconPath, string exePath)
        {
            Id = Guid.NewGuid();
            Title = title;
            DateAdded = dateAdded;
            LastRun = lastRun;
            IconPath = iconPath;
            ExePath = exePath;
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime LastRun { get; set; }

        public string IconPath { get; set; }

        public string ExePath { get; set; }
    }
}
