// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.SearchResource
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System;
using Google.Apis.Discovery;
using Google.Apis.Services;
using Google.Apis.Util;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>The "search" collection of methods.</summary>
  public class SearchResource
  {
    private const string Resource = "search";
    /// <summary>The service which this resource belongs to.</summary>
    private readonly IClientService service;

    /// <summary>Constructs a new resource.</summary>
    public SearchResource(IClientService service)
    {
      this.service = service;
    }

    /// <summary>Returns a collection of search results that match the query parameters specified in the API
    /// request. By default, a search result set identifies matching video, channel, and playlist resources, but you
    /// can also configure queries to only retrieve a specific type of resource.</summary>
    /// <param name="part">The part parameter specifies a comma-separated list of one or more search resource properties
    /// that the API response will include. Set the parameter value to snippet.</param>
    public virtual SearchResource.ListRequest List(string part)
    {
      return new SearchResource.ListRequest(this.service, part);
    }

    /// <summary>Returns a collection of search results that match the query parameters specified in the API
    /// request. By default, a search result set identifies matching video, channel, and playlist resources, but you
    /// can also configure queries to only retrieve a specific type of resource.</summary>
    public class ListRequest : YouTubeBaseServiceRequest<SearchListResponse>
    {
      /// <summary>Constructs a new List request.</summary>
      public ListRequest(IClientService service, string part)
        : base(service)
      {
        this.Part = part;
        this.InitParameters();
      }

      /// <summary>The part parameter specifies a comma-separated list of one or more search resource properties
      /// that the API response will include. Set the parameter value to snippet.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>The channelId parameter indicates that the API response should only contain resources created
      /// by the channel</summary>
      [RequestParameter("channelId", RequestParameterType.Query)]
      public virtual string ChannelId { get; set; }

      /// <summary>The channelType parameter lets you restrict a search to a particular type of channel.</summary>
      [RequestParameter("channelType", RequestParameterType.Query)]
      public virtual SearchResource.ListRequest.ChannelTypeEnum? ChannelType { get; set; }

      /// <summary>The eventType parameter restricts a search to broadcast events. If you specify a value for this
      /// parameter, you must also set the type parameter's value to video.</summary>
      [RequestParameter("eventType", RequestParameterType.Query)]
      public virtual SearchResource.ListRequest.EventTypeEnum? EventType { get; set; }

      /// <summary>Note: This parameter is intended exclusively for YouTube content partners.
      /// 
      /// The forContentOwner parameter restricts the search to only retrieve resources owned by the content owner
      /// specified by the onBehalfOfContentOwner parameter. The user must be authenticated using a CMS account
      /// linked to the specified content owner and onBehalfOfContentOwner must be provided.</summary>
      [RequestParameter("forContentOwner", RequestParameterType.Query)]
      public virtual bool? ForContentOwner { get; set; }

      /// <summary>The forDeveloper parameter restricts the search to only retrieve videos uploaded via the
      /// developer's application or website. The API server uses the request's authorization credentials to
      /// identify the developer. Therefore, a developer can restrict results to videos uploaded through the
      /// developer's own app or website but not to videos uploaded through other apps or sites.</summary>
      [RequestParameter("forDeveloper", RequestParameterType.Query)]
      public virtual bool? ForDeveloper { get; set; }

      /// <summary>The forMine parameter restricts the search to only retrieve videos owned by the authenticated
      /// user. If you set this parameter to true, then the type parameter's value must also be set to
      /// video.</summary>
      [RequestParameter("forMine", RequestParameterType.Query)]
      public virtual bool? ForMine { get; set; }

      /// <summary>The location parameter, in conjunction with the locationRadius parameter, defines a circular
      /// geographic area and also restricts a search to videos that specify, in their metadata, a geographic
      /// location that falls within that area. The parameter value is a string that specifies latitude/longitude
      /// coordinates e.g. (37.42307,-122.08427).
      /// 
      /// - The location parameter value identifies the point at the center of the area. - The locationRadius
      /// parameter specifies the maximum distance that the location associated with a video can be from that
      /// point for the video to still be included in the search results.The API returns an error if your request
      /// specifies a value for the location parameter but does not also specify a value for the locationRadius
      /// parameter.</summary>
      [RequestParameter("location", RequestParameterType.Query)]
      public virtual string Location { get; set; }

      /// <summary>The locationRadius parameter, in conjunction with the location parameter, defines a circular
      /// geographic area.
      /// 
      /// The parameter value must be a floating point number followed by a measurement unit. Valid measurement
      /// units are m, km, ft, and mi. For example, valid parameter values include 1500m, 5km, 10000ft, and
      /// 0.75mi. The API does not support locationRadius parameter values larger than 1000 kilometers.
      /// 
      /// Note: See the definition of the location parameter for more information.</summary>
      [RequestParameter("locationRadius", RequestParameterType.Query)]
      public virtual string LocationRadius { get; set; }

      /// <summary>The maxResults parameter specifies the maximum number of items that should be returned in the
      /// result set.</summary>
      /// 
      ///             [default: 5]
      ///             [minimum: 0]
      ///             [maximum: 50]
      [RequestParameter("maxResults", RequestParameterType.Query)]
      public virtual long? MaxResults { get; set; }

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

      /// <summary>The order parameter specifies the method that will be used to order resources in the API
      /// response.</summary>
      /// 
      ///             [default: SEARCH_SORT_RELEVANCE]
      [RequestParameter("order", RequestParameterType.Query)]
      public virtual SearchResource.ListRequest.OrderEnum? Order { get; set; }

      /// <summary>The pageToken parameter identifies a specific page in the result set that should be returned.
      /// In an API response, the nextPageToken and prevPageToken properties identify other pages that could be
      /// retrieved.</summary>
      [RequestParameter("pageToken", RequestParameterType.Query)]
      public virtual string PageToken { get; set; }

      /// <summary>The publishedAfter parameter indicates that the API response should only contain resources
      /// created after the specified time. The value is an RFC 3339 formatted date-time value
      /// (1970-01-01T00:00:00Z).</summary>
      [RequestParameter("publishedAfter", RequestParameterType.Query)]
      public virtual DateTime? PublishedAfter { get; set; }

      /// <summary>The publishedBefore parameter indicates that the API response should only contain resources
      /// created before the specified time. The value is an RFC 3339 formatted date-time value
      /// (1970-01-01T00:00:00Z).</summary>
      [RequestParameter("publishedBefore", RequestParameterType.Query)]
      public virtual DateTime? PublishedBefore { get; set; }

      /// <summary>The q parameter specifies the query term to search for.
      /// 
      /// Your request can also use the Boolean NOT (-) and OR (|) operators to exclude videos or to find videos
      /// that are associated with one of several search terms. For example, to search for videos matching either
      /// "boating" or "sailing", set the q parameter value to boating|sailing. Similarly, to search for videos
      /// matching either "boating" or "sailing" but not "fishing", set the q parameter value to boating|sailing
      /// -fishing. Note that the pipe character must be URL-escaped when it is sent in your API request. The URL-
      /// escaped value for the pipe character is %7C.</summary>
      [RequestParameter("q", RequestParameterType.Query)]
      public virtual string Q { get; set; }

      /// <summary>The regionCode parameter instructs the API to return search results for the specified country.
      /// The parameter value is an ISO 3166-1 alpha-2 country code.</summary>
      [RequestParameter("regionCode", RequestParameterType.Query)]
      public virtual string RegionCode { get; set; }

      /// <summary>The relatedToVideoId parameter retrieves a list of videos that are related to the video that
      /// the parameter value identifies. The parameter value must be set to a YouTube video ID and, if you are
      /// using this parameter, the type parameter must be set to video.</summary>
      [RequestParameter("relatedToVideoId", RequestParameterType.Query)]
      public virtual string RelatedToVideoId { get; set; }

      /// <summary>The relevanceLanguage parameter instructs the API to return search results that are most
      /// relevant to the specified language. The parameter value is typically an ISO 639-1 two-letter language
      /// code. However, you should use the values zh-Hans for simplified Chinese and zh-Hant for traditional
      /// Chinese. Please note that results in other languages will still be returned if they are highly relevant
      /// to the search query term.</summary>
      [RequestParameter("relevanceLanguage", RequestParameterType.Query)]
      public virtual string RelevanceLanguage { get; set; }

      /// <summary>The safeSearch parameter indicates whether the search results should include restricted content
      /// as well as standard content.</summary>
      [RequestParameter("safeSearch", RequestParameterType.Query)]
      public virtual SearchResource.ListRequest.SafeSearchEnum? SafeSearch { get; set; }

      /// <summary>The topicId parameter indicates that the API response should only contain resources associated
      /// with the specified topic. The value identifies a Freebase topic ID.</summary>
      [RequestParameter("topicId", RequestParameterType.Query)]
      public virtual string TopicId { get; set; }

      /// <summary>The type parameter restricts a search query to only retrieve a particular type of resource. The
      /// value is a comma-separated list of resource types.</summary>
      /// 
      ///             [default: video,channel,playlist]
      [RequestParameter("type", RequestParameterType.Query)]
      public virtual string Type { get; set; }

      /// <summary>The videoCaption parameter indicates whether the API should filter video search results based
      /// on whether they have captions. If you specify a value for this parameter, you must also set the type
      /// parameter's value to video.</summary>
      [RequestParameter("videoCaption", RequestParameterType.Query)]
      public virtual SearchResource.ListRequest.VideoCaptionEnum? VideoCaption { get; set; }

      /// <summary>The videoCategoryId parameter filters video search results based on their category. If you
      /// specify a value for this parameter, you must also set the type parameter's value to video.</summary>
      [RequestParameter("videoCategoryId", RequestParameterType.Query)]
      public virtual string VideoCategoryId { get; set; }

      /// <summary>The videoDefinition parameter lets you restrict a search to only include either high definition
      /// (HD) or standard definition (SD) videos. HD videos are available for playback in at least 720p, though
      /// higher resolutions, like 1080p, might also be available. If you specify a value for this parameter, you
      /// must also set the type parameter's value to video.</summary>
      [RequestParameter("videoDefinition", RequestParameterType.Query)]
      public virtual SearchResource.ListRequest.VideoDefinitionEnum? VideoDefinition { get; set; }

      /// <summary>The videoDimension parameter lets you restrict a search to only retrieve 2D or 3D videos. If
      /// you specify a value for this parameter, you must also set the type parameter's value to video.</summary>
      [RequestParameter("videoDimension", RequestParameterType.Query)]
      public virtual SearchResource.ListRequest.VideoDimensionEnum? VideoDimension { get; set; }

      /// <summary>The videoDuration parameter filters video search results based on their duration. If you
      /// specify a value for this parameter, you must also set the type parameter's value to video.</summary>
      [RequestParameter("videoDuration", RequestParameterType.Query)]
      public virtual SearchResource.ListRequest.VideoDurationEnum? VideoDuration { get; set; }

      /// <summary>The videoEmbeddable parameter lets you to restrict a search to only videos that can be embedded
      /// into a webpage. If you specify a value for this parameter, you must also set the type parameter's value
      /// to video.</summary>
      [RequestParameter("videoEmbeddable", RequestParameterType.Query)]
      public virtual SearchResource.ListRequest.VideoEmbeddableEnum? VideoEmbeddable { get; set; }

      /// <summary>The videoLicense parameter filters search results to only include videos with a particular
      /// license. YouTube lets video uploaders choose to attach either the Creative Commons license or the
      /// standard YouTube license to each of their videos. If you specify a value for this parameter, you must
      /// also set the type parameter's value to video.</summary>
      [RequestParameter("videoLicense", RequestParameterType.Query)]
      public virtual SearchResource.ListRequest.VideoLicenseEnum? VideoLicense { get; set; }

      /// <summary>The videoSyndicated parameter lets you to restrict a search to only videos that can be played
      /// outside youtube.com. If you specify a value for this parameter, you must also set the type parameter's
      /// value to video.</summary>
      [RequestParameter("videoSyndicated", RequestParameterType.Query)]
      public virtual SearchResource.ListRequest.VideoSyndicatedEnum? VideoSyndicated { get; set; }

      /// <summary>The videoType parameter lets you restrict a search to a particular type of videos. If you
      /// specify a value for this parameter, you must also set the type parameter's value to video.</summary>
      [RequestParameter("videoType", RequestParameterType.Query)]
      public virtual SearchResource.ListRequest.VideoTypeEnum? VideoType { get; set; }

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
          return "search";
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
        this.RequestParameters.Add("channelId", (IParameter) new Parameter()
        {
          Name = "channelId",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("channelType", (IParameter) new Parameter()
        {
          Name = "channelType",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("eventType", (IParameter) new Parameter()
        {
          Name = "eventType",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("forContentOwner", (IParameter) new Parameter()
        {
          Name = "forContentOwner",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("forDeveloper", (IParameter) new Parameter()
        {
          Name = "forDeveloper",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("forMine", (IParameter) new Parameter()
        {
          Name = "forMine",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("location", (IParameter) new Parameter()
        {
          Name = "location",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("locationRadius", (IParameter) new Parameter()
        {
          Name = "locationRadius",
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
          DefaultValue = "5",
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
        this.RequestParameters.Add("order", (IParameter) new Parameter()
        {
          Name = "order",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = "SEARCH_SORT_RELEVANCE",
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
        this.RequestParameters.Add("publishedAfter", (IParameter) new Parameter()
        {
          Name = "publishedAfter",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("publishedBefore", (IParameter) new Parameter()
        {
          Name = "publishedBefore",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("q", (IParameter) new Parameter()
        {
          Name = "q",
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
        this.RequestParameters.Add("relatedToVideoId", (IParameter) new Parameter()
        {
          Name = "relatedToVideoId",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("relevanceLanguage", (IParameter) new Parameter()
        {
          Name = "relevanceLanguage",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("safeSearch", (IParameter) new Parameter()
        {
          Name = "safeSearch",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("topicId", (IParameter) new Parameter()
        {
          Name = "topicId",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("type", (IParameter) new Parameter()
        {
          Name = "type",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = "video,channel,playlist",
          Pattern = (string) null
        });
        this.RequestParameters.Add("videoCaption", (IParameter) new Parameter()
        {
          Name = "videoCaption",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("videoCategoryId", (IParameter) new Parameter()
        {
          Name = "videoCategoryId",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("videoDefinition", (IParameter) new Parameter()
        {
          Name = "videoDefinition",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("videoDimension", (IParameter) new Parameter()
        {
          Name = "videoDimension",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("videoDuration", (IParameter) new Parameter()
        {
          Name = "videoDuration",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("videoEmbeddable", (IParameter) new Parameter()
        {
          Name = "videoEmbeddable",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("videoLicense", (IParameter) new Parameter()
        {
          Name = "videoLicense",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("videoSyndicated", (IParameter) new Parameter()
        {
          Name = "videoSyndicated",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("videoType", (IParameter) new Parameter()
        {
          Name = "videoType",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
      }

      /// <summary>The channelType parameter lets you restrict a search to a particular type of channel.</summary>
      public enum ChannelTypeEnum
      {
        /// <summary>Return all channels.</summary>
        [StringValue("any")] Any,
        /// <summary>Only retrieve shows.</summary>
        [StringValue("show")] Show,
      }

      /// <summary>The eventType parameter restricts a search to broadcast events. If you specify a value for this
      /// parameter, you must also set the type parameter's value to video.</summary>
      public enum EventTypeEnum
      {
        /// <summary>Only include completed broadcasts.</summary>
        [StringValue("completed")] Completed,
        /// <summary>Only include active broadcasts.</summary>
        [StringValue("live")] Live,
        /// <summary>Only include upcoming broadcasts.</summary>
        [StringValue("upcoming")] Upcoming,
      }

      /// <summary>The order parameter specifies the method that will be used to order resources in the API
      /// response.</summary>
      public enum OrderEnum
      {
        /// <summary>Resources are sorted in reverse chronological order based on the date they were
        /// created.</summary>
        [StringValue("date")] Date,
        /// <summary>Resources are sorted from highest to lowest rating.</summary>
        [StringValue("rating")] Rating,
        /// <summary>Resources are sorted based on their relevance to the search query. This is the default
        /// value for this parameter.</summary>
        [StringValue("relevance")] Relevance,
        /// <summary>Resources are sorted alphabetically by title.</summary>
        [StringValue("title")] Title,
        /// <summary>Channels are sorted in descending order of their number of uploaded videos.</summary>
        [StringValue("videoCount")] VideoCount,
        /// <summary>Resources are sorted from highest to lowest number of views.</summary>
        [StringValue("viewCount")] ViewCount,
      }

      /// <summary>The safeSearch parameter indicates whether the search results should include restricted content
      /// as well as standard content.</summary>
      public enum SafeSearchEnum
      {
        /// <summary>YouTube will filter some content from search results and, at the least, will filter content
        /// that is restricted in your locale. Based on their content, search results could be removed from
        /// search results or demoted in search results. This is the default parameter value.</summary>
        [StringValue("moderate")] Moderate,
        /// <summary>YouTube will not filter the search result set.</summary>
        [StringValue("none")] None,
        /// <summary>YouTube will try to exclude all restricted content from the search result set. Based on
        /// their content, search results could be removed from search results or demoted in search
        /// results.</summary>
        [StringValue("strict")] Strict,
      }

      /// <summary>The videoCaption parameter indicates whether the API should filter video search results based
      /// on whether they have captions. If you specify a value for this parameter, you must also set the type
      /// parameter's value to video.</summary>
      public enum VideoCaptionEnum
      {
        /// <summary>Do not filter results based on caption availability.</summary>
        [StringValue("any")] Any,
        /// <summary>Only include videos that have captions.</summary>
        [StringValue("closedCaption")] ClosedCaption,
        /// <summary>Only include videos that do not have captions.</summary>
        [StringValue("none")] None,
      }

      /// <summary>The videoDefinition parameter lets you restrict a search to only include either high definition
      /// (HD) or standard definition (SD) videos. HD videos are available for playback in at least 720p, though
      /// higher resolutions, like 1080p, might also be available. If you specify a value for this parameter, you
      /// must also set the type parameter's value to video.</summary>
      public enum VideoDefinitionEnum
      {
        /// <summary>Return all videos, regardless of their resolution.</summary>
        [StringValue("any")] Any,
        /// <summary>Only retrieve HD videos.</summary>
        [StringValue("high")] High,
        /// <summary>Only retrieve videos in standard definition.</summary>
        [StringValue("standard")] Standard,
      }

      /// <summary>The videoDimension parameter lets you restrict a search to only retrieve 2D or 3D videos. If
      /// you specify a value for this parameter, you must also set the type parameter's value to video.</summary>
      public enum VideoDimensionEnum
      {
        /// <summary>Restrict search results to exclude 3D videos.</summary>
        [StringValue("2d")] Value2d,
        /// <summary>Restrict search results to only include 3D videos.</summary>
        [StringValue("3d")] Value3d,
        /// <summary>Include both 3D and non-3D videos in returned results. This is the default value.</summary>
        [StringValue("any")] Any,
      }

      /// <summary>The videoDuration parameter filters video search results based on their duration. If you
      /// specify a value for this parameter, you must also set the type parameter's value to video.</summary>
      public enum VideoDurationEnum
      {
        /// <summary>Do not filter video search results based on their duration. This is the default
        /// value.</summary>
        [StringValue("any")] Any,
        /// <summary>Only include videos longer than 20 minutes.</summary>
        [StringValue("long")] Long__,
        /// <summary>Only include videos that are between four and 20 minutes long (inclusive).</summary>
        [StringValue("medium")] Medium,
        /// <summary>Only include videos that are less than four minutes long.</summary>
        [StringValue("short")] Short__,
      }

      /// <summary>The videoEmbeddable parameter lets you to restrict a search to only videos that can be embedded
      /// into a webpage. If you specify a value for this parameter, you must also set the type parameter's value
      /// to video.</summary>
      public enum VideoEmbeddableEnum
      {
        /// <summary>Return all videos, embeddable or not.</summary>
        [StringValue("any")] Any,
        /// <summary>Only retrieve embeddable videos.</summary>
        [StringValue("true")] True__,
      }

      /// <summary>The videoLicense parameter filters search results to only include videos with a particular
      /// license. YouTube lets video uploaders choose to attach either the Creative Commons license or the
      /// standard YouTube license to each of their videos. If you specify a value for this parameter, you must
      /// also set the type parameter's value to video.</summary>
      public enum VideoLicenseEnum
      {
        /// <summary>Return all videos, regardless of which license they have, that match the query
        /// parameters.</summary>
        [StringValue("any")] Any,
        /// <summary>Only return videos that have a Creative Commons license. Users can reuse videos with this
        /// license in other videos that they create. Learn more.</summary>
        [StringValue("creativeCommon")] CreativeCommon,
        /// <summary>Only return videos that have the standard YouTube license.</summary>
        [StringValue("youtube")] Youtube,
      }

      /// <summary>The videoSyndicated parameter lets you to restrict a search to only videos that can be played
      /// outside youtube.com. If you specify a value for this parameter, you must also set the type parameter's
      /// value to video.</summary>
      public enum VideoSyndicatedEnum
      {
        /// <summary>Return all videos, syndicated or not.</summary>
        [StringValue("any")] Any,
        /// <summary>Only retrieve syndicated videos.</summary>
        [StringValue("true")] True__,
      }

      /// <summary>The videoType parameter lets you restrict a search to a particular type of videos. If you
      /// specify a value for this parameter, you must also set the type parameter's value to video.</summary>
      public enum VideoTypeEnum
      {
        /// <summary>Return all videos.</summary>
        [StringValue("any")] Any,
        /// <summary>Only retrieve episodes of shows.</summary>
        [StringValue("episode")] Episode,
        /// <summary>Only retrieve movies.</summary>
        [StringValue("movie")] Movie,
      }
    }
  }
}
