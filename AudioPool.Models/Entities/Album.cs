// Entities: The stuff that maps to the database that includes all the stuff
using System.Collections;

namespace AudioPool.Models.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        public string? ModifiedBy { get; set; }
        
        // Foreign keys: Artist (M-to-M), Song (1-to-M)
        public ICollection<Artist> Artists { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}