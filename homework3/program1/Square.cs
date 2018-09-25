using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Square:Shape
    {
        double sideLength;
        public Square(double sideLength)
        {
            this.sideLength = sideLength;
        }
        public override double Area()
        {
            return sideLength * sideLength;
        }
    }
}
