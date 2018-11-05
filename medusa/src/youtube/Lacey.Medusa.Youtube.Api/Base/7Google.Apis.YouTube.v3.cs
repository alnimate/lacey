// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.CommentThreadsResource
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Discovery;
using Google.Apis.Services;
using Google.Apis.Util;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>The "commentThreads" collection of methods.</summary>
  public class CommentThreadsResource
  {
    private const string Resource = "commentThreads";
    /// <summary>The service which this resource belongs to.</summary>
    private readonly IClientService service;

    /// <summary>Constructs a new resource.</summary>
    public CommentThreadsResource(IClientService service)
    {
      this.service = service;
    }

    /// <summary>Creates a new top-level comment. To add a reply to an existing comment, use the comments.insert
    /// method instead.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter identifies the properties that the API response will include. Set the
    /// parameter value to snippet. The snippet part has a quota cost of 2 units.</param>
    public virtual CommentThreadsResource.InsertRequest Insert(CommentThread body, string part)
    {
      return new CommentThreadsResource.InsertRequest(this.service, body, part);
    }

    /// <summary>Returns a list of comment threads that match the API request parameters.</summary>
    /// <param name="part">The part parameter specifies a comma-separated list of one or more commentThread resource
    /// properties that the API response will include.</param>
    public virtual CommentThreadsResource.ListRequest List(string part)
    {
      return new CommentThreadsResource.ListRequest(this.service, part);
    }

    /// <summary>Modifies the top-level comment in a comment thread.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter specifies a comma-separated list of commentThread resource properties that the
    /// API response will include. You must at least include the snippet part in the parameter value since that part
    /// contains all of the properties that the API request can update.</param>
    public virtual CommentThreadsResource.UpdateRequest Update(CommentThread body, string part)
    {
      return new CommentThreadsResource.UpdateRequest(this.service, body, part);
    }

    /// <summary>Creates a new top-level comment. To add a reply to an existing comment, use the comments.insert
    /// method instead.</summary>
    public class InsertRequest : YouTubeBaseServiceRequest<CommentThread>
    {
      /// <summary>Constructs a new Insert request.</summary>
      public InsertRequest(IClientService service, CommentThread body, string part)
        : base(service)
      {
        this.Part = part;
        this.Body = body;
        this.InitParameters();
      }

      /// <summary>The part parameter identifies the properties that the API response will include. Set the
      /// parameter value to snippet. The snippet part has a quota cost of 2 units.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>Gets or sets the body of this request.</summary>
      private CommentThread Body { get; set; }

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
          return "commentThreads";
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

    /// <summary>Returns a list of comment threads that match the API request parameters.</summary>
    public class ListRequest : YouTubeBaseServiceRequest<CommentThreadListResponse>
    {
      /// <summary>Constructs a new List request.</summary>
      public ListRequest(IClientService service, string part)
        : base(service)
      {
        this.Part = part;
        this.InitParameters();
      }

      /// <summary>The part parameter specifies a comma-separated list of one or more commentThread resource
      /// properties that the API response will include.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>The allThreadsRelatedToChannelId parameter instructs the API to return all comment threads
      /// associated with the specified channel. The response can include comments about the channel or about the
      /// channel's videos.</summary>
      [RequestParameter("allThreadsRelatedToChannelId", RequestParameterType.Query)]
      public virtual string AllThreadsRelatedToChannelId { get; set; }

      /// <summary>The channelId parameter instructs the API to return comment threads containing comments about
      /// the specified channel. (The response will not include comments left on videos that the channel
      /// uploaded.)</summary>
      [RequestParameter("channelId", RequestParameterType.Query)]
      public virtual string ChannelId { get; set; }

      /// <summary>The id parameter specifies a comma-separated list of comment thread IDs for the resources that
      /// should be retrieved.</summary>
      [RequestParameter("id", RequestParameterType.Query)]
      public virtual string Id { get; set; }

      /// <summary>The maxResults parameter specifies the maximum number of items that should be returned in the
      /// result set.
      /// 
      /// Note: This parameter is not supported for use in conjunction with the id parameter.</summary>
      /// 
      ///              [default: 20]
      ///              [minimum: 1]
      ///              [maximum: 100]
      [RequestParameter("maxResults", RequestParameterType.Query)]
      public virtual long? MaxResults { get; set; }

      /// <summary>Set this parameter to limit the returned comment threads to a particular moderation state.
      /// 
      /// Note: This parameter is not supported for use in conjunction with the id parameter.</summary>
      /// 
      ///              [default: MODERATION_STATUS_PUBLISHED]
      [RequestParameter("moderationStatus", RequestParameterType.Query)]
      public virtual CommentThreadsResource.ListRequest.ModerationStatusEnum? ModerationStatus { get; set; }

      /// <summary>The order parameter specifies the order in which the API response should list comment threads.
      /// Valid values are: - time - Comment threads are ordered by time. This is the default behavior. -
      /// relevance - Comment threads are ordered by relevance.Note: This parameter is not supported for use in
      /// conjunction with the id parameter.</summary>
      /// 
      ///             [default: true]
      [RequestParameter("order", RequestParameterType.Query)]
      public virtual CommentThreadsResource.ListRequest.OrderEnum? Order { get; set; }

      /// <summary>The pageToken parameter identifies a specific page in the result set that should be returned.
      /// In an API response, the nextPageToken property identifies the next page of the result that can be
      /// retrieved.
      /// 
      /// Note: This parameter is not supported for use in conjunction with the id parameter.</summary>
      [RequestParameter("pageToken", RequestParameterType.Query)]
      public virtual string PageToken { get; set; }

      /// <summary>The searchTerms parameter instructs the API to limit the API response to only contain comments
      /// that contain the specified search terms.
      /// 
      /// Note: This parameter is not supported for use in conjunction with the id parameter.</summary>
      [RequestParameter("searchTerms", RequestParameterType.Query)]
      public virtual string SearchTerms { get; set; }

      /// <summary>Set this parameter's value to html or plainText to instruct the API to return the comments left
      /// by users in html formatted or in plain text.</summary>
      /// 
      ///             [default: FORMAT_HTML]
      [RequestParameter("textFormat", RequestParameterType.Query)]
      public virtual CommentThreadsResource.ListRequest.TextFormatEnum? TextFormat { get; set; }

      /// <summary>The videoId parameter instructs the API to return comment threads associated with the specified
      /// video ID.</summary>
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
          return "commentThreads";
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
        this.RequestParameters.Add("allThreadsRelatedToChannelId", (IParameter) new Parameter()
        {
          Name = "allThreadsRelatedToChannelId",
          IsRequired = false,
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
          DefaultValue = "20",
          Pattern = (string) null
        });
        this.RequestParameters.Add("moderationStatus", (IParameter) new Parameter()
        {
          Name = "moderationStatus",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = "MODERATION_STATUS_PUBLISHED",
          Pattern = (string) null
        });
        this.RequestParameters.Add("order", (IParameter) new Parameter()
        {
          Name = "order",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = "true",
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
        this.RequestParameters.Add("searchTerms", (IParameter) new Parameter()
        {
          Name = "searchTerms",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("textFormat", (IParameter) new Parameter()
        {
          Name = "textFormat",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = "FORMAT_HTML",
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

      /// <summary>Set this parameter to limit the returned comment threads to a particular moderation state.
      /// 
      /// Note: This parameter is not supported for use in conjunction with the id parameter.</summary>
      public enum ModerationStatusEnum
      {
        /// <summary>Retrieve comment threads that are awaiting review by a moderator. A comment thread can be
        /// included in the response if the top-level comment or at least one of the replies to that comment are
        /// awaiting review.</summary>
        [StringValue("heldForReview")] HeldForReview,
        /// <summary>Retrieve comment threads classified as likely to be spam. A comment thread can be included
        /// in the response if the top-level comment or at least one of the replies to that comment is
        /// considered likely to be spam.</summary>
        [StringValue("likelySpam")] LikelySpam,
        /// <summary>Retrieve threads of published comments. This is the default value. A comment thread can be
        /// included in the response if its top-level comment has been published.</summary>
        [StringValue("published")] Published,
      }

      /// <summary>The order parameter specifies the order in which the API response should list comment threads.
      /// Valid values are: - time - Comment threads are ordered by time. This is the default behavior. -
      /// relevance - Comment threads are ordered by relevance.Note: This parameter is not supported for use in
      /// conjunction with the id parameter.</summary>
      public enum OrderEnum
      {
        /// <summary>Order by relevance.</summary>
        [StringValue("relevance")] Relevance,
        /// <summary>Order by time.</summary>
        [StringValue("time")] Time,
      }

      /// <summary>Set this parameter's value to html or plainText to instruct the API to return the comments left
      /// by users in html formatted or in plain text.</summary>
      public enum TextFormatEnum
      {
        /// <summary>Returns the comments in HTML format. This is the default value.</summary>
        [StringValue("html")] Html,
        /// <summary>Returns the comments in plain text format.</summary>
        [StringValue("plainText")] PlainText,
      }
    }

    /// <summary>Modifies the top-level comment in a comment thread.</summary>
    public class UpdateRequest : YouTubeBaseServiceRequest<CommentThread>
    {
      /// <summary>Constructs a new Update request.</summary>
      public UpdateRequest(IClientService service, CommentThread body, string part)
        : base(service)
      {
        this.Part = part;
        this.Body = body;
        this.InitParameters();
      }

      /// <summary>The part parameter specifies a comma-separated list of commentThread resource properties that
      /// the API response will include. You must at least include the snippet part in the parameter value since
      /// that part contains all of the properties that the API request can update.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>Gets or sets the body of this request.</summary>
      private CommentThread Body { get; set; }

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
          return "commentThreads";
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
      }
    }
  }
}
