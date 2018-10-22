using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace Progrem
{
    [TestClass]
    public class UnitTest1    
    {
        //
        //ps:此测试类列举了四个测试函数
        //以下函数每个函数都创建了order及orderservice对象，防止不同函数之间的干扰影响测试结果
        //


        //构造订单基本信息,用于以后的测试
       
        OrderDetails od1 = new OrderDetails(1, "Math    ", 2, 80);   //初始化明细
        OrderDetails od2 = new OrderDetails(2, "English ", 5, 100);
        OrderDetails od3 = new OrderDetails(3, "Chinese ", 0, 120);
        OrderDetails od4 = new OrderDetails(4, "C#      ", 1, 90);
        OrderDetails od5 = new OrderDetails(2, "English ", 3, 10);

        Customers cu1 = new Customers(1, "Customer1");    //顾客
        Customers cu2 = new Customers(2, "Customer2");


        [TestMethod]
        public void TestMethod1()//方法Add()的测试函数
        {
            List<Order> order1 = new List<Order>();
            Order or1 = new Order(1, cu1);     //订单
            Order or2 = new Order(2, cu2);

            or1.AddDetails(od1);    //订单1添加的条目
            or1.AddDetails(od2);
            or1.AddDetails(od3);
            or1.AddDetails(od4);
            or1.AddDetails(od5);

            or2.AddDetails(od2);   //订单2添加的条目
            or2.AddDetails(od4);

            order1.Add(or1);
            order1.Add(or2);

            OrderService ors = new OrderService();   //订单操作
            ors.AddOrder(or1);       //添加订单
            ors.AddOrder(or2);

            Assert.IsTrue(order1[0] == ors.order[0] && order1[1] == ors.order[1]);
        }


        [TestMethod]
        public void TestMethod2()     //买家名字查询测试函数
        {
            Order or1 = new Order(1, cu1);
            Order or2 = new Order(2, cu2); // Customer2订单

            or1.AddDetails(od1);    //订单1添加的条目
            or1.AddDetails(od2);
            or1.AddDetails(od3);
            or1.AddDetails(od4);
            or1.AddDetails(od5);

            or2.AddDetails(od2);   //订单2添加的条目
            or2.AddDetails(od4);

            OrderService ors = new OrderService();   //订单操作
            ors.AddOrder(or1);       //添加订单
            ors.AddOrder(or2);
            List<Order> order2 = ors.GetOrderByCust("Customer2");
            //List<Order> order1 = new List<Order>();   //测试集合
            //order1.Add(or2);

            Assert.IsTrue(or2== order2[0]);
        }


        [TestMethod]
        public void TestMethod3()  //测试通过id删除订单的测试函数
        {
            Order or1 = new Order(1, cu1);
            Order or2 = new Order(2, cu2); // Customer2订单

            or1.AddDetails(od1);    //订单1添加的条目
            or1.AddDetails(od2);
            or1.AddDetails(od3);
            or1.AddDetails(od4);
            or1.AddDetails(od5);

            or2.AddDetails(od2);   //订单2添加的条目
            or2.AddDetails(od4);

            OrderService ors = new OrderService();   //订单操作
            ors.AddOrder(or1);       //添加订单
            ors.AddOrder(or2);

            List<Order> order = new List<Order>();
            order = ors.DeleteOrderByID(2);

            Assert.IsTrue(or1 == order[0]);
        }

        [TestMethod]
        public void TestMethod4()   //用来测试获取某一商品信息的函数
        {
            Order or1 = new Order(1, cu1);
            Order or2 = new Order(2, cu2); // Customer2订单
            or1.AddDetails(od1);    //订单1添加的条目
            or1.AddDetails(od2);
            or1.AddDetails(od3);
            or1.AddDetails(od4);
            or1.AddDetails(od5);

            or2.AddDetails(od2);   //订单2添加的条目
            or2.AddDetails(od4);

            OrderService ors = new OrderService();   //订单操作
            ors.AddOrder(or1);       //添加订单
            ors.AddOrder(or2);

            List<Order> order = new List<Order>();
            order = ors.GetOrderByGoodsName("C#      ");  //只获取订单中指定商品的信息

            Order or3 = new Order(1, cu1);
            Order or4 = new Order(2, cu2);
            or3.AddDetails(od4);
            or4.AddDetails(od4);

            Assert.IsTrue(od4 == order[0].list[0] && od4 == order[1].list[0]);
        }

    }
}
