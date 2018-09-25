using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    abstract public class Shape
    {
        public string Type
        {
            get;
            set;
        }

        abstract public double Area();
    }
}
