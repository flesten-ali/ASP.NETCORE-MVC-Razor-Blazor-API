namespace BathenyShop.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
