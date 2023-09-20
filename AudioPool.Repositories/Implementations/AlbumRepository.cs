using AudioPool.Models.DTOs;
using AudioPool.Models.Entities;
using AudioPool.Models.InputModels;
using AudioPool.Repositories.Contexts;
using AudioPool.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AudioPool.Repositories.Implementations
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly AudioPoolDbContext _dbContext;

        public AlbumRepository(AudioPoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<SongDTO> ListSongsOnAlbum(int id)
        {
            var songs = _dbContext.Songs.Where(s => s.Album.Id == id).Select(s => new SongDTO
            {
                id = s.Id,
                name = s.Name,
                duration = s.Duration
            });
            return songs;
        }

        public AlbumDetailsDTO ReadAlbum(int id)
        {
            var album = _dbContext.Albums.Include(a => a.Songs).Include(a => a.Artists).FirstOrDefault(a => a.Id == id);

            if (album == null) { throw new KeyNotFoundException(); }
            var albumSongs = album.Songs?.Select(s => new SongDTO
            {
                id = s.Id,
                name = s.Name,
                duration = s.Duration
            }) ?? Enumerable.Empty<SongDTO>();
            var albumArtists = album.Artists?.Select(a => new ArtistDTO
            {
                id = a.Id,
                name = a.Name,
                bio = a.Bio,
                coverImageUrl = a.CoverImageUrl,
                dateOfStart = a.DateOfStart
            }) ?? Enumerable.Empty<ArtistDTO>();
            return new AlbumDetailsDTO
            {
                id = album.Id,
                name = album.Name,
                releaseDate = album.ReleaseDate,
                coverImageUrl = album.CoverImageUrl,
                description = album.Description,
                artists = albumArtists,
                songs = albumSongs
            };
        }

        public void RemoveAlbum(int id)
        {
            var album = _dbContext.Albums.Find(id);
            if (album == null) { throw new KeyNotFoundException(); }
            _dbContext.Albums.Remove(album);
            _dbContext.SaveChanges();
        }

        public int StoreAlbum(AlbumInputModel album)
        {
            var newAlbum = new Album
            {
                Name = album.name,
                ReleaseDate = album.releaseDate,
                CoverImageUrl = album.coverImageUrl,
                Description = album.description,
                DateCreated = DateTime.Now
            };

            var artists = _dbContext.Artists.Where(a => album.artistIds.Contains(a.Id)).ToList();
            newAlbum.Artists = artists;
            _dbContext.Albums.Add(newAlbum);
            _dbContext.SaveChanges();

            return newAlbum.Id;
        }
    }
}