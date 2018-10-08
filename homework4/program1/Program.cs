using System;
using System.Timers;
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
            Console.WriteLine("下面是时间的写法:");
            Console.WriteLine(DateTime.Now.ToString());
            Console.WriteLine("请输入闹钟时间:");
            try
            {
                DateTime time = Convert.ToDateTime(Console.ReadLine());
                Clock myclock = new Clock();
                myclock.TimeCome += new Clock.EventHandler(Clock_alarm);
                if(time>DateTime.Now)//比较时间大小
                {
                    myclock.AtTime(time);
                }
                else
                {
                    Console.WriteLine("你的输入有误!");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Clock_alarm(object sender, TimeEventArgs e)
        {
            Console.WriteLine("时间到了!!!");
        }
    }
}
