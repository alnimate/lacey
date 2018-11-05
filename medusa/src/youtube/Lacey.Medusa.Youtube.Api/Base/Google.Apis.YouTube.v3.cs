// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.YouTubeService
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.Collections.Generic;
using Google.Apis.Discovery;
using Google.Apis.Services;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>The YouTube Service.</summary>
  public class YouTubeService : BaseClientService
  {
    /// <summary>The API version.</summary>
    public const string Version = "v3";
    /// <summary>The discovery version used to generate this service.</summary>
    public static DiscoveryVersion DiscoveryVersionUsed;
    private readonly ActivitiesResource activities;
    private readonly CaptionsResource captions;
    private readonly ChannelBannersResource channelBanners;
    private readonly ChannelSectionsResource channelSections;
    private readonly ChannelsResource channels;
    private readonly CommentThreadsResource commentThreads;
    private readonly CommentsResource comments;
    private readonly GuideCategoriesResource guideCategories;
    private readonly I18nLanguagesResource i18nLanguages;
    private readonly I18nRegionsResource i18nRegions;
    private readonly LiveBroadcastsResource liveBroadcasts;
    private readonly LiveChatBansResource liveChatBans;
    private readonly LiveChatMessagesResource liveChatMessages;
    private readonly LiveChatModeratorsResource liveChatModerators;
    private readonly LiveStreamsResource liveStreams;
    private readonly PlaylistItemsResource playlistItems;
    private readonly PlaylistsResource playlists;
    private readonly SearchResource search;
    private readonly SponsorsResource sponsors;
    private readonly SubscriptionsResource subscriptions;
    private readonly SuperChatEventsResource superChatEvents;
    private readonly ThumbnailsResource thumbnails;
    private readonly VideoAbuseReportReasonsResource videoAbuseReportReasons;
    private readonly VideoCategoriesResource videoCategories;
    private readonly VideosResource videos;
    private readonly WatermarksResource watermarks;

    /// <summary>Constructs a new service.</summary>
    public YouTubeService()
      : this(new BaseClientService.Initializer())
    {
    }

    /// <summary>Constructs a new service.</summary>
    /// <param name="initializer">The service initializer.</param>
    public YouTubeService(BaseClientService.Initializer initializer)
      : base(initializer)
    {
      this.activities = new ActivitiesResource((IClientService) this);
      this.captions = new CaptionsResource((IClientService) this);
      this.channelBanners = new ChannelBannersResource((IClientService) this);
      this.channelSections = new ChannelSectionsResource((IClientService) this);
      this.channels = new ChannelsResource((IClientService) this);
      this.commentThreads = new CommentThreadsResource((IClientService) this);
      this.comments = new CommentsResource((IClientService) this);
      this.guideCategories = new GuideCategoriesResource((IClientService) this);
      this.i18nLanguages = new I18nLanguagesResource((IClientService) this);
      this.i18nRegions = new I18nRegionsResource((IClientService) this);
      this.liveBroadcasts = new LiveBroadcastsResource((IClientService) this);
      this.liveChatBans = new LiveChatBansResource((IClientService) this);
      this.liveChatMessages = new LiveChatMessagesResource((IClientService) this);
      this.liveChatModerators = new LiveChatModeratorsResource((IClientService) this);
      this.liveStreams = new LiveStreamsResource((IClientService) this);
      this.playlistItems = new PlaylistItemsResource((IClientService) this);
      this.playlists = new PlaylistsResource((IClientService) this);
      this.search = new SearchResource((IClientService) this);
      this.sponsors = new SponsorsResource((IClientService) this);
      this.subscriptions = new SubscriptionsResource((IClientService) this);
      this.superChatEvents = new SuperChatEventsResource((IClientService) this);
      this.thumbnails = new ThumbnailsResource((IClientService) this);
      this.videoAbuseReportReasons = new VideoAbuseReportReasonsResource((IClientService) this);
      this.videoCategories = new VideoCategoriesResource((IClientService) this);
      this.videos = new VideosResource((IClientService) this);
      this.watermarks = new WatermarksResource((IClientService) this);
    }

    /// <summary>Gets the service supported features.</summary>
    public override IList<string> Features
    {
      get
      {
        return (IList<string>) new string[0];
      }
    }

    /// <summary>Gets the service name.</summary>
    public override string Name
    {
      get
      {
        return "youtube";
      }
    }

    /// <summary>Gets the service base URI.</summary>
    public override string BaseUri
    {
      get
      {
        return "https://www.googleapis.com/youtube/v3/";
      }
    }

    /// <summary>Gets the service base path.</summary>
    public override string BasePath
    {
      get
      {
        return "youtube/v3/";
      }
    }

    /// <summary>Gets the batch base URI; <c>null</c> if unspecified.</summary>
    public override string BatchUri
    {
      get
      {
        return "https://www.googleapis.com/batch/youtube/v3";
      }
    }

    /// <summary>Gets the batch base path; <c>null</c> if unspecified.</summary>
    public override string BatchPath
    {
      get
      {
        return "batch/youtube/v3";
      }
    }

    /// <summary>Gets the Activities resource.</summary>
    public virtual ActivitiesResource Activities
    {
      get
      {
        return this.activities;
      }
    }

    /// <summary>Gets the Captions resource.</summary>
    public virtual CaptionsResource Captions
    {
      get
      {
        return this.captions;
      }
    }

    /// <summary>Gets the ChannelBanners resource.</summary>
    public virtual ChannelBannersResource ChannelBanners
    {
      get
      {
        return this.channelBanners;
      }
    }

    /// <summary>Gets the ChannelSections resource.</summary>
    public virtual ChannelSectionsResource ChannelSections
    {
      get
      {
        return this.channelSections;
      }
    }

    /// <summary>Gets the Channels resource.</summary>
    public virtual ChannelsResource Channels
    {
      get
      {
        return this.channels;
      }
    }

    /// <summary>Gets the CommentThreads resource.</summary>
    public virtual CommentThreadsResource CommentThreads
    {
      get
      {
        return this.commentThreads;
      }
    }

    /// <summary>Gets the Comments resource.</summary>
    public virtual CommentsResource Comments
    {
      get
      {
        return this.comments;
      }
    }

    /// <summary>Gets the GuideCategories resource.</summary>
    public virtual GuideCategoriesResource GuideCategories
    {
      get
      {
        return this.guideCategories;
      }
    }

    /// <summary>Gets the I18nLanguages resource.</summary>
    public virtual I18nLanguagesResource I18nLanguages
    {
      get
      {
        return this.i18nLanguages;
      }
    }

    /// <summary>Gets the I18nRegions resource.</summary>
    public virtual I18nRegionsResource I18nRegions
    {
      get
      {
        return this.i18nRegions;
      }
    }

    /// <summary>Gets the LiveBroadcasts resource.</summary>
    public virtual LiveBroadcastsResource LiveBroadcasts
    {
      get
      {
        return this.liveBroadcasts;
      }
    }

    /// <summary>Gets the LiveChatBans resource.</summary>
    public virtual LiveChatBansResource LiveChatBans
    {
      get
      {
        return this.liveChatBans;
      }
    }

    /// <summary>Gets the LiveChatMessages resource.</summary>
    public virtual LiveChatMessagesResource LiveChatMessages
    {
      get
      {
        return this.liveChatMessages;
      }
    }

    /// <summary>Gets the LiveChatModerators resource.</summary>
    public virtual LiveChatModeratorsResource LiveChatModerators
    {
      get
      {
        return this.liveChatModerators;
      }
    }

    /// <summary>Gets the LiveStreams resource.</summary>
    public virtual LiveStreamsResource LiveStreams
    {
      get
      {
        return this.liveStreams;
      }
    }

    /// <summary>Gets the PlaylistItems resource.</summary>
    public virtual PlaylistItemsResource PlaylistItems
    {
      get
      {
        return this.playlistItems;
      }
    }

    /// <summary>Gets the Playlists resource.</summary>
    public virtual PlaylistsResource Playlists
    {
      get
      {
        return this.playlists;
      }
    }

    /// <summary>Gets the Search resource.</summary>
    public virtual SearchResource Search
    {
      get
      {
        return this.search;
      }
    }

    /// <summary>Gets the Sponsors resource.</summary>
    public virtual SponsorsResource Sponsors
    {
      get
      {
        return this.sponsors;
      }
    }

    /// <summary>Gets the Subscriptions resource.</summary>
    public virtual SubscriptionsResource Subscriptions
    {
      get
      {
        return this.subscriptions;
      }
    }

    /// <summary>Gets the SuperChatEvents resource.</summary>
    public virtual SuperChatEventsResource SuperChatEvents
    {
      get
      {
        return this.superChatEvents;
      }
    }

    /// <summary>Gets the Thumbnails resource.</summary>
    public virtual ThumbnailsResource Thumbnails
    {
      get
      {
        return this.thumbnails;
      }
    }

    /// <summary>Gets the VideoAbuseReportReasons resource.</summary>
    public virtual VideoAbuseReportReasonsResource VideoAbuseReportReasons
    {
      get
      {
        return this.videoAbuseReportReasons;
      }
    }

    /// <summary>Gets the VideoCategories resource.</summary>
    public virtual VideoCategoriesResource VideoCategories
    {
      get
      {
        return this.videoCategories;
      }
    }

    /// <summary>Gets the Videos resource.</summary>
    public virtual VideosResource Videos
    {
      get
      {
        return this.videos;
      }
    }

    /// <summary>Gets the Watermarks resource.</summary>
    public virtual WatermarksResource Watermarks
    {
      get
      {
        return this.watermarks;
      }
    }

    /// <summary>Available OAuth 2.0 scopes for use with the YouTube Data API.</summary>
    public class Scope
    {
      /// <summary>Manage your YouTube account</summary>
      public static string Youtube = "https://www.googleapis.com/auth/youtube";
      /// <summary>Manage your YouTube account</summary>
      public static string YoutubeForceSsl = "https://www.googleapis.com/auth/youtube.force-ssl";
      /// <summary>View your YouTube account</summary>
      public static string YoutubeReadonly = "https://www.googleapis.com/auth/youtube.readonly";
      /// <summary>Manage your YouTube videos</summary>
      public static string YoutubeUpload = "https://www.googleapis.com/auth/youtube.upload";
      /// <summary>View and manage your assets and associated content on YouTube</summary>
      public static string Youtubepartner = "https://www.googleapis.com/auth/youtubepartner";
      /// <summary>View private information of your YouTube channel relevant during the audit process with a
      /// YouTube partner</summary>
      public static string YoutubepartnerChannelAudit = "https://www.googleapis.com/auth/youtubepartner-channel-audit";
    }
  }
}
