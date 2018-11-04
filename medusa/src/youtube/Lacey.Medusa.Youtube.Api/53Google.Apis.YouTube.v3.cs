// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ChannelContentOwnerDetails
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System;
using Google.Apis.Requests;
using Google.Apis.Util;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>The contentOwnerDetails object encapsulates channel data that is relevant for YouTube Partners linked
  /// with the channel.</summary>
  public class ChannelContentOwnerDetails : IDirectResponseSchema
  {
    /// <summary>The ID of the content owner linked to the channel.</summary>
    [JsonProperty("contentOwner")]
    public virtual string ContentOwner { get; set; }

    /// <summary>The date and time of when the channel was linked to the content owner. The value is specified in
    /// ISO 8601 (YYYY-MM-DDThh:mm:ss.sZ) format.</summary>
    [JsonProperty("timeLinked")]
    public virtual string TimeLinkedRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.ChannelContentOwnerDetails.TimeLinkedRaw" />.</summary>
    [JsonIgnore]
    public virtual DateTime? TimeLinked
    {
      get
      {
        return Utilities.GetDateTimeFromString(this.TimeLinkedRaw);
      }
      set
      {
        this.TimeLinkedRaw = Utilities.GetStringFromDateTime(value);
      }
    }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
