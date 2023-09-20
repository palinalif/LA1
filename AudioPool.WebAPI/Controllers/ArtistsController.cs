using AudioPool.Models.InputModels;
using AudioPool.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AudioPool.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtistsController : ControllerBase
{
    private readonly IArtistService _artistService;
    public ArtistsController(IArtistService artistService)
    {
        _artistService = artistService;
    }

    [HttpGet("")]
    public IActionResult GetAllArtists([FromQuery] int pageSize ) 
    {
        return Ok(_artistService.ListArtists());
    }
    [HttpGet("{id}", Name = "ReadArtist")]
    public IActionResult GetArtistById(int id) 
    {
        return Ok(_artistService.ReadArtist(id));
    }
    [HttpGet("{id}/albums")]
    public IActionResult GetAllArtistAlbums(int id) 
    {
        return Ok(_artistService.ListArtistAlbums(id));
    }

    // Authorized routes
    [HttpPost("")]
    public IActionResult CreateNewArtist([FromBody] ArtistInputModel artist)
    {
        var newArtistId = _artistService.StoreArtist(artist);
        return CreatedAtRoute("ReadArtist", new { id = newArtistId }, null);
    }
    [HttpPut("{id}")]
    public IActionResult UpdateArtist(int id, [FromBody] ArtistInputModel artist)
    {
        _artistService.UpdateArtist(id, artist);
        return NoContent();
    }
    [HttpPatch("{artistId}/genres/{genreId}")]
    public IActionResult AddGenreToArtist(int artistId, int genreId) 
    {
        _artistService.AddGenreToArtist(artistId, genreId);
        return NoContent();
    }
}
