// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.LiveChatMessagesResource
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Discovery;
using Lacey.Medusa.Common.Api.Core.Base.Util;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>The "liveChatMessages" collection of methods.</summary>
  internal class LiveChatMessagesResource
  {
    private const string Resource = "liveChatMessages";
    /// <summary>The service which this resource belongs to.</summary>
    private readonly IClientService service;

    /// <summary>Constructs a new resource.</summary>
    public LiveChatMessagesResource(IClientService service)
    {
      this.service = service;
    }

    /// <summary>Deletes a chat message.</summary>
    /// <param name="id">The id parameter specifies the YouTube chat message ID of the resource that is being
    /// deleted.</param>
    public virtual LiveChatMessagesResource.DeleteRequest Delete(string id)
    {
      return new LiveChatMessagesResource.DeleteRequest(this.service, id);
    }

    /// <summary>Adds a message to a live chat.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter serves two purposes. It identifies the properties that the write operation
    /// will set as well as the properties that the API response will include. Set the parameter value to
    /// snippet.</param>
    public virtual LiveChatMessagesResource.InsertRequest Insert(LiveChatMessage body, string part)
    {
      return new LiveChatMessagesResource.InsertRequest(this.service, body, part);
    }

    /// <summary>Lists live chat messages for a specific chat.</summary>
    /// <param name="liveChatId">The liveChatId parameter specifies the ID of the chat whose messages will be
    /// returned.</param>
    /// <param name="part">The part parameter specifies the liveChatComment resource parts that
    /// the API response will include. Supported values are id and snippet.</param>
    public virtual LiveChatMessagesResource.ListRequest List(string liveChatId, string part)
    {
      return new LiveChatMessagesResource.ListRequest(this.service, liveChatId, part);
    }

    /// <summary>Deletes a chat message.</summary>
    internal class DeleteRequest : YouTubeBaseServiceRequest<string>
    {
      /// <summary>Constructs a new Delete request.</summary>
      public DeleteRequest(IClientService service, string id)
        : base(service)
      {
        this.Id = id;
        this.InitParameters();
      }

      /// <summary>The id parameter specifies the YouTube chat message ID of the resource that is being
      /// deleted.</summary>
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
          return "liveChat/messages";
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

    /// <summary>Adds a message to a live chat.</summary>
    internal class InsertRequest : YouTubeBaseServiceRequest<LiveChatMessage>
    {
      /// <summary>Constructs a new Insert request.</summary>
      public InsertRequest(IClientService service, LiveChatMessage body, string part)
        : base(service)
      {
        this.Part = part;
        this.Body = body;
        this.InitParameters();
      }

      /// <summary>The part parameter serves two purposes. It identifies the properties that the write operation
      /// will set as well as the properties that the API response will include. Set the parameter value to
      /// snippet.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>Gets or sets the body of this request.</summary>
      private LiveChatMessage Body { get; set; }

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
          return "liveChat/messages";
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

    /// <summary>Lists live chat messages for a specific chat.</summary>
    internal class ListRequest : YouTubeBaseServiceRequest<LiveChatMessageListResponse>
    {
      /// <summary>Constructs a new List request.</summary>
      public ListRequest(IClientService service, string liveChatId, string part)
        : base(service)
      {
        this.LiveChatId = liveChatId;
        this.Part = part;
        this.InitParameters();
      }

      /// <summary>The liveChatId parameter specifies the ID of the chat whose messages will be
      /// returned.</summary>
      [RequestParameter("liveChatId", RequestParameterType.Query)]
      public virtual string LiveChatId { get; private set; }

      /// <summary>The part parameter specifies the liveChatComment resource parts that the API response will
      /// include. Supported values are id and snippet.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>The hl parameter instructs the API to retrieve localized resource metadata for a specific
      /// application language that the YouTube website supports. The parameter value must be a language code
      /// included in the list returned by the i18nLanguages.list method.
      /// 
      /// If localized resource details are available in that language, the resource's snippet.localized object
      /// will contain the localized values. However, if localized details are not available, the
      /// snippet.localized object will contain resource details in the resource's default language.</summary>
      [RequestParameter("hl", RequestParameterType.Query)]
      public virtual string Hl { get; set; }

      /// <summary>The maxResults parameter specifies the maximum number of messages that should be returned in
      /// the result set.</summary>
      /// 
      ///             [default: 500]
      ///             [minimum: 200]
      ///             [maximum: 2000]
      [RequestParameter("maxResults", RequestParameterType.Query)]
      public virtual long? MaxResults { get; set; }

      /// <summary>The pageToken parameter identifies a specific page in the result set that should be returned.
      /// In an API response, the nextPageToken property identify other pages that could be retrieved.</summary>
      [RequestParameter("pageToken", RequestParameterType.Query)]
      public virtual string PageToken { get; set; }

      /// <summary>The profileImageSize parameter specifies the size of the user profile pictures that should be
      /// returned in the result set. Default: 88.</summary>
      /// 
      ///             [minimum: 16]
      ///             [maximum: 720]
      [RequestParameter("profileImageSize", RequestParameterType.Query)]
      public virtual long? ProfileImageSize { get; set; }

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
          return "liveChat/messages";
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
        this.RequestParameters.Add("hl", (IParameter) new Parameter()
        {
          Name = "hl",
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
          DefaultValue = "500",
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
        this.RequestParameters.Add("profileImageSize", (IParameter) new Parameter()
        {
          Name = "profileImageSize",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
      }
    }
  }
}
