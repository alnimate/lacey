// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.LiveChatSuperChatDetails
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  public class LiveChatSuperChatDetails : IDirectResponseSchema
  {
    /// <summary>A rendered string that displays the fund amount and currency to the user.</summary>
    [JsonProperty("amountDisplayString")]
    public virtual string AmountDisplayString { get; set; }

    /// <summary>The amount purchased by the user, in micros (1,750,000 micros = 1.75).</summary>
    [JsonProperty("amountMicros")]
    public virtual ulong? AmountMicros { get; set; }

    /// <summary>The currency in which the purchase was made.</summary>
    [JsonProperty("currency")]
    public virtual string Currency { get; set; }

    /// <summary>The tier in which the amount belongs to. Lower amounts belong to lower tiers. Starts at
    /// 1.</summary>
    [JsonProperty("tier")]
    public virtual long? Tier { get; set; }

    /// <summary>The comment added by the user to this Super Chat event.</summary>
    [JsonProperty("userComment")]
    public virtual string UserComment { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
