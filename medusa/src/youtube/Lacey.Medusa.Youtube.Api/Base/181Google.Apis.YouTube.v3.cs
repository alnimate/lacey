// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.LiveChatMessageSnippet
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System;
using Lacey.Medusa.Common.Api.Base.Requests;
using Lacey.Medusa.Common.Api.Core.Base.Util;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  public class LiveChatMessageSnippet : IDirectResponseSchema
  {
    /// <summary>The ID of the user that authored this message, this field is not always filled. textMessageEvent -
    /// the user that wrote the message fanFundingEvent - the user that funded the broadcast newSponsorEvent - the
    /// user that just became a sponsor messageDeletedEvent - the moderator that took the action
    /// messageRetractedEvent - the author that retracted their message userBannedEvent - the moderator that took
    /// the action superChatEvent - the user that made the purchase</summary>
    [JsonProperty("authorChannelId")]
    public virtual string AuthorChannelId { get; set; }

    /// <summary>Contains a string that can be displayed to the user. If this field is not present the message is
    /// silent, at the moment only messages of type TOMBSTONE and CHAT_ENDED_EVENT are silent.</summary>
    [JsonProperty("displayMessage")]
    public virtual string DisplayMessage { get; set; }

    /// <summary>Details about the funding event, this is only set if the type is 'fanFundingEvent'.</summary>
    [JsonProperty("fanFundingEventDetails")]
    public virtual LiveChatFanFundingEventDetails FanFundingEventDetails { get; set; }

    /// <summary>Whether the message has display content that should be displayed to users.</summary>
    [JsonProperty("hasDisplayContent")]
    public virtual bool? HasDisplayContent { get; set; }

    [JsonProperty("liveChatId")]
    public virtual string LiveChatId { get; set; }

    [JsonProperty("messageDeletedDetails")]
    public virtual LiveChatMessageDeletedDetails MessageDeletedDetails { get; set; }

    [JsonProperty("messageRetractedDetails")]
    public virtual LiveChatMessageRetractedDetails MessageRetractedDetails { get; set; }

    [JsonProperty("pollClosedDetails")]
    public virtual LiveChatPollClosedDetails PollClosedDetails { get; set; }

    [JsonProperty("pollEditedDetails")]
    public virtual LiveChatPollEditedDetails PollEditedDetails { get; set; }

    [JsonProperty("pollOpenedDetails")]
    public virtual LiveChatPollOpenedDetails PollOpenedDetails { get; set; }

    [JsonProperty("pollVotedDetails")]
    public virtual LiveChatPollVotedDetails PollVotedDetails { get; set; }

    /// <summary>The date and time when the message was orignally published. The value is specified in ISO 8601
    /// (YYYY-MM-DDThh:mm:ss.sZ) format.</summary>
    [JsonProperty("publishedAt")]
    public virtual string PublishedAtRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.Base.LiveChatMessageSnippet.PublishedAtRaw" />.</summary>
    [JsonIgnore]
    public virtual DateTime? PublishedAt
    {
      get
      {
        return Utilities.GetDateTimeFromString(this.PublishedAtRaw);
      }
      set
      {
        this.PublishedAtRaw = Utilities.GetStringFromDateTime(value);
      }
    }

    /// <summary>Details about the Super Chat event, this is only set if the type is 'superChatEvent'.</summary>
    [JsonProperty("superChatDetails")]
    public virtual LiveChatSuperChatDetails SuperChatDetails { get; set; }

    /// <summary>Details about the text message, this is only set if the type is 'textMessageEvent'.</summary>
    [JsonProperty("textMessageDetails")]
    public virtual LiveChatTextMessageDetails TextMessageDetails { get; set; }

    /// <summary>The type of message, this will always be present, it determines the contents of the message as well
    /// as which fields will be present.</summary>
    [JsonProperty("type")]
    public virtual string Type { get; set; }

    [JsonProperty("userBannedDetails")]
    public virtual LiveChatUserBannedMessageDetails UserBannedDetails { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
