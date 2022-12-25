using DataLayer;

namespace Service
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> Get( int[]? categoryId,  string? dir = "asc",  int? fromPrice = null,  int? toPrice = null,  string? description = null);
    }
}