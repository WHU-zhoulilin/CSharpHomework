using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    [Serializable]
    public class OrderDetails
    {
        static public int u=1;
        [Key]
        public int Id
        {
            get;set;
        }
        public Customer Customer
        {
            get;
            set;
        }
        public List<Goods> goodslist=new List<Goods>();
        public OrderDetails()
        {

        }
        public OrderDetails(Customer customer)
        {
            this.Customer = customer;
            this.Id = u++;
        }
        public void AddOrderDetails(Goods goods)
        {
            if (goods.Count > 0)
            {
                goodslist.Add(goods);
            }
        }
        public void ShowTheDetails()
        {
            foreach(Goods goods in goodslist)
            {
                if (goods.Count == 0)
                {
                    goodslist.Remove(goods);
                }
            }
            double sum=0;
            Console.WriteLine("================================================================================");
            Console.WriteLine(this.Customer.Name + "购买了");
            foreach (Goods g in goodslist)
            {
                sum += g.Count * g.Price;
                Console.WriteLine(g.Name + " * " + g.Count+"      "+g.Price+" * "+g.Count+" = "+g.Price*g.Count);
            }
            Console.WriteLine("共计:" + sum + "元!");
            Console.WriteLine("================================================================================\n");
        }

        public override string ToString()
        {
            double sum = 0;
            string result = this.Customer.Name + "购买了";
            foreach(Goods g in goodslist)
            {
                sum += g.Count * g.Price;
                result +=g.Count+"份"+g.Name+"("+g.Price+"元/份)  \n";
            }
            result += "共计" + sum + "元";
            return result;
        }
    }
}
