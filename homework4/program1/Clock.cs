using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    
    class Clock
    {
        static TimeEventArgs args = new TimeEventArgs();
        public delegate void EventHandler(object sender, TimeEventArgs e);//声明委托
        public event EventHandler TimeCome;   //声明一个委托
        Timer timer = new Timer(1000);//用定时器每次检查是否到了定的时间
        public void AtTime(DateTime t)
        {
            args.time = t;
            timer.Enabled = true;
            timer.Elapsed += Check;
            Console.Read();
        }
        public void Check(object source, ElapsedEventArgs e)
        {
            if (DateTime.Now.ToString() == args.time.ToString())//比较时间相等的方法,为什么？
            {
                TimeCome(this, args);
                timer.Stop();
            }
        }
    }
}

