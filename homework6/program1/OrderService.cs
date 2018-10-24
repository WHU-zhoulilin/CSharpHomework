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
    public class OrderService
    {
        public OrderService()
        {
        }
        public List<Order> OrderList = new List<Order>();
        public void AddOrder(Order order)
        {
            if (order != null)
            {
                OrderList.Add(order);
                order.ShowOrder();
            }
            else
            {
                throw new NullReferenceException("订单不存在!");
            }
        }
        public void DeleteOrder(Order order)
        {
            if (order != null&&this.OrderList.Contains(order))
            {
                Console.WriteLine(order.orderDetails.Customer.Name + "的订单已经取消!");
                OrderList.Remove(order);
            }
            else
            {
                throw new Exception("订单列表中不存在该订单!");
            }

        }
        public Order QueryOrderByNumber(int ordernumber)
        {
            foreach (Order order in OrderList)
            {
                if (order.Ordernumber == ordernumber)
                {
                 
                    return order;
                }
            }
            Console.WriteLine("未找到该订单!");
            return null;
        }
        public List<Order> QueryOrderByCustomer(string customer)
        {
            var result = OrderList.Where(order =>
                     order.orderDetails.Customer.Name== customer);
            if (result.Count() != 0)
            {
                return result.ToList<Order>();
            }
            else
            {
                throw new Exception("没有找到符合条件的订单!");
            }
        }
        public List<Order> QueryOrderByGoods(string goods)
        {
            var result = OrderList.Where(order =>
                    order.orderDetails.goodslist.Where(d => d.Name == goods)
                    .Count() > 0
                );
            if (result.Count() != 0)
            {
                return result.ToList<Order>();
            }
            else
            {
                throw new Exception("没有找到符合条件的订单!");
            }
            
        }
        public void ModifyOrder(Order order, string goods,string goods1)
        {
            if (order != null)
            {
                Console.WriteLine("原订单为:");
                order.ShowOrder();
                Goods tempGoods = (Goods)order.orderDetails.goodslist.Where(d => d.Name == goods).FirstOrDefault<Goods>();
                try
                {
                    Goods goods2 = new Goods(goods1, tempGoods.Count);
                    order.orderDetails.goodslist.Remove((Goods)order.orderDetails.goodslist.Where(d => d.Name == goods).First<Goods>());
                    order.orderDetails.goodslist.Add(goods2);
                    Console.WriteLine("修改后的订单为:");
                    order.ShowOrder();
                }
                catch(NullReferenceException e)
                {
                    throw new NullReferenceException("该订单不包括" + goods + "这种商品!");
                }
            }
            else
            {
                Console.WriteLine("无法修改，因为不存在该订单!");
            }
        }
        public void ModifyOrder(Order order, string goods,string goods1 ,int count)
        {
            if (order != null)
            {
                Console.WriteLine("原订单为:");
                order.ShowOrder();
                Goods goods2 = new Goods(goods1, count);
                order.orderDetails.goodslist.Remove((Goods)order.orderDetails.goodslist.Where(d => d.Name == goods).FirstOrDefault<Goods>());
                order.orderDetails.goodslist.Add(goods2);
                Console.WriteLine("修改后的订单为:");
                order.ShowOrder();

            }
            else
            {
                Console.WriteLine("无法修改，因为不存在该订单!");
            }
        }
        public void XmlSerializeExport(XmlSerializer ser,string fileName,object obj)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    ser.Serialize(fs, obj);
                }
            }
            catch(Exception e)
            {
                throw new Exception("序列化的对象的类型不一致!");
            }
        }
        public Order[] XmlSerializeImport(XmlSerializer ser,FileStream fs)
        {
            if(fs.CanRead)
            {
                return (Order[])ser.Deserialize(fs);
            }
            return null;
        }
    }
}
