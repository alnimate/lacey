// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.LiveChatModeratorsResource
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Discovery;
using Lacey.Medusa.Common.Api.Core.Base.Util;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>The "liveChatModerators" collection of methods.</summary>
  public class LiveChatModeratorsResource
  {
    private const string Resource = "liveChatModerators";
    /// <summary>The service which this resource belongs to.</summary>
    private readonly IClientService service;

    /// <summary>Constructs a new resource.</summary>
    public LiveChatModeratorsResource(IClientService service)
    {
      this.service = service;
    }

    /// <summary>Removes a chat moderator.</summary>
    /// <param name="id">The id parameter identifies the chat moderator to remove. The value uniquely identifies both the
    /// moderator and the chat.</param>
    public virtual LiveChatModeratorsResource.DeleteRequest Delete(string id)
    {
      return new LiveChatModeratorsResource.DeleteRequest(this.service, id);
    }

    /// <summary>Adds a new moderator for the chat.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter serves two purposes in this operation. It identifies the properties that the
    /// write operation will set as well as the properties that the API response returns. Set the parameter value to
    /// snippet.</param>
    public virtual LiveChatModeratorsResource.InsertRequest Insert(LiveChatModerator body, string part)
    {
      return new LiveChatModeratorsResource.InsertRequest(this.service, body, part);
    }

    /// <summary>Lists moderators for a live chat.</summary>
    /// <param name="liveChatId">The liveChatId parameter specifies the YouTube live chat for which the API should return
    /// moderators.</param>
    /// <param name="part">The part parameter specifies the liveChatModerator resource parts
    /// that the API response will include. Supported values are id and snippet.</param>
    public virtual LiveChatModeratorsResource.ListRequest List(string liveChatId, string part)
    {
      return new LiveChatModeratorsResource.ListRequest(this.service, liveChatId, part);
    }

    /// <summary>Removes a chat moderator.</summary>
    public class DeleteRequest : YouTubeBaseServiceRequest<string>
    {
      /// <summary>Constructs a new Delete request.</summary>
      public DeleteRequest(IClientService service, string id)
        : base(service)
      {
        this.Id = id;
        this.InitParameters();
      }

      /// <summary>The id parameter identifies the chat moderator to remove. The value uniquely identifies both
      /// the moderator and the chat.</summary>
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
          return "liveChat/moderators";
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

    /// <summary>Adds a new moderator for the chat.</summary>
    public class InsertRequest : YouTubeBaseServiceRequest<LiveChatModerator>
    {
      /// <summary>Constructs a new Insert request.</summary>
      public InsertRequest(IClientService service, LiveChatModerator body, string part)
        : base(service)
      {
        this.Part = part;
        this.Body = body;
        this.InitParameters();
      }

      /// <summary>The part parameter serves two purposes in this operation. It identifies the properties that the
      /// write operation will set as well as the properties that the API response returns. Set the parameter
      /// value to snippet.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>Gets or sets the body of this request.</summary>
      private LiveChatModerator Body { get; set; }

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
          return "liveChat/moderators";
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

    /// <summary>Lists moderators for a live chat.</summary>
    public class ListRequest : YouTubeBaseServiceRequest<LiveChatModeratorListResponse>
    {
      /// <summary>Constructs a new List request.</summary>
      public ListRequest(IClientService service, string liveChatId, string part)
        : base(service)
      {
        this.LiveChatId = liveChatId;
        this.Part = part;
        this.InitParameters();
      }

      /// <summary>The liveChatId parameter specifies the YouTube live chat for which the API should return
      /// moderators.</summary>
      [RequestParameter("liveChatId", RequestParameterType.Query)]
      public virtual string LiveChatId { get; private set; }

      /// <summary>The part parameter specifies the liveChatModerator resource parts that the API response will
      /// include. Supported values are id and snippet.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>The maxResults parameter specifies the maximum number of items that should be returned in the
      /// result set.</summary>
      /// 
      ///             [default: 5]
      ///             [minimum: 0]
      ///             [maximum: 50]
      [RequestParameter("maxResults", RequestParameterType.Query)]
      public virtual long? MaxResults { get; set; }

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
          return "liveChat/moderators";
        }
      }

      /// <summary>Initializes List parameter list.</summary>
      protected override void InitParameters()
      {
        base.InitParameters();
        this.RequestParameters.Add("liveChatId", (IParameter) new Parameter()
        {
          Name = "liveChatId",
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
        this.RequestParameters.Add("maxResults", (IParameter) new Parameter()
        {
          Name = "maxResults",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = "5",
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
  }
}
