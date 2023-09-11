using AudioPool.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace AudioPool.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtistsController : ControllerBase
{
    [HttpGet("")]
    public IActionResult GetAllArtists([FromQuery] int pageSize ) 
    {
        return Ok();
    }
    [HttpGet("{id}")]
    public IActionResult GetArtistById(int id) 
    {
        return Ok();
    }
    [HttpGet("{id}/albums")]
    public IActionResult GetAllArtistAlbums(int id) 
    {
        return Ok();
    }

    // Authorized routes
    [HttpPost("")]
    public IActionResult CreateNewArtist([FromBody] ArtistInputModel artist)
    {
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult UpdateArtist(int id, [FromBody] ArtistInputModel artist)
    {
        return Ok();
    }
    [HttpPatch("{artistId}/genres/{genreId}")]
    public IActionResult AddGenreToArtist(int artistId, int genreId) 
    {
        return Ok();
    }
}
