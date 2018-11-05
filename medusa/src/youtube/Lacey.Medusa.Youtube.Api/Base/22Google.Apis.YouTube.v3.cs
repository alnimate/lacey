// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.WatermarksResource
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.IO;
using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Base.Upload;
using Lacey.Medusa.Common.Api.Core.Base.Discovery;
using Lacey.Medusa.Common.Api.Core.Base.Util;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>The "watermarks" collection of methods.</summary>
  internal class WatermarksResource
  {
    private const string Resource = "watermarks";
    /// <summary>The service which this resource belongs to.</summary>
    private readonly IClientService service;

    /// <summary>Constructs a new resource.</summary>
    public WatermarksResource(IClientService service)
    {
      this.service = service;
    }

    /// <summary>Uploads a watermark image to YouTube and sets it for a channel.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="channelId">The channelId parameter specifies the YouTube channel ID for which the watermark is being
    /// provided.</param>
    public virtual WatermarksResource.SetRequest Set(InvideoBranding body, string channelId)
    {
      return new WatermarksResource.SetRequest(this.service, body, channelId);
    }

    /// <summary>Uploads a watermark image to YouTube and sets it for a channel.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="channelId">The channelId parameter specifies the YouTube channel ID for which the watermark is being
    /// provided.</param>
    /// <param name="stream">The stream to upload.</param>
    /// <param name="contentType">The content type of the stream to upload.</param>
    public virtual WatermarksResource.SetMediaUpload Set(InvideoBranding body, string channelId, Stream stream, string contentType)
    {
      return new WatermarksResource.SetMediaUpload(this.service, body, channelId, stream, contentType);
    }

    /// <summary>Deletes a channel's watermark image.</summary>
    /// <param name="channelId">The channelId parameter specifies the YouTube channel ID for which the watermark is being
    /// unset.</param>
    public virtual WatermarksResource.UnsetRequest Unset(string channelId)
    {
      return new WatermarksResource.UnsetRequest(this.service, channelId);
    }

    /// <summary>Uploads a watermark image to YouTube and sets it for a channel.</summary>
    internal class SetRequest : YouTubeBaseServiceRequest<string>
    {
      /// <summary>Constructs a new Set request.</summary>
      public SetRequest(IClientService service, InvideoBranding body, string channelId)
        : base(service)
      {
        this.ChannelId = channelId;
        this.Body = body;
        this.InitParameters();
      }

      /// <summary>The channelId parameter specifies the YouTube channel ID for which the watermark is being
      /// provided.</summary>
      [RequestParameter("channelId", RequestParameterType.Query)]
      public virtual string ChannelId { get; private set; }

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
      private InvideoBranding Body { get; set; }

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
          return "set";
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
          return "watermarks/set";
        }
      }

      /// <summary>Initializes Set parameter list.</summary>
      protected override void InitParameters()
      {
        base.InitParameters();
        this.RequestParameters.Add("channelId", (IParameter) new Parameter()
        {
          Name = "channelId",
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

    /// <summary>Set media upload which supports resumable upload.</summary>
    internal class SetMediaUpload : ResumableUpload<InvideoBranding>
    {
      /// <summary>Data format for the response.</summary>
      /// 
      ///             [default: json]
      [RequestParameter("alt", RequestParameterType.Query)]
      public virtual WatermarksResource.SetMediaUpload.AltEnum? Alt { get; set; }

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

      /// <summary>The channelId parameter specifies the YouTube channel ID for which the watermark is being
      /// provided.</summary>
      [RequestParameter("channelId", RequestParameterType.Query)]
      public virtual string ChannelId { get; private set; }

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

      /// <summary>Constructs a new Set media upload instance.</summary>
      public SetMediaUpload(IClientService service, InvideoBranding body, string channelId, Stream stream, string contentType)
        : base(service, string.Format("/{0}/{1}{2}", (object) "upload", (object) service.BasePath, (object) "watermarks/set"), "POST", stream, contentType)
      {
        this.ChannelId = channelId;
        this.Body = body;
      }

      /// <summary>Data format for the response.</summary>
      public enum AltEnum
      {
        /// <summary>Responses with Content-Type of application/json</summary>
        [StringValue("json")] Json,
      }
    }

    /// <summary>Deletes a channel's watermark image.</summary>
    internal class UnsetRequest : YouTubeBaseServiceRequest<string>
    {
      /// <summary>Constructs a new Unset request.</summary>
      public UnsetRequest(IClientService service, string channelId)
        : base(service)
      {
        this.ChannelId = channelId;
        this.InitParameters();
      }

      /// <summary>The channelId parameter specifies the YouTube channel ID for which the watermark is being
      /// unset.</summary>
      [RequestParameter("channelId", RequestParameterType.Query)]
      public virtual string ChannelId { get; private set; }

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
          return "unset";
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
          return "watermarks/unset";
        }
      }

      /// <summary>Initializes Unset parameter list.</summary>
      protected override void InitParameters()
      {
        base.InitParameters();
        this.RequestParameters.Add("channelId", (IParameter) new Parameter()
        {
          Name = "channelId",
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
