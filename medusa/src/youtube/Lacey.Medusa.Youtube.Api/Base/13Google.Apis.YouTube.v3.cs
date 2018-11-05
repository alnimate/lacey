// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.LiveStreamsResource
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Discovery;
using Lacey.Medusa.Common.Api.Core.Base.Util;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>The "liveStreams" collection of methods.</summary>
  internal class LiveStreamsResource
  {
    private const string Resource = "liveStreams";
    /// <summary>The service which this resource belongs to.</summary>
    private readonly IClientService service;

    /// <summary>Constructs a new resource.</summary>
    public LiveStreamsResource(IClientService service)
    {
      this.service = service;
    }

    /// <summary>Deletes a video stream.</summary>
    /// <param name="id">The id parameter specifies the YouTube live stream ID for the resource that is being
    /// deleted.</param>
    public virtual LiveStreamsResource.DeleteRequest Delete(string id)
    {
      return new LiveStreamsResource.DeleteRequest(this.service, id);
    }

    /// <summary>Creates a video stream. The stream enables you to send your video to YouTube, which can then
    /// broadcast the video to your audience.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter serves two purposes in this operation. It identifies the properties that the
    /// write operation will set as well as the properties that the API response will include.
    /// 
    /// The part properties that you can include in the parameter value are id, snippet, cdn, and status.</param>
    public virtual LiveStreamsResource.InsertRequest Insert(LiveStream body, string part)
    {
      return new LiveStreamsResource.InsertRequest(this.service, body, part);
    }

    /// <summary>Returns a list of video streams that match the API request parameters.</summary>
    /// <param name="part">The part parameter specifies a comma-separated list of one or more liveStream resource properties
    /// that the API response will include. The part names that you can include in the parameter value are id, snippet, cdn,
    /// and status.</param>
    public virtual LiveStreamsResource.ListRequest List(string part)
    {
      return new LiveStreamsResource.ListRequest(this.service, part);
    }

    /// <summary>Updates a video stream. If the properties that you want to change cannot be updated, then you need
    /// to create a new stream with the proper settings.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter serves two purposes in this operation. It identifies the properties that the
    /// write operation will set as well as the properties that the API response will include.
    /// 
    /// The part properties that you can include in the parameter value are id, snippet, cdn, and status.
    /// 
    /// Note that this method will override the existing values for all of the mutable properties that are contained in any
    /// parts that the parameter value specifies. If the request body does not specify a value for a mutable property, the
    /// existing value for that property will be removed.</param>
    public virtual LiveStreamsResource.UpdateRequest Update(LiveStream body, string part)
    {
      return new LiveStreamsResource.UpdateRequest(this.service, body, part);
    }

    /// <summary>Deletes a video stream.</summary>
    internal class DeleteRequest : YouTubeBaseServiceRequest<string>
    {
      /// <summary>Constructs a new Delete request.</summary>
      public DeleteRequest(IClientService service, string id)
        : base(service)
      {
        this.Id = id;
        this.InitParameters();
      }

      /// <summary>The id parameter specifies the YouTube live stream ID for the resource that is being
      /// deleted.</summary>
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
          return "liveStreams";
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
        this.RequestParameters.Add("onBehalfOfContentOwnerChannel", (IParameter) new Parameter()
        {
          Name = "onBehalfOfContentOwnerChannel",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
      }
    }

    /// <summary>Creates a video stream. The stream enables you to send your video to YouTube, which can then
    /// broadcast the video to your audience.</summary>
    internal class InsertRequest : YouTubeBaseServiceRequest<LiveStream>
    {
      /// <summary>Constructs a new Insert request.</summary>
      public InsertRequest(IClientService service, LiveStream body, string part)
        : base(service)
      {
        this.Part = part;
        this.Body = body;
        this.InitParameters();
      }

      /// <summary>The part parameter serves two purposes in this operation. It identifies the properties that the
      /// write operation will set as well as the properties that the API response will include.
      /// 
      /// The part properties that you can include in the parameter value are id, snippet, cdn, and
      /// status.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

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

      /// <summary>Gets or sets the body of this request.</summary>
      private LiveStream Body { get; set; }

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
          return "liveStreams";
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
      }
    }

    /// <summary>Returns a list of video streams that match the API request parameters.</summary>
    internal class ListRequest : YouTubeBaseServiceRequest<LiveStreamListResponse>
    {
      /// <summary>Constructs a new List request.</summary>
      public ListRequest(IClientService service, string part)
        : base(service)
      {
        this.Part = part;
        this.InitParameters();
      }

      /// <summary>The part parameter specifies a comma-separated list of one or more liveStream resource
      /// properties that the API response will include. The part names that you can include in the parameter
      /// value are id, snippet, cdn, and status.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>The id parameter specifies a comma-separated list of YouTube stream IDs that identify the
      /// streams being retrieved. In a liveStream resource, the id property specifies the stream's ID.</summary>
      [RequestParameter("id", RequestParameterType.Query)]
      public virtual string Id { get; set; }

      /// <summary>The maxResults parameter specifies the maximum number of items that should be returned in the
      /// result set.</summary>
      /// 
      ///             [default: 5]
      ///             [minimum: 0]
      ///             [maximum: 50]
      [RequestParameter("maxResults", RequestParameterType.Query)]
      public virtual long? MaxResults { get; set; }

      /// <summary>The mine parameter can be used to instruct the API to only return streams owned by the
      /// authenticated user. Set the parameter value to true to only retrieve your own streams.</summary>
      [RequestParameter("mine", RequestParameterType.Query)]
      public virtual bool? Mine { get; set; }

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

      /// <summary>The pageToken parameter identifies a specific page in the result set that should be returned.
      /// In an API response, the nextPageToken and prevPageToken properties identify other pages that could be
      /// retrieved.</summary>
      [RequestParameter("pageToken", RequestParameterType.Query)]
      public virtual string PageToken { get; set; }

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
          return "liveStreams";
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
        this.RequestParameters.Add("id", (IParameter) new Parameter()
        {
          Name = "id",
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
        this.RequestParameters.Add("mine", (IParameter) new Parameter()
        {
          Name = "mine",
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
        this.RequestParameters.Add("onBehalfOfContentOwnerChannel", (IParameter) new Parameter()
        {
          Name = "onBehalfOfContentOwnerChannel",
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
      }
    }

    /// <summary>Updates a video stream. If the properties that you want to change cannot be updated, then you need
    /// to create a new stream with the proper settings.</summary>
    internal class UpdateRequest : YouTubeBaseServiceRequest<LiveStream>
    {
      /// <summary>Constructs a new Update request.</summary>
      public UpdateRequest(IClientService service, LiveStream body, string part)
        : base(service)
      {
        this.Part = part;
        this.Body = body;
        this.InitParameters();
      }

      /// <summary>The part parameter serves two purposes in this operation. It identifies the properties that the
      /// write operation will set as well as the properties that the API response will include.
      /// 
      /// The part properties that you can include in the parameter value are id, snippet, cdn, and status.
      /// 
      /// Note that this method will override the existing values for all of the mutable properties that are
      /// contained in any parts that the parameter value specifies. If the request body does not specify a value
      /// for a mutable property, the existing value for that property will be removed.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

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

      /// <summary>Gets or sets the body of this request.</summary>
      private LiveStream Body { get; set; }

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
          return "liveStreams";
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
        this.RequestParameters.Add("onBehalfOfContentOwnerChannel", (IParameter) new Parameter()
        {
          Name = "onBehalfOfContentOwnerChannel",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
      }
    }
  }
}
