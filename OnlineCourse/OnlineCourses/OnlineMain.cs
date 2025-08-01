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
        // int courseCourse = 2003;

        // Console.Clear();

        do
        {
            Console.WriteLine("ONLINE COURSE ENROLLMENT");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Choose an operation.");
            int choice;
            Console.WriteLine("1. User Registration \n2. User Login \n3. Exit");
            bool userInput = int.TryParse(Console.ReadLine(), out choice);


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
