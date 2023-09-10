using AudioPool.Models.InputModels;
using Microsoft.AspNetCore.Mvc;


namespace AudioPool.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GenresController : ControllerBase
{
    [HttpGet("")]
    public IActionResult GetAllGenres() 
    {
        return Ok();
    }
    [HttpGet("{id}")]
    public IActionResult GetGenreById(int id) 
    {
        return Ok();
    }

    // Authorized endpoints
    [HttpPost("")]
    public IActionResult CreateNewGenre([FromBody] GenreInputModel genre)
    {
        return Ok();
    }
}
