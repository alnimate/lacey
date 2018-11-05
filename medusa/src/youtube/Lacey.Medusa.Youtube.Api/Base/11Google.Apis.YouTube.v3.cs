// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.I18nRegionsResource
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Discovery;
using Lacey.Medusa.Common.Api.Core.Base.Util;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>The "i18nRegions" collection of methods.</summary>
  internal class I18nRegionsResource
  {
    private const string Resource = "i18nRegions";
    /// <summary>The service which this resource belongs to.</summary>
    private readonly IClientService service;

    /// <summary>Constructs a new resource.</summary>
    public I18nRegionsResource(IClientService service)
    {
      this.service = service;
    }

    /// <summary>Returns a list of content regions that the YouTube website supports.</summary>
    /// <param name="part">The part parameter specifies the i18nRegion resource properties that the API response will
    /// include. Set the parameter value to snippet.</param>
    public virtual I18nRegionsResource.ListRequest List(string part)
    {
      return new I18nRegionsResource.ListRequest(this.service, part);
    }

    /// <summary>Returns a list of content regions that the YouTube website supports.</summary>
    internal class ListRequest : YouTubeBaseServiceRequest<I18nRegionListResponse>
    {
      /// <summary>Constructs a new List request.</summary>
      public ListRequest(IClientService service, string part)
        : base(service)
      {
        this.Part = part;
        this.InitParameters();
      }

      /// <summary>The part parameter specifies the i18nRegion resource properties that the API response will
      /// include. Set the parameter value to snippet.</summary>
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
          return "i18nRegions";
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
