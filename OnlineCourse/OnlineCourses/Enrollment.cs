using System;

namespace OnlineCourses;

public partial class UserOperations
{
 public void Enroll(string userId, int idCounter)
    {
        int noOfcourses = 0;
        Console.WriteLine("Enter course ID to Enroll");
        string inputID = Console.ReadLine()!;

        CourseDetails? res = coursesList.Find(courses => courses.CourseID == inputID);

        if (res == null)
        {
            Console.WriteLine("\n----------------------------------------------");
            Console.WriteLine("Invalid Course ID. Please enter a valid one");
            Console.WriteLine("----------------------------------------------\n");
        }
        else
        {
            if (res.SeatsAvailable == 0)
            {
                Console.WriteLine("\n----------------------------------------------");
                Console.WriteLine("Seats are not available for the current course");
                Console.WriteLine("----------------------------------------------\n");
            }
            else
            {

                noOfcourses = enrollmentDetails.Count(enrolled => enrolled.RegistrationID == userId);

                if (noOfcourses < 2)
                {
                    EnrollmentDetails newEnrollment = new EnrollmentDetails()
                    {
                        EnrollmentID = "EMT"+idCounter.ToString(),
                        CourseID = res.CourseID,
                        RegistrationID = userId,
                        EnrollmentDate = DateTime.Now
                    };
                    enrollmentDetails.Add(newEnrollment);


                }
                else if (noOfcourses == 2)
                {
                    Console.WriteLine("\n---------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("\nYou have already enrolled in two courses.You can enroll in the next course on {0}\n", EarliestCourseEndDate(userId).ToString("MMMM d, yyyy"));
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------\n");
                }
            }
        }
    }

    public void EnrollmentHistory(string userId)
    {
        var userCourses = UserCourses(userId);

        Console.WriteLine("\n----------------------------------------------");
        Console.WriteLine("***COURSES ENROLLED***");
        Console.WriteLine("----------------------------------------------");
        foreach (var item in userCourses)
        {
            Console.WriteLine("\nENROLLMENT ID: {0}", item.EnrollmentID);
            Console.WriteLine("COURSE ID: {0}", item.CourseID);
            Console.WriteLine("ENROLLMENT DATE: {0}", item.EnrollmentDate);
            Console.WriteLine("..........................................");
        }
        Console.WriteLine();
    }

    // Get courses enrolled by the current user
    public List<EnrollmentDetails> UserCourses(string userId)
    {
        List<EnrollmentDetails> userCourses = enrollmentDetails.FindAll(enroled => enroled.RegistrationID == userId);
        return userCourses;
    }

    //Get the earliest date when user will finish one of the courses.
    public DateTime EarliestCourseEndDate(string userId)
    {
        var userCourses = UserCourses(userId);

        List<DateTime> endDate = new List<DateTime>();
        foreach (var item in userCourses)
        {
            CourseDetails mycourse = coursesList.Find(courses => courses.CourseID == item.CourseID)!;
            if (mycourse.CourseID == item.CourseID)
            {
                DateTime finishDate = item.EnrollmentDate.AddMonths(mycourse.CourseDuration);
                endDate.Add(finishDate);
            }
        }
        return endDate.Min();
    }

    public void NextEnrollment(string userId)
    {
        Console.WriteLine("You can enroll the next course on {0} ", EarliestCourseEndDate(userId).ToString("MMMM d, yyyy"));
        var userCourses = UserCourses(userId);

        foreach (var item in userCourses)
        {
            CourseDetails mycourse = coursesList.Find(courses => courses.CourseID == item.CourseID)!;
            if (mycourse.CourseID == item.CourseID)
            {
                int monthDiff = EarliestCourseEndDate(userId).Month - item.EnrollmentDate.Month;
                if (monthDiff == mycourse.CourseDuration)
                {
                    Console.WriteLine($"\nCourse ID: {mycourse.CourseID}\nCourse Name: {mycourse.CourseName}\nTrainers Name: {mycourse.TrainerName}\nCourse Duration: {mycourse.CourseDuration}\nSeats Available: {mycourse.SeatsAvailable}");
                }
            }
        }


    }


}
