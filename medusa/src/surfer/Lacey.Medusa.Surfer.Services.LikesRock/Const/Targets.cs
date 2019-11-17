namespace Lacey.Medusa.Surfer.Services.LikesRock.Const
{
    internal static class Targets
    {
        internal static readonly Target[] All = {
            new Target { Social = Socials.Facebook, Ids = new [] { 1, 9, 16, 17, 41 } }, 
            new Target { Social = Socials.Instagram, Ids = new [] { 18, 19 } }, 
            new Target { Social = Socials.Telegram, Ids = new [] { 43, 44, 45 } }, 
            new Target { Social = Socials.VKontakte, Ids = new [] { 6, 7, 8, 15, 31 } }, 
            new Target { Social = Socials.Twitter, Ids = new [] { 5, 12, 13, 14 } }, 
            new Target { Social = Socials.Youtube, Ids = new [] { 4, 23, 24, 36 } }, 
            new Target { Social = Socials.Odnoklass, Ids = new [] { 34, 35, 42, 46 } }, 
            new Target { Social = Socials.Websites, Ids = new [] { 32 } }, 
            new Target { Social = Socials.Maya, Ids = new [] { 38, 39, 40 } }
        };

        internal class Target
        {
            public string Social { get; set; }

            public int[] Ids { get; set; }
        }
    }
}