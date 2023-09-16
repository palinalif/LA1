namespace AudioPool.Models.DTOs
{
    public class SongDTO : HyperMediaModel
    {
        public int id;
        public string? name;
        public TimeSpan duration;
    }
}