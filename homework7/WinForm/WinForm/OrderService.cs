using System;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;

namespace WinForm
{
   
    //订单管理，实现查找，删除等功能
    [Serializable]   //说明该类可序列化
    public class OrderService
    {
        public List<Order> _order = new List<Order>();   //定义Order的集合
        public List<Order> order{
            get
            {
                return _order;
            }
            }

        //生成html文件
        public void CreateHTML()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"E:\project\C#\git\homework7\WinForm\WinForm\File.xml");

                XPathNavigator nav = doc.CreateNavigator();
                nav.MoveToRoot();

                XslCompiledTransform xt = new XslCompiledTransform();
                xt.Load(@"E:\project\C#\git\homework7\WinForm\WinForm\File.xslt");

                FileStream outFileStream = File.OpenWrite(@"..\..\file.html");
                XmlTextWriter writer =
                    new XmlTextWriter(outFileStream, System.Text.Encoding.UTF8);
                xt.Transform(nav, null, writer);


            }
            catch (XmlException e)
            {
                Console.WriteLine("XML Exception:" + e.ToString());
            }
            catch (XsltException e)
            {
                Console.WriteLine("XSLT Exception:" + e.ToString());
            }
        }
        //订单数据验证
        public bool Test()
        {
            for(int i = 0; i < order.Count - 1; i++)  //判断是否重复
            {
                if ((order[i].ID) == (order[i + 1].ID)&&order[i].ID == null && order[i+1].ID == null)
                    return false;
                i++;
            }

            //判断订单号格式是否合理
            string pattern = @"^\s*2[0-9]{3}(0[0-9]|1[0-2])(0[0-9]|[1-2][0-9]|3[0-1])";         
            string pattern1 = @"^(\+86|0086)?\s*1[34578]\d{9}$";   //判断客户手机号是否合理
            Regex rx = new Regex(pattern);
            Regex rx1 = new Regex(pattern1);    
            foreach (Order o in order) {
                Match m = rx.Match(o.ID);
                Match m1 = rx1.Match(o.Cust.Number);
                if (!m.Success || !m1.Success)
                    return false;
            }       
            return true;
        }

        public OrderService()
        {

        }
        public void AddOrder(Order or)
        {
            if (order.Contains(or))
                throw new Exception("The order has been existed");
            order.Add(or);
        }

        //创建xml文件
        public string Export(string name)
        {          
             XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(@"E:\project\C#\git\homework7\WinForm\WinForm\File.xml", FileMode.Create))
            {         
                xs.Serialize(fs,order);
            }
            
            return name;
        }

        //读取xml文件
        public List<Order> Import(string name)
        {
            List<Order> temp = new List<Order>();
             XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(name, FileMode.Create))       
            {
                List<Order> or = (List<Order>)xs.Deserialize(fs);
                foreach (Order o in or)
                {
                    temp.Add(o);
                    //Console.WriteLine(o);
                }
            }
            return temp;
        }

        //获得所有订单
        public List<Order> GetAllOrders()
        {
            return order;
        }

        //通过买家名字查询订单
        public List<Order> GetOrderByCust(string name)
        {
            List<Order> or = new List<Order>();
            var m = from n in order where n.Cust.Name == name select n; 
            foreach (Order o in m)      //使用linq改进程序
                or.Add(o);
            //foreach (Order o in order)
            //    if (o.Cust.Name == name)
            //    {
            //        or.Add(o);
            //    }
            return or;
        }

        //通过订单ID删除订单
        public List<Order> DeleteOrderByID(int id)
        {
            List<Order> or = new List<Order>();
            //order.RemoveAll(o => o.ID == id);
            //foreach (Order s in order)
            //    or.Add(s);
            //return or;
            var m = from n in order where int.Parse(n.ID )!= id select n;
            foreach (Order x in m)
                or.Add(x);
            return or;
        }

        //获得订单中的某一明细
        public List<Order> GetOrderByGoodsName(string name)
        {
            List<Order> or = new List<Order>();
            foreach (Order o in order)
            {
                o.GetOrderDetailsByName(name);
                or.Add(o);
            }
            return or;
        }

       // 获取所有订单的总价格
        //public double All()
        //{
        //    double all = 0;
        //    foreach(Order o in order)
        //    {
        //        all = all + o.AddOrderDetails();
        //    }
        //    return all;
        //}

    }
}
