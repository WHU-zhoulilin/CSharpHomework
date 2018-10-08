using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class ShapeFactory
    {
        static public Shape CreateShape(string type)
        {
            Shape shape = null;
            try
            {
                if (type.Equals("triangle"))
                {
                    Console.WriteLine("请输入三角形的三条边:");
                    double a = Convert.ToDouble(Console.ReadLine());
                    double b = Convert.ToDouble(Console.ReadLine());
                    double c = Convert.ToDouble(Console.ReadLine());
                    shape = new Triangle(a, b, c);
                }
                if(type.Equals("circular"))
                {
                    Console.WriteLine("请输入圆形的半径:");
                    double radius = Convert.ToDouble(Console.ReadLine());
                    shape = new Circular(radius);
                }
                if (type.Equals("square"))
                {
                    Console.WriteLine("请输入正方形的边长:");
                    double sideLength = Convert.ToDouble(Console.ReadLine());
                    shape = new Square(sideLength);
                }
                if (type.Equals("rectangle"))
                {
                    Console.WriteLine("请输入矩形的长和宽:");
                    double length = Convert.ToDouble(Console.ReadLine());
                    double width = Convert.ToDouble(Console.ReadLine());
                    shape = new Rectangle(length,width);
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return shape;
        }
    }
}
