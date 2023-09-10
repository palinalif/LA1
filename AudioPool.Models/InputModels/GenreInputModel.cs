// Input value: What we want the input to look like
using System.ComponentModel.DataAnnotations;

namespace AudioPool.Models.InputModels
{
    public class GenreInputModel
    {
        [Required]
        [MinLength(3)]
        public string? name { get; set; }
    }
}