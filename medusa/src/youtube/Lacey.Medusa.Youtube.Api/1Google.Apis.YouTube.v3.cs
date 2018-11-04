// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.YouTubeBaseServiceRequest`1
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Discovery;
using Google.Apis.Requests;
using Google.Apis.Services;
using Google.Apis.Util;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>A base abstract class for YouTube requests.</summary>
  public abstract class YouTubeBaseServiceRequest<TResponse> : ClientServiceRequest<TResponse>
  {
    /// <summary>Constructs a new YouTubeBaseServiceRequest instance.</summary>
    protected YouTubeBaseServiceRequest(IClientService service)
      : base(service)
    {
    }

    /// <summary>Data format for the response.</summary>
    /// 
    ///             [default: json]
    [RequestParameter("alt", RequestParameterType.Query)]
    public virtual YouTubeBaseServiceRequest<TResponse>.AltEnum? Alt { get; set; }

    /// <summary>Selector specifying which fields to include in a partial response.</summary>
    [RequestParameter("fields", RequestParameterType.Query)]
    public virtual string Fields { get; set; }

    /// <summary>API key. Your API key identifies your project and provides you with API access, quota, and reports.
    /// Required unless you provide an OAuth 2.0 token.</summary>
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

    /// <summary>Initializes YouTube parameter list.</summary>
    protected override void InitParameters()
    {
      base.InitParameters();
      this.RequestParameters.Add("alt", (IParameter) new Parameter()
      {
        Name = "alt",
        IsRequired = false,
        ParameterType = "query",
        DefaultValue = "json",
        Pattern = (string) null
      });
      this.RequestParameters.Add("fields", (IParameter) new Parameter()
      {
        Name = "fields",
        IsRequired = false,
        ParameterType = "query",
        DefaultValue = (string) null,
        Pattern = (string) null
      });
      this.RequestParameters.Add("key", (IParameter) new Parameter()
      {
        Name = "key",
        IsRequired = false,
        ParameterType = "query",
        DefaultValue = (string) null,
        Pattern = (string) null
      });
      this.RequestParameters.Add("oauth_token", (IParameter) new Parameter()
      {
        Name = "oauth_token",
        IsRequired = false,
        ParameterType = "query",
        DefaultValue = (string) null,
        Pattern = (string) null
      });
      this.RequestParameters.Add("prettyPrint", (IParameter) new Parameter()
      {
        Name = "prettyPrint",
        IsRequired = false,
        ParameterType = "query",
        DefaultValue = "true",
        Pattern = (string) null
      });
      this.RequestParameters.Add("quotaUser", (IParameter) new Parameter()
      {
        Name = "quotaUser",
        IsRequired = false,
        ParameterType = "query",
        DefaultValue = (string) null,
        Pattern = (string) null
      });
      this.RequestParameters.Add("userIp", (IParameter) new Parameter()
      {
        Name = "userIp",
        IsRequired = false,
        ParameterType = "query",
        DefaultValue = (string) null,
        Pattern = (string) null
      });
    }

    /// <summary>Data format for the response.</summary>
    public enum AltEnum
    {
      /// <summary>Responses with Content-Type of application/json</summary>
      [StringValue("json")] Json,
    }
  }
}
