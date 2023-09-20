namespace AudioPool.Models.DTOs
{
    public class SongDTO : HyperMediaModel
    {
        public int id { get; set; }
        public string? name { get; set; }
        public TimeSpan duration { get; set; }
    }
}