using AudioPool.Models.DTOs;
using AudioPool.Models.InputModels;
using AudioPool.Repositories.Interfaces;
using AudioPool.Services.Interfaces;

namespace AudioPool.Services.Implementations
{
    public class GenreService : IGenreService 
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public IEnumerable<GenreDTO> ListGenres()
        {
            return _genreRepository.ListGenres();
        }

        public GenreDetailsDTO ReadGenre(int id)
        {
            return _genreRepository.ReadGenre(id);
        }

        public int StoreGenre(GenreInputModel genre)
        {
            return _genreRepository.StoreGenre(genre);
        }
    }
}