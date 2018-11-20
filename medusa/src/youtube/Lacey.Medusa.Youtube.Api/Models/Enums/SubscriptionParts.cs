namespace Lacey.Medusa.Youtube.Api.Models.Enums
{
    public static class SubscriptionParts
    {
        public const string ContentDetails = "contentDetails";

        public const string Id = "id";

        public const string Snippet = "snippet";

        public const string SubscriberSnippet = "subscriberSnippet";

        public static readonly string[] All = {
            ContentDetails,
            Id,
            Snippet,
            SubscriberSnippet
        };
    }
}