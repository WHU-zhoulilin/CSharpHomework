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
            try
            {
                OrderService orderService = new OrderService();
                Console.WriteLine("共有3种食品");
                Console.WriteLine("苹果 5元，香蕉 2.5元，火锅 100元");

                //下面的代码可省去操作者的一步步操作，可直接显示结果

                Goods goods1 = new Goods("苹果");
                Goods goods2 = new Goods("香蕉");
                Goods goods3 = new Goods("火锅");

                Order order1 = new Order("周礼林", goods1, 1);
                Order order2 = new Order("周礼林", goods3, 2);
                Order order3 = new Order("张三", goods1, 1);



                orderService.AddOrder(order1);
                orderService.AddOrder(order2);
                orderService.AddOrder(order3);
                orderService.QueryOrderByCustomer("周礼林");
                orderService.QueryOrderByGoods("苹果");
                orderService.ModifyOrder(order1, "火锅", 5);
                orderService.ModifyOrder(order1, 3);
                orderService.DeleteOrder(order1);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        //下面的函数可以做具体的一步步的操作，添加，查询，删除，修改
        //Func(orderService);
    


        static void Func(OrderService orderService)
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
                            Console.WriteLine("请输入姓名:");
                            string customer = Console.ReadLine();
                            Console.WriteLine("请输入商品名称:");
                            Goods goods = new Goods(Console.ReadLine());
                            Console.WriteLine("请输入购买商品的数目(整数):");
                            int count = Convert.ToInt32(Console.ReadLine());
                            Order order = new Order(customer, goods,count);
                            orderService.AddOrder(order);
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
                            Console.WriteLine("按姓名查询请输入:1");
                            Console.WriteLine("按商品查询请输入:2");
                            Console.WriteLine("按订单号查询请输入:3");
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
                            Console.WriteLine("单修改商品种类请输入:1");
                            Console.WriteLine("单修改商品数量请输入:2");
                            Console.WriteLine("都要修改请输入:3");
                            int i = Convert.ToInt32(Console.ReadLine());
                            switch (i)
                            {
                                case 1:
                                    Console.WriteLine("请输入要修改为的商品种类:");
                                    orderService.ModifyOrder(order, Console.ReadLine());
                                    break;
                                case 2:
                                    Console.WriteLine("请输入要修改为的商品数目:");
                                    orderService.ModifyOrder(order,Convert .ToInt32( Console.ReadLine()));
                                    break;
                                case 3:
                                    Console.WriteLine("请输入要修改为的商品种类:");
                                    string goods = Console.ReadLine();
                                    Console.WriteLine("请输入要修改为的商品数目:");
                                    orderService.ModifyOrder(order,goods, Convert.ToInt32(Console.ReadLine()));
                                    break;
                            }
                            break;
                        }
                }
            }
            catch
            {
                Console.WriteLine("你的输入有误，即将返回程序初始状态!");
                Func(orderService);
            }
            Func(orderService);
        }
    }
}
