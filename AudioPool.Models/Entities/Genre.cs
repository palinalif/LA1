// Entities: The stuff that maps to the database that includes all the stuff
namespace AudioPool.Models.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string? ModifiedBy { get; set; }
        
        // Foreign keys: Artist (M-to-M)
        public ICollection<Artist> Artists { get; set; }
    }
}