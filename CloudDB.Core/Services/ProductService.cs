using CloudDB.Core.Interfaces;
using CloudDB.Domain.DTO;
using CloudDB.Infrastructure.Interfaces;

namespace CloudDB.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _repo;

        public ProductService(IProductRepo repo)
        {
            _repo = repo;
        }

        public async Task CreateProduct(ProductCreateDTO product)
        {
            await _repo.CreateProduct(product);
        }

        public async Task UpdateProduct(ProductUpdateDTO product)
        {
           await _repo.UpdateProduct(product);
        }
    }
}
