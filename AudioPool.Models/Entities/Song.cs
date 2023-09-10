// Entities: The stuff that maps to the database that includes all the stuff
namespace AudioPool.Models.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string? ModifiedBy { get; set; }
        
        // Foreign keys: Album (1-to-M)
        public Album Album { get; set; }
    }
}