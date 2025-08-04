using System;

namespace OnlineCourses;

public partial class UserOperations
{
    int idEnroll = 3005;
    //LOGIN
    public void Login()
    {
        correct = true;
        Console.WriteLine("ENTER USER ID:");
        string inputID = Console.ReadLine()!;
        Console.WriteLine("\n----------------------------------");

        UserDetails? result = users.Find(user => user.RegistrationID == inputID);

        if (result == null)
        {
            Console.WriteLine("Invalid User ID. Please enter a valid one");
        }
        else
        {
            do
            {
                Console.WriteLine("Welcome {0}",result.UserName);
                Console.WriteLine("----------------------------------\n");
                System.Console.WriteLine("Please choose an operation below to continue\n");
                Console.WriteLine("a. Enroll Course \nb. View Enrollment History \nc. Next Enrollment \nd. Exit");
                char choice = Convert.ToChar(Console.ReadLine()!);

                switch (choice)
                {
                    case 'a':
                        DisplayCourses();
                        Enroll(inputID, idEnroll);
                        idEnroll++;
                        break;
                    case 'b':
                        EnrollmentHistory(inputID);
                        break;
                    case 'c':
                        NextEnrollment(inputID);
                        break;
                    case 'd':
                        correct = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            } while (correct);
        }

    }

}