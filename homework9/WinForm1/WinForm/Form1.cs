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
    //ps:能创建和同步成功，但最后有一个报错。
    public partial class Form1 : Form
    {
        public static int close = 0;

        public static OrderService os = new OrderService();
        public List<Order> order = new List<Order>();
        public static bool AddOrder = false;

        private string num = "20181112001";
         public string Num
        {
            get
            {
                return num;
            }
            set
            {             
                num = value;
            }
        }   
        public Form1()
        {
            InitializeComponent();
            order = os.GetAllOrders();

            bindingSource1.DataSource = order;
            //绑定查询条件
            textBox1.DataBindings.Add("Text", this, "Num");
            if(order.Count !=0)
                bindingSource2.DataSource = order[0].list;         
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)  //查询
        {          
                bindingSource1.DataSource = order.Where(s => s.ID ==Num);          
                
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        public static Form1Edit form1 = new Form1Edit(new Order());

        private void button3_Click(object sender, EventArgs e)    //新建订单
        {
            AddOrder = true;
            form1.ShowDialog();         
            Order order1 = form1.GetResult();
            if (order1 != null)
            {
                order.Add(order1);

                os.AddOrder(order1);  //与数据库同步

                bindingSource1.ResetBindings(false);  //重新绑定
                bindingSource2.ResetBindings(false);
            }
        }

        private void button2_Click(object sender, EventArgs e)   //删除订单
        {
            Order or = (Order)bindingSource1.Current;
            if (or != null)
            {

                order.RemoveAll(o => (o.ID == or.ID));

                os.DeleteOrderByID(or.ID);

                bindingSource1.ResetBindings(false);  //重新绑定
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)   //修改订单一某一明细数量
        {
            AddOrder = false;
            form1 = new Form1Edit((Order)bindingSource1.Current);
            form1.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //ps:此处为刷新第二个view
            string temp = label4.Text;
            string temp1 = temp.Substring(8, 3);   //截取字符串

            bindingSource2.DataSource = order[int.Parse(temp1) - 1].list;
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
