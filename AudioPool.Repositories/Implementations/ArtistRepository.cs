using AudioPool.Models.DTOs;
using AudioPool.Models.Entities;
using AudioPool.Models.InputModels;
using AudioPool.Repositories.Contexts;
using AudioPool.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.VisualBasic;

namespace AudioPool.Repositories.Implementations
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly AudioPoolDbContext _dbContext;
        public ArtistRepository(AudioPoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void AddGenreToArtist(int id, int genreId)
        {
            var artist = _dbContext.Artists.Include(a => a.Genres).FirstOrDefault(a => a.Id == id);
            if (artist == null) { throw new KeyNotFoundException(); }

            // find genre with that id
            var genre = _dbContext.Genres.Find(genreId);
            if (genre == null) { throw new KeyNotFoundException(); }
            artist.Genres.Add(genre);
            _dbContext.SaveChanges();
        }

        public IEnumerable<AlbumDTO> ListArtistAlbums(int id)
        {
            var artist = _dbContext.Artists.Include(a => a.Albums).FirstOrDefault(a => a.Id == id);
            if (artist == null) { throw new KeyNotFoundException(); }
            return artist.Albums.Select(a => new AlbumDTO
            {
                id = a.Id,
                name = a.Name,
                releaseDate = a.ReleaseDate,
                coverImageUrl = a.CoverImageUrl,
                description = a.Description
            });
        }

        public IEnumerable<ArtistDTO> ListArtists()
        {
            return _dbContext.Artists.Select(a => new ArtistDTO{
                id = a.Id,
                name = a.Name,
                bio = a.Bio,
                coverImageUrl = a.CoverImageUrl,
                dateOfStart = a.DateOfStart
            });
        }

        public ArtistDetailsDTO ReadArtist(int id)
        {
            var artist = _dbContext.Artists.Include(a => a.Albums).Include(a => a.Genres).FirstOrDefault(a => a.Id == id);
            if (artist == null) { throw new KeyNotFoundException(); }
            var artistAlbums = artist.Albums?.Select(a => new AlbumDTO
            {
                id = a.Id,
                name = a.Name,
                releaseDate = a.ReleaseDate,
                coverImageUrl = a.CoverImageUrl,
                description = a.Description
            }) ?? Enumerable.Empty<AlbumDTO>();
            var artistGenres = artist.Genres?.Select(g => new GenreDTO
            {
                id = g.Id,
                name = g.Name
            }) ?? Enumerable.Empty<GenreDTO>();;
            return new ArtistDetailsDTO
            {
                id = artist.Id,
                name = artist.Name,
                bio = artist.Bio,
                coverImageUrl = artist.CoverImageUrl,
                dateOfStart = artist.DateOfStart,
                albums = artistAlbums,
                genres = artistGenres
            };
        }

        public int StoreArtist(ArtistInputModel artist)
        {
            var newArtist = new Artist
            {
                Name = artist.name,
                Bio = artist.bio,
                CoverImageUrl = artist.coverImageUrl,
                DateOfStart = artist.dateOfStart,
                DateCreated = DateTime.Now
            };

            _dbContext.Artists.Add(newArtist);
            _dbContext.SaveChanges();
            return newArtist.Id;
        }

        public void UpdateArtist(int id, ArtistInputModel updatedArtist)
        {
            var artist = _dbContext.Artists.Find(id);
            if (artist == null) { throw new KeyNotFoundException(); }
            artist.Name = updatedArtist.name;
            artist.Bio = updatedArtist.bio;
            artist.CoverImageUrl = updatedArtist.coverImageUrl;
            artist.DateOfStart = updatedArtist.dateOfStart;
            artist.DateModified = DateTime.Now;
            artist.ModifiedBy = "AudioPoolAdmin";
            _dbContext.SaveChanges();
        }
    }
}