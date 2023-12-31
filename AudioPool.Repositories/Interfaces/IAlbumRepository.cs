using AudioPool.Models.DTOs;
using AudioPool.Models.InputModels;

namespace AudioPool.Repositories.Interfaces
{
    public interface IAlbumRepository
    {
        int StoreAlbum(AlbumInputModel album);
        AlbumDetailsDTO ReadAlbum(int id);
        IEnumerable<SongDTO> ListSongsOnAlbum(int id);
        void RemoveAlbum(int id);
    }
}