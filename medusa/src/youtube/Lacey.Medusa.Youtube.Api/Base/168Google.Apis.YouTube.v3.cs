// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.VideoSuggestions
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.Collections.Generic;
using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Specifies suggestions on how to improve video content, including encoding hints, tag suggestions, and
  /// editor suggestions.</summary>
  internal class VideoSuggestions : IDirectResponseSchema
  {
    /// <summary>A list of video editing operations that might improve the video quality or playback experience of
    /// the uploaded video.</summary>
    [JsonProperty("editorSuggestions")]
    public virtual IList<string> EditorSuggestions { get; set; }

    /// <summary>A list of errors that will prevent YouTube from successfully processing the uploaded video video.
    /// These errors indicate that, regardless of the video's current processing status, eventually, that status
    /// will almost certainly be failed.</summary>
    [JsonProperty("processingErrors")]
    public virtual IList<string> ProcessingErrors { get; set; }

    /// <summary>A list of suggestions that may improve YouTube's ability to process the video.</summary>
    [JsonProperty("processingHints")]
    public virtual IList<string> ProcessingHints { get; set; }

    /// <summary>A list of reasons why YouTube may have difficulty transcoding the uploaded video or that might
    /// result in an erroneous transcoding. These warnings are generated before YouTube actually processes the
    /// uploaded video file. In addition, they identify issues that are unlikely to cause the video processing to
    /// fail but that might cause problems such as sync issues, video artifacts, or a missing audio track.</summary>
    [JsonProperty("processingWarnings")]
    public virtual IList<string> ProcessingWarnings { get; set; }

    /// <summary>A list of keyword tags that could be added to the video's metadata to increase the likelihood that
    /// users will locate your video when searching or browsing on YouTube.</summary>
    [JsonProperty("tagSuggestions")]
    public virtual IList<VideoSuggestionsTagSuggestion> TagSuggestions { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
