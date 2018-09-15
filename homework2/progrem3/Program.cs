using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace progrem3
{
    class Program
    {

        static void Main(string[] args)
        {

            //1.一般方法
            //bool isRight = true;
            //for (int i = 3; i < 100; i++)
            //{
            //    isRight = true;
            //    for (int j = 2; j < i; j++)
            //    {
            //        if (i % j == 0)
            //        {
            //            isRight = false;
            //            break;
            //        }
            //    }
            //    if (isRight == true)
            //    {
            //        Console.Write(i + "  ");                  
            //    }
            //}



            //2.使用list实现埃氏筛法
            List<int> list = new List<int>();
            for (int i = 3; i < 100; i++)             //添加元素
                list.Add(i);        
            for (int j = 2; j < 100; j++)
            {
                for (int i = list.Count - 1; i >= 0; i--)      //反向遍历
                {
                    if ((list[i] % j) == 0&& list[i] != j)       //首先删除2的倍数，依次为3的倍数.......
                    {
                        list.RemoveAt(i);
                    }
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

        }
    }
}
