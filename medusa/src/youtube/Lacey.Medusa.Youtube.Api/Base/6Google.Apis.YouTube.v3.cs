// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.ChannelsResource
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Discovery;
using Google.Apis.Services;
using Google.Apis.Util;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>The "channels" collection of methods.</summary>
  public class ChannelsResource
  {
    private const string Resource = "channels";
    /// <summary>The service which this resource belongs to.</summary>
    private readonly IClientService service;

    /// <summary>Constructs a new resource.</summary>
    public ChannelsResource(IClientService service)
    {
      this.service = service;
    }

    /// <summary>Returns a collection of zero or more channel resources that match the request criteria.</summary>
    /// <param name="part">The part parameter specifies a comma-separated list of one or more channel resource properties
    /// that the API response will include.
    /// 
    /// If the parameter identifies a property that contains child properties, the child properties will be included in the
    /// response. For example, in a channel resource, the contentDetails property contains other properties, such as the
    /// uploads properties. As such, if you set part=contentDetails, the API response will also contain all of those nested
    /// properties.</param>
    public virtual ChannelsResource.ListRequest List(string part)
    {
      return new ChannelsResource.ListRequest(this.service, part);
    }

    /// <summary>Updates a channel's metadata. Note that this method currently only supports updates to the channel
    /// resource's brandingSettings and invideoPromotion objects and their child properties.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter serves two purposes in this operation. It identifies the properties that the
    /// write operation will set as well as the properties that the API response will include.
    /// 
    /// The API currently only allows the parameter value to be set to either brandingSettings or invideoPromotion. (You
    /// cannot update both of those parts with a single request.)
    /// 
    /// Note that this method overrides the existing values for all of the mutable properties that are contained in any
    /// parts that the parameter value specifies.</param>
    public virtual ChannelsResource.UpdateRequest Update(Channel body, string part)
    {
      return new ChannelsResource.UpdateRequest(this.service, body, part);
    }

    /// <summary>Returns a collection of zero or more channel resources that match the request criteria.</summary>
    public class ListRequest : YouTubeBaseServiceRequest<ChannelListResponse>
    {
      /// <summary>Constructs a new List request.</summary>
      public ListRequest(IClientService service, string part)
        : base(service)
      {
        this.Part = part;
        this.InitParameters();
      }

      /// <summary>The part parameter specifies a comma-separated list of one or more channel resource properties
      /// that the API response will include.
      /// 
      /// If the parameter identifies a property that contains child properties, the child properties will be
      /// included in the response. For example, in a channel resource, the contentDetails property contains other
      /// properties, such as the uploads properties. As such, if you set part=contentDetails, the API response
      /// will also contain all of those nested properties.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>The categoryId parameter specifies a YouTube guide category, thereby requesting YouTube
      /// channels associated with that category.</summary>
      [RequestParameter("categoryId", RequestParameterType.Query)]
      public virtual string CategoryId { get; set; }

      /// <summary>The forUsername parameter specifies a YouTube username, thereby requesting the channel
      /// associated with that username.</summary>
      [RequestParameter("forUsername", RequestParameterType.Query)]
      public virtual string ForUsername { get; set; }

      /// <summary>The hl parameter should be used for filter out the properties that are not in the given
      /// language. Used for the brandingSettings part.</summary>
      [RequestParameter("hl", RequestParameterType.Query)]
      public virtual string Hl { get; set; }

      /// <summary>The id parameter specifies a comma-separated list of the YouTube channel ID(s) for the
      /// resource(s) that are being retrieved. In a channel resource, the id property specifies the channel's
      /// YouTube channel ID.</summary>
      [RequestParameter("id", RequestParameterType.Query)]
      public virtual string Id { get; set; }

      /// <summary>Note: This parameter is intended exclusively for YouTube content partners.
      /// 
      /// Set this parameter's value to true to instruct the API to only return channels managed by the content
      /// owner that the onBehalfOfContentOwner parameter specifies. The user must be authenticated as a CMS
      /// account linked to the specified content owner and onBehalfOfContentOwner must be provided.</summary>
      [RequestParameter("managedByMe", RequestParameterType.Query)]
      public virtual bool? ManagedByMe { get; set; }

      /// <summary>The maxResults parameter specifies the maximum number of items that should be returned in the
      /// result set.</summary>
      /// 
      ///             [default: 5]
      ///             [minimum: 0]
      ///             [maximum: 50]
      [RequestParameter("maxResults", RequestParameterType.Query)]
      public virtual long? MaxResults { get; set; }

      /// <summary>Set this parameter's value to true to instruct the API to only return channels owned by the
      /// authenticated user.</summary>
      [RequestParameter("mine", RequestParameterType.Query)]
      public virtual bool? Mine { get; set; }

      /// <summary>Use the subscriptions.list method and its mySubscribers parameter to retrieve a list of
      /// subscribers to the authenticated user's channel.</summary>
      [RequestParameter("mySubscribers", RequestParameterType.Query)]
      public virtual bool? MySubscribers { get; set; }

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
          return "channels";
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
        this.RequestParameters.Add("categoryId", (IParameter) new Parameter()
        {
          Name = "categoryId",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("forUsername", (IParameter) new Parameter()
        {
          Name = "forUsername",
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
        this.RequestParameters.Add("managedByMe", (IParameter) new Parameter()
        {
          Name = "managedByMe",
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
        this.RequestParameters.Add("mySubscribers", (IParameter) new Parameter()
        {
          Name = "mySubscribers",
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
      }
    }

    /// <summary>Updates a channel's metadata. Note that this method currently only supports updates to the channel
    /// resource's brandingSettings and invideoPromotion objects and their child properties.</summary>
    public class UpdateRequest : YouTubeBaseServiceRequest<Channel>
    {
      /// <summary>Constructs a new Update request.</summary>
      public UpdateRequest(IClientService service, Channel body, string part)
        : base(service)
      {
        this.Part = part;
        this.Body = body;
        this.InitParameters();
      }

      /// <summary>The part parameter serves two purposes in this operation. It identifies the properties that the
      /// write operation will set as well as the properties that the API response will include.
      /// 
      /// The API currently only allows the parameter value to be set to either brandingSettings or
      /// invideoPromotion. (You cannot update both of those parts with a single request.)
      /// 
      /// Note that this method overrides the existing values for all of the mutable properties that are contained
      /// in any parts that the parameter value specifies.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>The onBehalfOfContentOwner parameter indicates that the authenticated user is acting on behalf
      /// of the content owner specified in the parameter value. This parameter is intended for YouTube content
      /// partners that own and manage many different YouTube channels. It allows content owners to authenticate
      /// once and get access to all their video and channel data, without having to provide authentication
      /// credentials for each individual channel. The actual CMS account that the user authenticates with needs
      /// to be linked to the specified YouTube content owner.</summary>
      [RequestParameter("onBehalfOfContentOwner", RequestParameterType.Query)]
      public virtual string OnBehalfOfContentOwner { get; set; }

      /// <summary>Gets or sets the body of this request.</summary>
      private Channel Body { get; set; }

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
          return "channels";
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
