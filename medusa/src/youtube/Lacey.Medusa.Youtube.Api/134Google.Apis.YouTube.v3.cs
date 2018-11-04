﻿// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.SubscriptionSubscriberSnippet
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>Basic details about a subscription's subscriber including title, description, channel ID and
  /// thumbnails.</summary>
  public class SubscriptionSubscriberSnippet : IDirectResponseSchema
  {
    /// <summary>The channel ID of the subscriber.</summary>
    [JsonProperty("channelId")]
    public virtual string ChannelId { get; set; }

    /// <summary>The description of the subscriber.</summary>
    [JsonProperty("description")]
    public virtual string Description { get; set; }

    /// <summary>Thumbnails for this subscriber.</summary>
    [JsonProperty("thumbnails")]
    public virtual ThumbnailDetails Thumbnails { get; set; }

    /// <summary>The title of the subscriber.</summary>
    [JsonProperty("title")]
    public virtual string Title { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
