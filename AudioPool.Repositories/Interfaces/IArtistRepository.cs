using AudioPool.Models.DTOs;
using AudioPool.Models.InputModels;

namespace AudioPool.Repositories.Interfaces
{
    public interface IArtistRepository
    {
        int StoreArtist(ArtistInputModel artist);
        ArtistDetailsDTO ReadArtist(int id);
        void UpdateArtist(int id, ArtistInputModel updatedArtist);
        void AddGenreToArtist(int id, int genreId);
        IEnumerable<ArtistDTO> ListArtists();
        IEnumerable<AlbumDTO> ListArtistAlbums(int id);
    }
}