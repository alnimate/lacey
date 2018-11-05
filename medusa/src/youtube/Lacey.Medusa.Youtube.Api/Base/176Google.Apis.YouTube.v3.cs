// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.LiveChatMessage
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>A liveChatMessage resource represents a chat message in a YouTube Live Chat.</summary>
  public class LiveChatMessage : IDirectResponseSchema
  {
    /// <summary>The authorDetails object contains basic details about the user that posted this message.</summary>
    [JsonProperty("authorDetails")]
    public virtual LiveChatMessageAuthorDetails AuthorDetails { get; set; }

    /// <summary>Etag of this resource.</summary>
    [JsonProperty("etag")]
    public virtual string ETag { get; set; }

    /// <summary>The ID that YouTube assigns to uniquely identify the message.</summary>
    [JsonProperty("id")]
    public virtual string Id { get; set; }

    /// <summary>Identifies what kind of resource this is. Value: the fixed string
    /// "youtube#liveChatMessage".</summary>
    [JsonProperty("kind")]
    public virtual string Kind { get; set; }

    /// <summary>The snippet object contains basic details about the message.</summary>
    [JsonProperty("snippet")]
    public virtual LiveChatMessageSnippet Snippet { get; set; }
  }
}
