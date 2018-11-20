namespace Lacey.Medusa.Youtube.Api.Models.Enums
{
    public static class ChannelParts
    {
        public const string AuditDetails = "auditDetails";

        public const string BrandingSettings = "brandingSettings";

        public const string ContentDetails = "contentDetails";

        public const string ContentOwnerDetails = "contentOwnerDetails";

        public const string Id = "id";

        public const string InvideoPromotion = "invideoPromotion";

        public const string Localizations = "localizations";

        public const string Snippet = "snippet";

        public const string Statistics = "statistics";

        public const string Status = "status";

        public const string TopicDetails = "topicDetails";

        public static readonly string[] All = {
            AuditDetails,
            BrandingSettings,
            ContentDetails,
            ContentOwnerDetails,
            Id,
            InvideoPromotion,
            Localizations,
            Snippet,
            Statistics,
            Status,
            TopicDetails
        };

        public static readonly string[] AllAnonymous = {
            BrandingSettings,
            ContentDetails,
            ContentOwnerDetails,
            Id,
            InvideoPromotion,
            Localizations,
            Snippet,
            Statistics,
            Status,
            TopicDetails
        };
    }
}