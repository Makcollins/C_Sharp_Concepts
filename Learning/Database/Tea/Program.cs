using System;
using System.Threading.Tasks;

namespace Tea
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await MakeCoffee();
        }

        static async Task MakeCoffee()
        {
            var water = BoilWater();
            Console.WriteLine("get a cup");
            Console.WriteLine("Put coffee in the cup");
            Console.WriteLine("Add sugar");
            var bread = MakeBread();
            await water;
            Console.WriteLine("Add boild water to cup ");
            Console.WriteLine("Tea ready");
            await bread;
        }
        static async Task BoilWater()
        {
            Console.WriteLine("Get the kettle");
            Console.WriteLine("Add water in the kettle");
            Console.WriteLine("Connect kettle to power");
            Console.WriteLine("Water boiling");
            await Task.Delay(5000);
            Console.WriteLine("Water stopped boiling");
        }

        static async Task MakeBread()
        {
            Console.WriteLine("Put bread in a plate");
            Console.WriteLine("Apply Butter");
            await Task.Delay(6000);
            Console.WriteLine("Serve");
        }
    }
}