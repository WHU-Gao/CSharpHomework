using System;
using System.Threading;
namespace Progrem
{
    //
    //闹钟定时功能
    //
    //1.定义参数类型
    public class Time
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
    }
    //2.声明委托
    public delegate void ClockTime(object sender, Time e);  
    class Clock
    {
        //3.声明时间
        public event ClockTime SetClock;
        public  void SetTime(int s)  //定时
        {
            Thread.Sleep(1000 * s);   //休眠
            Time time = new Time();
            time.Hour = DateTime.Now.Hour; //获取小时
            time.Minute = DateTime.Now.Minute; //获取分钟  
            time.Second = DateTime.Now.Second; //获取秒数                    
            SetClock(this, time);     //4.发生事件
        }       
    }
    class Progrem
    {
        static void Main(string[] args)
        {
            //输出现在时间
            string now = DateTime.Now.ToLongTimeString();
            Console.WriteLine("当前时间是：" + now);

            Console.Write("请输入多少秒后提醒：");
            int s = int.Parse(Console.ReadLine());
            Console.WriteLine(s + "秒后提醒！");

            Clock clock = new Clock();
            //5.注册事件
            clock.SetClock += Progrem.Show;
            clock.SetTime(s);
        }
        //6.事件处理方法
        public static void Show(object sender, Time e)
        {           
            Console.WriteLine("现在的时间是：" + e.Hour + " : " + e.Minute + " : " + e.Second); //ps: 输入时的延迟会导致响应时显示的时间偏大
            Console.WriteLine("现在可以打《王者荣耀》了！");
        }
    }
}
