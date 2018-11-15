using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    [Serializable]
    public class Order
    {
        public static int ordernumber = 1;
        public int Ordernumber
        {
            get;
            set;
        }
        public string Datenumber
        {
            get;
            set;
        }
        public OrderDetails orderDetails
        {
            get;
            set;
        }
        public Order()
        {

        }
        public Order(OrderDetails orderDetails)
        {
            this.orderDetails = orderDetails;
            this.Datenumber =System.DateTime.Now.Year.ToString()+"-"+System.DateTime.Now.Month.ToString()+"-"
                        +System .DateTime .Now.Day.ToString()+"-"+ordernumber;
            this.Ordernumber = ordernumber;
            ordernumber++;
        }
        public void ShowOrder()
        {
            Console.WriteLine("-----------");
            Console.WriteLine("订单号   " + this.Ordernumber);
            this.orderDetails.ShowTheDetails();
        }
    }
}
