namespace AudioPool.Models.DTOs
{
    public class AlbumDetailsDTO : HyperMediaModel
    {
        public int id { get; set; }
        public string? name { get; set; }
        public DateTime releaseDate { get; set; }
        public string? coverImageUrl { get; set; }
        public string? description { get; set; }
        public IEnumerable<ArtistDTO> artists { get; set; }
        public IEnumerable<SongDTO> songs { get; set; }
    }
}