using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using AudioPool.Models.DTOs;
using AudioPool.Models.Entities;
using AudioPool.Models.InputModels;
using AudioPool.Repositories.Contexts;
using AudioPool.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            var song = _dbContext.Songs.Include(s => s.Album).FirstOrDefault(s => s.Id == id);
            if (song == null) { throw new KeyNotFoundException(); }
            var songAlbum = new AlbumDTO
            {
                id = song.Album.Id,
                name = song.Album.Name,
                releaseDate = song.Album.ReleaseDate,
                coverImageUrl = song.Album.CoverImageUrl,
                description = song.Album.Description
            };

            // Find the index of the song in the AlbumDetailsDTO's Songs list
            var album = _dbContext.Albums.Include(a => a.Songs).FirstOrDefault(a => a.Id == song.Album.Id);
            int trackNumber = 0;

            if (album != null)
            {
                var orderedSongs = album.Songs.OrderBy(s => s.Id).ToList();
                trackNumber = orderedSongs.ToList().FindIndex(s => s.Id == id);
            }

            return new SongDetailsDTO
            {
                id = song.Id,
                name = song.Name,
                duration = song.Duration,
                album = songAlbum,
                TrackNumberOnAlbum = trackNumber+1
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