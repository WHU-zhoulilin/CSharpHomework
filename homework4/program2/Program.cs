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
            Show(orderService);
        }
        static void Show(OrderService orderService)
        {
            Console.WriteLine("添加订单请输入:1");
            Console.WriteLine("删除订单请输入:2");
            Console.WriteLine("查询订单请输入:3");
            Console.WriteLine("修改订单请输入:4");
            try
            {
                int request = Convert.ToInt32(Console.ReadLine());
                switch (request)
                {
                    case 1:
                        {
                            Console.WriteLine("请输入姓名和商品:");
                            orderService.AddOrder(Console.ReadLine(), Console.ReadLine());
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("请输入要删除的订单号:");
                            Order order = orderService.QueryOrderByNumber(Convert.ToInt32(Console.ReadLine()));
                            orderService.DeleteOrder(order);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("按名字查询:1");
                            Console.WriteLine("按商品查询:2");
                            Console.WriteLine("按订单号查询:3");
                            int i = Convert.ToInt32(Console.ReadLine());
                            switch (i)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("请输入姓名:");
                                        orderService.QueryOrderByCustomer(Console.ReadLine());
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("请输入商品:");
                                        orderService.QueryOrderByGoods(Console.ReadLine());
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.WriteLine("请输入订单号:");
                                        orderService.QueryOrderByNumber(Convert.ToInt32(Console.ReadLine()));
                                        break;
                                    }
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("请输入要修改的订单号:");
                            Order order = orderService.QueryOrderByNumber(Convert.ToInt32(Console.ReadLine()));
                            Console.WriteLine("请输入要修改为的商品:");
                            orderService.ModifyOrder(order, Console.ReadLine());
                            break;
                        }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("你的输入有误，将返回程序初始状态!");
                Show(orderService);
            }
            Show(orderService);
        }
    }
}
