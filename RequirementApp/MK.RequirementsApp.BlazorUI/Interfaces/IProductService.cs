using MK.RequirementsApp.Domain;

namespace MK.RequirementsApp.BlazorUI.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task UpdateProductStatus(int productId);
        Task CreateProduct(ProductDTO product);
        Task DeleteProduct(int productId);
    }
}
