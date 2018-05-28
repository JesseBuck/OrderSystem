using Microsoft.EntityFrameworkCore;

namespace FoodOrderSystem.Models
{
    public class FoodOrderContext : DbContext
    {
        public FoodOrderContext(DbContextOptions<FoodOrderContext> options) : base(options) 
        {
        }

        public DbSet<FoodOrder> FoodOrders { get; set; }
        public DbSet<FoodOrderItem> FoodOrderItems { get; set; }
    }
}