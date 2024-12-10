using System;

namespace Prototype
{
    internal class Program
    {
        abstract class Prototype
        {
            public int Id { get; private set; }

            public Prototype(int id)
            {
                this.Id = id;
            }

            public abstract Prototype Clone();
        }

        class Triangle : Prototype
        {
            public double SideA { get; set; }
            public double SideB { get; set; }
            public double SideC { get; set; }

            public Triangle(int id, double sideA, double sideB, double sideC)
                : base(id)
            {
                SideA = sideA;
                SideB = sideB;
                SideC = sideC;
            }

            public override Prototype Clone()
            {
                return new Triangle(Id, SideA, SideB, SideC);
            }

            public void Display()
            {
                Console.WriteLine($"Triangle ID: {Id}, Sides: {SideA}, {SideB}, {SideC}");
            }
        }

        static void Main(string[] args)
        {

            Triangle triangle = new Triangle(3, 3.0, 4.0, 5.0);
            Triangle clonedTriangle = (Triangle)triangle.Clone();

            triangle.Display();
            clonedTriangle.Display();

            Console.Read();
        }
    }
}
