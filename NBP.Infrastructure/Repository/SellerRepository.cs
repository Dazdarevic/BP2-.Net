using Microsoft.EntityFrameworkCore;
using NBP.Application.Interfaces;
using NBP.Application.DTOs;
using NBP.Domain.Entities;
using NBP.Infrastructure.Data;

namespace NBP.Infrastructure.Repository
{
    public class SellerRepository : ISellerRepository
    {
        private readonly DataContext dc;

        public SellerRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void AddProductAsync(Product product)
        {
            dc.Products.Add(product);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await dc.Products.ToListAsync();
        }
    }
}
