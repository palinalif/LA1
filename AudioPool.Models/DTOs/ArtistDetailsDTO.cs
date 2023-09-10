namespace AudioPool.Models.DTOs
{
    public class ArtistDetailsDTO
    {
         public int id;
        public string? name;
        public string? bio;
        public string? coverImageUrl;
        public DateTime? dateOfStart;
        public IEnumerable<AlbumDTO> albums;
        public IEnumerable<GenreDTO> genres;
    }
}