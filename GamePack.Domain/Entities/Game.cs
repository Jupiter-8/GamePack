namespace GamePack.Domain.Entities
{
    /// <summary>
    /// Class that describes game entity.
    /// </summary>
    public class Game : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="title">Game title.</param>
        /// <param name="dateAdded">Time when game has been added to the library.</param>
        /// <param name="lastRun">Last time of launch of the game.</param>
        /// <param name="iconPath">Path to the icon of the game.</param>
        /// <param name="exePath">Path to the exe file of the game.</param>
        /// <param name="categoryId">Category id.</param>
        public Game(
            string title,
            DateTime dateAdded,
            DateTime lastRun,
            string iconPath,
            string exePath,
            Guid categoryId) : base()
        {
            Title = title;
            DateAdded = dateAdded;
            LastRun = lastRun;
            IconPath = iconPath;
            ExePath = exePath;
            CategoryId = categoryId;
        }

        /// <summary>
        /// Game title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Time when game has been added to the library.
        /// </summary>
        public DateTime DateAdded { get; set; }

        /// <summary>
        /// Last time of launch of the game.
        /// </summary>
        public DateTime LastRun { get; set; }

        /// <summary>
        /// Path to the icon of the game.
        /// </summary>
        public string IconPath { get; set; }

        /// <summary>
        /// Path to the exe file of the game.
        /// </summary>
        public string ExePath { get; set; }

        /// <summary>
        /// Gets or sets category id.
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Get or sets category.
        /// </summary>
        public Category Category { get; set; }
    }
}
