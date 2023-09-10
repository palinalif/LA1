// Input value: What we want the input to look like
using System.ComponentModel.DataAnnotations;

namespace AudioPool.Models.InputModels
{
    public class AlbumInputModel
    {
        [Required]
        [MinLength(3)]
        public string? name { get; set; }
        [Required]
        public DateTime releaseDate { get; set; }
        [Required]
        public IEnumerable<int> artistIds { get; set; }
        [Url]
        public string coverImageUrl { get; set; }
        [MinLength(10)]
        public string description { get; set; }
    }
}