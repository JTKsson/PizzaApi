using CloudDB.Domain.DTO;

namespace CloudDB.Core.Interfaces
{
    public interface IProductService
    {
        Task CreateProduct(ProductCreateDTO product);
        Task UpdateProduct(ProductUpdateDTO product);
    }
}
