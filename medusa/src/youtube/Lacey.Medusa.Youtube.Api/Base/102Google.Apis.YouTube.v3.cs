// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.LiveStreamContentDetails
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Detailed settings of a stream.</summary>
  public class LiveStreamContentDetails : IDirectResponseSchema
  {
    /// <summary>The ingestion URL where the closed captions of this stream are sent.</summary>
    [JsonProperty("closedCaptionsIngestionUrl")]
    public virtual string ClosedCaptionsIngestionUrl { get; set; }

    /// <summary>Indicates whether the stream is reusable, which means that it can be bound to multiple broadcasts.
    /// It is common for broadcasters to reuse the same stream for many different broadcasts if those broadcasts
    /// occur at different times.
    /// 
    /// If you set this value to false, then the stream will not be reusable, which means that it can only be bound
    /// to one broadcast. Non-reusable streams differ from reusable streams in the following ways: - A non-reusable
    /// stream can only be bound to one broadcast. - A non-reusable stream might be deleted by an automated process
    /// after the broadcast ends. - The  liveStreams.list method does not list non-reusable streams if you call the
    /// method and set the mine parameter to true. The only way to use that method to retrieve the resource for a
    /// non-reusable stream is to use the id parameter to identify the stream.</summary>
    [JsonProperty("isReusable")]
    public virtual bool? IsReusable { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
