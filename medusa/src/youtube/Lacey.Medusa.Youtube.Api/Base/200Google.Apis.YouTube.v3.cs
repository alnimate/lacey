// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.SuperChatEventSnippet
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System;
using Lacey.Medusa.Common.Api.Base.Requests;
using Lacey.Medusa.Common.Api.Core.Base.Util;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  public class SuperChatEventSnippet : IDirectResponseSchema
  {
    /// <summary>The purchase amount, in micros of the purchase currency. e.g., 1 is represented as
    /// 1000000.</summary>
    [JsonProperty("amountMicros")]
    public virtual ulong? AmountMicros { get; set; }

    /// <summary>Channel id where the event occurred.</summary>
    [JsonProperty("channelId")]
    public virtual string ChannelId { get; set; }

    /// <summary>The text contents of the comment left by the user.</summary>
    [JsonProperty("commentText")]
    public virtual string CommentText { get; set; }

    /// <summary>The date and time when the event occurred. The value is specified in ISO 8601 (YYYY-MM-
    /// DDThh:mm:ss.sZ) format.</summary>
    [JsonProperty("createdAt")]
    public virtual string CreatedAtRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.Base.SuperChatEventSnippet.CreatedAtRaw" />.</summary>
    [JsonIgnore]
    public virtual DateTime? CreatedAt
    {
      get
      {
        return Utilities.GetDateTimeFromString(this.CreatedAtRaw);
      }
      set
      {
        this.CreatedAtRaw = Utilities.GetStringFromDateTime(value);
      }
    }

    /// <summary>The currency in which the purchase was made. ISO 4217.</summary>
    [JsonProperty("currency")]
    public virtual string Currency { get; set; }

    /// <summary>A rendered string that displays the purchase amount and currency (e.g., "$1.00"). The string is
    /// rendered for the given language.</summary>
    [JsonProperty("displayString")]
    public virtual string DisplayString { get; set; }

    /// <summary>True if this event is a Super Chat for Good purchase.</summary>
    [JsonProperty("isSuperChatForGood")]
    public virtual bool? IsSuperChatForGood { get; set; }

    /// <summary>The tier for the paid message, which is based on the amount of money spent to purchase the
    /// message.</summary>
    [JsonProperty("messageType")]
    public virtual long? MessageType { get; set; }

    /// <summary>If this event is a Super Chat for Good purchase, this field will contain information about the
    /// charity the purchase is donated to.</summary>
    [JsonProperty("nonprofit")]
    public virtual Nonprofit Nonprofit { get; set; }

    /// <summary>Details about the supporter.</summary>
    [JsonProperty("supporterDetails")]
    public virtual ChannelProfileDetails SupporterDetails { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
