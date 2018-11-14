using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm
{
    //定义顾客的一些信息
    public class Customers
    {
        public int ID { set; get; }   //顾客ID
        public string Name { set; get; }  //顾客姓名
        public string Number { set; get; }  //顾客电话

        public Customers()
        {

        }

        public Customers(int id, string name, string num)   //定义构造函数,初始化属性
        {
           ID = id;
            Name = name;
            Number = num;
        }

        public override string ToString()   //返回买家信息
        {
            //return "买家ID: " + ID + "  买家姓名: " + Name;
            return Name + " " + Number;
        }
    }
}
