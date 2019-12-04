namespace Lacey.Medusa.Surfer.Services.LikesRock.Const
{
    internal static class Socials
    {
        internal static readonly SocialInfo[] All = {
            new SocialInfo { Name = SocialNames.Facebook, Targets = new []
            {
                new Target("FB Page Likes", 1), 
                new Target("FB Subscr", 9), 
                new Target("FB Friends", 16), 
                new Target("FB Post Likes", 17), 
                new Target("FB Groups", 41) 
            }}, 
            new SocialInfo { Name = SocialNames.Instagram, Targets = new []
            {
                new Target("IN Likes", 18), 
                new Target("IN Subscr", 19)
            }}, 
            new SocialInfo { Name = SocialNames.Telegram, Targets = new []
            {
                new Target("TG Channels", 43), 
                new Target("TG Chats", 44), 
                new Target("TG Bots", 45) 
            }}, 
            new SocialInfo { Name = SocialNames.VKontakte, Targets = new []
            {
                new Target("VK Pages", 6), 
                new Target("VK Followers", 7), 
                new Target("VK Groups", 8), 
                new Target("VK Reports", 15), 
                new Target("VK Likes", 31) 
            }}, 
            new SocialInfo { Name = SocialNames.Twitter, Targets = new []
            {
                new Target("TW Followers", 5), 
                new Target("TW Tweets", 12), 
                new Target("TW Retweets", 13), 
                new Target("TW Likes", 14)
            }}, 
            new SocialInfo { Name = SocialNames.Youtube, Targets = new []
            {
                new Target("YT Subscr", 4), 
                new Target("YT Likes", 23), 
                new Target("YT Views", 24), 
                new Target("YT Dislikes", 36) 
            }}, 
            new SocialInfo { Name = SocialNames.Odnoklass, Targets = new []
            {
                new Target("OK Shares", 34), 
                new Target("OK Groups", 35), 
                new Target("OK Classes", 42), 
                new Target("OK Friends", 46),
            }}, 
            new SocialInfo { Name = SocialNames.Websites, Targets = new []
            {
                new Target("Sites View", 32) 
            }}, 
            new SocialInfo { Name = SocialNames.Maya, Targets = new []
            {
                new Target("MAYA Contacts", 38), 
                new Target("MAYA Reposts", 39), 
                new Target("MAYA Likes", 40) 
            }}
        };

        internal class SocialInfo
        {
            public string Name { get; set; }

            public Target[] Targets { get; set; }
        }

        internal class Target
        {
            public string Name { get; }

            public int Id { get; }

            public Target(string name, int id)
            {
                Name = name;
                Id = id;
            }
        }
    }
}