using CloudDB.Domain.DTO;

namespace CloudDB.Infrastructure.Interfaces
{
    public interface IProductRepo
    {
        Task CreateProduct(ProductCreateDTO product);
        Task UpdateProduct(ProductUpdateDTO product);
    }
}
