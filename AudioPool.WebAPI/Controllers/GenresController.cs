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
        var genres = _genreService.ListGenres().ToList();
        foreach (var genre in genres)
        {
            Console.WriteLine($"Genre ID: {genre.id}, Name: {genre.name}");
        }
        return Ok(genres);
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
