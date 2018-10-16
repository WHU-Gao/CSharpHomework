using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Progrem2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoScrollMinSize = new Size(ClientRectangle.Width, ClientRectangle.Height);
            //textBox1.Text = "左偏移";
            //textBox2.Text = "右偏移";
            //textBox3.Text = "per1";
            //textBox4.Text = "per2";
            //textBox5.Text = "线条宽度";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null)
                graphics = this.CreateGraphics();
            
            drawCayleyTree(12, 150, 310, 100, -Math.PI / 2);

            try
            {
                th1 = Math.PI * (double.Parse(textBox1.Text)/180);
                th2 = Math.PI * (double.Parse(textBox2.Text)/180);
                Form1.per1 = double.Parse(textBox3.Text);
                Form1.per2 = double.Parse(textBox4.Text);
                width = float.Parse(textBox5.Text);    //线条宽度
                color = textBox6.Text;    //颜色
            }
            catch
            {
                Console.WriteLine("输入异常！");
            }
            //th1 = double.Parse(textBox1.Text);
            //th2 = double.Parse(textBox2.Text);
        }

        private Graphics graphics;
        //static double th1 = 30 * Math.PI / 180;
        //static double th2 = 20 * Math.PI / 180;
        static double th1 = 0.0;
        static double th2 = 0.0;
        static double per1 =0.0;
        static double per2 = 0.0;
        static float width = 0.0f;
        static string color ="";

        double a = 0;

        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0)
                return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);
            
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);

            drawCayleyTree(n - 1, x1 - leng * Math.Cos(th) * 0.3, y1 - leng * Math.Sin(th) * 0.3, per2 * leng, th - th2);
        }


        void drawLine(double x0, double y0, double x1, double y1)
        {
            //设置颜色
            Pen p = null;
            if (color == "Purple")
                p = new Pen(Color.Purple, width);
            if (color == "Blue")
                p = new Pen(Color.Blue, width);
            if (color == "Red")
                p = new Pen(Color.Red, width);
            else
                p = new Pen(Color.Black, width);
                //Pen p = new Pen(Color.Purple, width);
            graphics.DrawLine(p, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
