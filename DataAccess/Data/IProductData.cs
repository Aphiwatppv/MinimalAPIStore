using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IProductData
    {
        Task AddnewProduct(ProductModel product);
        Task<IEnumerable<ProductModel>> GetAllproducts();
        Task<ProductModel> GetProductDetails(int productId);
        Task<IEnumerable<ProductModel>> GetProductsByName(string namePattern);
        Task IncreaseProductStock(int productId, int incrementAmount);
        Task ReduceProductStock(int productId, int decrementAmount);
        Task RemoveProductById(int productId);
        Task UpdateProductAlertLimit(int productId, int newAlertLimit);
        Task UpdateProductName(int productId, string newProductName);
        Task UpdateProductPrice(int productId, decimal newProductPrice);
    }
}