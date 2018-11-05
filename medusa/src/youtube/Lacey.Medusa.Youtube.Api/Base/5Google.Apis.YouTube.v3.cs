// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.ChannelSectionsResource
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Discovery;
using Lacey.Medusa.Common.Api.Core.Base.Util;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>The "channelSections" collection of methods.</summary>
  internal class ChannelSectionsResource
  {
    private const string Resource = "channelSections";
    /// <summary>The service which this resource belongs to.</summary>
    private readonly IClientService service;

    /// <summary>Constructs a new resource.</summary>
    public ChannelSectionsResource(IClientService service)
    {
      this.service = service;
    }

    /// <summary>Deletes a channelSection.</summary>
    /// <param name="id">The id parameter specifies the YouTube channelSection ID for the resource that is being deleted. In
    /// a channelSection resource, the id property specifies the YouTube channelSection ID.</param>
    public virtual ChannelSectionsResource.DeleteRequest Delete(string id)
    {
      return new ChannelSectionsResource.DeleteRequest(this.service, id);
    }

    /// <summary>Adds a channelSection for the authenticated user's channel.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter serves two purposes in this operation. It identifies the properties that the
    /// write operation will set as well as the properties that the API response will include.
    /// 
    /// The part names that you can include in the parameter value are snippet and contentDetails.</param>
    public virtual ChannelSectionsResource.InsertRequest Insert(ChannelSection body, string part)
    {
      return new ChannelSectionsResource.InsertRequest(this.service, body, part);
    }

    /// <summary>Returns channelSection resources that match the API request criteria.</summary>
    /// <param name="part">The part parameter specifies a comma-separated list of one or more channelSection resource
    /// properties that the API response will include. The part names that you can include in the parameter value are id,
    /// snippet, and contentDetails.
    /// 
    /// If the parameter identifies a property that contains child properties, the child properties will be included in the
    /// response. For example, in a channelSection resource, the snippet property contains other properties, such as a
    /// display title for the channelSection. If you set part=snippet, the API response will also contain all of those
    /// nested properties.</param>
    public virtual ChannelSectionsResource.ListRequest List(string part)
    {
      return new ChannelSectionsResource.ListRequest(this.service, part);
    }

    /// <summary>Update a channelSection.</summary>
    /// <param name="body">The body of the request.</param>
    /// <param name="part">The part parameter serves two purposes in this operation. It identifies the properties that the
    /// write operation will set as well as the properties that the API response will include.
    /// 
    /// The part names that you can include in the parameter value are snippet and contentDetails.</param>
    public virtual ChannelSectionsResource.UpdateRequest Update(ChannelSection body, string part)
    {
      return new ChannelSectionsResource.UpdateRequest(this.service, body, part);
    }

    /// <summary>Deletes a channelSection.</summary>
    internal class DeleteRequest : YouTubeBaseServiceRequest<string>
    {
      /// <summary>Constructs a new Delete request.</summary>
      public DeleteRequest(IClientService service, string id)
        : base(service)
      {
        this.Id = id;
        this.InitParameters();
      }

      /// <summary>The id parameter specifies the YouTube channelSection ID for the resource that is being
      /// deleted. In a channelSection resource, the id property specifies the YouTube channelSection
      /// ID.</summary>
      [RequestParameter("id", RequestParameterType.Query)]
      public virtual string Id { get; private set; }

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
          return "channelSections";
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

    /// <summary>Adds a channelSection for the authenticated user's channel.</summary>
    internal class InsertRequest : YouTubeBaseServiceRequest<ChannelSection>
    {
      /// <summary>Constructs a new Insert request.</summary>
      public InsertRequest(IClientService service, ChannelSection body, string part)
        : base(service)
      {
        this.Part = part;
        this.Body = body;
        this.InitParameters();
      }

      /// <summary>The part parameter serves two purposes in this operation. It identifies the properties that the
      /// write operation will set as well as the properties that the API response will include.
      /// 
      /// The part names that you can include in the parameter value are snippet and contentDetails.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

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

      /// <summary>This parameter can only be used in a properly authorized request. Note: This parameter is
      /// intended exclusively for YouTube content partners.
      /// 
      /// The onBehalfOfContentOwnerChannel parameter specifies the YouTube channel ID of the channel to which a
      /// video is being added. This parameter is required when a request specifies a value for the
      /// onBehalfOfContentOwner parameter, and it can only be used in conjunction with that parameter. In
      /// addition, the request must be authorized using a CMS account that is linked to the content owner that
      /// the onBehalfOfContentOwner parameter specifies. Finally, the channel that the
      /// onBehalfOfContentOwnerChannel parameter value specifies must be linked to the content owner that the
      /// onBehalfOfContentOwner parameter specifies.
      /// 
      /// This parameter is intended for YouTube content partners that own and manage many different YouTube
      /// channels. It allows content owners to authenticate once and perform actions on behalf of the channel
      /// specified in the parameter value, without having to provide authentication credentials for each separate
      /// channel.</summary>
      [RequestParameter("onBehalfOfContentOwnerChannel", RequestParameterType.Query)]
      public virtual string OnBehalfOfContentOwnerChannel { get; set; }

      /// <summary>Gets or sets the body of this request.</summary>
      private ChannelSection Body { get; set; }

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
          return "channelSections";
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
        this.RequestParameters.Add("onBehalfOfContentOwner", (IParameter) new Parameter()
        {
          Name = "onBehalfOfContentOwner",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
        this.RequestParameters.Add("onBehalfOfContentOwnerChannel", (IParameter) new Parameter()
        {
          Name = "onBehalfOfContentOwnerChannel",
          IsRequired = false,
          ParameterType = "query",
          DefaultValue = (string) null,
          Pattern = (string) null
        });
      }
    }

    /// <summary>Returns channelSection resources that match the API request criteria.</summary>
    internal class ListRequest : YouTubeBaseServiceRequest<ChannelSectionListResponse>
    {
      /// <summary>Constructs a new List request.</summary>
      public ListRequest(IClientService service, string part)
        : base(service)
      {
        this.Part = part;
        this.InitParameters();
      }

      /// <summary>The part parameter specifies a comma-separated list of one or more channelSection resource
      /// properties that the API response will include. The part names that you can include in the parameter
      /// value are id, snippet, and contentDetails.
      /// 
      /// If the parameter identifies a property that contains child properties, the child properties will be
      /// included in the response. For example, in a channelSection resource, the snippet property contains other
      /// properties, such as a display title for the channelSection. If you set part=snippet, the API response
      /// will also contain all of those nested properties.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

      /// <summary>The channelId parameter specifies a YouTube channel ID. The API will only return that channel's
      /// channelSections.</summary>
      [RequestParameter("channelId", RequestParameterType.Query)]
      public virtual string ChannelId { get; set; }

      /// <summary>The hl parameter indicates that the snippet.localized property values in the returned
      /// channelSection resources should be in the specified language if localized values for that language are
      /// available. For example, if the API request specifies hl=de, the snippet.localized properties in the API
      /// response will contain German titles if German titles are available. Channel owners can provide localized
      /// channel section titles using either the channelSections.insert or channelSections.update
      /// method.</summary>
      [RequestParameter("hl", RequestParameterType.Query)]
      public virtual string Hl { get; set; }

      /// <summary>The id parameter specifies a comma-separated list of the YouTube channelSection ID(s) for the
      /// resource(s) that are being retrieved. In a channelSection resource, the id property specifies the
      /// YouTube channelSection ID.</summary>
      [RequestParameter("id", RequestParameterType.Query)]
      public virtual string Id { get; set; }

      /// <summary>Set this parameter's value to true to retrieve a feed of the authenticated user's
      /// channelSections.</summary>
      [RequestParameter("mine", RequestParameterType.Query)]
      public virtual bool? Mine { get; set; }

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
          return "channelSections";
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
        this.RequestParameters.Add("hl", (IParameter) new Parameter()
        {
          Name = "hl",
          IsRequired = false,
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
        this.RequestParameters.Add("mine", (IParameter) new Parameter()
        {
          Name = "mine",
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

    /// <summary>Update a channelSection.</summary>
    internal class UpdateRequest : YouTubeBaseServiceRequest<ChannelSection>
    {
      /// <summary>Constructs a new Update request.</summary>
      public UpdateRequest(IClientService service, ChannelSection body, string part)
        : base(service)
      {
        this.Part = part;
        this.Body = body;
        this.InitParameters();
      }

      /// <summary>The part parameter serves two purposes in this operation. It identifies the properties that the
      /// write operation will set as well as the properties that the API response will include.
      /// 
      /// The part names that you can include in the parameter value are snippet and contentDetails.</summary>
      [RequestParameter("part", RequestParameterType.Query)]
      public virtual string Part { get; private set; }

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
      private ChannelSection Body { get; set; }

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
          return "channelSections";
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
