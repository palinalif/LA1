// Entities: The stuff that maps to the database that includes all the stuff
using System.Collections;

namespace AudioPool.Models.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? DateOfStart { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string? ModifiedBy { get; set; }
        
        // Foreign keys: Genre (M-to-M) - Album (M-to-M)
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}