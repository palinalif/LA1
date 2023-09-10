// Input value: What we want the input to look like
using System.ComponentModel.DataAnnotations;

namespace AudioPool.Models.InputModels
{
    public class SongInputModel
    {
        [Required]
        [MinLength(3)]
        public string? name { get; set; }
        [Required]
        public TimeSpan duration { get; set; }
        [Required]
        public int albumId { get; set; }
    }
}