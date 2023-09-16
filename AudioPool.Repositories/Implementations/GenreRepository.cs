using System.Data.Common;
using AudioPool.Models.DTOs;
using AudioPool.Models.Entities;
using AudioPool.Models.InputModels;
using AudioPool.Repositories.Contexts;
using AudioPool.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AudioPool.Repositories.Implementations
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AudioPoolDbContext _dbContext;

        public GenreRepository(AudioPoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<GenreDTO> ListGenres()
        {
            return _dbContext.Genres.Select(g => new GenreDTO{
                id = g.Id,
                name = g.Name
            });
        }

        public GenreDetailsDTO ReadGenre(int id)
        {
            var genre = _dbContext.Genres.Include(g => g.Artists).FirstOrDefault(a => a.Id == id);
            if (genre == null) { throw new KeyNotFoundException(); }

            return new GenreDetailsDTO
            {
                id = genre.Id,
                name = genre.Name,
                numberOfArtists = genre.Artists.Count()
            };
        }

        public int StoreGenre(GenreInputModel genre)
        {
            var newGenre = new Genre
            {
                Name = genre.name,
                DateCreated = DateTime.Now
            };
            _dbContext.Genres.Add(newGenre);
            _dbContext.SaveChanges();

            return newGenre.Id;
        }
    }
}