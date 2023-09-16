namespace AudioPool.Models.DTOs
{
    public class AlbumDTO : HyperMediaModel
    {
        public int id;
        public string? name;
        public DateTime releaseDate;
        public string? coverImageUrl;
        public string? description;
    }
}