// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.GuideCategoriesResource
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Discovery;
using Google.Apis.Services;
using Google.Apis.Util;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>The "guideCategories" collection of methods.</summary>
  public class GuideCategoriesResource
  {
    private const string Resource = "guideCategories";
    /// <summary>The service which this resource belongs to.</summary>
    private readonly IClientService service;

    /// <summary>Constructs a new resource.</summary>
    public GuideCategoriesResource(IClientService service)
    {
      this.service = service;
    }

    /// <summary>Returns a list of categories that can be associated with YouTube channels.</summary>
    /// <param name="part">The part parameter specifies the guideCategory resource properties that the API response will
    /// include. Set the parameter value to snippet.</param>
    public virtual GuideCategoriesResource.ListRequest List(string part)
    {
      return new GuideCategoriesResource.ListRequest(this.service, part);
    }

    /// <summary>Returns a list of categories that can be associated with YouTube channels.</summary>
    public class ListRequest : YouTubeBaseServiceRequest<GuideCategoryListResponse>
    {
      /// <summary>Constructs a new List request.</summary>
      public ListRequest(IClientService service, string part)
        : base(service)
      {
        this.Part = part;
        this.InitParameters();
      }

      /// <summary>The part parameter specifies the guideCategory resource properties that the API response will
      /// include. Set the parameter value to snippet.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>The hl parameter specifies the language that will be used for text values in the API
      /// response.</summary>
      /// 
      ///             [default: en-US]
      [RequestParameter("hl", RequestParameterType.Query)]
      public virtual string Hl { get; set; }

      /// <summary>The id parameter specifies a comma-separated list of the YouTube channel category ID(s) for the
      /// resource(s) that are being retrieved. In a guideCategory resource, the id property specifies the YouTube
      /// channel category ID.</summary>
      [RequestParameter("id", RequestParameterType.Query)]
      public virtual string Id { get; set; }

      /// <summary>The regionCode parameter instructs the API to return the list of guide categories available in
      /// the specified country. The parameter value is an ISO 3166-1 alpha-2 country code.</summary>
      [RequestParameter("regionCode", RequestParameterType.Query)]
      public virtual string RegionCode { get; set; }

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
          return "guideCategories";
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
          DefaultValue = "en-US",
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
        this.RequestParameters.Add("regionCode", (IParameter) new Parameter()
        {
          Name = "regionCode",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
      }
    }
  }
}
