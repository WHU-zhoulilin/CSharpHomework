using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Order
    {
        static int ordernumber=1;
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
        public string Goods
        {
            get;
            set;
        }
        public Order(string customer,string goods)
        {
            this.Customer = customer;
            this.Goods = goods;
            this.Ordernumber = ordernumber;
            ordernumber++;
        }
        public override string ToString()
        {
            return (this.Customer + "购买了" + this.Goods + "。订单号为" + this.Ordernumber);
        }
    }
}
