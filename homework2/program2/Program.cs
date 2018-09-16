using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = 5;
            Console.WriteLine("请输入" + length + "个整数：");
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                try
                {
                    array[i] = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("最大值：" + MaxInArray(array));
            Console.WriteLine("最小值：" + MinInArray(array));
            Console.WriteLine("平均值：" + AvgOfArray(array));
            Console.WriteLine("总和：" + SumOfArray(array));
        }
        static int MaxInArray(int[] a)
        {
            int max = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                max = max > a[i] ? max : a[i];
            }
            return max;
        }
        static int MinInArray(int[] a)
        {
            int min = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                min = min < a[i] ? min : a[i];
            }
            return min;
        }
        static int SumOfArray(int[] a)
        {
            int sum = 0;
            foreach (int i in a)
            {
                sum += i;
            }
            return sum;
        }
        static double AvgOfArray(int[] a)
        {
            return SumOfArray(a) * 1.0 / a.Length;
        }
    }
}
