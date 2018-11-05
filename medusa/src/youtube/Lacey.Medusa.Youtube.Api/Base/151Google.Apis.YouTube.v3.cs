// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.VideoFileDetails
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.Collections.Generic;
using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Describes original video file properties, including technical details about audio and video streams,
  /// but also metadata information like content length, digitization time, or geotagging information.</summary>
  public class VideoFileDetails : IDirectResponseSchema
  {
    /// <summary>A list of audio streams contained in the uploaded video file. Each item in the list contains
    /// detailed metadata about an audio stream.</summary>
    [JsonProperty("audioStreams")]
    public virtual IList<VideoFileDetailsAudioStream> AudioStreams { get; set; }

    /// <summary>The uploaded video file's combined (video and audio) bitrate in bits per second.</summary>
    [JsonProperty("bitrateBps")]
    public virtual ulong? BitrateBps { get; set; }

    /// <summary>The uploaded video file's container format.</summary>
    [JsonProperty("container")]
    public virtual string Container { get; set; }

    /// <summary>The date and time when the uploaded video file was created. The value is specified in ISO 8601
    /// format. Currently, the following ISO 8601 formats are supported: - Date only: YYYY-MM-DD - Naive time: YYYY-
    /// MM-DDTHH:MM:SS - Time with timezone: YYYY-MM-DDTHH:MM:SS+HH:MM</summary>
    [JsonProperty("creationTime")]
    public virtual string CreationTime { get; set; }

    /// <summary>The length of the uploaded video in milliseconds.</summary>
    [JsonProperty("durationMs")]
    public virtual ulong? DurationMs { get; set; }

    /// <summary>The uploaded file's name. This field is present whether a video file or another type of file was
    /// uploaded.</summary>
    [JsonProperty("fileName")]
    public virtual string FileName { get; set; }

    /// <summary>The uploaded file's size in bytes. This field is present whether a video file or another type of
    /// file was uploaded.</summary>
    [JsonProperty("fileSize")]
    public virtual ulong? FileSize { get; set; }

    /// <summary>The uploaded file's type as detected by YouTube's video processing engine. Currently, YouTube only
    /// processes video files, but this field is present whether a video file or another type of file was
    /// uploaded.</summary>
    [JsonProperty("fileType")]
    public virtual string FileType { get; set; }

    /// <summary>A list of video streams contained in the uploaded video file. Each item in the list contains
    /// detailed metadata about a video stream.</summary>
    [JsonProperty("videoStreams")]
    public virtual IList<VideoFileDetailsVideoStream> VideoStreams { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
