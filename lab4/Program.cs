using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    // Батьківський клас PointSpace
    class PointSpace
    {
        protected double x;
        protected double y;
        protected double z;

        public PointSpace(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void Print()
        {
            Console.WriteLine($"Координати точки: x = {x.ToString("F2")}, y = {y.ToString("F2")}, z = {z.ToString("F2")}");
        }

        // Віртуальний метод для знаходження відстані до початку координат
        public virtual double Length()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
        }
    }

    // Дочірній клас PointPlane
    class PointPlane : PointSpace
    {
        public PointPlane(double x, double y) : base(x, y, 0)
        {
        }

        // Перевизначений метод для знаходження відстані до початку координат на площині
        public override double Length()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Random random = new Random();

            for (int i = 0; i < 3; i++)
            {
                double x = random.NextDouble() * 10;
                double y = random.NextDouble() * 10;

                PointSpace point;

                if (i % 2 == 0)
                {
                    point = new PointSpace(x, y, random.NextDouble() * 10);
                }
                else
                {
                    point = new PointPlane(x, y);
                }

                point.Print();
                double length = point.Length();
                Console.WriteLine($"Відстань до початку координат L: {length.ToString("F2")}\n");
            }

            Console.ReadLine();
        }
    }
    
}
