using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    [Serializable]
    public class Goods
    {
        static public Dictionary<string, double> goodsDic = new Dictionary<string, double>();
        static public void InitGoods()
        {
            goodsDic.Add("苹果", 5);
            goodsDic.Add("香蕉", 2.5);
            goodsDic.Add("火锅", 100);
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (goodsDic.Keys.Contains(value))
                {
                    name = value;
                }
                else
                {
                    throw new Exception($"没有{value}这种商品!");
                }
            }
        }
        private double price;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("单价必须>0!");
                }
                this.price = value;
            }
        }
        private int count;
        public int Count
        {
            get
            {
                return this.count;
            }
            set
            {
                 this.count = value;
            }
        }
        public Goods()
        {

        }
        public Goods(string name,int count)
        {
            this.Count = count;
            this.Name = name;
            this.Price = goodsDic[name];
        }
    }
}
