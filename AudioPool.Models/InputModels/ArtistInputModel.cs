// Input value: What we want the input to look like
using System.ComponentModel.DataAnnotations;

namespace AudioPool.Models.InputModels
{
    public class ArtistInputModel
    {
        [Required]
        [MinLength(3)]
        public string? name { get; set; }
        [MinLength(10)]
        public string bio { get; set; }
        [Url]
        public string coverImageUrl { get; set; }
        [Required]
        public DateTime dateOfStart { get; set; }
    }
}