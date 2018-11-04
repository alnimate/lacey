// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ChannelBrandingSettings
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.Collections.Generic;
using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>Branding properties of a YouTube channel.</summary>
  public class ChannelBrandingSettings : IDirectResponseSchema
  {
    /// <summary>Branding properties for the channel view.</summary>
    [JsonProperty("channel")]
    public virtual ChannelSettings Channel { get; set; }

    /// <summary>Additional experimental branding properties.</summary>
    [JsonProperty("hints")]
    public virtual IList<PropertyValue> Hints { get; set; }

    /// <summary>Branding properties for branding images.</summary>
    [JsonProperty("image")]
    public virtual ImageSettings Image { get; set; }

    /// <summary>Branding properties for the watch page.</summary>
    [JsonProperty("watch")]
    public virtual WatchSettings Watch { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
