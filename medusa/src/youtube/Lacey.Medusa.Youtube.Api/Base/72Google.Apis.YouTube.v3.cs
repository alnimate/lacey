// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.CommentThread
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>A comment thread represents information that applies to a top level comment and all its replies. It can
  /// also include the top level comment itself and some of the replies.</summary>
  internal class CommentThread : IDirectResponseSchema
  {
    /// <summary>Etag of this resource.</summary>
    [JsonProperty("etag")]
    public virtual string ETag { get; set; }

    /// <summary>The ID that YouTube uses to uniquely identify the comment thread.</summary>
    [JsonProperty("id")]
    public virtual string Id { get; set; }

    /// <summary>Identifies what kind of resource this is. Value: the fixed string
    /// "youtube#commentThread".</summary>
    [JsonProperty("kind")]
    public virtual string Kind { get; set; }

    /// <summary>The replies object contains a limited number of replies (if any) to the top level comment found in
    /// the snippet.</summary>
    [JsonProperty("replies")]
    public virtual CommentThreadReplies Replies { get; set; }

    /// <summary>The snippet object contains basic details about the comment thread and also the top level
    /// comment.</summary>
    [JsonProperty("snippet")]
    public virtual CommentThreadSnippet Snippet { get; set; }
  }
}
