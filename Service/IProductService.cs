using DataLayer;

namespace Service
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> Get();
    }
}