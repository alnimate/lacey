namespace Lacey.Medusa.Youtube.Api.Models.Enums
{
    public static class CommentParts
    {
        public const string Id = "id";

        public const string Replies = "replies";

        public const string Snippet = "snippet";

        public static readonly string[] All = {
            Id,
            Snippet,
            Replies
        };
    }
}