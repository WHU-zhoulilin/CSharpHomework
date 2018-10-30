using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }
   
        public void Prepare()
        {
            List<program1.Goods> orderlist = new List<program1.Goods>();
            program1.OrderService orderService = new program1.OrderService();
            program1.Goods.InitGoods();
            program1.Customer customer1 = new program1.Customer("周礼林");
            program1.Customer customer2 = new program1.Customer("张三");

            program1.Goods goods1 = new program1.Goods("苹果", 1);
            program1.Goods goods2 = new program1.Goods("香蕉", 2);
            program1.Goods goods3 = new program1.Goods("火锅", 3);
            orderlist.Add(goods1);
            orderlist.Add(goods2);
            orderlist.Add(goods3);


            program1.OrderDetails orderDetails1 = new program1.OrderDetails(customer1);
            program1.OrderDetails orderDetails2 = new program1.OrderDetails(customer2);

            orderDetails1.AddOrderDetails(goods1);
            orderDetails1.AddOrderDetails(goods3);
            orderDetails2.AddOrderDetails(goods1);
            orderDetails2.AddOrderDetails(goods2);

            program1.Order order1 = new program1.Order(orderDetails1);
            program1.Order order2 = new program1.Order(orderDetails2);
            //orderlist.Add(order1);
            //orderlist.Add(order2);
            this.orderBindingSource1.DataSource = orderlist;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Prepare();
        }
    }
}
