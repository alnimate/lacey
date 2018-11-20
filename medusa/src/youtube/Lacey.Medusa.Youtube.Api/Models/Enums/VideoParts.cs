namespace Lacey.Medusa.Youtube.Api.Models.Enums
{
    public static class VideoParts
    {
        public const string ContentDetails = "contentDetails";

        public const string FileDetails = "fileDetails";

        public const string Id = "id";

        public const string LiveStreamingDetails = "liveStreamingDetails";

        public const string Localizations = "localizations";

        public const string Player = "player";

        public const string ProcessingDetails = "processingDetails";

        public const string RecordingDetails = "recordingDetails";

        public const string Snippet = "snippet";

        public const string Statistics = "statistics";

        public const string Status = "status";

        public const string Suggestions = "suggestions";

        public const string TopicDetails = "topicDetails";

        public static readonly string[] All = {
            ContentDetails,
            FileDetails,
            Id,
            LiveStreamingDetails,
            Localizations,
            Player,
            ProcessingDetails,
            RecordingDetails,
            Snippet,
            Statistics,
            Suggestions,
            TopicDetails
        };

        public static readonly string[] AllAnonymous = {
            ContentDetails,
            Id,
            LiveStreamingDetails,
            Localizations,
            Player,
            RecordingDetails,
            Snippet,
            Statistics,
            TopicDetails
        };
    }
}