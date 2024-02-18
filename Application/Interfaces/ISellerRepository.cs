using NBP.Domain.Entities;

namespace NBP.Application.Interfaces
{
    public interface ISellerRepository
    {
        void AddProductAsync(Product product);
        Task<IEnumerable<Product>> GetAllProductsAsync();


    }
}
