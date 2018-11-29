namespace program1
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class OrderDB : DbContext
    {
        public OrderDB()
            : base("OrderDataBase")
        {
        }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }


    }

    
}