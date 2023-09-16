namespace AudioPool.Models.DTOs
{
    public class ArtistDTO : HyperMediaModel
    {
        public int id;
        public string? name;
        public string? bio;
        public string? coverImageUrl;
        public DateTime? dateOfStart;
    }
}