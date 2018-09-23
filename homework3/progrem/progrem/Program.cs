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

        public override string ToString()       //输出图形面积名称和边长
        {
            return string.Format("{0,-10}",Name) + "   Area: " + Area;
        }
    }

    //三角形
    class Triangle : Shape
    {
       
        public Triangle(string name, int width, int height) : base(name)
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
        public Circle( string name , double radius) : base(name)
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
        public Square( string name, double side) :base(name)
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
        public Rectangle( string name, double width, double length) : base(name)
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
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shapes:");
            Shape[] shapes =
            {
                new Triangle("Triangle", 3, 4),
                new Circle( "Circle", 3),
                new Square("Square", 3),
                new Rectangle( "Rectangle", 3, 4)
            };

            foreach (Shape i in shapes)
                Console.WriteLine(i);
        }
    }
}
