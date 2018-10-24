using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    [Serializable]
    public class OrderDetails
    {
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
        }
        public void AddOrderDetails(Goods goods)
        {
            goodslist.Add(goods);
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
    }
}
