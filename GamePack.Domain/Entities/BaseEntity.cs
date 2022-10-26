namespace GamePack.Domain.Entities
{
    /// <summary>
    /// Base domain entity class.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntity"/> class.
        /// </summary>
        public BaseEntity() => Id = Guid.NewGuid();

        /// <summary>
        /// Gets or sets entity identifier.
        /// </summary>
        public Guid Id { get; set; }
    }
}
