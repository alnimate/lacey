// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.ChannelBannersResource
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.IO;
using Google.Apis.Discovery;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>The "channelBanners" collection of methods.</summary>
  public class ChannelBannersResource
  {
    private const string Resource = "channelBanners";
    /// <summary>The service which this resource belongs to.</summary>
    private readonly IClientService service;

    /// <summary>Constructs a new resource.</summary>
    public ChannelBannersResource(IClientService service)
    {
      this.service = service;
    }

    /// <summary>Uploads a channel banner image to YouTube. This method represents the first two steps in a three-
    /// step process to update the banner image for a channel:
    /// 
    /// - Call the channelBanners.insert method to upload the binary image data to YouTube. The image must have a
    /// 16:9 aspect ratio and be at least 2120x1192 pixels. - Extract the url property's value from the response
    /// that the API returns for step 1. - Call the channels.update method to update the channel's branding
    /// settings. Set the brandingSettings.image.bannerExternalUrl property's value to the URL obtained in step
    /// 2.</summary>
    /// <param name="body">The body of the request.</param>
    public virtual ChannelBannersResource.InsertRequest Insert(ChannelBannerResource body)
    {
      return new ChannelBannersResource.InsertRequest(this.service, body);
    }

    /// <summary>Uploads a channel banner image to YouTube. This method represents the first two steps in a three-
    /// step process to update the banner image for a channel:
    /// 
    /// - Call the channelBanners.insert method to upload the binary image data to YouTube. The image must have a
    /// 16:9 aspect ratio and be at least 2120x1192 pixels. - Extract the url property's value from the response
    /// that the API returns for step 1. - Call the channels.update method to update the channel's branding
    /// settings. Set the brandingSettings.image.bannerExternalUrl property's value to the URL obtained in step
    /// 2.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="stream">The stream to upload.</param>
    /// <param name="contentType">The content type of the stream to upload.</param>
    public virtual ChannelBannersResource.InsertMediaUpload Insert(ChannelBannerResource body, Stream stream, string contentType)
    {
      return new ChannelBannersResource.InsertMediaUpload(this.service, body, stream, contentType);
    }

    /// <summary>Uploads a channel banner image to YouTube. This method represents the first two steps in a three-
    /// step process to update the banner image for a channel:
    /// 
    /// - Call the channelBanners.insert method to upload the binary image data to YouTube. The image must have a
    /// 16:9 aspect ratio and be at least 2120x1192 pixels. - Extract the url property's value from the response
    /// that the API returns for step 1. - Call the channels.update method to update the channel's branding
    /// settings. Set the brandingSettings.image.bannerExternalUrl property's value to the URL obtained in step
    /// 2.</summary>
    public class InsertRequest : YouTubeBaseServiceRequest<ChannelBannerResource>
    {
      /// <summary>Constructs a new Insert request.</summary>
      public InsertRequest(IClientService service, ChannelBannerResource body)
        : base(service)
      {
        this.Body = body;
        this.InitParameters();
      }

      /// <summary>The channelId parameter identifies the YouTube channel to which the banner is uploaded. The
      /// channelId parameter was introduced as a required parameter in May 2017. As this was a backward-
      /// incompatible change, channelBanners.insert requests that do not specify this parameter will not return
      /// an error until six months have passed from the time that the parameter was introduced. Please see the
      /// API Terms of Service for the official policy regarding backward incompatible changes and the API
      /// revision history for the exact date that the parameter was introduced.</summary>
      [RequestParameter("channelId", RequestParameterType.Query)]
      public virtual string ChannelId { get; set; }

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
      private ChannelBannerResource Body { get; set; }

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
          return "channelBanners/insert";
        }
      }

      /// <summary>Initializes Insert parameter list.</summary>
      protected override void InitParameters()
      {
        base.InitParameters();
        this.RequestParameters.Add("channelId", (IParameter) new Parameter()
        {
          Name = "channelId",
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
      }
    }

    /// <summary>Insert media upload which supports resumable upload.</summary>
    public class InsertMediaUpload : ResumableUpload<ChannelBannerResource, ChannelBannerResource>
    {
      /// <summary>Data format for the response.</summary>
      /// 
      ///             [default: json]
      [RequestParameter("alt", RequestParameterType.Query)]
      public virtual ChannelBannersResource.InsertMediaUpload.AltEnum? Alt { get; set; }

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

      /// <summary>The channelId parameter identifies the YouTube channel to which the banner is uploaded. The
      /// channelId parameter was introduced as a required parameter in May 2017. As this was a backward-
      /// incompatible change, channelBanners.insert requests that do not specify this parameter will not return
      /// an error until six months have passed from the time that the parameter was introduced. Please see the
      /// API Terms of Service for the official policy regarding backward incompatible changes and the API
      /// revision history for the exact date that the parameter was introduced.</summary>
      [RequestParameter("channelId", RequestParameterType.Query)]
      public virtual string ChannelId { get; set; }

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

      /// <summary>Constructs a new Insert media upload instance.</summary>
      public InsertMediaUpload(IClientService service, ChannelBannerResource body, Stream stream, string contentType)
      : base(service, string.Format("/{0}/{1}{2}", (object)"upload", (object)service.BasePath, (object)"channelBanners/insert"), "POST", stream, contentType)
      {
        this.Body = body;
      }

      /// <summary>Data format for the response.</summary>
      public enum AltEnum
      {
        /// <summary>Responses with Content-Type of application/json</summary>
        [StringValue("json")] Json,
      }
    }
  }
}
