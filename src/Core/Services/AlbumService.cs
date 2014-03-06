using Core.Dtos;
using Core.Entities;
using Core.Services.Validation;
using GenericRepository.EntityFramework;

namespace Core.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IEntityRepository<Album> _albumRepository;
        private IValidationProvider _validationProvider;

        public AlbumService(
            IEntityRepository<Album> albumRepository,
            IValidationProvider validationProvider
            )
        {
            _albumRepository = albumRepository;
            _validationProvider = validationProvider;
        }

        public void CreateAlbum(AlbumDto dto)
        {
            //ValidateAlbum(dto);
            _validationProvider.Validate(dto);
        }

        private void ValidateAlbum(AlbumDto albumToValidate)
        {
            if (albumToValidate.Price >= 100)
            {
                _validationProvider.Validate(albumToValidate);
            }
        }

    }

}
