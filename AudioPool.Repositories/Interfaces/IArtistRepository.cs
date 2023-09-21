using AudioPool.Models;
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
        Envelope<ArtistDTO> ListArtists(int pageNumber, int pageSize);
        IEnumerable<AlbumDTO> ListArtistAlbums(int id);
    }
}