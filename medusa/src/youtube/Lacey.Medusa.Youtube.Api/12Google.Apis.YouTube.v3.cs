// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.LiveBroadcastsResource
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System;
using Google.Apis.Discovery;
using Google.Apis.Services;
using Google.Apis.Util;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>The "liveBroadcasts" collection of methods.</summary>
  public class LiveBroadcastsResource
  {
    private const string Resource = "liveBroadcasts";
    /// <summary>The service which this resource belongs to.</summary>
    private readonly IClientService service;

    /// <summary>Constructs a new resource.</summary>
    public LiveBroadcastsResource(IClientService service)
    {
      this.service = service;
    }

    /// <summary>Binds a YouTube broadcast to a stream or removes an existing binding between a broadcast and a
    /// stream. A broadcast can only be bound to one video stream, though a video stream may be bound to more than
    /// one broadcast.</summary>
    /// <param name="id">The id parameter specifies the unique ID of the broadcast that is being bound to a video
    /// stream.</param>
    /// <param name="part">The part parameter specifies a comma-separated list of one or more
    /// liveBroadcast resource properties that the API response will include. The part names that you can include in the
    /// parameter value are id, snippet, contentDetails, and status.</param>
    public virtual LiveBroadcastsResource.BindRequest Bind(string id, string part)
    {
      return new LiveBroadcastsResource.BindRequest(this.service, id, part);
    }

    /// <summary>Controls the settings for a slate that can be displayed in the broadcast stream.</summary>
    /// <param name="id">The id parameter specifies the YouTube live broadcast ID that uniquely identifies the broadcast in
    /// which the slate is being updated.</param>
    /// <param name="part">The part parameter specifies a comma-separated
    /// list of one or more liveBroadcast resource properties that the API response will include. The part names that you
    /// can include in the parameter value are id, snippet, contentDetails, and status.</param>
    public virtual LiveBroadcastsResource.ControlRequest Control(string id, string part)
    {
      return new LiveBroadcastsResource.ControlRequest(this.service, id, part);
    }

    /// <summary>Deletes a broadcast.</summary>
    /// <param name="id">The id parameter specifies the YouTube live broadcast ID for the resource that is being
    /// deleted.</param>
    public virtual LiveBroadcastsResource.DeleteRequest Delete(string id)
    {
      return new LiveBroadcastsResource.DeleteRequest(this.service, id);
    }

    /// <summary>Creates a broadcast.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter serves two purposes in this operation. It identifies the properties that the
    /// write operation will set as well as the properties that the API response will include.
    /// 
    /// The part properties that you can include in the parameter value are id, snippet, contentDetails, and
    /// status.</param>
    public virtual LiveBroadcastsResource.InsertRequest Insert(LiveBroadcast body, string part)
    {
      return new LiveBroadcastsResource.InsertRequest(this.service, body, part);
    }

    /// <summary>Returns a list of YouTube broadcasts that match the API request parameters.</summary>
    /// <param name="part">The part parameter specifies a comma-separated list of one or more liveBroadcast resource
    /// properties that the API response will include. The part names that you can include in the parameter value are id,
    /// snippet, contentDetails, and status.</param>
    public virtual LiveBroadcastsResource.ListRequest List(string part)
    {
      return new LiveBroadcastsResource.ListRequest(this.service, part);
    }

    /// <summary>Changes the status of a YouTube live broadcast and initiates any processes associated with the new
    /// status. For example, when you transition a broadcast's status to testing, YouTube starts to transmit video
    /// to that broadcast's monitor stream. Before calling this method, you should confirm that the value of the
    /// status.streamStatus property for the stream bound to your broadcast is active.</summary>
    /// <param name="broadcastStatus">The broadcastStatus parameter identifies the state to which the broadcast is changing.
    /// Note that to transition a broadcast to either the testing or live state, the status.streamStatus must be active for
    /// the stream that the broadcast is bound to.</param>
    /// <param name="id">The id parameter specifies the unique ID
    /// of the broadcast that is transitioning to another status.</param>
    /// <param name="part">The part parameter
    /// specifies a comma-separated list of one or more liveBroadcast resource properties that the API response will
    /// include. The part names that you can include in the parameter value are id, snippet, contentDetails, and
    /// status.</param>
    public virtual LiveBroadcastsResource.TransitionRequest Transition(LiveBroadcastsResource.TransitionRequest.BroadcastStatusEnum broadcastStatus, string id, string part)
    {
      return new LiveBroadcastsResource.TransitionRequest(this.service, broadcastStatus, id, part);
    }

    /// <summary>Updates a broadcast. For example, you could modify the broadcast settings defined in the
    /// liveBroadcast resource's contentDetails object.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter serves two purposes in this operation. It identifies the properties that the
    /// write operation will set as well as the properties that the API response will include.
    /// 
    /// The part properties that you can include in the parameter value are id, snippet, contentDetails, and status.
    /// 
    /// Note that this method will override the existing values for all of the mutable properties that are contained in any
    /// parts that the parameter value specifies. For example, a broadcast's privacy status is defined in the status part.
    /// As such, if your request is updating a private or unlisted broadcast, and the request's part parameter value
    /// includes the status part, the broadcast's privacy setting will be updated to whatever value the request body
    /// specifies. If the request body does not specify a value, the existing privacy setting will be removed and the
    /// broadcast will revert to the default privacy setting.</param>
    public virtual LiveBroadcastsResource.UpdateRequest Update(LiveBroadcast body, string part)
    {
      return new LiveBroadcastsResource.UpdateRequest(this.service, body, part);
    }

    /// <summary>Binds a YouTube broadcast to a stream or removes an existing binding between a broadcast and a
    /// stream. A broadcast can only be bound to one video stream, though a video stream may be bound to more than
    /// one broadcast.</summary>
    public class BindRequest : YouTubeBaseServiceRequest<LiveBroadcast>
    {
      /// <summary>Constructs a new Bind request.</summary>
      public BindRequest(IClientService service, string id, string part)
        : base(service)
      {
        this.Id = id;
        this.Part = part;
        this.InitParameters();
      }

      /// <summary>The id parameter specifies the unique ID of the broadcast that is being bound to a video
      /// stream.</summary>
      [RequestParameter("id", RequestParameterType.Query)]
      public virtual string Id { get; private set; }

      /// <summary>The part parameter specifies a comma-separated list of one or more liveBroadcast resource
      /// properties that the API response will include. The part names that you can include in the parameter
      /// value are id, snippet, contentDetails, and status.</summary>
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

      /// <summary>The streamId parameter specifies the unique ID of the video stream that is being bound to a
      /// broadcast. If this parameter is omitted, the API will remove any existing binding between the broadcast
      /// and a video stream.</summary>
      [RequestParameter("streamId", RequestParameterType.Query)]
      public virtual string StreamId { get; set; }

      /// <summary>Gets the method name.</summary>
      public override string MethodName
      {
        get
        {
          return "bind";
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
          return "liveBroadcasts/bind";
        }
      }

      /// <summary>Initializes Bind parameter list.</summary>
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
        this.RequestParameters.Add("streamId", (IParameter) new Parameter()
        {
          Name = "streamId",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
      }
    }

    /// <summary>Controls the settings for a slate that can be displayed in the broadcast stream.</summary>
    public class ControlRequest : YouTubeBaseServiceRequest<LiveBroadcast>
    {
      /// <summary>Constructs a new Control request.</summary>
      public ControlRequest(IClientService service, string id, string part)
        : base(service)
      {
        this.Id = id;
        this.Part = part;
        this.InitParameters();
      }

      /// <summary>The id parameter specifies the YouTube live broadcast ID that uniquely identifies the broadcast
      /// in which the slate is being updated.</summary>
      [RequestParameter("id", RequestParameterType.Query)]
      public virtual string Id { get; private set; }

      /// <summary>The part parameter specifies a comma-separated list of one or more liveBroadcast resource
      /// properties that the API response will include. The part names that you can include in the parameter
      /// value are id, snippet, contentDetails, and status.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>The displaySlate parameter specifies whether the slate is being enabled or disabled.</summary>
      [RequestParameter("displaySlate", RequestParameterType.Query)]
      public virtual bool? DisplaySlate { get; set; }

      /// <summary>The offsetTimeMs parameter specifies a positive time offset when the specified slate change
      /// will occur. The value is measured in milliseconds from the beginning of the broadcast's monitor stream,
      /// which is the time that the testing phase for the broadcast began. Even though it is specified in
      /// milliseconds, the value is actually an approximation, and YouTube completes the requested action as
      /// closely as possible to that time.
      /// 
      /// If you do not specify a value for this parameter, then YouTube performs the action as soon as possible.
      /// See the Getting started guide for more details.
      /// 
      /// Important: You should only specify a value for this parameter if your broadcast stream is
      /// delayed.</summary>
      [RequestParameter("offsetTimeMs", RequestParameterType.Query)]
      public virtual ulong? OffsetTimeMs { get; set; }

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

      /// <summary>The walltime parameter specifies the wall clock time at which the specified slate change will
      /// occur. The value is specified in ISO 8601 (YYYY-MM-DDThh:mm:ss.sssZ) format.</summary>
      [RequestParameter("walltime", RequestParameterType.Query)]
      public virtual DateTime? Walltime { get; set; }

      /// <summary>Gets the method name.</summary>
      public override string MethodName
      {
        get
        {
          return "control";
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
          return "liveBroadcasts/control";
        }
      }

      /// <summary>Initializes Control parameter list.</summary>
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
        this.RequestParameters.Add("part", (IParameter) new Parameter()
        {
          Name = "part",
          IsRequired = true,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("displaySlate", (IParameter) new Parameter()
        {
          Name = "displaySlate",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("offsetTimeMs", (IParameter) new Parameter()
        {
          Name = "offsetTimeMs",
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
        this.RequestParameters.Add("walltime", (IParameter) new Parameter()
        {
          Name = "walltime",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
      }
    }

    /// <summary>Deletes a broadcast.</summary>
    public class DeleteRequest : YouTubeBaseServiceRequest<string>
    {
      /// <summary>Constructs a new Delete request.</summary>
      public DeleteRequest(IClientService service, string id)
        : base(service)
      {
        this.Id = id;
        this.InitParameters();
      }

      /// <summary>The id parameter specifies the YouTube live broadcast ID for the resource that is being
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
          return "liveBroadcasts";
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

    /// <summary>Creates a broadcast.</summary>
    public class InsertRequest : YouTubeBaseServiceRequest<LiveBroadcast>
    {
      /// <summary>Constructs a new Insert request.</summary>
      public InsertRequest(IClientService service, LiveBroadcast body, string part)
        : base(service)
      {
        this.Part = part;
        this.Body = body;
        this.InitParameters();
      }

      /// <summary>The part parameter serves two purposes in this operation. It identifies the properties that the
      /// write operation will set as well as the properties that the API response will include.
      /// 
      /// The part properties that you can include in the parameter value are id, snippet, contentDetails, and
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
      private LiveBroadcast Body { get; set; }

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
          return "liveBroadcasts";
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

    /// <summary>Returns a list of YouTube broadcasts that match the API request parameters.</summary>
    public class ListRequest : YouTubeBaseServiceRequest<LiveBroadcastListResponse>
    {
      /// <summary>Constructs a new List request.</summary>
      public ListRequest(IClientService service, string part)
        : base(service)
      {
        this.Part = part;
        this.InitParameters();
      }

      /// <summary>The part parameter specifies a comma-separated list of one or more liveBroadcast resource
      /// properties that the API response will include. The part names that you can include in the parameter
      /// value are id, snippet, contentDetails, and status.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>The broadcastStatus parameter filters the API response to only include broadcasts with the
      /// specified status.</summary>
      [RequestParameter("broadcastStatus", RequestParameterType.Query)]
      public virtual LiveBroadcastsResource.ListRequest.BroadcastStatusEnum? BroadcastStatus { get; set; }

      /// <summary>The broadcastType parameter filters the API response to only include broadcasts with the
      /// specified type. This is only compatible with the mine filter for now.</summary>
      /// 
      ///             [default: BROADCAST_TYPE_FILTER_EVENT]
      [RequestParameter("broadcastType", RequestParameterType.Query)]
      public virtual LiveBroadcastsResource.ListRequest.BroadcastTypeEnum? BroadcastType { get; set; }

      /// <summary>The id parameter specifies a comma-separated list of YouTube broadcast IDs that identify the
      /// broadcasts being retrieved. In a liveBroadcast resource, the id property specifies the broadcast's
      /// ID.</summary>
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

      /// <summary>The mine parameter can be used to instruct the API to only return broadcasts owned by the
      /// authenticated user. Set the parameter value to true to only retrieve your own broadcasts.</summary>
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
          return "liveBroadcasts";
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
        this.RequestParameters.Add("broadcastStatus", (IParameter) new Parameter()
        {
          Name = "broadcastStatus",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("broadcastType", (IParameter) new Parameter()
        {
          Name = "broadcastType",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = "BROADCAST_TYPE_FILTER_EVENT",
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

      /// <summary>The broadcastStatus parameter filters the API response to only include broadcasts with the
      /// specified status.</summary>
      public enum BroadcastStatusEnum
      {
        /// <summary>Return current live broadcasts.</summary>
        [StringValue("active")] Active,
        /// <summary>Return all broadcasts.</summary>
        [StringValue("all")] All,
        /// <summary>Return broadcasts that have already ended.</summary>
        [StringValue("completed")] Completed,
        /// <summary>Return broadcasts that have not yet started.</summary>
        [StringValue("upcoming")] Upcoming,
      }

      /// <summary>The broadcastType parameter filters the API response to only include broadcasts with the
      /// specified type. This is only compatible with the mine filter for now.</summary>
      public enum BroadcastTypeEnum
      {
        /// <summary>Return all broadcasts.</summary>
        [StringValue("all")] All,
        /// <summary>Return only scheduled event broadcasts.</summary>
        [StringValue("event")] Event__,
        /// <summary>Return only persistent broadcasts.</summary>
        [StringValue("persistent")] Persistent,
      }
    }

    /// <summary>Changes the status of a YouTube live broadcast and initiates any processes associated with the new
    /// status. For example, when you transition a broadcast's status to testing, YouTube starts to transmit video
    /// to that broadcast's monitor stream. Before calling this method, you should confirm that the value of the
    /// status.streamStatus property for the stream bound to your broadcast is active.</summary>
    public class TransitionRequest : YouTubeBaseServiceRequest<LiveBroadcast>
    {
      /// <summary>Constructs a new Transition request.</summary>
      public TransitionRequest(IClientService service, LiveBroadcastsResource.TransitionRequest.BroadcastStatusEnum broadcastStatus, string id, string part)
        : base(service)
      {
        this.BroadcastStatus = broadcastStatus;
        this.Id = id;
        this.Part = part;
        this.InitParameters();
      }

      /// <summary>The broadcastStatus parameter identifies the state to which the broadcast is changing. Note
      /// that to transition a broadcast to either the testing or live state, the status.streamStatus must be
      /// active for the stream that the broadcast is bound to.</summary>
      [RequestParameter("broadcastStatus", RequestParameterType.Query)]
      public virtual LiveBroadcastsResource.TransitionRequest.BroadcastStatusEnum BroadcastStatus { get; private set; }

      /// <summary>The id parameter specifies the unique ID of the broadcast that is transitioning to another
      /// status.</summary>
      [RequestParameter("id", RequestParameterType.Query)]
      public virtual string Id { get; private set; }

      /// <summary>The part parameter specifies a comma-separated list of one or more liveBroadcast resource
      /// properties that the API response will include. The part names that you can include in the parameter
      /// value are id, snippet, contentDetails, and status.</summary>
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

      /// <summary>Gets the method name.</summary>
      public override string MethodName
      {
        get
        {
          return "transition";
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
          return "liveBroadcasts/transition";
        }
      }

      /// <summary>Initializes Transition parameter list.</summary>
      protected override void InitParameters()
      {
        base.InitParameters();
        this.RequestParameters.Add("broadcastStatus", (IParameter) new Parameter()
        {
          Name = "broadcastStatus",
          IsRequired = true,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("id", (IParameter) new Parameter()
        {
          Name = "id",
          IsRequired = true,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
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

      /// <summary>The broadcastStatus parameter identifies the state to which the broadcast is changing. Note
      /// that to transition a broadcast to either the testing or live state, the status.streamStatus must be
      /// active for the stream that the broadcast is bound to.</summary>
      public enum BroadcastStatusEnum
      {
        /// <summary>The broadcast is over. YouTube stops transmitting video.</summary>
        [StringValue("complete")] Complete,
        /// <summary>The broadcast is visible to its audience. YouTube transmits video to the broadcast's
        /// monitor stream and its broadcast stream.</summary>
        [StringValue("live")] Live,
        /// <summary>Start testing the broadcast. YouTube transmits video to the broadcast's monitor stream.
        /// Note that you can only transition a broadcast to the testing state if its
        /// contentDetails.monitorStream.enableMonitorStream property is set to true.</summary>
        [StringValue("testing")] Testing,
      }
    }

    /// <summary>Updates a broadcast. For example, you could modify the broadcast settings defined in the
    /// liveBroadcast resource's contentDetails object.</summary>
    public class UpdateRequest : YouTubeBaseServiceRequest<LiveBroadcast>
    {
      /// <summary>Constructs a new Update request.</summary>
      public UpdateRequest(IClientService service, LiveBroadcast body, string part)
        : base(service)
      {
        this.Part = part;
        this.Body = body;
        this.InitParameters();
      }

      /// <summary>The part parameter serves two purposes in this operation. It identifies the properties that the
      /// write operation will set as well as the properties that the API response will include.
      /// 
      /// The part properties that you can include in the parameter value are id, snippet, contentDetails, and
      /// status.
      /// 
      /// Note that this method will override the existing values for all of the mutable properties that are
      /// contained in any parts that the parameter value specifies. For example, a broadcast's privacy status is
      /// defined in the status part. As such, if your request is updating a private or unlisted broadcast, and
      /// the request's part parameter value includes the status part, the broadcast's privacy setting will be
      /// updated to whatever value the request body specifies. If the request body does not specify a value, the
      /// existing privacy setting will be removed and the broadcast will revert to the default privacy
      /// setting.</summary>
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
      private LiveBroadcast Body { get; set; }

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
          return "liveBroadcasts";
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
