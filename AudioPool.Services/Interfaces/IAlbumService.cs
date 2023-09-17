using AudioPool.Models.DTOs;
using AudioPool.Models.InputModels;

namespace AudioPool.Services.Interfaces
{
    public interface IAlbumService
    {
        int StoreAlbum(AlbumInputModel album);
        AlbumDetailsDTO ReadAlbum(int id);
        IEnumerable<SongDTO> ListSongsOnAlbum(int id);
        void RemoveAlbum(int id);
    }
}