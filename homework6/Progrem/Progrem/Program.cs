using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Progrem
{
  //1、在OrderService中添加一个Export方法，可以将所有的订单序列化为XML文件；添加一个Import方法可以从XML文件中载入订单。

 //2、为OrderService类的各个Public方法，编写测试用例，使用合法和非法的输出数据进行测试。

    public class Progrem
    {
        public static void Main()
        {
              
            try
            {            
                OrderDetails od1 = new OrderDetails(1, "Math    ", 2, 80);   //初始化明细
                OrderDetails od2 = new OrderDetails(2, "English ", 5, 100);
                OrderDetails od3 = new OrderDetails(3, "Chinese ", 0, 120);
                OrderDetails od4 = new OrderDetails(4, "C#      ", 1, 90);
                OrderDetails od5 = new OrderDetails(2, "English ", 3, 10);

                Customers cu1 = new Customers(1, "Customer1");    //顾客
                Customers cu2 = new Customers(2, "Customer2");

                Order or1 = new Order(1, cu1);     //订单
                Order or2 = new Order(2, cu2);

                OrderService ors = new OrderService();   //订单操作
                ors.AddOrder(or1);       //添加订单
                ors.AddOrder(or2);

                OrderService ors1 = new OrderService();   //订单操作
                ors1.AddOrder(or1);       //添加订单
                ors1.AddOrder(or2);

                or1.AddDetails(od1);    //订单1添加的条目
                or1.AddDetails(od2);
                or1.AddDetails(od3);
                or1.AddDetails(od4);
                or1.AddDetails(od5);

                or2.AddDetails(od2);   //订单2添加的条目
                or2.AddDetails(od4);

                Console.WriteLine(or1);   //输出订单信息
                Console.WriteLine(or2);

                //ps:此为对订单明细的处理
                or1.DeleteDetailsByID(2);   //删除ID为2的条目
                Console.WriteLine("删除ID为2的条目:  ");
                Console.WriteLine(or1);

                or1.DeleteDetailsByName("Chinese ");   //删除Name为Chinese的条目
                Console.WriteLine("删除Name为Chinese的条目:  ");
                Console.WriteLine(or1);

                

                List<Order> order = new List<Order>();  //定义Order形集合

                Console.WriteLine("所有订单为：");
                order = ors.GetAllOrders();
                foreach (Order o in order)
                    Console.WriteLine(o);

                Console.WriteLine("获得Customer2的订单：");
                order = ors.GetOrderByCust("Customer2");
                foreach (Order o in order)
                    Console.WriteLine(o);         

                Console.WriteLine("删除ID为2的订单：");
                order = ors.DeleteOrderByID(2);
                foreach (Order o in order)
                    Console.WriteLine(o);

                Console.WriteLine("XML文件的应用：");
                ors.Serialize("order.xml");   //创建xml文件
                List<Order> lo = ors.ReadXml("order.xml");
                foreach (Order o1 in lo)
                    Console.WriteLine(o1);

                Console.WriteLine("商品名为C#的订单：");
                order = ors.GetOrderByGoodsName("C#      ");
                foreach (Order o in order)
                    Console.WriteLine(o);

                //ps:此处使用ors因为上述操作删除了部分明细，不便于做总价判断
                //Console.WriteLine("ors1订单为：");
                //order = ors1.GetAllOrders();
                //foreach (Order o in order)
                //    Console.WriteLine(o);

                //Console.WriteLine("订单总金额大于500的为：");
                //foreach (Order o in order)
                //{
                //    if (o.GetOrderDetails() > 500)
                //    {
                //        Console.Write(o);
                //        Console.WriteLine("总金额为：" + o.GetOrderDetails() + "\n");
                //    }
                //}

            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
