using AudioPool.Models.InputModels;
using AudioPool.Services.Implementations;
using AudioPool.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AudioPool.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GenresController : ControllerBase
{
    private readonly IGenreService _genreService;
    public GenresController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpGet("")]
    public IActionResult GetAllGenres() 
    {
        return Ok(_genreService.ListGenres());
    }
    [HttpGet("{id}", Name = "ReadGenre")]
    public IActionResult GetGenreById(int id) 
    {
        return Ok(_genreService.ReadGenre(id));
    }

    // Authorized endpoints
    [HttpPost("")]
    public IActionResult CreateNewGenre([FromBody] GenreInputModel genre)
    {
        var newGenreId = _genreService.StoreGenre(genre);
        return CreatedAtRoute("ReadGenre", new { genreId = newGenreId });
    }
}
