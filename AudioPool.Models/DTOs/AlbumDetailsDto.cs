namespace AudioPool.Models.DTOs
{
    public class AlbumDetailsDTO : HyperMediaModel
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