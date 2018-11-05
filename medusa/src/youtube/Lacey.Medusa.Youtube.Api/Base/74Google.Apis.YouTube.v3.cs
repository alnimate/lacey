// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.CommentThreadReplies
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.Collections.Generic;
using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Comments written in (direct or indirect) reply to the top level comment.</summary>
  public class CommentThreadReplies : IDirectResponseSchema
  {
    /// <summary>A limited number of replies. Unless the number of replies returned equals total_reply_count in the
    /// snippet the returned replies are only a subset of the total number of replies.</summary>
    [JsonProperty("comments")]
    public virtual IList<Comment> Comments { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
