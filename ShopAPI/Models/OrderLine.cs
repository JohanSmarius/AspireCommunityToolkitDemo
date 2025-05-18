using CommunityToolkit.Diagnostics;

namespace ShopAPI.Model;

public class OrderLine
{
    private int _quantity = 1;
    private decimal _discountPercentage = 0;
    public int Id { get; set; }

    public int OrderId { get; set; }

    public Order Order { get; set; } = null!;

    public Product Product { get; set; } = null!;

    public int ProductId { get; set; }

    public int Quantity
    {
        get => _quantity;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Quantity cannot be negative or zero");
            }

            if (value > 100)
            {
                throw new ArgumentException("Quantity cannot be more than 100");
            }

            _quantity = value;
        }
    }

    public decimal DiscountPercentage
    {
        get => _discountPercentage;
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Discount Percentage cannot be negative or larger than 100");
            }

            _discountPercentage = value;
        }
    }
}