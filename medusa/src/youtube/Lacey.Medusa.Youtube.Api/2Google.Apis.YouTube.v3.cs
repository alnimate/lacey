// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.ActivitiesResource
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System;
using Google.Apis.Discovery;
using Google.Apis.Services;
using Google.Apis.Util;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>The "activities" collection of methods.</summary>
  public class ActivitiesResource
  {
    private const string Resource = "activities";
    /// <summary>The service which this resource belongs to.</summary>
    private readonly IClientService service;

    /// <summary>Constructs a new resource.</summary>
    public ActivitiesResource(IClientService service)
    {
      this.service = service;
    }

    /// <summary>Posts a bulletin for a specific channel. (The user submitting the request must be authorized to act
    /// on the channel's behalf.)
    /// 
    /// Note: Even though an activity resource can contain information about actions like a user rating a video or
    /// marking a video as a favorite, you need to use other API methods to generate those activity resources. For
    /// example, you would use the API's videos.rate() method to rate a video and the playlistItems.insert() method
    /// to mark a video as a favorite.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter serves two purposes in this operation. It identifies the properties that the
    /// write operation will set as well as the properties that the API response will include.</param>
    public virtual ActivitiesResource.InsertRequest Insert(Activity body, string part)
    {
      return new ActivitiesResource.InsertRequest(this.service, body, part);
    }

    /// <summary>Returns a list of channel activity events that match the request criteria. For example, you can
    /// retrieve events associated with a particular channel, events associated with the user's subscriptions and
    /// Google+ friends, or the YouTube home page feed, which is customized for each user.</summary>
    /// <param name="part">The part parameter specifies a comma-separated list of one or more activity resource properties
    /// that the API response will include.
    /// 
    /// If the parameter identifies a property that contains child properties, the child properties will be included in the
    /// response. For example, in an activity resource, the snippet property contains other properties that identify the
    /// type of activity, a display title for the activity, and so forth. If you set part=snippet, the API response will
    /// also contain all of those nested properties.</param>
    public virtual ActivitiesResource.ListRequest List(string part)
    {
      return new ActivitiesResource.ListRequest(this.service, part);
    }

    /// <summary>Posts a bulletin for a specific channel. (The user submitting the request must be authorized to act
    /// on the channel's behalf.)
    /// 
    /// Note: Even though an activity resource can contain information about actions like a user rating a video or
    /// marking a video as a favorite, you need to use other API methods to generate those activity resources. For
    /// example, you would use the API's videos.rate() method to rate a video and the playlistItems.insert() method
    /// to mark a video as a favorite.</summary>
    public class InsertRequest : YouTubeBaseServiceRequest<Activity>
    {
      /// <summary>Constructs a new Insert request.</summary>
      public InsertRequest(IClientService service, Activity body, string part)
        : base(service)
      {
        this.Part = part;
        this.Body = body;
        this.InitParameters();
      }

      /// <summary>The part parameter serves two purposes in this operation. It identifies the properties that the
      /// write operation will set as well as the properties that the API response will include.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>Gets or sets the body of this request.</summary>
      private Activity Body { get; set; }

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
          return "activities";
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

    /// <summary>Returns a list of channel activity events that match the request criteria. For example, you can
    /// retrieve events associated with a particular channel, events associated with the user's subscriptions and
    /// Google+ friends, or the YouTube home page feed, which is customized for each user.</summary>
    public class ListRequest : YouTubeBaseServiceRequest<ActivityListResponse>
    {
      /// <summary>Constructs a new List request.</summary>
      public ListRequest(IClientService service, string part)
        : base(service)
      {
        this.Part = part;
        this.InitParameters();
      }

      /// <summary>The part parameter specifies a comma-separated list of one or more activity resource properties
      /// that the API response will include.
      /// 
      /// If the parameter identifies a property that contains child properties, the child properties will be
      /// included in the response. For example, in an activity resource, the snippet property contains other
      /// properties that identify the type of activity, a display title for the activity, and so forth. If you
      /// set part=snippet, the API response will also contain all of those nested properties.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>The channelId parameter specifies a unique YouTube channel ID. The API will then return a list
      /// of that channel's activities.</summary>
      [RequestParameter("channelId", RequestParameterType.Query)]
      public virtual string ChannelId { get; set; }

      /// <summary>Set this parameter's value to true to retrieve the activity feed that displays on the YouTube
      /// home page for the currently authenticated user.</summary>
      [RequestParameter("home", RequestParameterType.Query)]
      public virtual bool? Home { get; set; }

      /// <summary>The maxResults parameter specifies the maximum number of items that should be returned in the
      /// result set.</summary>
      /// 
      ///             [default: 5]
      ///             [minimum: 0]
      ///             [maximum: 50]
      [RequestParameter("maxResults", RequestParameterType.Query)]
      public virtual long? MaxResults { get; set; }

      /// <summary>Set this parameter's value to true to retrieve a feed of the authenticated user's
      /// activities.</summary>
      [RequestParameter("mine", RequestParameterType.Query)]
      public virtual bool? Mine { get; set; }

      /// <summary>The pageToken parameter identifies a specific page in the result set that should be returned.
      /// In an API response, the nextPageToken and prevPageToken properties identify other pages that could be
      /// retrieved.</summary>
      [RequestParameter("pageToken", RequestParameterType.Query)]
      public virtual string PageToken { get; set; }

      /// <summary>The publishedAfter parameter specifies the earliest date and time that an activity could have
      /// occurred for that activity to be included in the API response. If the parameter value specifies a day,
      /// but not a time, then any activities that occurred that day will be included in the result set. The value
      /// is specified in ISO 8601 (YYYY-MM-DDThh:mm:ss.sZ) format.</summary>
      [RequestParameter("publishedAfter", RequestParameterType.Query)]
      public virtual DateTime? PublishedAfter { get; set; }

      /// <summary>The publishedBefore parameter specifies the date and time before which an activity must have
      /// occurred for that activity to be included in the API response. If the parameter value specifies a day,
      /// but not a time, then any activities that occurred that day will be excluded from the result set. The
      /// value is specified in ISO 8601 (YYYY-MM-DDThh:mm:ss.sZ) format.</summary>
      [RequestParameter("publishedBefore", RequestParameterType.Query)]
      public virtual DateTime? PublishedBefore { get; set; }

      /// <summary>The regionCode parameter instructs the API to return results for the specified country. The
      /// parameter value is an ISO 3166-1 alpha-2 country code. YouTube uses this value when the authorized
      /// user's previous activity on YouTube does not provide enough information to generate the activity
      /// feed.</summary>
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
          return "activities";
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
        this.RequestParameters.Add("home", (IParameter) new Parameter()
        {
          Name = "home",
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
        this.RequestParameters.Add("mine", (IParameter) new Parameter()
        {
          Name = "mine",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
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
