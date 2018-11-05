// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ChannelConversionPings
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.Collections.Generic;
using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>The conversionPings object encapsulates information about conversion pings that need to be respected by
  /// the channel.</summary>
  internal class ChannelConversionPings : IDirectResponseSchema
  {
    /// <summary>Pings that the app shall fire (authenticated by biscotti cookie). Each ping has a context, in which
    /// the app must fire the ping, and a url identifying the ping.</summary>
    [JsonProperty("pings")]
    public virtual IList<ChannelConversionPing> Pings { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
