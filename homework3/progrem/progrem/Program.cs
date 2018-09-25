using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progrem
{
    //简单简单工厂模式建立四种图形：三角形，正方形，圆形，矩形

    abstract class Shape      //父类
    {
        
        public Shape(String name)   //构造方法
        {
            Name = name;
        }
        public string Name { get; set; }           //名字属性
        public abstract double Area { get; }   //抽象面积属性   

        public void  Show()       //输出图形面积名称和边长
        {
            Console.WriteLine( string.Format("{0,-10}", Name) + "   Area: " + Area);
        }
    }

    //三角形
    class Triangle : Shape
    {

        public Triangle(string name, double width, double height) : base(name)
        {
            Width = width;
            Height = height;
        }
        public double Width { get; set; }   //属性
        public double Height { get; set; }

        public override double Area    //面积属性
        {
            get
            {
                return Width * Height / 2;
            }
        }
    }

    //圆形
    class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle(string name, double radius) : base(name)
        {
            Radius = radius;
        }
        public override double Area
        {
            get
            {
                return Radius * Radius * Math.PI;
            }
        }
    }

    //正方形
    class Square : Shape
    {
        public double Side { get; set; }
        public Square(string name, double side) : base(name)
        {
            Side = side;
        }
        public override double Area
        {
            get
            {
                return Side * Side;
            }
        }
    }

    //矩形
    class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Length { get; set; }
        public Rectangle(string name, double width, double length) : base(name)
        {
            Width = width;
            Length = length;
        }
        public override double Area
        {
            get
            {
                return Width * Length;
            }
        }
    }

    //工厂
    class ShapesFactory{
        public static Shape InitShapes(string name)
        {
            if(name == "Triangle") //三角形
            {
                try
                {
                    Console.Write("请输入三角形的宽和高：");
                    double height = Double.Parse(Console.ReadLine());
                    double width = Double.Parse(Console.ReadLine());
                    return new Triangle("Triangle", width,height);
                }
                catch
                {
                    Console.WriteLine("数据输入有误！");
                    return null;
                }
            }
            if(name == "Circle")   //圆形
            {
                try
                {
                    Console.Write("请输入圆的半径：");
                    double radius = Double.Parse(Console.ReadLine());
                    return new Circle("Circle", radius);
                }
                catch
                {
                    Console.WriteLine("数据输入有误！");
                    return null;
                }
            }
            if(name == "Square")  //正方形
            {
                try
                {
                    Console.Write("请输入正方形的边长：");
                    double side = Double.Parse(Console.ReadLine());
                    return new Square("Square", side);
                }
                catch
                {
                    Console.WriteLine("数据输入有误！");
                    return null;
                }
            }
            if(name == "Rectangle") //矩形
            {
                try
                {
                    Console.Write("请输入矩形的宽和长：");
                    double height = Double.Parse(Console.ReadLine());
                    double width = Double.Parse(Console.ReadLine());
                    return new Rectangle("Rectangle", width, height);
                }
                catch
                {
                    Console.WriteLine("数据输入有误！");
                    return null;
                }
            }
            else
            {             
                return null;
            }
        }
        }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Shapes:");
                Console.WriteLine("Triangle(三角形), Circle(圆形), Square(正方形) and Rectangle(矩形) can be chose. ");
                Console.Write("Please enter the name you choose: ");
                Shape shape;
                string name = Console.ReadLine();
                shape = ShapesFactory.InitShapes(name);
                shape.Show();
            }
            catch
            {
                Console.WriteLine("图片工厂中没有该图形!");
            }
        }
    }

}
