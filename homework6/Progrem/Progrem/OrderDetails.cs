using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrem
{
    //订单明细，包含商品的价格、数量和名称
    public class OrderDetails
    {
        public int ID { set; get; }                 //ID
        public string Name { set; get; }   //名称
        public int Count { set; get; }        //数量
        public double Price { set; get;}    //价格

        public OrderDetails()
        {

        }

        public OrderDetails(int id, string name, int count, double price)  //带参构造方法
        {
            ID = id;
            Name = name;
            Count = count;
            Price = price;

            if (count < 0)   //数量小于0抛出异常
                throw new Exception("The num of goods is not right.");
        }

        public override string ToString()   //重写ToString(),使其返回商品的属性
        {
            return "商品ID：" + ID +"   商品名称：" + Name + "   商品数量：" + Count + "   商品价格：" + Price;
        }
    }
}
