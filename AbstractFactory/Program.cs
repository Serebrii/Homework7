﻿using System;

namespace AbstractFactory
{
    internal class Program
    {
        public abstract class Car
        {
            public abstract void Info();
            public void Interact(Engine engine)
            {
                Info();
                Console.WriteLine("Set Engine: ");
                engine.GetPower();
            }
        }

        public class Ford : Car
        {
            public override void Info()
            {
                Console.WriteLine("Ford");
            }
        }

        public class Toyota : Car
        {
            public override void Info()
            {
                Console.WriteLine("Toyota");
            }
        }

        public class Mersedes : Car
        {
            public override void Info()
            {
                Console.WriteLine("Mersedes");
            }
        }

        public abstract class Engine
        {
            public virtual void GetPower()
            {
            }
        }

        public class FordEngine : Engine
        {
            public override void GetPower()
            {
                Console.WriteLine("Ford Engine");
            }
        }

        public class ToyotaEngine : Engine
        {
            public override void GetPower()
            {
                Console.WriteLine("Toyota Engine");
            }
        }

        public class MersedesEngine : Engine
        {
            public override void GetPower()
            {
                Console.WriteLine("Mersedes Engine");
            }
        }

        public interface ICarFactory
        {
            Car CreateCar();
            Engine CreateEngine();
        }

        public class FordFactory : ICarFactory
        {
            public Car CreateCar()
            {
                return new Ford();
            }

            public Engine CreateEngine()
            {
                return new FordEngine();
            }
        }

        public class ToyotaFactory : ICarFactory
        {
            public Car CreateCar()
            {
                return new Toyota();
            }

            public Engine CreateEngine()
            {
                return new ToyotaEngine();
            }
        }

        public class MersedesFactory : ICarFactory
        {
            public Car CreateCar()
            {
                return new Mersedes();
            }

            public Engine CreateEngine()
            {
                return new MersedesEngine();
            }
        }

        public class ClientFactory
        {
            private Car car;
            private Engine engine;

            public ClientFactory(ICarFactory factory)
            {
                car = factory.CreateCar();
                engine = factory.CreateEngine();
            }

            public void Run()
            {
                car.Interact(engine);
            }
        }

        static void Main(string[] args)
        {
            ICarFactory carFactory = new ToyotaFactory();
            ClientFactory client1 = new ClientFactory(carFactory);
            client1.Run();

            carFactory = new FordFactory();
            ClientFactory client2 = new ClientFactory(carFactory);
            client2.Run();

            carFactory = new MersedesFactory();
            ClientFactory client3 = new ClientFactory(carFactory);
            client3.Run();

            Console.ReadKey();
        }
        
    }
}
