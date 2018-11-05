// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.CaptionSnippet
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System;
using Lacey.Medusa.Common.Api.Base.Requests;
using Lacey.Medusa.Common.Api.Core.Base.Util;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Basic details about a caption track, such as its language and name.</summary>
  public class CaptionSnippet : IDirectResponseSchema
  {
    /// <summary>The type of audio track associated with the caption track.</summary>
    [JsonProperty("audioTrackType")]
    public virtual string AudioTrackType { get; set; }

    /// <summary>The reason that YouTube failed to process the caption track. This property is only present if the
    /// state property's value is failed.</summary>
    [JsonProperty("failureReason")]
    public virtual string FailureReason { get; set; }

    /// <summary>Indicates whether YouTube synchronized the caption track to the audio track in the video. The value
    /// will be true if a sync was explicitly requested when the caption track was uploaded. For example, when
    /// calling the captions.insert or captions.update methods, you can set the sync parameter to true to instruct
    /// YouTube to sync the uploaded track to the video. If the value is false, YouTube uses the time codes in the
    /// uploaded caption track to determine when to display captions.</summary>
    [JsonProperty("isAutoSynced")]
    public virtual bool? IsAutoSynced { get; set; }

    /// <summary>Indicates whether the track contains closed captions for the deaf and hard of hearing. The default
    /// value is false.</summary>
    [JsonProperty("isCC")]
    public virtual bool? IsCC { get; set; }

    /// <summary>Indicates whether the caption track is a draft. If the value is true, then the track is not
    /// publicly visible. The default value is false.</summary>
    [JsonProperty("isDraft")]
    public virtual bool? IsDraft { get; set; }

    /// <summary>Indicates whether caption track is formatted for "easy reader," meaning it is at a third-grade
    /// level for language learners. The default value is false.</summary>
    [JsonProperty("isEasyReader")]
    public virtual bool? IsEasyReader { get; set; }

    /// <summary>Indicates whether the caption track uses large text for the vision-impaired. The default value is
    /// false.</summary>
    [JsonProperty("isLarge")]
    public virtual bool? IsLarge { get; set; }

    /// <summary>The language of the caption track. The property value is a BCP-47 language tag.</summary>
    [JsonProperty("language")]
    public virtual string Language { get; set; }

    /// <summary>The date and time when the caption track was last updated. The value is specified in ISO 8601
    /// (YYYY-MM-DDThh:mm:ss.sZ) format.</summary>
    [JsonProperty("lastUpdated")]
    public virtual string LastUpdatedRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.Base.CaptionSnippet.LastUpdatedRaw" />.</summary>
    [JsonIgnore]
    public virtual DateTime? LastUpdated
    {
      get
      {
        return Utilities.GetDateTimeFromString(this.LastUpdatedRaw);
      }
      set
      {
        this.LastUpdatedRaw = Utilities.GetStringFromDateTime(value);
      }
    }

    /// <summary>The name of the caption track. The name is intended to be visible to the user as an option during
    /// playback.</summary>
    [JsonProperty("name")]
    public virtual string Name { get; set; }

    /// <summary>The caption track's status.</summary>
    [JsonProperty("status")]
    public virtual string Status { get; set; }

    /// <summary>The caption track's type.</summary>
    [JsonProperty("trackKind")]
    public virtual string TrackKind { get; set; }

    /// <summary>The ID that YouTube uses to uniquely identify the video associated with the caption
    /// track.</summary>
    [JsonProperty("videoId")]
    public virtual string VideoId { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
