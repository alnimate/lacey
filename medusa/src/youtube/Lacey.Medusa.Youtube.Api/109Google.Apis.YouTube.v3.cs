// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.MonitorStreamInfo
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>Settings and Info of the monitor stream</summary>
  public class MonitorStreamInfo : IDirectResponseSchema
  {
    /// <summary>If you have set the enableMonitorStream property to true, then this property determines the length
    /// of the live broadcast delay.</summary>
    [JsonProperty("broadcastStreamDelayMs")]
    public virtual long? BroadcastStreamDelayMs { get; set; }

    /// <summary>HTML code that embeds a player that plays the monitor stream.</summary>
    [JsonProperty("embedHtml")]
    public virtual string EmbedHtml { get; set; }

    /// <summary>This value determines whether the monitor stream is enabled for the broadcast. If the monitor
    /// stream is enabled, then YouTube will broadcast the event content on a special stream intended only for the
    /// broadcaster's consumption. The broadcaster can use the stream to review the event content and also to
    /// identify the optimal times to insert cuepoints.
    /// 
    /// You need to set this value to true if you intend to have a broadcast delay for your event.
    /// 
    /// Note: This property cannot be updated once the broadcast is in the testing or live state.</summary>
    [JsonProperty("enableMonitorStream")]
    public virtual bool? EnableMonitorStream { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
