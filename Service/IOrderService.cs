using DataLayer;

namespace Service
{
    public interface IOrderService
    {
        Task<Order> Post(Order user);
    }
}