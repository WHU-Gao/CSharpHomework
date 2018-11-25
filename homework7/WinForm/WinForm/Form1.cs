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
    
    public partial class Form1 : Form
    {
        public static int close = 0;

        public List<Order> order = new List<Order>();
        private string num = "20181112000";
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
            //订单信息
            OrderDetails od1 = new OrderDetails(1, "Math    ", 2, 80);   //初始化明细
            OrderDetails od2 = new OrderDetails(2, "English ", 5, 100);
            OrderDetails od3 = new OrderDetails(3, "Chinese ", 4, 120);
            OrderDetails od4 = new OrderDetails(4, "C#      ", 1, 90);
            OrderDetails od5 = new OrderDetails(2, "English ", 3, 10);

            Customers cu1 = new Customers(1, "Customer1", "15327402588");    //顾客
            Customers cu2 = new Customers(2, "Customer2","13279526774");
            //Customers cu3 = new Customers(3, "Customer3");
            Order or1 = new Order("20181113001", cu1);     //订单
            Order or2 = new Order("20181112002", cu2);
            //Order or3 = new Order(3, cu3);

            or1.AddDetails(od1);    //订单1添加的条目   
            or1.AddDetails(od3);                   

            or2.AddDetails(od2);   //订单2添加的条目
            or2.AddDetails(od4);

            //or3.AddDetails(od3);

            order.Add(or1);
            order.Add(or2);

            OrderService ors = new OrderService();   //订单操作
            ors.AddOrder(or1);       //添加订单
            ors.AddOrder(or2);
            if (!ors.Test())
            {
                MessageBox.Show("The ID is not right!");
                return;
            }
            ors.Export("File");  //转换为xml文件

            //ors.CreateHTML();  //生成html文件

            InitializeComponent();

            bindingSource1.DataSource = order;
            //绑定查询条件
            textBox1.DataBindings.Add("Text", this, "Num");

            //int temp = int.Parse(label4.Text);
            bindingSource2.DataSource = order[0].list; ;
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
            
            form1.ShowDialog();
            
            //if (close == 1)  //close为1关闭窗体
            //{
            //    form1.Close();
            //    close = 0;
            //}

            Order order1 = form1.GetResult();
            if (order1 != null)
            {
                order.Add(order1);  
                bindingSource1.ResetBindings(false);  //重新绑定
                //textBox1.Text = order1.ToString();
                bindingSource2.ResetBindings(false);
            }             
        }

        private void button2_Click(object sender, EventArgs e)   //删除订单
        {
            Order or = (Order)bindingSource1.Current;
            if (or != null)
            {
               
                order.RemoveAll(o => (o.ID == or.ID));
                bindingSource1.ResetBindings(false);  //重新绑定
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)   //修改订单一某一明细数量
        {
            //Form1Edit form = new Form1Edit((Order)bindingSource1.Current);
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
