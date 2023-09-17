using AudioPool.Models.DTOs;
using AudioPool.Models.InputModels;

namespace AudioPool.Services.Interfaces
{
    public interface IGenreService
    {
        int StoreGenre(GenreInputModel genre);
        IEnumerable<GenreDTO> ListGenres();
        GenreDetailsDTO ReadGenre(int id);
    }
}