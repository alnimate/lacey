namespace Lacey.Medusa.Youtube.Api.Models.Enums
{
    public static class PlaylistParts
    {
        public const string ContentDetails = "contentDetails";

        public const string Id = "id";

        public const string Localizations = "localizations";

        public const string Player = "player";

        public const string Snippet = "snippet";

        public const string Status = "status";

        public static readonly string[] All = {
            ContentDetails,
            Id,
            Localizations,
            Player,
            Snippet,
            Status,
        };
    }
}