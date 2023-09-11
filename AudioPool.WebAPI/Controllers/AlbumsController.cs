using AudioPool.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace AudioPool.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AlbumsController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetAlbumById(int id) 
    {
        return Ok();
    }
    [HttpGet("{id}/songs")]
    public IActionResult GetSongsOnAlbum(int id) 
    {
        return Ok();
    }

    // Authorized routes
    [HttpPost("")]
    public IActionResult CreateNewAlbum([FromBody] AlbumInputModel album)
    {
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteAlbumById(int id)
    {
        return Ok();
    }
}
