using AudioPool.Models.DTOs;
using AudioPool.Models.InputModels;

namespace AudioPool.Services.Interfaces
{
    public interface ISongService
    {
        int StoreSong(SongInputModel song);
        SongDetailsDTO ReadSong(int id);
        void UpdateSong(int id, SongInputModel updatedSong);
        void RemoveSong(int id);
    }
}