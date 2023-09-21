using AudioPool.Models.InputModels;
using AudioPool.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AudioPool.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SongsController : ControllerBase
{
    private readonly ISongService _songService;
    public SongsController(ISongService songService)
    {
        _songService = songService;
    }

    [HttpGet("{id}", Name = "ReadSong")]
    public IActionResult GetSongById(int id) 
    {
        return Ok(_songService.ReadSong(id));
    }

    // Authorized routes
    [TokenAuthorization]
    [HttpPost("")]
    public IActionResult CreateNewSong([FromBody] SongInputModel song)
    {
        var newSongId = _songService.StoreSong(song);
        return CreatedAtRoute("ReadSong", new { id = newSongId }, null);    
    }
    [TokenAuthorization]
    [HttpPut("{id}")]
    public IActionResult UpdateSong(int id, [FromBody] SongInputModel song)
    {
        _songService.UpdateSong(id, song);
        return Ok();
    }
    [TokenAuthorization]
    [HttpDelete("{id}")]
    public IActionResult DeleteSong(int id)
    {
        _songService.RemoveSong(id);
        return Ok();
    }
}