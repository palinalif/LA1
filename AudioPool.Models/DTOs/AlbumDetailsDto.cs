namespace AudioPool.Models.DTOs
{
    public class AlbumDetailsDTO
    {
        public int id;
        public string? name;
        public DateTime releaseDate;
        public string? coverImageUrl;
        public string? description;
        public IEnumerable<ArtistDTO> artists;
        public IEnumerable<SongDTO> songs;
    }
}