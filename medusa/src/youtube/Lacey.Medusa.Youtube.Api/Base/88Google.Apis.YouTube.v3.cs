// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.IngestionInfo
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Describes information necessary for ingesting an RTMP or an HTTP stream.</summary>
  public class IngestionInfo : IDirectResponseSchema
  {
    /// <summary>The backup ingestion URL that you should use to stream video to YouTube. You have the option of
    /// simultaneously streaming the content that you are sending to the ingestionAddress to this URL.</summary>
    [JsonProperty("backupIngestionAddress")]
    public virtual string BackupIngestionAddress { get; set; }

    /// <summary>The primary ingestion URL that you should use to stream video to YouTube. You must stream video to
    /// this URL.
    /// 
    /// Depending on which application or tool you use to encode your video stream, you may need to enter the stream
    /// URL and stream name separately or you may need to concatenate them in the following format:
    /// 
    /// STREAM_URL/STREAM_NAME</summary>
    [JsonProperty("ingestionAddress")]
    public virtual string IngestionAddress { get; set; }

    /// <summary>The HTTP or RTMP stream name that YouTube assigns to the video stream.</summary>
    [JsonProperty("streamName")]
    public virtual string StreamName { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
