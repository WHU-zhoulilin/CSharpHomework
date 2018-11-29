namespace program1
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class OrderDB : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“OrderDB”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“program1.OrderDB”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“OrderDB”
        //连接字符串。
        public OrderDB()
            : base("name=OrderDataBase")
        {
        }
        public DbSet<Order> Order { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}