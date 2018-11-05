// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.VideoAbuseReportReasonsResource
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Discovery;
using Lacey.Medusa.Common.Api.Core.Base.Util;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>The "videoAbuseReportReasons" collection of methods.</summary>
  public class VideoAbuseReportReasonsResource
  {
    private const string Resource = "videoAbuseReportReasons";
    /// <summary>The service which this resource belongs to.</summary>
    private readonly IClientService service;

    /// <summary>Constructs a new resource.</summary>
    public VideoAbuseReportReasonsResource(IClientService service)
    {
      this.service = service;
    }

    /// <summary>Returns a list of abuse reasons that can be used for reporting abusive videos.</summary>
    /// <param name="part">The part parameter specifies the videoCategory resource parts that the API response will include.
    /// Supported values are id and snippet.</param>
    public virtual VideoAbuseReportReasonsResource.ListRequest List(string part)
    {
      return new VideoAbuseReportReasonsResource.ListRequest(this.service, part);
    }

    /// <summary>Returns a list of abuse reasons that can be used for reporting abusive videos.</summary>
    public class ListRequest : YouTubeBaseServiceRequest<VideoAbuseReportReasonListResponse>
    {
      /// <summary>Constructs a new List request.</summary>
      public ListRequest(IClientService service, string part)
        : base(service)
      {
        this.Part = part;
        this.InitParameters();
      }

      /// <summary>The part parameter specifies the videoCategory resource parts that the API response will
      /// include. Supported values are id and snippet.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>The hl parameter specifies the language that should be used for text values in the API
      /// response.</summary>
      /// 
      ///             [default: en_US]
      [RequestParameter("hl", RequestParameterType.Query)]
      public virtual string Hl { get; set; }

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
          return "videoAbuseReportReasons";
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
        this.RequestParameters.Add("hl", (IParameter) new Parameter()
        {
          Name = "hl",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = "en_US",
          Pattern = (string) null
        });
      }
    }
  }
}
