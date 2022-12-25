using DataLayer;

namespace Service
{
    public interface IOrderService
    {
        Task Post(Order user);
    }
}