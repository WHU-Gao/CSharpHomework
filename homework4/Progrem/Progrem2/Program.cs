using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrem2
{
    // 写一个订单管理的控制台程序，能够实现添加订单、删除订单、修改订单、查询订单
    //(按照订单号、商品名称、客户等字段进行查询）功能。在订单删除、修改失败时，
    //能够产生异常并显示给客户错误信息。
    //提示：需要写Order（订单）、OrderDetails（订单明细），OrderService（订单服务）几个类，
    //订单数据可以保存在OrderService中一个List中。

    //订单明细
    public class OrderDetails   
    {
        public int GoodsCounts { set; get; }  //订单号
       public int GoodsNum { set; get; }      //订单数量
        public string GoodsName { set; get; } //商品名称
        public string GoodsMaster { set; get; } //客户名称
    }
    
    //订单
    class Order 
    {
        //声明一队列，保存订单数据
       public List<OrderDetails> list = new List<OrderDetails>();

        //添加订单明细
        public void AddOrder()
        {
            OrderDetails detail1 = new OrderDetails();
            try
            {
                 Console.Write("请输入订单号：");
                string s1 = Console.ReadLine();
                int num;

                if (int.TryParse(s1, out num) == false)   //输入检查              
                    throw new MyExcession("");              
                
                Console.Write("请输入商品数量：");
                string s2 = Console.ReadLine();
                int count;

                if (int.TryParse(s2, out count) == false)
                    throw new MyExcession("");

                Console.Write("请输入商品名称：");
                string goodsname = Console.ReadLine();
                Console.Write("请输入客户姓名：");
                string goodsmaster = Console.ReadLine();
                Console.WriteLine();

                //初始化订单
                detail1.GoodsNum = num;
                detail1.GoodsCounts = count;
                detail1.GoodsName = goodsname;
                detail1.GoodsMaster = goodsmaster;

                //添加到队列
                list.Add(detail1);
                //MyOrder(this, order1);     //调用事件
            }
            catch
            {
                Console.WriteLine("输入数值异常！");              
            }
        }
    }

    //订单管理
    class OrderService : Order
    {
        static void Main(string[] args)
        {
            Order order = new Order();
            //添加订单明细
            AddOrderDetails(order);
            AddOrderDetails(order);

            //输出订单
            Console.WriteLine("订单如下：");
            WriteOrder(order.list);
            Console.WriteLine();

            //修改订单
            Console.Write("请输入想修改的订单号：");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("请输入更改后的商品数量：");
            int count = int.Parse(Console.ReadLine());
            ChangeOrder(order.list, num1, count);
            Console.WriteLine("修改后订单为：");
            //修改后订单
            WriteOrder(order.list);
            Console.WriteLine();

            Console.Write("请输入删除的订单号：");        
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("删除后订单为：");
            //按条件删除某些条目
            DelOrder(order.list, num2);
            //删除后订单
            WriteOrder(order.list);
        }

        //添加订单
        public static void AddOrderDetails(Order order)
        {
            order.AddOrder();
        }

        //输出订单
        public static void WriteOrder(List<OrderDetails> list)
        {
            for(int i =0; i < list.Count; i++)
            {
                Console.WriteLine("订单号：" + list[i].GoodsNum + "     " + "商品数量：" + list[i].GoodsCounts);
                Console.WriteLine("商品名称：" + list[i].GoodsName + "    " + "客户姓名：" + list[i].GoodsMaster);
            }
        }

        //按条件删除订单
        public static void DelOrder(List<OrderDetails> list, int num)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].GoodsNum == num)
                    list.Remove(list[i]);
            }
        }

        //修改订单
        public static void ChangeOrder(List<OrderDetails> list, int num, int count)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].GoodsNum == num)
                    list[i].GoodsCounts = count;
            }
        }
    }

    //异常处理
    class MyExcession: System.FormatException
    {
        public MyExcession(string message)
        {
            Console.WriteLine(message);
        }
    }
}
