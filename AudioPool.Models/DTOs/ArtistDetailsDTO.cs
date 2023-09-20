namespace AudioPool.Models.DTOs
{
    public class ArtistDetailsDTO : HyperMediaModel
    {
         public int id { get; set; }
        public string? name { get; set; }
        public string? bio { get; set; }
        public string? coverImageUrl { get; set; }
        public DateTime? dateOfStart { get; set; }
        public IEnumerable<AlbumDTO> albums { get; set; }
        public IEnumerable<GenreDTO> genres { get; set; }
    }
}