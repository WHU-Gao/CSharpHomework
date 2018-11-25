using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Form1Edit : Form
    {
        Order result = new Order();

        public Order GetResult()   //获取添加的订单
        {
            return result;
        }

        public Form1Edit()
        {
            InitializeComponent();
        }

        public Form1Edit(Order order) : this()
        {
            bindingSource1.DataSource = order.list;   //绑定          
        }

        private void Form1Edit_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)     //保存
        {
          try
            {
                OrderDetails od = (OrderDetails)bindingSource1.Current;

                result.ID = textBox1.Text;
                Customers ct = new Customers();
                ct.Name = textBox2.Text;
                ct.Number = textBox3.Text;
                result.Cust = ct;

                result.AddDetails(od);

            }
            catch
            {
                throw new Exception("输入有误！");
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.form1.Close();
        }
    }
}
