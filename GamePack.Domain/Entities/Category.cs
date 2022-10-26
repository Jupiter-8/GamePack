namespace GamePack.Domain.Entities
{
    /// <summary>
    /// Class that describes category entity.
    /// </summary>
    public class Category : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        /// <param name="name">Category name.</param>
        public Category(string name) : base()
        {
            Name = name;
        }

        /// <summary>
        /// Category name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get or sets category games.
        /// </summary>
        public List<Game> Games { get; set; }
    }
}
