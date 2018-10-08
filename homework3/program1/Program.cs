using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("圆形=circular");
            Console.WriteLine("三角形=triangle");
            Console.WriteLine("正方形=square");
            Console.WriteLine("矩形=rectangle");
            Console.WriteLine("请输入你想要使用的图形:");
            string type = Console.ReadLine();
            //ShapeFactory factory = new ShapeFactory();
            try
            {
                Shape shape =ShapeFactory.CreateShape(type);//工厂的静态成员函数
                Console.WriteLine("面积为:" + shape.Area());
            }
            catch
            {
                Console.WriteLine("您的输入有误!");
            }
        }
        
    }
    
}
