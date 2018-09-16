﻿using System;
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
            Console.WriteLine("请输入一个整数：");
            int a = 0;
            try
            {
                a = Convert.ToInt32(Console.ReadLine());
                Console.Write(a + " = ");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            for (int i = 2; i <= a / 2; i++)
            {
                if (a % i == 0)
                {
                    a = a / i;
                    Console.Write(i + " x ");
                    i = 1;
                }
            }
            Console.WriteLine(a + "");
        }
    }
}
