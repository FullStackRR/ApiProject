namespace DataLayer
{
    public interface IOrderItemData
    {
        Task Post(OrderItem item);
    }
}