namespace AudioPool.Models.DTOs
{
    public class GenreDetailsDTO : HyperMediaModel
    {
        public int id { get; set; }
        public string? name { get; set; }
        public int numberOfArtists { get; set; }
    }
}