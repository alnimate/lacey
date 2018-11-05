// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.Subscription
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>A subscription resource contains information about a YouTube user subscription. A subscription notifies
  /// a user when new videos are added to a channel or when another user takes one of several actions on YouTube, such
  /// as uploading a video, rating a video, or commenting on a video.</summary>
  public class Subscription : IDirectResponseSchema
  {
    /// <summary>The contentDetails object contains basic statistics about the subscription.</summary>
    [JsonProperty("contentDetails")]
    public virtual SubscriptionContentDetails ContentDetails { get; set; }

    /// <summary>Etag of this resource.</summary>
    [JsonProperty("etag")]
    public virtual string ETag { get; set; }

    /// <summary>The ID that YouTube uses to uniquely identify the subscription.</summary>
    [JsonProperty("id")]
    public virtual string Id { get; set; }

    /// <summary>Identifies what kind of resource this is. Value: the fixed string "youtube#subscription".</summary>
    [JsonProperty("kind")]
    public virtual string Kind { get; set; }

    /// <summary>The snippet object contains basic details about the subscription, including its title and the
    /// channel that the user subscribed to.</summary>
    [JsonProperty("snippet")]
    public virtual SubscriptionSnippet Snippet { get; set; }

    /// <summary>The subscriberSnippet object contains basic details about the sbuscriber.</summary>
    [JsonProperty("subscriberSnippet")]
    public virtual SubscriptionSubscriberSnippet SubscriberSnippet { get; set; }
  }
}
