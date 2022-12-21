namespace DataLayer
{
    public interface ICategoryData
    {
        Task<IEnumerable<Category>> Get();
    }
}