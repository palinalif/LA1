using AudioPool.Models.DTOs;
using AudioPool.Models.InputModels;

namespace AudioPool.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        int StoreGenre(GenreInputModel genre);
        IEnumerable<GenreDTO> ListGenres();
        GenreDetailsDTO ReadGenre(int id);
    }
}