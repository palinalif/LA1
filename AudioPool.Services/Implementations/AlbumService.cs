using AudioPool.Models.DTOs;
using AudioPool.Models.InputModels;
using AudioPool.Repositories.Interfaces;
using AudioPool.Services.Interfaces;

namespace AudioPool.Services.Implementations
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }
        public IEnumerable<SongDTO> ListSongsOnAlbum(int id)
        {
            return _albumRepository.ListSongsOnAlbum(id);
        }

        public AlbumDetailsDTO ReadAlbum(int id)
        {
            return _albumRepository.ReadAlbum(id);
        }

        public void RemoveAlbum(int id)
        {
            _albumRepository.RemoveAlbum(id);
        }

        public int StoreAlbum(AlbumInputModel album)
        {
            return _albumRepository.StoreAlbum(album);
        }
    }
}