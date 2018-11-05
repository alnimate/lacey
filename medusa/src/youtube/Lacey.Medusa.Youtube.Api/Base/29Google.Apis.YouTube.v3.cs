// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.Activity
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>An activity resource contains information about an action that a particular channel, or user, has taken
  /// on YouTube.The actions reported in activity feeds include rating a video, sharing a video, marking a video as a
  /// favorite, commenting on a video, uploading a video, and so forth. Each activity resource identifies the type of
  /// action, the channel associated with the action, and the resource(s) associated with the action, such as the
  /// video that was rated or uploaded.</summary>
  internal class Activity : IDirectResponseSchema
  {
    /// <summary>The contentDetails object contains information about the content associated with the activity. For
    /// example, if the snippet.type value is videoRated, then the contentDetails object's content identifies the
    /// rated video.</summary>
    [JsonProperty("contentDetails")]
    public virtual ActivityContentDetails ContentDetails { get; set; }

    /// <summary>Etag of this resource.</summary>
    [JsonProperty("etag")]
    public virtual string ETag { get; set; }

    /// <summary>The ID that YouTube uses to uniquely identify the activity.</summary>
    [JsonProperty("id")]
    public virtual string Id { get; set; }

    /// <summary>Identifies what kind of resource this is. Value: the fixed string "youtube#activity".</summary>
    [JsonProperty("kind")]
    public virtual string Kind { get; set; }

    /// <summary>The snippet object contains basic details about the activity, including the activity's type and
    /// group ID.</summary>
    [JsonProperty("snippet")]
    public virtual ActivitySnippet Snippet { get; set; }
  }
}
