using AudioPool.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace AudioPool.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SongsController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetSongById(int id) 
    {
        return Ok();
    }

    // Authorized routes
    [HttpPost("")]
    public IActionResult CreateNewSong([FromBody] SongInputModel song)
    {
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult UpdateSong(int id, [FromBody] SongInputModel song)
    {
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteSong(int id)
    {
        return Ok();
    }
}