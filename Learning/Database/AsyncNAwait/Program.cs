using System;

namespace AsyncNAwait
{
    class Program
    {
        async static Task Main()
        {   
            await MakeTeaAsync();
        }
        
        public async static Task<string> MakeTeaAsync()
        {
            var boilingWater = BoilingWater();
            System.Console.WriteLine("Take the cups out");
            System.Console.WriteLine("Put tea in cups");
            var water = await boilingWater;
            var tea = $"pour {water} in cups";
            System.Console.WriteLine(tea);
            return tea;
        }

        public async static Task<string> BoilingWater()
        {
            System.Console.WriteLine("Start the kettle");
            System.Console.WriteLine("waiting for the kettle");
            await Task.Delay(2000);
            System.Console.WriteLine("Kettle finished boiling");
            return "water";
        }
    }
}