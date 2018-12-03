namespace Lacey.Medusa.Youtube.Domain.Entities
{
    public class PlaylistVideoEntity
    {
        public int PlaylistId { get; set; }

        public int VideoId { get; set; }

        public virtual PlaylistEntity Playlist { get; set; }

        public virtual VideoEntity Video { get; set; }
    }
}