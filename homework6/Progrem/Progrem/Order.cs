using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrem
{
    //订单，包含多条订单明细
    public class Order
    {
        public Order()
        {

        }

        public int ID { set; get; }   //订单ID

        public Customers Cust { set; get; }  // 买家属性

        public List<OrderDetails> list = new List<OrderDetails>();    //添加list

        public Order(int id, Customers cust)   //定义构造函数，包含顾客等信息
        {
            ID = id;
            Cust = cust;
        }

        public void AddDetails(OrderDetails od)     //添加明细
        {
            if (this.list.Contains(od))
            {
                throw new Exception("The orderdetail has been existed.");

            }
            list.Add(od);      //向list集合添加条目
        }

        public void DeleteDetails(OrderDetails od)    //删除明细
        {
            //bool isFound = list.Contains(od);
            //if (isFound == false)    //如果该明细不存在，抛出异常
            //    throw new Exception("Don't find the orderdetail.");
            list.Remove(od);  //删除明细
        }

        public void DeleteDetailsByID(int id)    // 删除所有Id为某一值的明细
        {
            list.RemoveAll(d => d.ID == id);    //linq
            
        }

        public void DeleteDetailsByName(string name)   //删除所有名字为name的明细
        {
            list.RemoveAll(x => x.Name == name);
        }
        
        public void GetOrderDetailsByName(string name)   //获取某一名称的明细
        {
            list.RemoveAll(x => x.Name != name);
        }

        public double GetOrderDetails()   //返回所有订单明细的总价
        {
            double all = 0;
            foreach (OrderDetails od in list)
                all = all + od.Count * od.Price;
            return all;
        }

        public override string ToString()    //返回订单的信息
        {
            string temp ="订单号：" + this.ID +  this.Cust + "\n";
            foreach(OrderDetails s in list)
            {
                temp += s;
                temp += "\n";
            }
            return temp;
        }
    }
}
