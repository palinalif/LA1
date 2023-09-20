using AudioPool.Models.DTOs;
using AudioPool.Models.InputModels;
using AudioPool.Repositories.Implementations;
using AudioPool.Repositories.Interfaces;
using AudioPool.Services.Interfaces;

namespace AudioPool.Services.Implementations
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void AddGenreToArtist(int id, int genreId)
        {
            _artistRepository.AddGenreToArtist(id, genreId);
        }

        public IEnumerable<AlbumDTO> ListArtistAlbums(int id)
        {
            return _artistRepository.ListArtistAlbums(id);
        }

        public IEnumerable<ArtistDTO> ListArtists()
        {
            return _artistRepository.ListArtists();
        }

        public ArtistDetailsDTO ReadArtist(int id)
        {
            var artist = _artistRepository.ReadArtist(id);
            if (artist == null) { return null; }
            return artist;
        }

        public int StoreArtist(ArtistInputModel artist)
        {
            return _artistRepository.StoreArtist(artist);
        }

        public void UpdateArtist(int id, ArtistInputModel updatedArtist)
        {
            _artistRepository.UpdateArtist(id, updatedArtist);
        }
    }
}