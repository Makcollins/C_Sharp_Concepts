using System;

namespace OnlineCourses;

public class OnlineMain
{
    static void Main(string[] args)
    {
        UserOperations operation= new UserOperations();
        operation.AddInitialUsers();
        operation.AddInitialCourses();
        operation.AddEnrollment();
        

        bool test = true;

        int idCounter = 1003;
     

        do
        {
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("ONLINE COURSE ENROLLMENT");
            Console.WriteLine("-----------------------------\n");
            Console.WriteLine("Please choose an operation below.");
            int choice;
            Console.WriteLine("1. User Registration \n2. User Login \n3. Exit");
            bool userInput = int.TryParse(Console.ReadLine(), out choice);
            Console.WriteLine("-----------------------------");

            if (userInput)
            {
                switch (choice)
                {
                    case 1:
                        operation.Register(idCounter);
                        idCounter++;
                        break;
                    case 2:
                        operation.Login();
                        break;
                    case 3:
                        test = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice!");
            }
        } while (test);

    }

}
