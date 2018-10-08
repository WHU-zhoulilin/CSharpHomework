using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            orderService.AddOrder("zll", "jiaozi");
            orderService.AddOrder("zsdl", "fan");
            orderService.AddOrder("zlsdfgf", "mian");
            Order order =orderService.QueryOrderByCustomer("zlfsdfg");
            orderService.DeleteOrder(order);
            order = orderService.QueryOrderByGoods("fan");
            orderService.ModifyOrder(order, "tudou");
            OrderDetails.DisplayOrder(order);
        }
    }
}
