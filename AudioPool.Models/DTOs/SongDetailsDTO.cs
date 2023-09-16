namespace AudioPool.Models.DTOs
{
    public class SongDetailsDTO : HyperMediaModel
    {
        public int id;
        public string? name;
        public TimeSpan duration;
        public AlbumDTO album;
        public int TrackNumberOnAlbum;
    }
}