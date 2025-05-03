using ShopAPI.Model;

namespace ShopAPI.Repository;

public interface IOrderRepository
{
    public void AddOrder(Order order);
}