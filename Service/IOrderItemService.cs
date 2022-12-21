using DataLayer;

namespace Service
{
    public interface IOrderItemService
    {
        Task Post(OrderItem orderItem);
    }
}