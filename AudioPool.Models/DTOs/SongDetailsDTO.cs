namespace AudioPool.Models.DTOs
{
    public class SongDetailsDTO : HyperMediaModel
    {
        public int id { get; set; }
        public string? name { get; set; }
        public TimeSpan duration { get; set; }
        public AlbumDTO album { get; set; }
        public int TrackNumberOnAlbum { get; set; }
    }
}