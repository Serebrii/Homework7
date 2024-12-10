using System;

namespace Adapter
{
    internal class Program
    {
        class OldWaterSupplySystem
        {
            public string ConnectToNarrowPipe()
            {
                return "old water supply system";
            }
        }

        interface INewWaterSupplySystem
        {
            string ConnectToWidePipe();
        }

        class NewWaterSupplySystem : INewWaterSupplySystem
        {
            public string ConnectToWidePipe()
            {
                return "new water supply system";
            }
        }

        class WaterSupplyAdapter : INewWaterSupplySystem
        {
            private readonly OldWaterSupplySystem _oldSystem;

            public WaterSupplyAdapter(OldWaterSupplySystem oldSystem)
            {
                _oldSystem = oldSystem;
            }

            public string ConnectToWidePipe()
            {
                return _oldSystem.ConnectToNarrowPipe();
            }
        }

        class WaterConsumer
        {
            public static void UseWater(INewWaterSupplySystem waterSystem)
            {
                Console.WriteLine(waterSystem.ConnectToWidePipe());
            }
        }

        static void Main(string[] args)
        {
            var newWaterSystem = new NewWaterSupplySystem();
            WaterConsumer.UseWater(newWaterSystem);

            var oldWaterSystem = new OldWaterSupplySystem();
            var adapter = new WaterSupplyAdapter(oldWaterSystem);
            WaterConsumer.UseWater(adapter);

            Console.ReadKey();
        }
    }
}
