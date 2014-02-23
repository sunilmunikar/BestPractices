using Core.Dtos;
using Core.Entities;
using Core.Services.Validation;
using GenericRepository.EntityFramework;

namespace Core.Services
{
    public class AlbumService : IAlbumService
    {
        private IValidationProvider _validationProvider;
        public AlbumService(
            IEntityRepository<Album> albumRepository,
            IValidationProvider validationProvider
            )
        {
            _validationProvider = validationProvider;
        }

        public void CreateAlbum(AlbumDto dto)
        {
            ValidateAlbum(dto);

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
