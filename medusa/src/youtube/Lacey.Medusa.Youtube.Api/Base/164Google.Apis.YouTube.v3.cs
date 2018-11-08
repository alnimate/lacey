// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.VideoRecordingDetails
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System;
using Lacey.Medusa.Common.Api.Base.Requests;
using Lacey.Medusa.Common.Api.Core.Base.Util;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Recording information associated with the video.</summary>
  internal class VideoRecordingDetails : IDirectResponseSchema
  {
    /// <summary>The geolocation information associated with the video.</summary>
    [JsonProperty("location")]
    public virtual GeoPoint Location { get; set; }

    /// <summary>The text description of the location where the video was recorded.</summary>
    [JsonProperty("locationDescription")]
    public virtual string LocationDescription { get; set; }

    /// <summary>The date and time when the video was recorded. The value is specified in ISO 8601 (YYYY-MM-
    /// DDThh:mm:ss.sssZ) format.</summary>
    [JsonProperty("recordingDate")]
    public virtual string RecordingDateRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.Base.VideoRecordingDetails.RecordingDateRaw" />.</summary>
    [JsonIgnore]
    public virtual DateTime? RecordingDate
    {
      get
      {
        return Utilities.GetDateTimeFromString(this.RecordingDateRaw);
      }
      set
      {
        this.RecordingDateRaw = Utilities.GetStringFromDateTime(value);
      }
    }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
