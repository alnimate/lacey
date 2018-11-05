// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.VideoProcessingDetails
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Describes processing status and progress and availability of some other Video resource parts.</summary>
  public class VideoProcessingDetails : IDirectResponseSchema
  {
    /// <summary>This value indicates whether video editing suggestions, which might improve video quality or the
    /// playback experience, are available for the video. You can retrieve these suggestions by requesting the
    /// suggestions part in your videos.list() request.</summary>
    [JsonProperty("editorSuggestionsAvailability")]
    public virtual string EditorSuggestionsAvailability { get; set; }

    /// <summary>This value indicates whether file details are available for the uploaded video. You can retrieve a
    /// video's file details by requesting the fileDetails part in your videos.list() request.</summary>
    [JsonProperty("fileDetailsAvailability")]
    public virtual string FileDetailsAvailability { get; set; }

    /// <summary>The reason that YouTube failed to process the video. This property will only have a value if the
    /// processingStatus property's value is failed.</summary>
    [JsonProperty("processingFailureReason")]
    public virtual string ProcessingFailureReason { get; set; }

    /// <summary>This value indicates whether the video processing engine has generated suggestions that might
    /// improve YouTube's ability to process the the video, warnings that explain video processing problems, or
    /// errors that cause video processing problems. You can retrieve these suggestions by requesting the
    /// suggestions part in your videos.list() request.</summary>
    [JsonProperty("processingIssuesAvailability")]
    public virtual string ProcessingIssuesAvailability { get; set; }

    /// <summary>The processingProgress object contains information about the progress YouTube has made in
    /// processing the video. The values are really only relevant if the video's processing status is
    /// processing.</summary>
    [JsonProperty("processingProgress")]
    public virtual VideoProcessingDetailsProcessingProgress ProcessingProgress { get; set; }

    /// <summary>The video's processing status. This value indicates whether YouTube was able to process the video
    /// or if the video is still being processed.</summary>
    [JsonProperty("processingStatus")]
    public virtual string ProcessingStatus { get; set; }

    /// <summary>This value indicates whether keyword (tag) suggestions are available for the video. Tags can be
    /// added to a video's metadata to make it easier for other users to find the video. You can retrieve these
    /// suggestions by requesting the suggestions part in your videos.list() request.</summary>
    [JsonProperty("tagSuggestionsAvailability")]
    public virtual string TagSuggestionsAvailability { get; set; }

    /// <summary>This value indicates whether thumbnail images have been generated for the video.</summary>
    [JsonProperty("thumbnailsAvailability")]
    public virtual string ThumbnailsAvailability { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
