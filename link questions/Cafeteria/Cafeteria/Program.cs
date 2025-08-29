using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Cafeteria
{
    class Program
    {    
        static void Main(string[] args)
        {
            AuthenticationManager authentication = new();
  
            Console.WriteLine("\n{0}\nCAFETERIA CARD MANAGEMENT\n{0}\n", new String('*', 60));
            do
            {
                Console.WriteLine("\n{0}\nMAIN MENU\n{0}", new String('.', 60));
                Console.WriteLine("\n1. User Registration\n2. User Login\n3. Exit");

                int.TryParse(Console.ReadLine()!, out int choice);

                switch (choice)
                {
                    case 1:
                       authentication.Registration();
                        break;
                    case 2:
                        authentication.UserLogin();
                        break;
                    case 3:
                        return;

                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }
            } while (true);

        }
    }
}