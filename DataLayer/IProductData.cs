namespace DataLayer
{
    public interface IProductData
    {
        Task<IEnumerable<Product>> Get();
    }
}