using System;

namespace OnlineCourses;

public partial class UserOperations
{
    //LOGIN
    public void Login()
    {
        correct = true;
        Console.WriteLine("ENTER USER ID:");
        string inputID = Console.ReadLine()!;

        UserDetails? result = users.Find(user => user.RegistrationID == inputID);

        if (result == null)
        {
            Console.WriteLine("Invalid User ID. Please enter a valid one");
        }
        else
        {
            do
            {
                Console.WriteLine("a. Enroll Course \nb. View Enrollment History \nc. Next Enrollment \nd. Exit");
                char choice = Convert.ToChar(Console.ReadLine()!);

                switch (choice)
                {
                    case 'a':
                        DisplayCourses();
                        Enroll(inputID);
                        break;
                    case 'b':
                        Console.WriteLine("History");
                        break;
                    case 'c':
                        Console.WriteLine("Next");
                        break;
                    case 'd':
                        Console.WriteLine("exit");
                        correct = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            } while (correct);
        }

    }

    public void Enroll(string userId)
    {
        Console.WriteLine("Enter course ID to Enroll");
        string inputID = Console.ReadLine()!;

        CourseDetails? res = coursesList.Find(courses => courses.CourseID == inputID);

        if (res == null)
        {
            Console.WriteLine("Invalid Course ID. Please enter a valid one");
        }
        else
        {
            if (res.SeatsAvailable == 0)
            {
                Console.WriteLine("Seats are not available for the current course");
            }
            else
            {
                int count = 0;

                count = enrollmentDetails.Count(enrolled => enrolled.RegistrationID == userId);

                Console.WriteLine("Enrolled = {0}", count);

            }
        }
    }
}
