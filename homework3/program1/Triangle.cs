using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Triangle:Shape
    {
        private double a;
        private double b;
        private double c;
        public Triangle(double a,double b,double c)
        {
            if (a > 0 && b > 0 && c > 0 && (a + b) > c && (a + c > b) && (b + c) > a)
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
            else
            {
                Console.WriteLine("您输入的边不构成三角形！");
            }
        }
        override public double Area()
        {
            double p = (a + b + c) / 2;
            return Math.Pow(p * (p - a) * (p - b) * (p - c), 0.5);  
        }
    }
}
