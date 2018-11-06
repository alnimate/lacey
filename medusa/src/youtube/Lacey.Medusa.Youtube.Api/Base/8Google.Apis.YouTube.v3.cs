// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.CommentsResource
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Discovery;
using Lacey.Medusa.Common.Api.Core.Base.Util;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>The "comments" collection of methods.</summary>
  public class CommentsResource
  {
    private const string Resource = "comments";
    /// <summary>The service which this resource belongs to.</summary>
    private readonly IClientService service;

    /// <summary>Constructs a new resource.</summary>
    public CommentsResource(IClientService service)
    {
      this.service = service;
    }

    /// <summary>Deletes a comment.</summary>
    /// <param name="id">The id parameter specifies the comment ID for the resource that is being deleted.</param>
    public virtual CommentsResource.DeleteRequest Delete(string id)
    {
      return new CommentsResource.DeleteRequest(this.service, id);
    }

    /// <summary>Creates a reply to an existing comment. Note: To create a top-level comment, use the
    /// commentThreads.insert method.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter identifies the properties that the API response will include. Set the
    /// parameter value to snippet. The snippet part has a quota cost of 2 units.</param>
    public virtual CommentsResource.InsertRequest Insert(Comment body, string part)
    {
      return new CommentsResource.InsertRequest(this.service, body, part);
    }

    /// <summary>Returns a list of comments that match the API request parameters.</summary>
    /// <param name="part">The part parameter specifies a comma-separated list of one or more comment resource properties
    /// that the API response will include.</param>
    public virtual CommentsResource.ListRequest List(string part)
    {
      return new CommentsResource.ListRequest(this.service, part);
    }

    /// <summary>Expresses the caller's opinion that one or more comments should be flagged as spam.</summary>
    /// <param name="id">The id parameter specifies a comma-separated list of IDs of comments that the caller believes
    /// should be classified as spam.</param>
    public virtual CommentsResource.MarkAsSpamRequest MarkAsSpam(string id)
    {
      return new CommentsResource.MarkAsSpamRequest(this.service, id);
    }

    /// <summary>Sets the moderation status of one or more comments. The API request must be authorized by the owner
    /// of the channel or video associated with the comments.</summary>
    /// <param name="id">The id parameter specifies a comma-separated list of IDs that identify the comments for which you
    /// are updating the moderation status.</param>
    /// <param name="moderationStatus">Identifies the new moderation
    /// status of the specified comments.</param>
    public virtual CommentsResource.SetModerationStatusRequest SetModerationStatus(string id, CommentsResource.SetModerationStatusRequest.ModerationStatusEnum moderationStatus)
    {
      return new CommentsResource.SetModerationStatusRequest(this.service, id, moderationStatus);
    }

    /// <summary>Modifies a comment.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter identifies the properties that the API response will include. You must at
    /// least include the snippet part in the parameter value since that part contains all of the properties that the API
    /// request can update.</param>
    public virtual CommentsResource.UpdateRequest Update(Comment body, string part)
    {
      return new CommentsResource.UpdateRequest(this.service, body, part);
    }

    /// <summary>Deletes a comment.</summary>
    public class DeleteRequest : YouTubeBaseServiceRequest<string>
    {
      /// <summary>Constructs a new Delete request.</summary>
      public DeleteRequest(IClientService service, string id)
        : base(service)
      {
        this.Id = id;
        this.InitParameters();
      }

      /// <summary>The id parameter specifies the comment ID for the resource that is being deleted.</summary>
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
          return "comments";
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

    /// <summary>Creates a reply to an existing comment. Note: To create a top-level comment, use the
    /// commentThreads.insert method.</summary>
    public class InsertRequest : YouTubeBaseServiceRequest<Comment>
    {
      /// <summary>Constructs a new Insert request.</summary>
      public InsertRequest(IClientService service, Comment body, string part)
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
      private Comment Body { get; set; }

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
          return "comments";
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

    /// <summary>Returns a list of comments that match the API request parameters.</summary>
    public class ListRequest : YouTubeBaseServiceRequest<CommentListResponse>
    {
      /// <summary>Constructs a new List request.</summary>
      public ListRequest(IClientService service, string part)
        : base(service)
      {
        this.Part = part;
        this.InitParameters();
      }

      /// <summary>The part parameter specifies a comma-separated list of one or more comment resource properties
      /// that the API response will include.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>The id parameter specifies a comma-separated list of comment IDs for the resources that are
      /// being retrieved. In a comment resource, the id property specifies the comment's ID.</summary>
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

      /// <summary>The pageToken parameter identifies a specific page in the result set that should be returned.
      /// In an API response, the nextPageToken property identifies the next page of the result that can be
      /// retrieved.
      /// 
      /// Note: This parameter is not supported for use in conjunction with the id parameter.</summary>
      [RequestParameter("pageToken", RequestParameterType.Query)]
      public virtual string PageToken { get; set; }

      /// <summary>The parentId parameter specifies the ID of the comment for which replies should be retrieved.
      /// 
      /// Note: YouTube currently supports replies only for top-level comments. However, replies to replies may be
      /// supported in the future.</summary>
      [RequestParameter("parentId", RequestParameterType.Query)]
      public virtual string ParentId { get; set; }

      /// <summary>This parameter indicates whether the API should return comments formatted as HTML or as plain
      /// text.</summary>
      /// 
      ///             [default: FORMAT_HTML]
      [RequestParameter("textFormat", RequestParameterType.Query)]
      public virtual CommentsResource.ListRequest.TextFormatEnum? TextFormat { get; set; }

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
          return "comments";
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
          DefaultValue = "20",
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
        this.RequestParameters.Add("parentId", (IParameter) new Parameter()
        {
          Name = "parentId",
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
      }

      /// <summary>This parameter indicates whether the API should return comments formatted as HTML or as plain
      /// text.</summary>
      public enum TextFormatEnum
      {
        /// <summary>Returns the comments in HTML format. This is the default value.</summary>
        [StringValue("html")] Html,
        /// <summary>Returns the comments in plain text format.</summary>
        [StringValue("plainText")] PlainText,
      }
    }

    /// <summary>Expresses the caller's opinion that one or more comments should be flagged as spam.</summary>
    public class MarkAsSpamRequest : YouTubeBaseServiceRequest<string>
    {
      /// <summary>Constructs a new MarkAsSpam request.</summary>
      public MarkAsSpamRequest(IClientService service, string id)
        : base(service)
      {
        this.Id = id;
        this.InitParameters();
      }

      /// <summary>The id parameter specifies a comma-separated list of IDs of comments that the caller believes
      /// should be classified as spam.</summary>
      [RequestParameter("id", RequestParameterType.Query)]
      public virtual string Id { get; private set; }

      /// <summary>Gets the method name.</summary>
      public override string MethodName
      {
        get
        {
          return "markAsSpam";
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
          return "comments/markAsSpam";
        }
      }

      /// <summary>Initializes MarkAsSpam parameter list.</summary>
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

    /// <summary>Sets the moderation status of one or more comments. The API request must be authorized by the owner
    /// of the channel or video associated with the comments.</summary>
    public class SetModerationStatusRequest : YouTubeBaseServiceRequest<string>
    {
      /// <summary>Constructs a new SetModerationStatus request.</summary>
      public SetModerationStatusRequest(IClientService service, string id, CommentsResource.SetModerationStatusRequest.ModerationStatusEnum moderationStatus)
        : base(service)
      {
        this.Id = id;
        this.ModerationStatus = moderationStatus;
        this.InitParameters();
      }

      /// <summary>The id parameter specifies a comma-separated list of IDs that identify the comments for which
      /// you are updating the moderation status.</summary>
      [RequestParameter("id", RequestParameterType.Query)]
      public virtual string Id { get; private set; }

      /// <summary>Identifies the new moderation status of the specified comments.</summary>
      [RequestParameter("moderationStatus", RequestParameterType.Query)]
      public virtual CommentsResource.SetModerationStatusRequest.ModerationStatusEnum ModerationStatus { get; private set; }

      /// <summary>The banAuthor parameter lets you indicate that you want to automatically reject any additional
      /// comments written by the comment's author. Set the parameter value to true to ban the author.
      /// 
      /// Note: This parameter is only valid if the moderationStatus parameter is also set to rejected.</summary>
      /// 
      ///              [default: false]
      [RequestParameter("banAuthor", RequestParameterType.Query)]
      public virtual bool? BanAuthor { get; set; }

      /// <summary>Gets the method name.</summary>
      public override string MethodName
      {
        get
        {
          return "setModerationStatus";
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
          return "comments/setModerationStatus";
        }
      }

      /// <summary>Initializes SetModerationStatus parameter list.</summary>
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
        this.RequestParameters.Add("moderationStatus", (IParameter) new Parameter()
        {
          Name = "moderationStatus",
          IsRequired = true,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("banAuthor", (IParameter) new Parameter()
        {
          Name = "banAuthor",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = "false",
          Pattern = (string) null
        });
      }

      /// <summary>Identifies the new moderation status of the specified comments.</summary>
      public enum ModerationStatusEnum
      {
        /// <summary>Marks a comment as awaiting review by a moderator.</summary>
        [StringValue("heldForReview")] HeldForReview,
        /// <summary>Clears a comment for public display.</summary>
        [StringValue("published")] Published,
        /// <summary>Rejects a comment as being unfit for display. This action also effectively hides all
        /// replies to the rejected comment.
        /// 
        /// Note: The API does not currently provide a way to list or otherwise discover rejected comments.
        /// However, you can change the moderation status of a rejected comment if you still know its ID. If you
        /// were to change the moderation status of a rejected comment, the comment replies would subsequently
        /// be discoverable again as well.</summary>
        [StringValue("rejected")] Rejected,
      }
    }

    /// <summary>Modifies a comment.</summary>
    public class UpdateRequest : YouTubeBaseServiceRequest<Comment>
    {
      /// <summary>Constructs a new Update request.</summary>
      public UpdateRequest(IClientService service, Comment body, string part)
        : base(service)
      {
        this.Part = part;
        this.Body = body;
        this.InitParameters();
      }

      /// <summary>The part parameter identifies the properties that the API response will include. You must at
      /// least include the snippet part in the parameter value since that part contains all of the properties
      /// that the API request can update.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>Gets or sets the body of this request.</summary>
      private Comment Body { get; set; }

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
          return "comments";
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
