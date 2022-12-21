using DataLayer;

namespace Service
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> Get();
    }
}