// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.VideosResource
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.IO;
using Google.Apis.Discovery;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>The "videos" collection of methods.</summary>
  public class VideosResource
  {
    private const string Resource = "videos";
    /// <summary>The service which this resource belongs to.</summary>
    private readonly IClientService service;

    /// <summary>Constructs a new resource.</summary>
    public VideosResource(IClientService service)
    {
      this.service = service;
    }

    /// <summary>Deletes a YouTube video.</summary>
    /// <param name="id">The id parameter specifies the YouTube video ID for the resource that is being deleted. In a video
    /// resource, the id property specifies the video's ID.</param>
    public virtual VideosResource.DeleteRequest Delete(string id)
    {
      return new VideosResource.DeleteRequest(this.service, id);
    }

    /// <summary>Retrieves the ratings that the authorized user gave to a list of specified videos.</summary>
    /// <param name="id">The id parameter specifies a comma-separated list of the YouTube video ID(s) for the resource(s)
    /// for which you are retrieving rating data. In a video resource, the id property specifies the video's
    /// ID.</param>
    public virtual VideosResource.GetRatingRequest GetRating(string id)
    {
      return new VideosResource.GetRatingRequest(this.service, id);
    }

    /// <summary>Uploads a video to YouTube and optionally sets the video's metadata.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter serves two purposes in this operation. It identifies the properties that the
    /// write operation will set as well as the properties that the API response will include.
    /// 
    /// Note that not all parts contain properties that can be set when inserting or updating a video. For example, the
    /// statistics object encapsulates statistics that YouTube calculates for a video and does not contain values that you
    /// can set or modify. If the parameter value specifies a part that does not contain mutable values, that part will
    /// still be included in the API response.</param>
    public virtual VideosResource.InsertRequest Insert(Video body, string part)
    {
      return new VideosResource.InsertRequest(this.service, body, part);
    }

    /// <summary>Uploads a video to YouTube and optionally sets the video's metadata.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter serves two purposes in this operation. It identifies the properties that the
    /// write operation will set as well as the properties that the API response will include.
    /// 
    /// Note that not all parts contain properties that can be set when inserting or updating a video. For example, the
    /// statistics object encapsulates statistics that YouTube calculates for a video and does not contain values that you
    /// can set or modify. If the parameter value specifies a part that does not contain mutable values, that part will
    /// still be included in the API response.</param>
    /// <param name="stream">The stream to upload.</param>
    /// <param name="contentType">The content type of the stream to upload.</param>
    public virtual VideosResource.InsertMediaUpload Insert(Video body, string part, Stream stream, string contentType)
    {
      return new VideosResource.InsertMediaUpload(this.service, body, part, stream, contentType);
    }

    /// <summary>Returns a list of videos that match the API request parameters.</summary>
    /// <param name="part">The part parameter specifies a comma-separated list of one or more video resource properties that
    /// the API response will include.
    /// 
    /// If the parameter identifies a property that contains child properties, the child properties will be included in the
    /// response. For example, in a video resource, the snippet property contains the channelId, title, description, tags,
    /// and categoryId properties. As such, if you set part=snippet, the API response will contain all of those
    /// properties.</param>
    public virtual VideosResource.ListRequest List(string part)
    {
      return new VideosResource.ListRequest(this.service, part);
    }

    /// <summary>Add a like or dislike rating to a video or remove a rating from a video.</summary>
    /// <param name="id">The id parameter specifies the YouTube video ID of the video that is being rated or having its
    /// rating removed.</param>
    /// <param name="rating">Specifies the rating to record.</param>
    public virtual VideosResource.RateRequest Rate(string id, VideosResource.RateRequest.RatingEnum rating)
    {
      return new VideosResource.RateRequest(this.service, id, rating);
    }

    /// <summary>Report abuse for a video.</summary>
    /// <param name="body">The body of the request.</param>
    public virtual VideosResource.ReportAbuseRequest ReportAbuse(VideoAbuseReport body)
    {
      return new VideosResource.ReportAbuseRequest(this.service, body);
    }

    /// <summary>Updates a video's metadata.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter serves two purposes in this operation. It identifies the properties that the
    /// write operation will set as well as the properties that the API response will include.
    /// 
    /// Note that this method will override the existing values for all of the mutable properties that are contained in any
    /// parts that the parameter value specifies. For example, a video's privacy setting is contained in the status part. As
    /// such, if your request is updating a private video, and the request's part parameter value includes the status part,
    /// the video's privacy setting will be updated to whatever value the request body specifies. If the request body does
    /// not specify a value, the existing privacy setting will be removed and the video will revert to the default privacy
    /// setting.
    /// 
    /// In addition, not all parts contain properties that can be set when inserting or updating a video. For example, the
    /// statistics object encapsulates statistics that YouTube calculates for a video and does not contain values that you
    /// can set or modify. If the parameter value specifies a part that does not contain mutable values, that part will
    /// still be included in the API response.</param>
    public virtual VideosResource.UpdateRequest Update(Video body, string part)
    {
      return new VideosResource.UpdateRequest(this.service, body, part);
    }

    /// <summary>Deletes a YouTube video.</summary>
    public class DeleteRequest : YouTubeBaseServiceRequest<string>
    {
      /// <summary>Constructs a new Delete request.</summary>
      public DeleteRequest(IClientService service, string id)
        : base(service)
      {
        this.Id = id;
        this.InitParameters();
      }

      /// <summary>The id parameter specifies the YouTube video ID for the resource that is being deleted. In a
      /// video resource, the id property specifies the video's ID.</summary>
      [RequestParameter("id", RequestParameterType.Query)]
      public virtual string Id { get; private set; }

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
          return "videos";
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

    /// <summary>Retrieves the ratings that the authorized user gave to a list of specified videos.</summary>
    public class GetRatingRequest : YouTubeBaseServiceRequest<VideoGetRatingResponse>
    {
      /// <summary>Constructs a new GetRating request.</summary>
      public GetRatingRequest(IClientService service, string id)
        : base(service)
      {
        this.Id = id;
        this.InitParameters();
      }

      /// <summary>The id parameter specifies a comma-separated list of the YouTube video ID(s) for the
      /// resource(s) for which you are retrieving rating data. In a video resource, the id property specifies the
      /// video's ID.</summary>
      [RequestParameter("id", RequestParameterType.Query)]
      public virtual string Id { get; private set; }

      /// <summary>Note: This parameter is intended exclusively for YouTube content partners.
      /// 
      /// The onBehalfOfContentOwner parameter indicates that the request's authorization credentials identify a
      /// YouTube CMS user who is acting on behalf of the content owner specified in the parameter value. This
      /// parameter is intended for YouTube content partners that own and manage many different YouTube channels.
      /// It allows content owners to authenticate once and get access to all their video and channel data,
      /// without having to provide authentication credentials for each individual channel. The CMS account that
      /// the user authenticates with must be linked to the specified YouTube content owner.</summary>
      [RequestParameter("onBehalfOfContentOwner", RequestParameterType.Query)]
      public virtual string OnBehalfOfContentOwner { get; set; }

      /// <summary>Gets the method name.</summary>
      public override string MethodName
      {
        get
        {
          return "getRating";
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
          return "videos/getRating";
        }
      }

      /// <summary>Initializes GetRating parameter list.</summary>
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

    /// <summary>Uploads a video to YouTube and optionally sets the video's metadata.</summary>
    public class InsertRequest : YouTubeBaseServiceRequest<Video>
    {
      /// <summary>Constructs a new Insert request.</summary>
      public InsertRequest(IClientService service, Video body, string part)
        : base(service)
      {
        this.Part = part;
        this.Body = body;
        this.InitParameters();
      }

      /// <summary>The part parameter serves two purposes in this operation. It identifies the properties that the
      /// write operation will set as well as the properties that the API response will include.
      /// 
      /// Note that not all parts contain properties that can be set when inserting or updating a video. For
      /// example, the statistics object encapsulates statistics that YouTube calculates for a video and does not
      /// contain values that you can set or modify. If the parameter value specifies a part that does not contain
      /// mutable values, that part will still be included in the API response.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>The autoLevels parameter indicates whether YouTube should automatically enhance the video's
      /// lighting and color.</summary>
      [RequestParameter("autoLevels", RequestParameterType.Query)]
      public virtual bool? AutoLevels { get; set; }

      /// <summary>The notifySubscribers parameter indicates whether YouTube should send a notification about the
      /// new video to users who subscribe to the video's channel. A parameter value of True indicates that
      /// subscribers will be notified of newly uploaded videos. However, a channel owner who is uploading many
      /// videos might prefer to set the value to False to avoid sending a notification about each new video to
      /// the channel's subscribers.</summary>
      /// 
      ///             [default: true]
      [RequestParameter("notifySubscribers", RequestParameterType.Query)]
      public virtual bool? NotifySubscribers { get; set; }

      /// <summary>Note: This parameter is intended exclusively for YouTube content partners.
      /// 
      /// The onBehalfOfContentOwner parameter indicates that the request's authorization credentials identify a
      /// YouTube CMS user who is acting on behalf of the content owner specified in the parameter value. This
      /// parameter is intended for YouTube content partners that own and manage many different YouTube channels.
      /// It allows content owners to authenticate once and get access to all their video and channel data,
      /// without having to provide authentication credentials for each individual channel. The CMS account that
      /// the user authenticates with must be linked to the specified YouTube content owner.</summary>
      [RequestParameter("onBehalfOfContentOwner", RequestParameterType.Query)]
      public virtual string OnBehalfOfContentOwner { get; set; }

      /// <summary>This parameter can only be used in a properly authorized request. Note: This parameter is
      /// intended exclusively for YouTube content partners.
      /// 
      /// The onBehalfOfContentOwnerChannel parameter specifies the YouTube channel ID of the channel to which a
      /// video is being added. This parameter is required when a request specifies a value for the
      /// onBehalfOfContentOwner parameter, and it can only be used in conjunction with that parameter. In
      /// addition, the request must be authorized using a CMS account that is linked to the content owner that
      /// the onBehalfOfContentOwner parameter specifies. Finally, the channel that the
      /// onBehalfOfContentOwnerChannel parameter value specifies must be linked to the content owner that the
      /// onBehalfOfContentOwner parameter specifies.
      /// 
      /// This parameter is intended for YouTube content partners that own and manage many different YouTube
      /// channels. It allows content owners to authenticate once and perform actions on behalf of the channel
      /// specified in the parameter value, without having to provide authentication credentials for each separate
      /// channel.</summary>
      [RequestParameter("onBehalfOfContentOwnerChannel", RequestParameterType.Query)]
      public virtual string OnBehalfOfContentOwnerChannel { get; set; }

      /// <summary>The stabilize parameter indicates whether YouTube should adjust the video to remove shaky
      /// camera motions.</summary>
      [RequestParameter("stabilize", RequestParameterType.Query)]
      public virtual bool? Stabilize { get; set; }

      /// <summary>Gets or sets the body of this request.</summary>
      private Video Body { get; set; }

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
          return "videos";
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
        this.RequestParameters.Add("autoLevels", (IParameter) new Parameter()
        {
          Name = "autoLevels",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("notifySubscribers", (IParameter) new Parameter()
        {
          Name = "notifySubscribers",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = "true",
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
        this.RequestParameters.Add("onBehalfOfContentOwnerChannel", (IParameter) new Parameter()
        {
          Name = "onBehalfOfContentOwnerChannel",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("stabilize", (IParameter) new Parameter()
        {
          Name = "stabilize",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
      }
    }

    /// <summary>Insert media upload which supports resumable upload.</summary>
    public class InsertMediaUpload : ResumableUpload<Video, Video>
    {
      /// <summary>Data format for the response.</summary>
      /// 
      ///             [default: json]
      [RequestParameter("alt", RequestParameterType.Query)]
      public virtual VideosResource.InsertMediaUpload.AltEnum? Alt { get; set; }

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
      /// write operation will set as well as the properties that the API response will include.
      /// 
      /// Note that not all parts contain properties that can be set when inserting or updating a video. For
      /// example, the statistics object encapsulates statistics that YouTube calculates for a video and does not
      /// contain values that you can set or modify. If the parameter value specifies a part that does not contain
      /// mutable values, that part will still be included in the API response.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>The autoLevels parameter indicates whether YouTube should automatically enhance the video's
      /// lighting and color.</summary>
      [RequestParameter("autoLevels", RequestParameterType.Query)]
      public virtual bool? AutoLevels { get; set; }

      /// <summary>The notifySubscribers parameter indicates whether YouTube should send a notification about the
      /// new video to users who subscribe to the video's channel. A parameter value of True indicates that
      /// subscribers will be notified of newly uploaded videos. However, a channel owner who is uploading many
      /// videos might prefer to set the value to False to avoid sending a notification about each new video to
      /// the channel's subscribers.</summary>
      /// 
      ///             [default: true]
      [RequestParameter("notifySubscribers", RequestParameterType.Query)]
      public virtual bool? NotifySubscribers { get; set; }

      /// <summary>Note: This parameter is intended exclusively for YouTube content partners.
      /// 
      /// The onBehalfOfContentOwner parameter indicates that the request's authorization credentials identify a
      /// YouTube CMS user who is acting on behalf of the content owner specified in the parameter value. This
      /// parameter is intended for YouTube content partners that own and manage many different YouTube channels.
      /// It allows content owners to authenticate once and get access to all their video and channel data,
      /// without having to provide authentication credentials for each individual channel. The CMS account that
      /// the user authenticates with must be linked to the specified YouTube content owner.</summary>
      [RequestParameter("onBehalfOfContentOwner", RequestParameterType.Query)]
      public virtual string OnBehalfOfContentOwner { get; set; }

      /// <summary>This parameter can only be used in a properly authorized request. Note: This parameter is
      /// intended exclusively for YouTube content partners.
      /// 
      /// The onBehalfOfContentOwnerChannel parameter specifies the YouTube channel ID of the channel to which a
      /// video is being added. This parameter is required when a request specifies a value for the
      /// onBehalfOfContentOwner parameter, and it can only be used in conjunction with that parameter. In
      /// addition, the request must be authorized using a CMS account that is linked to the content owner that
      /// the onBehalfOfContentOwner parameter specifies. Finally, the channel that the
      /// onBehalfOfContentOwnerChannel parameter value specifies must be linked to the content owner that the
      /// onBehalfOfContentOwner parameter specifies.
      /// 
      /// This parameter is intended for YouTube content partners that own and manage many different YouTube
      /// channels. It allows content owners to authenticate once and perform actions on behalf of the channel
      /// specified in the parameter value, without having to provide authentication credentials for each separate
      /// channel.</summary>
      [RequestParameter("onBehalfOfContentOwnerChannel", RequestParameterType.Query)]
      public virtual string OnBehalfOfContentOwnerChannel { get; set; }

      /// <summary>The stabilize parameter indicates whether YouTube should adjust the video to remove shaky
      /// camera motions.</summary>
      [RequestParameter("stabilize", RequestParameterType.Query)]
      public virtual bool? Stabilize { get; set; }

      /// <summary>Constructs a new Insert media upload instance.</summary>
      public InsertMediaUpload(IClientService service, Video body, string part, Stream stream, string contentType)
      : base(service, string.Format("/{0}/{1}{2}", (object)"upload", (object)service.BasePath, (object)"videos"), "POST", stream, contentType)
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

    /// <summary>Returns a list of videos that match the API request parameters.</summary>
    public class ListRequest : YouTubeBaseServiceRequest<VideoListResponse>
    {
      /// <summary>Constructs a new List request.</summary>
      public ListRequest(IClientService service, string part)
        : base(service)
      {
        this.Part = part;
        this.InitParameters();
      }

      /// <summary>The part parameter specifies a comma-separated list of one or more video resource properties
      /// that the API response will include.
      /// 
      /// If the parameter identifies a property that contains child properties, the child properties will be
      /// included in the response. For example, in a video resource, the snippet property contains the channelId,
      /// title, description, tags, and categoryId properties. As such, if you set part=snippet, the API response
      /// will contain all of those properties.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>The chart parameter identifies the chart that you want to retrieve.</summary>
      [RequestParameter("chart", RequestParameterType.Query)]
      public virtual VideosResource.ListRequest.ChartEnum? Chart { get; set; }

      /// <summary>The hl parameter instructs the API to retrieve localized resource metadata for a specific
      /// application language that the YouTube website supports. The parameter value must be a language code
      /// included in the list returned by the i18nLanguages.list method.
      /// 
      /// If localized resource details are available in that language, the resource's snippet.localized object
      /// will contain the localized values. However, if localized details are not available, the
      /// snippet.localized object will contain resource details in the resource's default language.</summary>
      [RequestParameter("hl", RequestParameterType.Query)]
      public virtual string Hl { get; set; }

      /// <summary>The id parameter specifies a comma-separated list of the YouTube video ID(s) for the
      /// resource(s) that are being retrieved. In a video resource, the id property specifies the video's
      /// ID.</summary>
      [RequestParameter("id", RequestParameterType.Query)]
      public virtual string Id { get; set; }

      /// <summary>DEPRECATED</summary>
      [RequestParameter("locale", RequestParameterType.Query)]
      public virtual string Locale { get; set; }

      /// <summary>The maxHeight parameter specifies a maximum height of the embedded player. If maxWidth is
      /// provided, maxHeight may not be reached in order to not violate the width request.</summary>
      /// 
      ///             [minimum: 72]
      ///             [maximum: 8192]
      [RequestParameter("maxHeight", RequestParameterType.Query)]
      public virtual long? MaxHeight { get; set; }

      /// <summary>The maxResults parameter specifies the maximum number of items that should be returned in the
      /// result set.
      /// 
      /// Note: This parameter is supported for use in conjunction with the myRating and chart parameters, but it
      /// is not supported for use in conjunction with the id parameter.</summary>
      /// 
      ///              [default: 5]
      ///              [minimum: 1]
      ///              [maximum: 50]
      [RequestParameter("maxResults", RequestParameterType.Query)]
      public virtual long? MaxResults { get; set; }

      /// <summary>The maxWidth parameter specifies a maximum width of the embedded player. If maxHeight is
      /// provided, maxWidth may not be reached in order to not violate the height request.</summary>
      /// 
      ///             [minimum: 72]
      ///             [maximum: 8192]
      [RequestParameter("maxWidth", RequestParameterType.Query)]
      public virtual long? MaxWidth { get; set; }

      /// <summary>Set this parameter's value to like or dislike to instruct the API to only return videos liked
      /// or disliked by the authenticated user.</summary>
      [RequestParameter("myRating", RequestParameterType.Query)]
      public virtual VideosResource.ListRequest.MyRatingEnum? MyRating { get; set; }

      /// <summary>Note: This parameter is intended exclusively for YouTube content partners.
      /// 
      /// The onBehalfOfContentOwner parameter indicates that the request's authorization credentials identify a
      /// YouTube CMS user who is acting on behalf of the content owner specified in the parameter value. This
      /// parameter is intended for YouTube content partners that own and manage many different YouTube channels.
      /// It allows content owners to authenticate once and get access to all their video and channel data,
      /// without having to provide authentication credentials for each individual channel. The CMS account that
      /// the user authenticates with must be linked to the specified YouTube content owner.</summary>
      [RequestParameter("onBehalfOfContentOwner", RequestParameterType.Query)]
      public virtual string OnBehalfOfContentOwner { get; set; }

      /// <summary>The pageToken parameter identifies a specific page in the result set that should be returned.
      /// In an API response, the nextPageToken and prevPageToken properties identify other pages that could be
      /// retrieved.
      /// 
      /// Note: This parameter is supported for use in conjunction with the myRating and chart parameters, but it
      /// is not supported for use in conjunction with the id parameter.</summary>
      [RequestParameter("pageToken", RequestParameterType.Query)]
      public virtual string PageToken { get; set; }

      /// <summary>The regionCode parameter instructs the API to select a video chart available in the specified
      /// region. This parameter can only be used in conjunction with the chart parameter. The parameter value is
      /// an ISO 3166-1 alpha-2 country code.</summary>
      [RequestParameter("regionCode", RequestParameterType.Query)]
      public virtual string RegionCode { get; set; }

      /// <summary>The videoCategoryId parameter identifies the video category for which the chart should be
      /// retrieved. This parameter can only be used in conjunction with the chart parameter. By default, charts
      /// are not restricted to a particular category.</summary>
      /// 
      ///             [default: 0]
      [RequestParameter("videoCategoryId", RequestParameterType.Query)]
      public virtual string VideoCategoryId { get; set; }

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
          return "videos";
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
        this.RequestParameters.Add("chart", (IParameter) new Parameter()
        {
          Name = "chart",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("hl", (IParameter) new Parameter()
        {
          Name = "hl",
          IsRequired = false,
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
        this.RequestParameters.Add("locale", (IParameter) new Parameter()
        {
          Name = "locale",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("maxHeight", (IParameter) new Parameter()
        {
          Name = "maxHeight",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("maxResults", (IParameter) new Parameter()
        {
          Name = "maxResults",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = "5",
          Pattern = (string) null
        });
        this.RequestParameters.Add("maxWidth", (IParameter) new Parameter()
        {
          Name = "maxWidth",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("myRating", (IParameter) new Parameter()
        {
          Name = "myRating",
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
        this.RequestParameters.Add("pageToken", (IParameter) new Parameter()
        {
          Name = "pageToken",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("regionCode", (IParameter) new Parameter()
        {
          Name = "regionCode",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("videoCategoryId", (IParameter) new Parameter()
        {
          Name = "videoCategoryId",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = "0",
          Pattern = (string) null
        });
      }

      /// <summary>The chart parameter identifies the chart that you want to retrieve.</summary>
      public enum ChartEnum
      {
        /// <summary>Return the most popular videos for the specified content region and video
        /// category.</summary>
        [StringValue("mostPopular")] MostPopular,
      }

      /// <summary>Set this parameter's value to like or dislike to instruct the API to only return videos liked
      /// or disliked by the authenticated user.</summary>
      public enum MyRatingEnum
      {
        /// <summary>Returns only videos disliked by the authenticated user.</summary>
        [StringValue("dislike")] Dislike,
        /// <summary>Returns only video liked by the authenticated user.</summary>
        [StringValue("like")] Like,
      }
    }

    /// <summary>Add a like or dislike rating to a video or remove a rating from a video.</summary>
    public class RateRequest : YouTubeBaseServiceRequest<string>
    {
      /// <summary>Constructs a new Rate request.</summary>
      public RateRequest(IClientService service, string id, VideosResource.RateRequest.RatingEnum rating)
        : base(service)
      {
        this.Id = id;
        this.Rating = rating;
        this.InitParameters();
      }

      /// <summary>The id parameter specifies the YouTube video ID of the video that is being rated or having its
      /// rating removed.</summary>
      [RequestParameter("id", RequestParameterType.Query)]
      public virtual string Id { get; private set; }

      /// <summary>Specifies the rating to record.</summary>
      [RequestParameter("rating", RequestParameterType.Query)]
      public virtual VideosResource.RateRequest.RatingEnum Rating { get; private set; }

      /// <summary>Gets the method name.</summary>
      public override string MethodName
      {
        get
        {
          return "rate";
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
          return "videos/rate";
        }
      }

      /// <summary>Initializes Rate parameter list.</summary>
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
        this.RequestParameters.Add("rating", (IParameter) new Parameter()
        {
          Name = "rating",
          IsRequired = true,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
      }

      /// <summary>Specifies the rating to record.</summary>
      public enum RatingEnum
      {
        /// <summary>Records that the authenticated user disliked the video.</summary>
        [StringValue("dislike")] Dislike,
        /// <summary>Records that the authenticated user liked the video.</summary>
        [StringValue("like")] Like,
        /// <summary>Removes any rating that the authenticated user had previously set for the video.</summary>
        [StringValue("none")] None,
      }
    }

    /// <summary>Report abuse for a video.</summary>
    public class ReportAbuseRequest : YouTubeBaseServiceRequest<string>
    {
      /// <summary>Constructs a new ReportAbuse request.</summary>
      public ReportAbuseRequest(IClientService service, VideoAbuseReport body)
        : base(service)
      {
        this.Body = body;
        this.InitParameters();
      }

      /// <summary>Note: This parameter is intended exclusively for YouTube content partners.
      /// 
      /// The onBehalfOfContentOwner parameter indicates that the request's authorization credentials identify a
      /// YouTube CMS user who is acting on behalf of the content owner specified in the parameter value. This
      /// parameter is intended for YouTube content partners that own and manage many different YouTube channels.
      /// It allows content owners to authenticate once and get access to all their video and channel data,
      /// without having to provide authentication credentials for each individual channel. The CMS account that
      /// the user authenticates with must be linked to the specified YouTube content owner.</summary>
      [RequestParameter("onBehalfOfContentOwner", RequestParameterType.Query)]
      public virtual string OnBehalfOfContentOwner { get; set; }

      /// <summary>Gets or sets the body of this request.</summary>
      private VideoAbuseReport Body { get; set; }

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
          return "reportAbuse";
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
          return "videos/reportAbuse";
        }
      }

      /// <summary>Initializes ReportAbuse parameter list.</summary>
      protected override void InitParameters()
      {
        base.InitParameters();
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

    /// <summary>Updates a video's metadata.</summary>
    public class UpdateRequest : YouTubeBaseServiceRequest<Video>
    {
      /// <summary>Constructs a new Update request.</summary>
      public UpdateRequest(IClientService service, Video body, string part)
        : base(service)
      {
        this.Part = part;
        this.Body = body;
        this.InitParameters();
      }

      /// <summary>The part parameter serves two purposes in this operation. It identifies the properties that the
      /// write operation will set as well as the properties that the API response will include.
      /// 
      /// Note that this method will override the existing values for all of the mutable properties that are
      /// contained in any parts that the parameter value specifies. For example, a video's privacy setting is
      /// contained in the status part. As such, if your request is updating a private video, and the request's
      /// part parameter value includes the status part, the video's privacy setting will be updated to whatever
      /// value the request body specifies. If the request body does not specify a value, the existing privacy
      /// setting will be removed and the video will revert to the default privacy setting.
      /// 
      /// In addition, not all parts contain properties that can be set when inserting or updating a video. For
      /// example, the statistics object encapsulates statistics that YouTube calculates for a video and does not
      /// contain values that you can set or modify. If the parameter value specifies a part that does not contain
      /// mutable values, that part will still be included in the API response.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

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

      /// <summary>Gets or sets the body of this request.</summary>
      private Video Body { get; set; }

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
          return "videos";
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
  }
}
