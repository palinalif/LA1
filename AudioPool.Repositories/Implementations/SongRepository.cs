using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using AudioPool.Models.DTOs;
using AudioPool.Models.Entities;
using AudioPool.Models.InputModels;
using AudioPool.Repositories.Contexts;
using AudioPool.Repositories.Interfaces;

namespace AudioPool.Repositories.Implementations
{
    public class SongRepository : ISongRepository
    {
        private readonly AudioPoolDbContext _dbContext;
        public SongRepository(AudioPoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public SongDetailsDTO ReadSong(int id)
        {
            var song = _dbContext.Songs.Find(id);
            if (song == null) { throw new KeyNotFoundException(); }
            var songAlbum = new AlbumDTO
            {
                id = song.Album.Id,
                name = song.Album.Name,
                releaseDate = song.Album.ReleaseDate,
                coverImageUrl = song.Album.CoverImageUrl,
                description = song.Album.Description
            };

            return new SongDetailsDTO
            {
                id = song.Id,
                name = song.Name,
                duration = song.Duration,
                album = songAlbum,
                TrackNumberOnAlbum = 0 // TOOD: Implement this properly
            };
        }

        public void RemoveSong(int id)
        {
            var song = _dbContext.Songs.Find(id);
            if (song == null) { throw new KeyNotFoundException(); }
            _dbContext.Songs.Remove(song);
            _dbContext.SaveChanges();
        }

        public int StoreSong(SongInputModel song)
        {
            var album = _dbContext.Albums.Find(song.albumId);
            if (album == null) { throw new KeyNotFoundException(); }
            var newSong = new Song
            {
                Name = song.name,
                Duration = song.duration,
                Album = album,
                DateCreated = DateTime.Now
            };
            _dbContext.Songs.Add(newSong);
            _dbContext.SaveChanges();

            return newSong.Id;
        }

        public void UpdateSong(int id, SongInputModel updatedSong)
        {
            var song = _dbContext.Songs.Find(id);
            if (song == null) { throw new KeyNotFoundException(); }
            var songAlbum = _dbContext.Albums.Find(updatedSong.albumId);
            if (songAlbum == null) { throw new KeyNotFoundException(); }
            song.Name = updatedSong.name;
            song.Duration = updatedSong.duration;
            song.Album = songAlbum;
            song.DateModified = DateTime.Now;
            song.ModifiedBy = "AudioPoolAdmin";
            _dbContext.SaveChanges();
        }
    }
}