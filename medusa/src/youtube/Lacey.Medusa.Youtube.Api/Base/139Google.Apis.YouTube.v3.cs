// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.Video
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.Collections.Generic;
using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>A video resource represents a YouTube video.</summary>
  public class Video : IDirectResponseSchema
  {
    /// <summary>Age restriction details related to a video. This data can only be retrieved by the video
    /// owner.</summary>
    [JsonProperty("ageGating")]
    public virtual VideoAgeGating AgeGating { get; set; }

    /// <summary>The contentDetails object contains information about the video content, including the length of the
    /// video and its aspect ratio.</summary>
    [JsonProperty("contentDetails")]
    public virtual VideoContentDetails ContentDetails { get; set; }

    /// <summary>Etag of this resource.</summary>
    [JsonProperty("etag")]
    public virtual string ETag { get; set; }

    /// <summary>The fileDetails object encapsulates information about the video file that was uploaded to YouTube,
    /// including the file's resolution, duration, audio and video codecs, stream bitrates, and more. This data can
    /// only be retrieved by the video owner.</summary>
    [JsonProperty("fileDetails")]
    public virtual VideoFileDetails FileDetails { get; set; }

    /// <summary>The ID that YouTube uses to uniquely identify the video.</summary>
    [JsonProperty("id")]
    public virtual string Id { get; set; }

    /// <summary>Identifies what kind of resource this is. Value: the fixed string "youtube#video".</summary>
    [JsonProperty("kind")]
    public virtual string Kind { get; set; }

    /// <summary>The liveStreamingDetails object contains metadata about a live video broadcast. The object will
    /// only be present in a video resource if the video is an upcoming, live, or completed live
    /// broadcast.</summary>
    [JsonProperty("liveStreamingDetails")]
    public virtual VideoLiveStreamingDetails LiveStreamingDetails { get; set; }

    /// <summary>List with all localizations.</summary>
    [JsonProperty("localizations")]
    public virtual IDictionary<string, VideoLocalization> Localizations { get; set; }

    /// <summary>The monetizationDetails object encapsulates information about the monetization status of the
    /// video.</summary>
    [JsonProperty("monetizationDetails")]
    public virtual VideoMonetizationDetails MonetizationDetails { get; set; }

    /// <summary>The player object contains information that you would use to play the video in an embedded
    /// player.</summary>
    [JsonProperty("player")]
    public virtual VideoPlayer Player { get; set; }

    /// <summary>The processingDetails object encapsulates information about YouTube's progress in processing the
    /// uploaded video file. The properties in the object identify the current processing status and an estimate of
    /// the time remaining until YouTube finishes processing the video. This part also indicates whether different
    /// types of data or content, such as file details or thumbnail images, are available for the video.
    /// 
    /// The processingProgress object is designed to be polled so that the video uploaded can track the progress
    /// that YouTube has made in processing the uploaded video file. This data can only be retrieved by the video
    /// owner.</summary>
    [JsonProperty("processingDetails")]
    public virtual VideoProcessingDetails ProcessingDetails { get; set; }

    /// <summary>The projectDetails object contains information about the project specific video metadata.</summary>
    [JsonProperty("projectDetails")]
    public virtual VideoProjectDetails ProjectDetails { get; set; }

    /// <summary>The recordingDetails object encapsulates information about the location, date and address where the
    /// video was recorded.</summary>
    [JsonProperty("recordingDetails")]
    public virtual VideoRecordingDetails RecordingDetails { get; set; }

    /// <summary>The snippet object contains basic details about the video, such as its title, description, and
    /// category.</summary>
    [JsonProperty("snippet")]
    public virtual VideoSnippet Snippet { get; set; }

    /// <summary>The statistics object contains statistics about the video.</summary>
    [JsonProperty("statistics")]
    public virtual VideoStatistics Statistics { get; set; }

    /// <summary>The status object contains information about the video's uploading, processing, and privacy
    /// statuses.</summary>
    [JsonProperty("status")]
    public virtual VideoStatus Status { get; set; }

    /// <summary>The suggestions object encapsulates suggestions that identify opportunities to improve the video
    /// quality or the metadata for the uploaded video. This data can only be retrieved by the video
    /// owner.</summary>
    [JsonProperty("suggestions")]
    public virtual VideoSuggestions Suggestions { get; set; }

    /// <summary>The topicDetails object encapsulates information about Freebase topics associated with the
    /// video.</summary>
    [JsonProperty("topicDetails")]
    public virtual VideoTopicDetails TopicDetails { get; set; }
  }
}
