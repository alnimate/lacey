namespace Lacey.Medusa.Youtube.Api.Models.Enums
{
    internal static class SectionParts
    {
        public const string ContentDetails = "contentDetails";

        public const string Id = "id";

        public const string Localizations = "localizations";

        public const string Snippet = "snippet";

        public const string Targeting = "targeting";

        public static readonly string[] All = {
            ContentDetails,
            Id,
            Localizations,
            Snippet,
            Targeting
        };
    }
}