using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ShopAPI.Database
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> context) : base(context)
        {
            
        }
    }
}
