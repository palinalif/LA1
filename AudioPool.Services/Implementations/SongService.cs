using AudioPool.Models.DTOs;
using AudioPool.Models.InputModels;
using AudioPool.Repositories.Implementations;
using AudioPool.Repositories.Interfaces;
using AudioPool.Services.Interfaces;

namespace AudioPool.Services.Implementations
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;

        public SongService(SongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        public SongDetailsDTO ReadSong(int id)
        {
            return _songRepository.ReadSong(id);
        }

        public void RemoveSong(int id)
        {
            _songRepository.RemoveSong(id);
        }

        public int StoreSong(SongInputModel song)
        {
            return _songRepository.StoreSong(song);
        }

        public void UpdateSong(int id, SongInputModel updatedSong)
        {
            _songRepository.UpdateSong(id, updatedSong);
        }
    }
}