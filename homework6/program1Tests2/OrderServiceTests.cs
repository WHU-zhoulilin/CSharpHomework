using Microsoft.VisualStudio.TestTools.UnitTesting;
using program1;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        //初始化商品字典 goodsDic;
      
        public OrderDetails Prepare()
        {
            Goods goods = new Goods("火锅", 5);
            OrderDetails orderDetails = new OrderDetails(new Customer("周礼林"));
            orderDetails.AddOrderDetails(goods);
            return orderDetails;
        }
        /// <summary>
        /// 以下测试函数以R结尾表示正确输入，以W结尾表示错误输入
        /// </summary>
        [TestMethod()]
        public void OrderServiceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddOrderTestR()
        {
            Goods.InitGoods();
            Order order = new Order(Prepare());//订单号为1
            OrderService orderService = new OrderService();
            orderService.AddOrder(order);
            Assert.IsNotNull(orderService.OrderList);    
        }
        [TestMethod()]
        public void AddOrderTestW()
        {
            try
            {
                Order order = null;
                OrderService orderService = new OrderService();
                orderService.AddOrder(order);
            }
            catch(NullReferenceException e)
            {
                Assert.AreEqual("订单不存在!", e.Message);
            }
           

        }

        [TestMethod()]
        public void DeleteOrderTestR()
        {
            Order order = new Order(Prepare());//订单号为2
            OrderService orderService1 = new OrderService();
            orderService1.AddOrder(order);
            orderService1.DeleteOrder(order);
            Assert.AreEqual(orderService1.OrderList.Count,0);
        }
        [TestMethod()]
        public void DeleteOrderTestW()
        {
            try
            {
                Order order = new Order(Prepare());//订单号为3
                OrderService orderService = new OrderService();
                orderService.DeleteOrder(order);
            }
            catch(Exception e)
            {
                Assert.AreEqual("订单列表中不存在该订单!", e.Message);
            }
        }

        [TestMethod()]
        public void QueryOrderByNumberTestR()
        {
            Order order = new Order(Prepare());//订单号为4
            OrderService orderService = new OrderService();
            orderService.AddOrder(order);
            Assert.IsNotNull(orderService.QueryOrderByNumber(4));
        }
        [TestMethod()]
        public void QueryOrderByNumberTestW()
        {
            Order order = new Order(Prepare());//订单号为5
            OrderService orderService = new OrderService();
            orderService.AddOrder(order);
            Assert.IsNull(orderService.QueryOrderByNumber(2));
        }

        [TestMethod()]
        public void QueryOrderByCustomerTestR()
        {
            Order order = new Order(Prepare());//订单号为6
            OrderService orderService = new OrderService();
            orderService.AddOrder(order);
            Assert.IsNotNull(orderService.QueryOrderByCustomer("周礼林"));
        }

        [TestMethod()]
        public void QueryOrderByCustomerTestW()
        {
            try
            {
                Order order = new Order(Prepare());//订单号为7
                OrderService orderService = new OrderService();
                orderService.AddOrder(order);
                orderService.QueryOrderByCustomer("周礼");
            }
            catch(Exception e)
            {
                Assert.AreEqual("没有找到符合条件的订单!", e.Message);
            }
        }

        [TestMethod()]
        public void QueryOrderByGoodsTestR()
        {
            Order order = new Order(Prepare());//订单号为8
            OrderService orderService = new OrderService();
            orderService.AddOrder(order);
            Assert.IsNotNull(orderService.QueryOrderByGoods("火锅"));
        }

        public void QueryOrderByGoodsTestW()
        {
            try
            {
                Order order = new Order(Prepare());//订单号为9
                OrderService orderService = new OrderService();
                orderService.AddOrder(order);
                orderService.QueryOrderByGoods("火车");
            }
            catch (Exception e)
            {
                Assert.AreEqual("没有找到符合条件的订单!", e.Message);
            }
        }

        [TestMethod()]
        public void ModifyOrderTestW()
        {
            try
            {
                Order order = new Order(Prepare());//订单号为10
                OrderService orderService = new OrderService();
                orderService.AddOrder(order);
                orderService.ModifyOrder(order, "火锅", "火车");
            }
            catch(Exception e)
            {
                Assert.AreEqual("没有火车这种商品!", e.Message);
            }
        }

        [TestMethod()]
        public void ModifyOrderTest1W()
        {
            try
            {
                Order order = new Order(Prepare());//订单号为11
                OrderService orderService = new OrderService();
                orderService.AddOrder(order);
                orderService.ModifyOrder(order, "火车", "火锅");
            }
            catch (Exception e)
            {
                Assert.AreEqual("该订单不包括火车这种商品!", e.Message);
            }
        }
        /// <summary>
        /// 
        /// 序列化的测试函数无法成功！！！
        /// </summary>
        [TestMethod()]
        public void XmlSerializeExportTestW()
        {
          
        }

        [TestMethod()]
        public void XmlSerializeImportTestW()
        {
            Assert.Fail();
        }
    }
}