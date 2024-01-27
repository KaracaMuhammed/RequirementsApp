using MK.RequirementsApp.Domain;

namespace MK.RequirementsApp.BlazorUI.Interfaces
{
    public interface IImageService
    {
        Task<List<ImageDTO>> GetAllImages();
        Task<List<ImageDTO>> GetActiveImages();
    }
}
