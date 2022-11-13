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
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string AvatarPath { get; set; }
    }
}
