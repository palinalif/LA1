namespace AudioPool.Models.DTOs
{
    public class ArtistDTO : HyperMediaModel
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? bio { get; set; }
        public string? coverImageUrl { get; set; }
        public DateTime? dateOfStart { get; set; }
    }
}