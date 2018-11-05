// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ChannelConversionPing
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Pings that the app shall fire (authenticated by biscotti cookie). Each ping has a context, in which the
  /// app must fire the ping, and a url identifying the ping.</summary>
  public class ChannelConversionPing : IDirectResponseSchema
  {
    /// <summary>Defines the context of the ping.</summary>
    [JsonProperty("context")]
    public virtual string Context { get; set; }

    /// <summary>The url (without the schema) that the player shall send the ping to. It's at caller's descretion to
    /// decide which schema to use (http vs https) Example of a returned url: //googleads.g.doubleclick.net/pagead/
    /// viewthroughconversion/962985656/?data=path%3DtHe_path%3Btype%3D
    /// cview%3Butuid%3DGISQtTNGYqaYl4sKxoVvKA=default The caller must append biscotti authentication (ms param in
    /// case of mobile, for example) to this ping.</summary>
    [JsonProperty("conversionUrl")]
    public virtual string ConversionUrl { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
