using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Circular:Shape 
    {
        static double PI = 3.14159;
        private double radius;
        public Circular(double radius)
        {
            this.radius = radius;
        }
        override public double Area()
        {
            return radius * radius * PI;
        }
    }
}
