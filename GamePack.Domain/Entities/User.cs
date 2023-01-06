namespace GamePack.Domain.Entities
{
    public class User : BaseEntity
    {
        public User(
            string username,
            string password,
            string avatarPath)
        {
            Username = username;
            Password = password;
            AvatarPath = avatarPath;
            SignedUpDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets or sets username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets avatar path.
        /// </summary>
        public string AvatarPath { get; set; }

        /// <summary>
        /// Gets or sets date when user has been registered.
        /// </summary>
        public DateTime SignedUpDate { get; set; }

        /// <summary>
        /// Gets or sets games.
        /// </summary>
        public List<Game> Games { get; set; }
    }
}
