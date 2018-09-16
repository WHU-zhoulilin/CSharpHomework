using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program3
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = 99;
            int[] array = new int[99];
            for (int i = 2; i <= 100; i++)
            {
                array[i - 2] = i;
            }
            for (int i = 2; i <= 100; i++)
            {
                int n = 0;
                for (int j = 0; j < length; j++)
                {
                    if (array[j] % i != 0 || array[j] / i == 1)
                    {
                        array[n] = array[j];
                        n++;
                    }
                }
                length = n;
            }
            Console.WriteLine("2-100中共有" + length + "个素数：");
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("" + array[i]);
            }
        }
    }
}
