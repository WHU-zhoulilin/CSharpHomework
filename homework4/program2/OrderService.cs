using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class OrderService
    {
        Dictionary<string, double> goodsDic = new Dictionary<string, double>();
        public OrderService()
        {
            goodsDic.Add("苹果", 5);
            goodsDic.Add("香蕉", 2.5);
            goodsDic.Add("火锅", 100);
        }
        List<Order> OrderList = new List<Order>();
        public void AddOrder(Order order)
        {
            OrderList.Add(order);
            Console.WriteLine(order.ToString());
        }
        public void DeleteOrder(Order order)
        {
            if (order != null)
            {
                Console.WriteLine(order.Customer + "的订单已经取消!");
                OrderList.Remove(order);
            }
            else
            {
                Console.WriteLine("无法删除，因为不存在该订单!");
            }

        }
        public Order QueryOrderByNumber(int ordernumber)
        {
            foreach (Order order in OrderList)
            {
                if (order.Ordernumber == ordernumber)
                {
                    Console.WriteLine("已找到符合要求的订单:");
                    OrderDetails.DisplayOrder(order);
                    return order;
                }
            }
            Console.WriteLine("未找到该订单!");
            return null;
        }
        public void QueryOrderByCustomer(string customer)
        {
            var result = from w in OrderList
                         where w.Customer == customer
                         select w;
            if (result.Count() != 0)
            {
                Console.WriteLine("查找的结果为:");
                foreach(var n in result)
                {
                    Console.WriteLine(n.ToString());
                }
            }
            else
            {
                Console.WriteLine("未找到符合条件的订单!");
            }
        }
        public void QueryOrderByGoods(string goods)
        {
            var result = from w in OrderList
                         where w.goods.Name == goods
                         select w;
            if (result.Count() != 0)
            {
                Console.WriteLine("查找的结果为:");
                foreach (var n in result)
                {
                    Console.WriteLine(n.ToString());
                }
            }
            else
            {
                Console.WriteLine("未找到符合条件的订单!");
            }
        }
        public void ModifyOrder(Order order, string goods)
        {
            if (order != null)
            {
                Console.WriteLine("原订单为:");
                Console.WriteLine(order.ToString());
                order.goods.Name = goods;
                order.goods.Price = goodsDic[goods];
                Console.WriteLine("修改后的订单为:");
                Console.WriteLine(order.ToString());
                
            }
            else
            {
                Console.WriteLine("无法修改，因为不存在该订单!");
            }
        }
        public void ModifyOrder(Order order, int count)
        {
            if (order != null)
            {
                Console.WriteLine("原订单为:");
                Console.WriteLine(order.ToString());
                order.Count = count;
                Console.WriteLine("修改后的订单为:");
                Console.WriteLine(order.ToString());

            }
            else
            {
                Console.WriteLine("无法修改，因为不存在该订单!");
            }
        }
        public void ModifyOrder(Order order, string goods,int count)
        {
            if (order != null)
            {
                Console.WriteLine("原订单为:");
                Console.WriteLine(order.ToString());
                order.goods.Name = goods;
                order.goods.Price = goodsDic[goods];
                order.Count = count;
                Console.WriteLine("修改后的订单为:");
                Console.WriteLine(order.ToString());

            }
            else
            {
                Console.WriteLine("无法修改，因为不存在该订单!");
            }
        }

    }
}

