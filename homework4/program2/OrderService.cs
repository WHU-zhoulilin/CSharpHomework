using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class OrderService
    {
        List <Order> OrderList = new List<Order>();
        public void AddOrder(string customer,string goods)
        {
            Order order = new Order(customer, goods);
            OrderList.Add(order);
            Console.WriteLine(order.Customer + "已成功订购" + order.Goods + ".  订单号为" + order.Ordernumber);
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
           foreach(Order order in OrderList)
            {
                if(order.Ordernumber==ordernumber)
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
            bool find = false;
            foreach (Order order in OrderList)
            {
                if (order.Customer == customer)
                {
                    Console.WriteLine("已找到符合要求的订单:");
                    OrderDetails.DisplayOrder(order);
                    find = true;
                }
            }
            if (!find)
            {
                Console.WriteLine("未找到该订单!");
            }
        }
        public void QueryOrderByGoods(string goods)
        {
            bool find = false;
            foreach (Order order in OrderList)
            {
                if (order.Goods == goods)
                {
                    Console.WriteLine("已找到符合要求的订单:");
                    OrderDetails.DisplayOrder(order);
                    find = true;
                }
            }
            if (!find)
            {
                Console.WriteLine("未找到该订单!");
            }
        }
        public void ModifyOrder(Order order,string goods)
        {
            if (order != null)
            {
                order.Goods = goods;
                Console.WriteLine(order.Customer + "已修改订单为" + order.Goods);
            }
            else
            {
                Console.WriteLine("无法修改，因为不存在该订单!");
            }
        }

    }
}
