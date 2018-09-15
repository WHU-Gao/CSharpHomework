using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progrem1
{
    class Program
    {
        static void Main(string[] args)
        {
            //求一个数的所有素数因子

            try
            {
                Console.Write("请输入一个大于1的正整数：");
                int n = int.Parse(Console.ReadLine());
                if(n <= 1)
                {
                    Console.WriteLine("输入错误！");
                    return;
                }
                int i = 2;
                Console.Write(n + "的所有素数因子为：");
                while(i <= n)
                {
                    if(n%i == 0)
                    {
                        Console.Write(i + "  ");
                        n = n / i;
                    }
                    else
                    {
                        i++;
                    }
                }
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("输入错误！请重新运行本程序。");
            }    
        }
    }
}
