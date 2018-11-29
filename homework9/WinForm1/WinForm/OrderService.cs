using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WinForm
{

    //订单管理，实现查找，删除等功能
    [Serializable]   //说明该类可序列化
    public class OrderService
    {
        public List<Order> _order = new List<Order>();   //定义Order的集合
        public List<Order> order
        {
            get
            {
                return _order;
            }
        }



        public OrderService()
        {

        }
        public void AddOrder(Order or)
        {
            //if (order.Contains(or))
            //    throw new Exception("The order has been existed");
            //order.Add(or);
            using (OrderDB db = new OrderDB())
            {
                db.order.Add(or);
                db.SaveChanges();
            }
        }

        //获得所有订单
        public List<Order> GetAllOrders()
        {
            using (var db = new OrderDB())
            {
                return db.order.Include("list").ToList<Order>();
            }
        }

        //通过买家名字查询订单
        public List<Order> GetOrderByCust(string name)
        {
            //List<Order> or = new List<Order>();
            //var m = from n in order where n.Cust.Name == name select n; 
            //foreach (Order o in m)      //使用linq改进程序
            //    or.Add(o);
            //return or;
            using (var db = new OrderDB())
            {
                return db.order
                  .Where(o => o.Cust.Name.Equals(name)).Include("list").ToList<Order>();
            }
        }

        //通过订单ID删除订单
        public List<Order> DeleteOrderByID(string id)
        {
            using (var db = new OrderDB())
            {
                return db.order
                    .Where(o => o.ID.Equals(id)).Include("list").ToList<Order>();
            }
        }

        //刷新
        public void Update(Order order)
        {
            using (var db = new OrderDB())
            {
                db.order.Attach(order);
                db.Entry(order).State = EntityState.Modified;
                order.list.ForEach(
                    item => db.Entry(item).State = EntityState.Modified);
                db.SaveChanges();
            }
        }

        //获得订单中的某一明细
        public List<Order> GetOrderByGoodsName(string name)
        {
            using (var db = new OrderDB())
            {
                var query = db.order
                  .Where(o => o.list.Where(
                    s => s.Name.Equals(name)).Count() > 0);
                return query.Include("list").ToList<Order>();
            }
        }
    }
    
}
