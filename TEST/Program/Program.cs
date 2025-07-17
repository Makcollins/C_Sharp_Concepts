using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string txt = "Chennai,Trichy,Mumbai";

            string[] txtArray = txt.Split(',');

            foreach (string item in txtArray)
            {
                Console.WriteLine(item);
            }
        }
    }
}