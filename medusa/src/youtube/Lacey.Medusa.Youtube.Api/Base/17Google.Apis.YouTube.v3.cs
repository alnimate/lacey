// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.SubscriptionsResource
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Discovery;
using Lacey.Medusa.Common.Api.Core.Base.Util;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>The "subscriptions" collection of methods.</summary>
  public class SubscriptionsResource
  {
    private const string Resource = "subscriptions";
    /// <summary>The service which this resource belongs to.</summary>
    private readonly IClientService service;

    /// <summary>Constructs a new resource.</summary>
    public SubscriptionsResource(IClientService service)
    {
      this.service = service;
    }

    /// <summary>Deletes a subscription.</summary>
    /// <param name="id">The id parameter specifies the YouTube subscription ID for the resource that is being deleted. In a
    /// subscription resource, the id property specifies the YouTube subscription ID.</param>
    public virtual SubscriptionsResource.DeleteRequest Delete(string id)
    {
      return new SubscriptionsResource.DeleteRequest(this.service, id);
    }

    /// <summary>Adds a subscription for the authenticated user's channel.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter serves two purposes in this operation. It identifies the properties that the
    /// write operation will set as well as the properties that the API response will include.</param>
    public virtual SubscriptionsResource.InsertRequest Insert(Subscription body, string part)
    {
      return new SubscriptionsResource.InsertRequest(this.service, body, part);
    }

    /// <summary>Returns subscription resources that match the API request criteria.</summary>
    /// <param name="part">The part parameter specifies a comma-separated list of one or more subscription resource
    /// properties that the API response will include.
    /// 
    /// If the parameter identifies a property that contains child properties, the child properties will be included in the
    /// response. For example, in a subscription resource, the snippet property contains other properties, such as a display
    /// title for the subscription. If you set part=snippet, the API response will also contain all of those nested
    /// properties.</param>
    public virtual SubscriptionsResource.ListRequest List(string part)
    {
      return new SubscriptionsResource.ListRequest(this.service, part);
    }

    /// <summary>Deletes a subscription.</summary>
    public class DeleteRequest : YouTubeBaseServiceRequest<string>
    {
      /// <summary>Constructs a new Delete request.</summary>
      public DeleteRequest(IClientService service, string id)
        : base(service)
      {
        this.Id = id;
        this.InitParameters();
      }

      /// <summary>The id parameter specifies the YouTube subscription ID for the resource that is being deleted.
      /// In a subscription resource, the id property specifies the YouTube subscription ID.</summary>
      [RequestParameter("id", RequestParameterType.Query)]
      public virtual string Id { get; private set; }

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
          return "subscriptions";
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
      }
    }

    /// <summary>Adds a subscription for the authenticated user's channel.</summary>
    public class InsertRequest : YouTubeBaseServiceRequest<Subscription>
    {
      /// <summary>Constructs a new Insert request.</summary>
      public InsertRequest(IClientService service, Subscription body, string part)
        : base(service)
      {
        this.Part = part;
        this.Body = body;
        this.InitParameters();
      }

      /// <summary>The part parameter serves two purposes in this operation. It identifies the properties that the
      /// write operation will set as well as the properties that the API response will include.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>Gets or sets the body of this request.</summary>
      private Subscription Body { get; set; }

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
          return "subscriptions";
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
      }
    }

    /// <summary>Returns subscription resources that match the API request criteria.</summary>
    public class ListRequest : YouTubeBaseServiceRequest<SubscriptionListResponse>
    {
      /// <summary>Constructs a new List request.</summary>
      public ListRequest(IClientService service, string part)
        : base(service)
      {
        this.Part = part;
        this.InitParameters();
      }

      /// <summary>The part parameter specifies a comma-separated list of one or more subscription resource
      /// properties that the API response will include.
      /// 
      /// If the parameter identifies a property that contains child properties, the child properties will be
      /// included in the response. For example, in a subscription resource, the snippet property contains other
      /// properties, such as a display title for the subscription. If you set part=snippet, the API response will
      /// also contain all of those nested properties.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>The channelId parameter specifies a YouTube channel ID. The API will only return that channel's
      /// subscriptions.</summary>
      [RequestParameter("channelId", RequestParameterType.Query)]
      public virtual string ChannelId { get; set; }

      /// <summary>The forChannelId parameter specifies a comma-separated list of channel IDs. The API response
      /// will then only contain subscriptions matching those channels.</summary>
      [RequestParameter("forChannelId", RequestParameterType.Query)]
      public virtual string ForChannelId { get; set; }

      /// <summary>The id parameter specifies a comma-separated list of the YouTube subscription ID(s) for the
      /// resource(s) that are being retrieved. In a subscription resource, the id property specifies the YouTube
      /// subscription ID.</summary>
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

      /// <summary>Set this parameter's value to true to retrieve a feed of the authenticated user's
      /// subscriptions.</summary>
      [RequestParameter("mine", RequestParameterType.Query)]
      public virtual bool? Mine { get; set; }

      /// <summary>Set this parameter's value to true to retrieve a feed of the subscribers of the authenticated
      /// user in reverse chronological order (newest first).</summary>
      [RequestParameter("myRecentSubscribers", RequestParameterType.Query)]
      public virtual bool? MyRecentSubscribers { get; set; }

      /// <summary>Set this parameter's value to true to retrieve a feed of the subscribers of the authenticated
      /// user in no particular order.</summary>
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

      /// <summary>The order parameter specifies the method that will be used to sort resources in the API
      /// response.</summary>
      /// 
      ///             [default: SUBSCRIPTION_ORDER_RELEVANCE]
      [RequestParameter("order", RequestParameterType.Query)]
      public virtual SubscriptionsResource.ListRequest.OrderEnum? Order { get; set; }

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
          return "subscriptions";
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
        this.RequestParameters.Add("channelId", (IParameter) new Parameter()
        {
          Name = "channelId",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("forChannelId", (IParameter) new Parameter()
        {
          Name = "forChannelId",
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
        this.RequestParameters.Add("myRecentSubscribers", (IParameter) new Parameter()
        {
          Name = "myRecentSubscribers",
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
        this.RequestParameters.Add("onBehalfOfContentOwnerChannel", (IParameter) new Parameter()
        {
          Name = "onBehalfOfContentOwnerChannel",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("order", (IParameter) new Parameter()
        {
          Name = "order",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = "SUBSCRIPTION_ORDER_RELEVANCE",
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

      /// <summary>The order parameter specifies the method that will be used to sort resources in the API
      /// response.</summary>
      public enum OrderEnum
      {
        /// <summary>Sort alphabetically.</summary>
        [StringValue("alphabetical")] Alphabetical,
        /// <summary>Sort by relevance.</summary>
        [StringValue("relevance")] Relevance,
        /// <summary>Sort by order of activity.</summary>
        [StringValue("unread")] Unread,
      }
    }
  }
}
