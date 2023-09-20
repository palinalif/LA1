using AudioPool.Models.Entities;
using AudioPool.Models.InputModels;
using AudioPool.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AudioPool.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AlbumsController : ControllerBase
{
    private readonly IAlbumService _albumService;
    public AlbumsController(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    [HttpGet("{id}", Name = "ReadAlbum")]
    public IActionResult GetAlbumById(int id) 
    {
        return Ok(_albumService.ReadAlbum(id));
    }
    [HttpGet("{id}/songs")]
    public IActionResult GetSongsOnAlbum(int id) 
    {
        return Ok(_albumService.ListSongsOnAlbum(id));
    }

    // Authorized routes
    [HttpPost("")]
    public IActionResult CreateNewAlbum([FromBody] AlbumInputModel album)
    {
        var newAlbumId = _albumService.StoreAlbum(album);
        return CreatedAtRoute("ReadAlbum", new { id = newAlbumId }, null);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteAlbumById(int id)
    {
        _albumService.RemoveAlbum(id);
        return NoContent();
    }
}
