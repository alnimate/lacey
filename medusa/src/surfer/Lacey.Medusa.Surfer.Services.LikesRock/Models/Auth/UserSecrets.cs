namespace Lacey.Medusa.Surfer.Services.LikesRock.Models.Auth
{
    public sealed class UserSecrets
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public Social[] Socials { get; set; }
    }
}