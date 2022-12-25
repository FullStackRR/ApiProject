namespace DataLayer
{
    public interface IOrderData
    {
        Task Post(Order order);
    }
}