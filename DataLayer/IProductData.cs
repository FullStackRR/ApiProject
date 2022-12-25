namespace DataLayer
{
    public interface IProductData
    {
        Task<IEnumerable<Product>> Get(int[]? categoryId, string? dir = "asc", int? fromPrice = null, int? toPrice = null, string? description = null);
    }
}