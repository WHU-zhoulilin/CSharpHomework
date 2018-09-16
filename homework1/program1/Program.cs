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
            double x=0, y=0;
            try
            {
                Console.WriteLine("请输入第一个乘数：");
                x = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("请输入第二个乘数：");
                y = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine(x + " x " + y + " = " + (x * y));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
