// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.SponsorsResource
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Discovery;
using Google.Apis.Services;
using Google.Apis.Util;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>The "sponsors" collection of methods.</summary>
  public class SponsorsResource
  {
    private const string Resource = "sponsors";
    /// <summary>The service which this resource belongs to.</summary>
    private readonly IClientService service;

    /// <summary>Constructs a new resource.</summary>
    public SponsorsResource(IClientService service)
    {
      this.service = service;
    }

    /// <summary>Lists sponsors for a channel.</summary>
    /// <param name="part">The part parameter specifies the sponsor resource parts that the API response will include.
    /// Supported values are id and snippet.</param>
    public virtual SponsorsResource.ListRequest List(string part)
    {
      return new SponsorsResource.ListRequest(this.service, part);
    }

    /// <summary>Lists sponsors for a channel.</summary>
    public class ListRequest : YouTubeBaseServiceRequest<SponsorListResponse>
    {
      /// <summary>Constructs a new List request.</summary>
      public ListRequest(IClientService service, string part)
        : base(service)
      {
        this.Part = part;
        this.InitParameters();
      }

      /// <summary>The part parameter specifies the sponsor resource parts that the API response will include.
      /// Supported values are id and snippet.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>The filter parameter specifies which channel sponsors to return.</summary>
      /// 
      ///             [default: POLL_NEWEST]
      [RequestParameter("filter", RequestParameterType.Query)]
      public virtual SponsorsResource.ListRequest.FilterEnum? Filter { get; set; }

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
          return "sponsors";
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
        this.RequestParameters.Add("filter", (IParameter) new Parameter()
        {
          Name = "filter",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = "POLL_NEWEST",
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

      /// <summary>The filter parameter specifies which channel sponsors to return.</summary>
      public enum FilterEnum
      {
        /// <summary>Return all sponsors, from newest to oldest.</summary>
        [StringValue("all")] All,
        /// <summary>Return the most recent sponsors, from newest to oldest.</summary>
        [StringValue("newest")] Newest,
      }
    }
  }
}
