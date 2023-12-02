using System;


namespace Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = [new Circle(9.3), new Triangle(9, 3, 7), new Quadrate(25), new Hexagon(5)];

            foreach (Shape shape in shapes)
            {
                Console.WriteLine();
                shape.Info();
                Console.WriteLine("Периметр: {0}", shape.Perimeter());
                Console.WriteLine("Площадь: {0}", shape.Square());
                Console.WriteLine("Радиус вписанной окружности: {0}", shape.Ring());
                shape.Rotate();
                shape.Ring();
            }
            Console.WriteLine("\nФигуры до сортировки по радиусу вписанной окружности");
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.ToString());
            }
            Array.Sort(shapes);
            Console.WriteLine("\nФигуры отсортированы по радиусу вписанной окружности");
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.ToString());
            }
        }
    }
    public abstract class Shape : IComparable<Shape>
    {
        public abstract void Info();
        public abstract double Perimeter();
        public abstract double Square();
        public abstract double Ring();
        public virtual void Rotate()
        { }
        public int CompareTo(Shape other)
        {
            return Ring().CompareTo(other.Ring());
        }
    }
    class Circle : Shape
    {
        protected double r;
        public Circle(double r)
        {
            this.r = r;
        }
        public override void Info()
        {
            Console.WriteLine("Окружность с радиусом  r = {0}", r);
        }
        public override double Perimeter()
        {
            return 2 * 3.14 * r;
        }
        public override double Square()
        {
            return 3.14 * r * r;
        }
        public override double Ring()
        {
            return r;
        }
    }
    class Triangle : Shape
    {
        protected double a, b, c;
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override void Info()
        {
            Console.WriteLine("Треугольник со сторонами а = {0}, b = {1}, c = {2}", a, b, c);
        }
        public override double Perimeter()
        {
            return a + b + c;
        }
        public override double Square()
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        public override double Ring()
        {
            double p = (a + b + c) / 2;
            return 2 * (p * (p - a) * (p - b) * (p - c)) / (a + b + c);
        }
        public override void Rotate() { Console.WriteLine("Фигура совершила вращение вокруг своего центра"); }
       }
    class Quadrate : Shape
    {
        protected double d;
        public Quadrate(double d)
        {
            this.d = d;
        }
        public override void Info()
        {
            Console.WriteLine("Квадрат со стороной d = {0}", d);
        }
        public override double Perimeter()
        {
            return d + d + d + d;
        }
        public override double Square()
        {
            return d * d;
        }
        public override double Ring()
        {
            return d / 2;
        }
        public override void Rotate() { Console.WriteLine("Фигура совершила вращение вокруг своего центра"); }
    }
    class Hexagon : Shape
    {
        protected double e;
        public Hexagon(double e)
        {
            this.e = e;
        }
        public override void Info()
        {
            Console.WriteLine("Правильный шестиугольник со стороной e = {0}", e);
        }
        public override double Perimeter()
        {
            return e * 6;
        }
        public override double Square()
        {
            return 3 * e * e * Math.Sqrt(3) / 2;
        }
        public override double Ring()
        {
            return Math.Sqrt(3) / 2 * e;
        }
    }
}