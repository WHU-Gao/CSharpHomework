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
            //从键盘上接收两个数字，计算这两个数的积
            Console.Write("请输入a的值：");
            double a = double.Parse(Console.ReadLine());
            Console.Write("请输入b的值：");
            double b = double.Parse(Console.ReadLine());
            double c = a * b;
            Console.Write("a与b的积为：");
            Console.WriteLine(a + " * " + b + " = " + c);
        }
    }
}
