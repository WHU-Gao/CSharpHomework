using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progrem2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入数组元素个数：");
            
            try
            {
               int num = int.Parse(Console.ReadLine());
                bool temp = isRight(num);
                while (!temp)     //当输入错误时重新输入
                {
                    Console.WriteLine("请输入大于0的整数");
                    Console.Write("请重新输入元素个数：");
                    num = int.Parse(Console.ReadLine());                            
                   temp = isRight(num);
                }
            }
            catch    // 抛出异常的处理
            {
                Console.WriteLine("输入错误！");
                Console.Write("请重新本程序！");
            }


            bool isRight(int num)    // 判断输入是否正确
            {
                if (num <= 0)
                {                 
                    return false;
                }              
                int[] a = new int[num];
                Console.WriteLine("请输入元素数据：");
                for (int i = 0; i < a.Length; i++)
                    a[i] = int.Parse(Console.ReadLine());

                int max = a[0], min = a[0], avg, all = 0;    //定义最大值、最小值、平均值和所有元素的和
                for (int i = 0; i < a.Length; i++)
                {
                    if (max < a[i])
                        max = a[i];
                    if (min > a[i])
                        min = a[i];
                    all += a[i];    //求和
                }
                avg = all / a.Length;  //平均值
                
                Console.WriteLine("最大值：" + max + "    最小值：" + min);
                Console.WriteLine("平均值：" + avg + "    其和：" + all);
                return true;
            }

        }
    }
}
