namespace DataLayer
{
    public interface IOrderData
    {
        Task<Order> Post(Order order);
    }
}