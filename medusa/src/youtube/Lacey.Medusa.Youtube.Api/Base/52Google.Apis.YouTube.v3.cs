// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ChannelContentDetails
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Details about the content of a channel.</summary>
  public class ChannelContentDetails : IDirectResponseSchema
  {
    [JsonProperty("relatedPlaylists")]
    public virtual ChannelContentDetails.RelatedPlaylistsData RelatedPlaylists { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }

    public class RelatedPlaylistsData
    {
      /// <summary>The ID of the playlist that contains the channel"s favorite videos. Use the
      /// playlistItems.insert and  playlistItems.delete to add or remove items from that list.</summary>
      [JsonProperty("favorites")]
      public virtual string Favorites { get; set; }

      /// <summary>The ID of the playlist that contains the channel"s liked videos. Use the   playlistItems.insert
      /// and  playlistItems.delete to add or remove items from that list.</summary>
      [JsonProperty("likes")]
      public virtual string Likes { get; set; }

      /// <summary>The ID of the playlist that contains the channel"s uploaded videos. Use the  videos.insert
      /// method to upload new videos and the videos.delete method to delete previously uploaded videos.</summary>
      [JsonProperty("uploads")]
      public virtual string Uploads { get; set; }

      /// <summary>The ID of the playlist that contains the channel"s watch history. Use the  playlistItems.insert
      /// and  playlistItems.delete to add or remove items from that list.</summary>
      [JsonProperty("watchHistory")]
      public virtual string WatchHistory { get; set; }

      /// <summary>The ID of the playlist that contains the channel"s watch later playlist. Use the
      /// playlistItems.insert and  playlistItems.delete to add or remove items from that list.</summary>
      [JsonProperty("watchLater")]
      public virtual string WatchLater { get; set; }
    }
  }
}
