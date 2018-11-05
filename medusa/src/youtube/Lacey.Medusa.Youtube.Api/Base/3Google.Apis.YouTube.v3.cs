// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.CaptionsResource
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.IO;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Discovery;
using Google.Apis.Download;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>The "captions" collection of methods.</summary>
  public class CaptionsResource
  {
    private const string Resource = "captions";
    /// <summary>The service which this resource belongs to.</summary>
    private readonly IClientService service;

    /// <summary>Constructs a new resource.</summary>
    public CaptionsResource(IClientService service)
    {
      this.service = service;
    }

    /// <summary>Deletes a specified caption track.</summary>
    /// <param name="id">The id parameter identifies the caption track that is being deleted. The value is a caption track
    /// ID as identified by the id property in a caption resource.</param>
    public virtual CaptionsResource.DeleteRequest Delete(string id)
    {
      return new CaptionsResource.DeleteRequest(this.service, id);
    }

    /// <summary>Downloads a caption track. The caption track is returned in its original format unless the request
    /// specifies a value for the tfmt parameter and in its original language unless the request specifies a value
    /// for the tlang parameter.</summary>
    /// <param name="id">The id parameter identifies the caption track that is being retrieved. The value is a caption track
    /// ID as identified by the id property in a caption resource.</param>
    public virtual CaptionsResource.DownloadRequest Download(string id)
    {
      return new CaptionsResource.DownloadRequest(this.service, id);
    }

    /// <summary>Uploads a caption track.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter specifies the caption resource parts that the API response will include. Set
    /// the parameter value to snippet.</param>
    public virtual CaptionsResource.InsertRequest Insert(Caption body, string part)
    {
      return new CaptionsResource.InsertRequest(this.service, body, part);
    }

    /// <summary>Uploads a caption track.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter specifies the caption resource parts that the API response will include. Set
    /// the parameter value to snippet.</param>
    /// <param name="stream">The stream to upload.</param>
    /// <param name="contentType">The content type of the stream to upload.</param>
    public virtual CaptionsResource.InsertMediaUpload Insert(Caption body, string part, Stream stream, string contentType)
    {
      return new CaptionsResource.InsertMediaUpload(this.service, body, part, stream, contentType);
    }

    /// <summary>Returns a list of caption tracks that are associated with a specified video. Note that the API
    /// response does not contain the actual captions and that the captions.download method provides the ability to
    /// retrieve a caption track.</summary>
    /// <param name="part">The part parameter specifies a comma-separated list of one or more caption resource parts that
    /// the API response will include. The part names that you can include in the parameter value are id and
    /// snippet.</param>
    /// <param name="videoId">The videoId parameter specifies the YouTube video ID of the video for
    /// which the API should return caption tracks.</param>
    public virtual CaptionsResource.ListRequest List(string part, string videoId)
    {
      return new CaptionsResource.ListRequest(this.service, part, videoId);
    }

    /// <summary>Updates a caption track. When updating a caption track, you can change the track's draft status,
    /// upload a new caption file for the track, or both.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter serves two purposes in this operation. It identifies the properties that the
    /// write operation will set as well as the properties that the API response will include. Set the property value to
    /// snippet if you are updating the track's draft status. Otherwise, set the property value to id.</param>
    public virtual CaptionsResource.UpdateRequest Update(Caption body, string part)
    {
      return new CaptionsResource.UpdateRequest(this.service, body, part);
    }

    /// <summary>Updates a caption track. When updating a caption track, you can change the track's draft status,
    /// upload a new caption file for the track, or both.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter serves two purposes in this operation. It identifies the properties that the
    /// write operation will set as well as the properties that the API response will include. Set the property value to
    /// snippet if you are updating the track's draft status. Otherwise, set the property value to id.</param>
    /// <param name="stream">The stream to upload.</param>
    /// <param name="contentType">The content type of the stream to upload.</param>
    public virtual CaptionsResource.UpdateMediaUpload Update(Caption body, string part, Stream stream, string contentType)
    {
      return new CaptionsResource.UpdateMediaUpload(this.service, body, part, stream, contentType);
    }

    /// <summary>Deletes a specified caption track.</summary>
    public class DeleteRequest : YouTubeBaseServiceRequest<string>
    {
      /// <summary>Constructs a new Delete request.</summary>
      public DeleteRequest(IClientService service, string id)
        : base(service)
      {
        this.Id = id;
        this.InitParameters();
      }

      /// <summary>The id parameter identifies the caption track that is being deleted. The value is a caption
      /// track ID as identified by the id property in a caption resource.</summary>
      [RequestParameter("id", RequestParameterType.Query)]
      public virtual string Id { get; private set; }

      /// <summary>ID of the Google+ Page for the channel that the request is be on behalf of</summary>
      [RequestParameter("onBehalfOf", RequestParameterType.Query)]
      public virtual string OnBehalfOf { get; set; }

      /// <summary>Note: This parameter is intended exclusively for YouTube content partners.
      /// 
      /// The onBehalfOfContentOwner parameter indicates that the request's authorization credentials identify a
      /// YouTube CMS user who is acting on behalf of the content owner specified in the parameter value. This
      /// parameter is intended for YouTube content partners that own and manage many different YouTube channels.
      /// It allows content owners to authenticate once and get access to all their video and channel data,
      /// without having to provide authentication credentials for each individual channel. The actual CMS account
      /// that the user authenticates with must be linked to the specified YouTube content owner.</summary>
      [RequestParameter("onBehalfOfContentOwner", RequestParameterType.Query)]
      public virtual string OnBehalfOfContentOwner { get; set; }

      /// <summary>Gets the method name.</summary>
      public override string MethodName
      {
        get
        {
          return "delete";
        }
      }

      /// <summary>Gets the HTTP method.</summary>
      public override string HttpMethod
      {
        get
        {
          return "DELETE";
        }
      }

      /// <summary>Gets the REST path.</summary>
      public override string RestPath
      {
        get
        {
          return "captions";
        }
      }

      /// <summary>Initializes Delete parameter list.</summary>
      protected override void InitParameters()
      {
        base.InitParameters();
        this.RequestParameters.Add("id", (IParameter) new Parameter()
        {
          Name = "id",
          IsRequired = true,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("onBehalfOf", (IParameter) new Parameter()
        {
          Name = "onBehalfOf",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("onBehalfOfContentOwner", (IParameter) new Parameter()
        {
          Name = "onBehalfOfContentOwner",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
      }
    }

    /// <summary>Downloads a caption track. The caption track is returned in its original format unless the request
    /// specifies a value for the tfmt parameter and in its original language unless the request specifies a value
    /// for the tlang parameter.</summary>
    public class DownloadRequest : YouTubeBaseServiceRequest<string>
    {
      /// <summary>Constructs a new Download request.</summary>
      public DownloadRequest(IClientService service, string id)
        : base(service)
      {
        this.Id = id;
        this.MediaDownloader = (IMediaDownloader) new MediaDownloader(service);
        this.InitParameters();
      }

      /// <summary>The id parameter identifies the caption track that is being retrieved. The value is a caption
      /// track ID as identified by the id property in a caption resource.</summary>
      [RequestParameter("id", RequestParameterType.Path)]
      public virtual string Id { get; private set; }

      /// <summary>ID of the Google+ Page for the channel that the request is be on behalf of</summary>
      [RequestParameter("onBehalfOf", RequestParameterType.Query)]
      public virtual string OnBehalfOf { get; set; }

      /// <summary>Note: This parameter is intended exclusively for YouTube content partners.
      /// 
      /// The onBehalfOfContentOwner parameter indicates that the request's authorization credentials identify a
      /// YouTube CMS user who is acting on behalf of the content owner specified in the parameter value. This
      /// parameter is intended for YouTube content partners that own and manage many different YouTube channels.
      /// It allows content owners to authenticate once and get access to all their video and channel data,
      /// without having to provide authentication credentials for each individual channel. The actual CMS account
      /// that the user authenticates with must be linked to the specified YouTube content owner.</summary>
      [RequestParameter("onBehalfOfContentOwner", RequestParameterType.Query)]
      public virtual string OnBehalfOfContentOwner { get; set; }

      /// <summary>The tfmt parameter specifies that the caption track should be returned in a specific format. If
      /// the parameter is not included in the request, the track is returned in its original format.</summary>
      [RequestParameter("tfmt", RequestParameterType.Query)]
      public virtual CaptionsResource.DownloadRequest.TfmtEnum? Tfmt { get; set; }

      /// <summary>The tlang parameter specifies that the API response should return a translation of the
      /// specified caption track. The parameter value is an ISO 639-1 two-letter language code that identifies
      /// the desired caption language. The translation is generated by using machine translation, such as Google
      /// Translate.</summary>
      [RequestParameter("tlang", RequestParameterType.Query)]
      public virtual string Tlang { get; set; }

      /// <summary>Gets the method name.</summary>
      public override string MethodName
      {
        get
        {
          return "download";
        }
      }

      /// <summary>Gets the HTTP method.</summary>
      public override string HttpMethod
      {
        get
        {
          return "GET";
        }
      }

      /// <summary>Gets the REST path.</summary>
      public override string RestPath
      {
        get
        {
          return "captions/{id}";
        }
      }

      /// <summary>Initializes Download parameter list.</summary>
      protected override void InitParameters()
      {
        base.InitParameters();
        this.RequestParameters.Add("id", (IParameter) new Parameter()
        {
          Name = "id",
          IsRequired = true,
          ParameterType = "path",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("onBehalfOf", (IParameter) new Parameter()
        {
          Name = "onBehalfOf",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("onBehalfOfContentOwner", (IParameter) new Parameter()
        {
          Name = "onBehalfOfContentOwner",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("tfmt", (IParameter) new Parameter()
        {
          Name = "tfmt",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("tlang", (IParameter) new Parameter()
        {
          Name = "tlang",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
      }

      /// <summary>Gets the media downloader.</summary>
      public IMediaDownloader MediaDownloader { get; private set; }

      /// <summary>
      /// <para>Synchronously download the media into the given stream.</para>
      /// <para>Warning: This method hides download errors; use <see cref="M:Lacey.Medusa.Youtube.Api.Base.CaptionsResource.DownloadRequest.DownloadWithStatus(System.IO.Stream)" /> instead.</para>
      /// </summary>
      public virtual void Download(Stream stream)
      {
        this.MediaDownloader.Download(this.GenerateRequestUri(), stream);
      }

      /// <summary>Synchronously download the media into the given stream.</summary>
      /// <returns>The final status of the download; including whether the download succeeded or failed.</returns>
      public virtual IDownloadProgress DownloadWithStatus(Stream stream)
      {
        return this.MediaDownloader.Download(this.GenerateRequestUri(), stream);
      }

      /// <summary>Asynchronously download the media into the given stream.</summary>
      public virtual Task<IDownloadProgress> DownloadAsync(Stream stream)
      {
        return this.MediaDownloader.DownloadAsync(this.GenerateRequestUri(), stream);
      }

      /// <summary>Asynchronously download the media into the given stream.</summary>
      public virtual Task<IDownloadProgress> DownloadAsync(Stream stream, CancellationToken cancellationToken)
      {
        return this.MediaDownloader.DownloadAsync(this.GenerateRequestUri(), stream, cancellationToken);
      }

      /// <summary>Synchronously download a range of the media into the given stream.</summary>
      public virtual IDownloadProgress DownloadRange(Stream stream, RangeHeaderValue range)
      {
        MediaDownloader mediaDownloader = new MediaDownloader(this.Service);
        mediaDownloader.Range = range;
        return mediaDownloader.Download(this.GenerateRequestUri(), stream);
      }

      /// <summary>Asynchronously download a range of the media into the given stream.</summary>
      public virtual Task<IDownloadProgress> DownloadRangeAsync(Stream stream, RangeHeaderValue range, CancellationToken cancellationToken = default (CancellationToken))
      {
        MediaDownloader mediaDownloader = new MediaDownloader(this.Service);
        mediaDownloader.Range = range;
        return mediaDownloader.DownloadAsync(this.GenerateRequestUri(), stream, cancellationToken);
      }

      /// <summary>The tfmt parameter specifies that the caption track should be returned in a specific format. If
      /// the parameter is not included in the request, the track is returned in its original format.</summary>
      public enum TfmtEnum
      {
        /// <summary>SubViewer subtitle.</summary>
        [StringValue("sbv")] Sbv,
        /// <summary>Scenarist Closed Caption format.</summary>
        [StringValue("scc")] Scc,
        /// <summary>SubRip subtitle.</summary>
        [StringValue("srt")] Srt,
        /// <summary>Timed Text Markup Language caption.</summary>
        [StringValue("ttml")] Ttml,
        /// <summary>Web Video Text Tracks caption.</summary>
        [StringValue("vtt")] Vtt,
      }
    }

    /// <summary>Uploads a caption track.</summary>
    public class InsertRequest : YouTubeBaseServiceRequest<Caption>
    {
      /// <summary>Constructs a new Insert request.</summary>
      public InsertRequest(IClientService service, Caption body, string part)
        : base(service)
      {
        this.Part = part;
        this.Body = body;
        this.InitParameters();
      }

      /// <summary>The part parameter specifies the caption resource parts that the API response will include. Set
      /// the parameter value to snippet.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>ID of the Google+ Page for the channel that the request is be on behalf of</summary>
      [RequestParameter("onBehalfOf", RequestParameterType.Query)]
      public virtual string OnBehalfOf { get; set; }

      /// <summary>Note: This parameter is intended exclusively for YouTube content partners.
      /// 
      /// The onBehalfOfContentOwner parameter indicates that the request's authorization credentials identify a
      /// YouTube CMS user who is acting on behalf of the content owner specified in the parameter value. This
      /// parameter is intended for YouTube content partners that own and manage many different YouTube channels.
      /// It allows content owners to authenticate once and get access to all their video and channel data,
      /// without having to provide authentication credentials for each individual channel. The actual CMS account
      /// that the user authenticates with must be linked to the specified YouTube content owner.</summary>
      [RequestParameter("onBehalfOfContentOwner", RequestParameterType.Query)]
      public virtual string OnBehalfOfContentOwner { get; set; }

      /// <summary>The sync parameter indicates whether YouTube should automatically synchronize the caption file
      /// with the audio track of the video. If you set the value to true, YouTube will disregard any time codes
      /// that are in the uploaded caption file and generate new time codes for the captions.
      /// 
      /// You should set the sync parameter to true if you are uploading a transcript, which has no time codes, or
      /// if you suspect the time codes in your file are incorrect and want YouTube to try to fix them.</summary>
      [RequestParameter("sync", RequestParameterType.Query)]
      public virtual bool? Sync { get; set; }

      /// <summary>Gets or sets the body of this request.</summary>
      private Caption Body { get; set; }

      /// <summary>Returns the body of the request.</summary>
      protected override object GetBody()
      {
        return (object) this.Body;
      }

      /// <summary>Gets the method name.</summary>
      public override string MethodName
      {
        get
        {
          return "insert";
        }
      }

      /// <summary>Gets the HTTP method.</summary>
      public override string HttpMethod
      {
        get
        {
          return "POST";
        }
      }

      /// <summary>Gets the REST path.</summary>
      public override string RestPath
      {
        get
        {
          return "captions";
        }
      }

      /// <summary>Initializes Insert parameter list.</summary>
      protected override void InitParameters()
      {
        base.InitParameters();
        this.RequestParameters.Add("part", (IParameter) new Parameter()
        {
          Name = "part",
          IsRequired = true,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("onBehalfOf", (IParameter) new Parameter()
        {
          Name = "onBehalfOf",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("onBehalfOfContentOwner", (IParameter) new Parameter()
        {
          Name = "onBehalfOfContentOwner",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("sync", (IParameter) new Parameter()
        {
          Name = "sync",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
      }
    }

    /// <summary>Insert media upload which supports resumable upload.</summary>
    public class InsertMediaUpload : ResumableUpload<Caption, Caption>
    {
      /// <summary>Data format for the response.</summary>
      /// 
      ///             [default: json]
      [RequestParameter("alt", RequestParameterType.Query)]
      public virtual CaptionsResource.InsertMediaUpload.AltEnum? Alt { get; set; }

      /// <summary>Selector specifying which fields to include in a partial response.</summary>
      [RequestParameter("fields", RequestParameterType.Query)]
      public virtual string Fields { get; set; }

      /// <summary>API key. Your API key identifies your project and provides you with API access, quota, and
      /// reports. Required unless you provide an OAuth 2.0 token.</summary>
      [RequestParameter("key", RequestParameterType.Query)]
      public virtual string Key { get; set; }

      /// <summary>OAuth 2.0 token for the current user.</summary>
      [RequestParameter("oauth_token", RequestParameterType.Query)]
      public virtual string OauthToken { get; set; }

      /// <summary>Returns response with indentations and line breaks.</summary>
      /// 
      ///             [default: true]
      [RequestParameter("prettyPrint", RequestParameterType.Query)]
      public virtual bool? PrettyPrint { get; set; }

      /// <summary>An opaque string that represents a user for quota purposes. Must not exceed 40
      /// characters.</summary>
      [RequestParameter("quotaUser", RequestParameterType.Query)]
      public virtual string QuotaUser { get; set; }

      /// <summary>Deprecated. Please use quotaUser instead.</summary>
      [RequestParameter("userIp", RequestParameterType.Query)]
      public virtual string UserIp { get; set; }

      /// <summary>The part parameter specifies the caption resource parts that the API response will include. Set
      /// the parameter value to snippet.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>ID of the Google+ Page for the channel that the request is be on behalf of</summary>
      [RequestParameter("onBehalfOf", RequestParameterType.Query)]
      public virtual string OnBehalfOf { get; set; }

      /// <summary>Note: This parameter is intended exclusively for YouTube content partners.
      /// 
      /// The onBehalfOfContentOwner parameter indicates that the request's authorization credentials identify a
      /// YouTube CMS user who is acting on behalf of the content owner specified in the parameter value. This
      /// parameter is intended for YouTube content partners that own and manage many different YouTube channels.
      /// It allows content owners to authenticate once and get access to all their video and channel data,
      /// without having to provide authentication credentials for each individual channel. The actual CMS account
      /// that the user authenticates with must be linked to the specified YouTube content owner.</summary>
      [RequestParameter("onBehalfOfContentOwner", RequestParameterType.Query)]
      public virtual string OnBehalfOfContentOwner { get; set; }

      /// <summary>The sync parameter indicates whether YouTube should automatically synchronize the caption file
      /// with the audio track of the video. If you set the value to true, YouTube will disregard any time codes
      /// that are in the uploaded caption file and generate new time codes for the captions.
      /// 
      /// You should set the sync parameter to true if you are uploading a transcript, which has no time codes, or
      /// if you suspect the time codes in your file are incorrect and want YouTube to try to fix them.</summary>
      [RequestParameter("sync", RequestParameterType.Query)]
      public virtual bool? Sync { get; set; }

      /// <summary>Constructs a new Insert media upload instance.</summary>
      public InsertMediaUpload(IClientService service, Caption body, string part, Stream stream, string contentType)
      : base(service, string.Format("/{0}/{1}{2}", (object)"upload", (object)service.BasePath, (object)"captions"), "POST", stream, contentType)
      {
        this.Part = part;
        this.Body = body;
      }

      /// <summary>Data format for the response.</summary>
      public enum AltEnum
      {
        /// <summary>Responses with Content-Type of application/json</summary>
        [StringValue("json")] Json,
      }
    }

    /// <summary>Returns a list of caption tracks that are associated with a specified video. Note that the API
    /// response does not contain the actual captions and that the captions.download method provides the ability to
    /// retrieve a caption track.</summary>
    public class ListRequest : YouTubeBaseServiceRequest<CaptionListResponse>
    {
      /// <summary>Constructs a new List request.</summary>
      public ListRequest(IClientService service, string part, string videoId)
        : base(service)
      {
        this.Part = part;
        this.VideoId = videoId;
        this.InitParameters();
      }

      /// <summary>The part parameter specifies a comma-separated list of one or more caption resource parts that
      /// the API response will include. The part names that you can include in the parameter value are id and
      /// snippet.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>The videoId parameter specifies the YouTube video ID of the video for which the API should
      /// return caption tracks.</summary>
      [RequestParameter("videoId", RequestParameterType.Query)]
      public virtual string VideoId { get; private set; }

      /// <summary>The id parameter specifies a comma-separated list of IDs that identify the caption resources
      /// that should be retrieved. Each ID must identify a caption track associated with the specified
      /// video.</summary>
      [RequestParameter("id", RequestParameterType.Query)]
      public virtual string Id { get; set; }

      /// <summary>ID of the Google+ Page for the channel that the request is on behalf of.</summary>
      [RequestParameter("onBehalfOf", RequestParameterType.Query)]
      public virtual string OnBehalfOf { get; set; }

      /// <summary>Note: This parameter is intended exclusively for YouTube content partners.
      /// 
      /// The onBehalfOfContentOwner parameter indicates that the request's authorization credentials identify a
      /// YouTube CMS user who is acting on behalf of the content owner specified in the parameter value. This
      /// parameter is intended for YouTube content partners that own and manage many different YouTube channels.
      /// It allows content owners to authenticate once and get access to all their video and channel data,
      /// without having to provide authentication credentials for each individual channel. The actual CMS account
      /// that the user authenticates with must be linked to the specified YouTube content owner.</summary>
      [RequestParameter("onBehalfOfContentOwner", RequestParameterType.Query)]
      public virtual string OnBehalfOfContentOwner { get; set; }

      /// <summary>Gets the method name.</summary>
      public override string MethodName
      {
        get
        {
          return "list";
        }
      }

      /// <summary>Gets the HTTP method.</summary>
      public override string HttpMethod
      {
        get
        {
          return "GET";
        }
      }

      /// <summary>Gets the REST path.</summary>
      public override string RestPath
      {
        get
        {
          return "captions";
        }
      }

      /// <summary>Initializes List parameter list.</summary>
      protected override void InitParameters()
      {
        base.InitParameters();
        this.RequestParameters.Add("part", (IParameter) new Parameter()
        {
          Name = "part",
          IsRequired = true,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("videoId", (IParameter) new Parameter()
        {
          Name = "videoId",
          IsRequired = true,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("id", (IParameter) new Parameter()
        {
          Name = "id",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("onBehalfOf", (IParameter) new Parameter()
        {
          Name = "onBehalfOf",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("onBehalfOfContentOwner", (IParameter) new Parameter()
        {
          Name = "onBehalfOfContentOwner",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
      }
    }

    /// <summary>Updates a caption track. When updating a caption track, you can change the track's draft status,
    /// upload a new caption file for the track, or both.</summary>
    public class UpdateRequest : YouTubeBaseServiceRequest<Caption>
    {
      /// <summary>Constructs a new Update request.</summary>
      public UpdateRequest(IClientService service, Caption body, string part)
        : base(service)
      {
        this.Part = part;
        this.Body = body;
        this.InitParameters();
      }

      /// <summary>The part parameter serves two purposes in this operation. It identifies the properties that the
      /// write operation will set as well as the properties that the API response will include. Set the property
      /// value to snippet if you are updating the track's draft status. Otherwise, set the property value to
      /// id.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>ID of the Google+ Page for the channel that the request is be on behalf of</summary>
      [RequestParameter("onBehalfOf", RequestParameterType.Query)]
      public virtual string OnBehalfOf { get; set; }

      /// <summary>Note: This parameter is intended exclusively for YouTube content partners.
      /// 
      /// The onBehalfOfContentOwner parameter indicates that the request's authorization credentials identify a
      /// YouTube CMS user who is acting on behalf of the content owner specified in the parameter value. This
      /// parameter is intended for YouTube content partners that own and manage many different YouTube channels.
      /// It allows content owners to authenticate once and get access to all their video and channel data,
      /// without having to provide authentication credentials for each individual channel. The actual CMS account
      /// that the user authenticates with must be linked to the specified YouTube content owner.</summary>
      [RequestParameter("onBehalfOfContentOwner", RequestParameterType.Query)]
      public virtual string OnBehalfOfContentOwner { get; set; }

      /// <summary>Note: The API server only processes the parameter value if the request contains an updated
      /// caption file.
      /// 
      /// The sync parameter indicates whether YouTube should automatically synchronize the caption file with the
      /// audio track of the video. If you set the value to true, YouTube will automatically synchronize the
      /// caption track with the audio track.</summary>
      [RequestParameter("sync", RequestParameterType.Query)]
      public virtual bool? Sync { get; set; }

      /// <summary>Gets or sets the body of this request.</summary>
      private Caption Body { get; set; }

      /// <summary>Returns the body of the request.</summary>
      protected override object GetBody()
      {
        return (object) this.Body;
      }

      /// <summary>Gets the method name.</summary>
      public override string MethodName
      {
        get
        {
          return "update";
        }
      }

      /// <summary>Gets the HTTP method.</summary>
      public override string HttpMethod
      {
        get
        {
          return "PUT";
        }
      }

      /// <summary>Gets the REST path.</summary>
      public override string RestPath
      {
        get
        {
          return "captions";
        }
      }

      /// <summary>Initializes Update parameter list.</summary>
      protected override void InitParameters()
      {
        base.InitParameters();
        this.RequestParameters.Add("part", (IParameter) new Parameter()
        {
          Name = "part",
          IsRequired = true,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("onBehalfOf", (IParameter) new Parameter()
        {
          Name = "onBehalfOf",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("onBehalfOfContentOwner", (IParameter) new Parameter()
        {
          Name = "onBehalfOfContentOwner",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("sync", (IParameter) new Parameter()
        {
          Name = "sync",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
      }
    }

    /// <summary>Update media upload which supports resumable upload.</summary>
    public class UpdateMediaUpload : ResumableUpload<Caption, Caption>
    {
      /// <summary>Data format for the response.</summary>
      /// 
      ///             [default: json]
      [RequestParameter("alt", RequestParameterType.Query)]
      public virtual CaptionsResource.UpdateMediaUpload.AltEnum? Alt { get; set; }

      /// <summary>Selector specifying which fields to include in a partial response.</summary>
      [RequestParameter("fields", RequestParameterType.Query)]
      public virtual string Fields { get; set; }

      /// <summary>API key. Your API key identifies your project and provides you with API access, quota, and
      /// reports. Required unless you provide an OAuth 2.0 token.</summary>
      [RequestParameter("key", RequestParameterType.Query)]
      public virtual string Key { get; set; }

      /// <summary>OAuth 2.0 token for the current user.</summary>
      [RequestParameter("oauth_token", RequestParameterType.Query)]
      public virtual string OauthToken { get; set; }

      /// <summary>Returns response with indentations and line breaks.</summary>
      /// 
      ///             [default: true]
      [RequestParameter("prettyPrint", RequestParameterType.Query)]
      public virtual bool? PrettyPrint { get; set; }

      /// <summary>An opaque string that represents a user for quota purposes. Must not exceed 40
      /// characters.</summary>
      [RequestParameter("quotaUser", RequestParameterType.Query)]
      public virtual string QuotaUser { get; set; }

      /// <summary>Deprecated. Please use quotaUser instead.</summary>
      [RequestParameter("userIp", RequestParameterType.Query)]
      public virtual string UserIp { get; set; }

      /// <summary>The part parameter serves two purposes in this operation. It identifies the properties that the
      /// write operation will set as well as the properties that the API response will include. Set the property
      /// value to snippet if you are updating the track's draft status. Otherwise, set the property value to
      /// id.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>ID of the Google+ Page for the channel that the request is be on behalf of</summary>
      [RequestParameter("onBehalfOf", RequestParameterType.Query)]
      public virtual string OnBehalfOf { get; set; }

      /// <summary>Note: This parameter is intended exclusively for YouTube content partners.
      /// 
      /// The onBehalfOfContentOwner parameter indicates that the request's authorization credentials identify a
      /// YouTube CMS user who is acting on behalf of the content owner specified in the parameter value. This
      /// parameter is intended for YouTube content partners that own and manage many different YouTube channels.
      /// It allows content owners to authenticate once and get access to all their video and channel data,
      /// without having to provide authentication credentials for each individual channel. The actual CMS account
      /// that the user authenticates with must be linked to the specified YouTube content owner.</summary>
      [RequestParameter("onBehalfOfContentOwner", RequestParameterType.Query)]
      public virtual string OnBehalfOfContentOwner { get; set; }

      /// <summary>Note: The API server only processes the parameter value if the request contains an updated
      /// caption file.
      /// 
      /// The sync parameter indicates whether YouTube should automatically synchronize the caption file with the
      /// audio track of the video. If you set the value to true, YouTube will automatically synchronize the
      /// caption track with the audio track.</summary>
      [RequestParameter("sync", RequestParameterType.Query)]
      public virtual bool? Sync { get; set; }

      /// <summary>Constructs a new Update media upload instance.</summary>
      public UpdateMediaUpload(IClientService service, Caption body, string part, Stream stream, string contentType)
      : base(service, string.Format("/{0}/{1}{2}", (object)"upload", (object)service.BasePath, (object)"captions"), "PUT", stream, contentType)
      {
        this.Part = part;
        this.Body = body;
      }

      /// <summary>Data format for the response.</summary>
      public enum AltEnum
      {
        /// <summary>Responses with Content-Type of application/json</summary>
        [StringValue("json")] Json,
      }
    }
  }
}
