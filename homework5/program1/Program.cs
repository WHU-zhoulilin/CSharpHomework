using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
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
                Goods.InitGoods();

                //下面的代码可省去操作者的一步步操作，可直接显示结果

                Customer customer1 = new Customer("周礼林");
                Customer customer2 = new Customer("张三");
                
                Goods goods1 = new Goods("苹果",1);
                Goods goods2 = new Goods("香蕉",2);
                Goods goods3 = new Goods("火锅",3);

                OrderDetails orderDetails1 = new OrderDetails(customer1);
                OrderDetails orderDetails2 = new OrderDetails(customer2);

                orderDetails1.AddOrderDetails(goods1);
                orderDetails1.AddOrderDetails(goods3);
                orderDetails2.AddOrderDetails(goods1);
                orderDetails2.AddOrderDetails(goods2);

                Order order1 = new Order(orderDetails1);
                Order order2 = new Order(orderDetails2);

                Order[] orderA1 =
                {
                    order1,
                    order2
                };


                orderService.AddOrder(order1);
                orderService.AddOrder(order2);

                List<Order> orderlist1= orderService.QueryOrderByCustomer("周礼林");
                Console.WriteLine("查找的结果为:");
                foreach (var n in orderlist1)
                {
                    n.ShowOrder();
                }

                orderService.QueryOrderByGoods("苹果");
                orderService.ModifyOrder(order1, "苹果", "香蕉");
                orderService.ModifyOrder(order2, "苹果", "火锅",5);

                //Xml序列化
                XmlSerializer xml = new XmlSerializer(typeof(Order));
                string xmlFileName = "s.xml";
                orderService.XmlSerializeExport(xml, xmlFileName, orderA1);

                //Xml反序列化
                FileStream fs = new FileStream("s.xml", FileMode.Open);
                Order[] orderA2 = orderService.XmlSerializeImport(xml, fs);
                foreach(Order n in orderA2)
                {
                    n.ShowOrder();
                }


                orderService.DeleteOrder(order1);
               

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
