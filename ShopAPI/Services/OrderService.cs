using ShopAPI.Exceptions;
using ShopAPI.Model;
using ShopAPI.Repository;

namespace ShopAPI.Services;

public class OrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        if (repository is null)
        {
            throw new ArgumentNullException(nameof(repository));
        }

        _repository = repository;
    }
    
    public void AddOrder(Order order, Customer customer)
    {
        if (order is null)
        {
            throw new ArgumentNullException(nameof(order));
        }

        if (customer is null)
        {
            throw new ArgumentNullException(nameof(customer));
        }

        if (customer.HasBackPayments)
        {
            throw new OrderException("Customer has back payments");
        }

        if (order.OrderStatus != OrderStatus.NEW)
        {
            throw new OrderException("Order status is not new");
        }

        order.Customer = customer;
        
        _repository.AddOrder(order);

    }
}