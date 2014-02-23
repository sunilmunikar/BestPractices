using System;
namespace Core.Services
{
    public interface IAlbumService
    {
        void CreateAlbum(Core.Dtos.AlbumDto dto);
    }
}
