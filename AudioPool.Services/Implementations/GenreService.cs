using AudioPool.Models.DTOs;
using AudioPool.Models.InputModels;
using AudioPool.Repositories.Interfaces;
using AudioPool.Services.Interfaces;
using AudioPool.Models;

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
            var genres = _genreRepository.ListGenres();
            if (genres == null) { return null; }
            return genres;
        }

        public GenreDetailsDTO ReadGenre(int id)
        {
            var genre = _genreRepository.ReadGenre(id);
            if (genre == null) { return null; }
            return genre;
        }

        public int StoreGenre(GenreInputModel genre)
        {
            return _genreRepository.StoreGenre(genre);
        }
    }
}