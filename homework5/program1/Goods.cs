using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Goods
    {
        Dictionary<string, double> goodsDic = new Dictionary<string, double>();
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
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
                price = value;
            }
        }
        public Goods(string name)
        {
            goodsDic.Add("苹果", 5);
            goodsDic.Add("香蕉", 2.5);
            goodsDic.Add("火锅", 100);
            this.name = name;
            this.price = goodsDic[name];
        }
    }
}
