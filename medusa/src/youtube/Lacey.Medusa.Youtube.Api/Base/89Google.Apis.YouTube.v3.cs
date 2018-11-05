// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.InvideoBranding
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  public class InvideoBranding : IDirectResponseSchema
  {
    [JsonProperty("imageBytes")]
    public virtual string ImageBytes { get; set; }

    [JsonProperty("imageUrl")]
    public virtual string ImageUrl { get; set; }

    [JsonProperty("position")]
    public virtual InvideoPosition Position { get; set; }

    [JsonProperty("targetChannelId")]
    public virtual string TargetChannelId { get; set; }

    [JsonProperty("timing")]
    public virtual InvideoTiming Timing { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
