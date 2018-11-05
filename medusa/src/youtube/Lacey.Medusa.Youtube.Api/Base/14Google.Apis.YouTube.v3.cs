// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.PlaylistItemsResource
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Discovery;
using Google.Apis.Services;
using Google.Apis.Util;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>The "playlistItems" collection of methods.</summary>
  public class PlaylistItemsResource
  {
    private const string Resource = "playlistItems";
    /// <summary>The service which this resource belongs to.</summary>
    private readonly IClientService service;

    /// <summary>Constructs a new resource.</summary>
    public PlaylistItemsResource(IClientService service)
    {
      this.service = service;
    }

    /// <summary>Deletes a playlist item.</summary>
    /// <param name="id">The id parameter specifies the YouTube playlist item ID for the playlist item that is being
    /// deleted. In a playlistItem resource, the id property specifies the playlist item's ID.</param>
    public virtual PlaylistItemsResource.DeleteRequest Delete(string id)
    {
      return new PlaylistItemsResource.DeleteRequest(this.service, id);
    }

    /// <summary>Adds a resource to a playlist.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter serves two purposes in this operation. It identifies the properties that the
    /// write operation will set as well as the properties that the API response will include.</param>
    public virtual PlaylistItemsResource.InsertRequest Insert(PlaylistItem body, string part)
    {
      return new PlaylistItemsResource.InsertRequest(this.service, body, part);
    }

    /// <summary>Returns a collection of playlist items that match the API request parameters. You can retrieve all
    /// of the playlist items in a specified playlist or retrieve one or more playlist items by their unique
    /// IDs.</summary>
    /// <param name="part">The part parameter specifies a comma-separated list of one or more playlistItem resource
    /// properties that the API response will include.
    /// 
    /// If the parameter identifies a property that contains child properties, the child properties will be included in the
    /// response. For example, in a playlistItem resource, the snippet property contains numerous fields, including the
    /// title, description, position, and resourceId properties. As such, if you set part=snippet, the API response will
    /// contain all of those properties.</param>
    public virtual PlaylistItemsResource.ListRequest List(string part)
    {
      return new PlaylistItemsResource.ListRequest(this.service, part);
    }

    /// <summary>Modifies a playlist item. For example, you could update the item's position in the
    /// playlist.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter serves two purposes in this operation. It identifies the properties that the
    /// write operation will set as well as the properties that the API response will include.
    /// 
    /// Note that this method will override the existing values for all of the mutable properties that are contained in any
    /// parts that the parameter value specifies. For example, a playlist item can specify a start time and end time, which
    /// identify the times portion of the video that should play when users watch the video in the playlist. If your request
    /// is updating a playlist item that sets these values, and the request's part parameter value includes the
    /// contentDetails part, the playlist item's start and end times will be updated to whatever value the request body
    /// specifies. If the request body does not specify values, the existing start and end times will be removed and
    /// replaced with the default settings.</param>
    public virtual PlaylistItemsResource.UpdateRequest Update(PlaylistItem body, string part)
    {
      return new PlaylistItemsResource.UpdateRequest(this.service, body, part);
    }

    /// <summary>Deletes a playlist item.</summary>
    public class DeleteRequest : YouTubeBaseServiceRequest<string>
    {
      /// <summary>Constructs a new Delete request.</summary>
      public DeleteRequest(IClientService service, string id)
        : base(service)
      {
        this.Id = id;
        this.InitParameters();
      }

      /// <summary>The id parameter specifies the YouTube playlist item ID for the playlist item that is being
      /// deleted. In a playlistItem resource, the id property specifies the playlist item's ID.</summary>
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
          return "playlistItems";
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

    /// <summary>Adds a resource to a playlist.</summary>
    public class InsertRequest : YouTubeBaseServiceRequest<PlaylistItem>
    {
      /// <summary>Constructs a new Insert request.</summary>
      public InsertRequest(IClientService service, PlaylistItem body, string part)
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
      private PlaylistItem Body { get; set; }

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
          return "playlistItems";
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
      }
    }

    /// <summary>Returns a collection of playlist items that match the API request parameters. You can retrieve all
    /// of the playlist items in a specified playlist or retrieve one or more playlist items by their unique
    /// IDs.</summary>
    public class ListRequest : YouTubeBaseServiceRequest<PlaylistItemListResponse>
    {
      /// <summary>Constructs a new List request.</summary>
      public ListRequest(IClientService service, string part)
        : base(service)
      {
        this.Part = part;
        this.InitParameters();
      }

      /// <summary>The part parameter specifies a comma-separated list of one or more playlistItem resource
      /// properties that the API response will include.
      /// 
      /// If the parameter identifies a property that contains child properties, the child properties will be
      /// included in the response. For example, in a playlistItem resource, the snippet property contains
      /// numerous fields, including the title, description, position, and resourceId properties. As such, if you
      /// set part=snippet, the API response will contain all of those properties.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>The id parameter specifies a comma-separated list of one or more unique playlist item
      /// IDs.</summary>
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

      /// <summary>The playlistId parameter specifies the unique ID of the playlist for which you want to retrieve
      /// playlist items. Note that even though this is an optional parameter, every request to retrieve playlist
      /// items must specify a value for either the id parameter or the playlistId parameter.</summary>
      [RequestParameter("playlistId", RequestParameterType.Query)]
      public virtual string PlaylistId { get; set; }

      /// <summary>The videoId parameter specifies that the request should return only the playlist items that
      /// contain the specified video.</summary>
      [RequestParameter("videoId", RequestParameterType.Query)]
      public virtual string VideoId { get; set; }

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
          return "playlistItems";
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
        this.RequestParameters.Add("playlistId", (IParameter) new Parameter()
        {
          Name = "playlistId",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("videoId", (IParameter) new Parameter()
        {
          Name = "videoId",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
      }
    }

    /// <summary>Modifies a playlist item. For example, you could update the item's position in the
    /// playlist.</summary>
    public class UpdateRequest : YouTubeBaseServiceRequest<PlaylistItem>
    {
      /// <summary>Constructs a new Update request.</summary>
      public UpdateRequest(IClientService service, PlaylistItem body, string part)
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
      /// contained in any parts that the parameter value specifies. For example, a playlist item can specify a
      /// start time and end time, which identify the times portion of the video that should play when users watch
      /// the video in the playlist. If your request is updating a playlist item that sets these values, and the
      /// request's part parameter value includes the contentDetails part, the playlist item's start and end times
      /// will be updated to whatever value the request body specifies. If the request body does not specify
      /// values, the existing start and end times will be removed and replaced with the default
      /// settings.</summary>
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

      /// <summary>Gets or sets the body of this request.</summary>
      private PlaylistItem Body { get; set; }

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
          return "playlistItems";
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
