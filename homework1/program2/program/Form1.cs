using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox5.Text = ("  请在第一个和第三个框中输入数据，在第二个框中输入运算符.");
        }

        double a = 0,b = 0,result = 0;    //声明变量
        string temp = null;   //用来储存输入的符号


        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty)
            {
                MessageBox.Show("请输入数据和运算符");      //防止未输入造成的异常
                return;
            }
             a = double.Parse(textBox1.Text); //获取输入的信息
             b = double.Parse(textBox3.Text);
            string c = textBox2.Text;
            if (c == "+"){
                result = a + b;
                temp = "+";
            }
           else if(c == "-")
            {
                result = a - b;
                temp = "-";
            }
            else if(c == "*")
            {
                result = a * b;
                temp = "*";
            }
            else
            {
                result = a / b;
                temp = "/";
            }
                textBox4.Text = (a + " " + temp + " " + b + " = " + result);

            button1.BackColor = Color.Purple;   //点击后改变颜色
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
