using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Order
    {
        static int ordernumber = 1;
        private int count;
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("商品数目必须>0!");
                }
                count = value;
            }
        }
        public int Ordernumber
        {
            get;
            set;
        }
        public string Customer
        {
            get;
            set;
        }
        public Goods goods;
        public Order(string customer, Goods goods, int count)
        {
            this.Customer = customer;
            this.goods = goods;
            this.Count = count;
            this.Ordernumber = ordernumber;
            ordernumber++;
        }
        public override string ToString()
        {
            string result = "================================================================================\n";
            result += $"此订单号为:{this.Ordernumber}\n";
            result += $"{this.Customer}购买了{this.Count}份({this.goods.Name}),总价格为{this.goods.Price * this.Count}元!";
            result += "\n================================================================================\n";
            return result;
        }
    }
}

