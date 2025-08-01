using System;

namespace OnlineCourses;

public partial class UserOperations
{
    List<UserDetails> users = new List<UserDetails>();
    UserDetails user1 = new UserDetails()
    {
        RegistrationID = "SYNC1001",
        UserName = "Ravichandran",
        Age = 30,
        Gen = Gender.Male,
        Qualification = "ME",
        MobileNumber = "9938388333",
        MailID = "ravi@gmail.com"
    };
    UserDetails user2 = new UserDetails()
    {
        RegistrationID = "SYNC1002",
        UserName = "Priyadharshini",
        Age = 25,
        Gen = Gender.Female,
        Qualification = "BE",
        MobileNumber = "9944444455",
        MailID = "priya@gmail.com"
    };

    public void AddInitialUsers()
    {
        users.Add(user1);
        users.Add(user2);
    }

    List<CourseDetails> coursesList = new List<CourseDetails>();
    CourseDetails course1 = new CourseDetails()
    {
        CourseID = "CS2001",
        CourseName = "C#",
        TrainerName = "Baskaran",
        CourseDuration = 5,
        SeatsAvailable = 0
    };

    CourseDetails course2 = new CourseDetails()
    {
        CourseID = "CS2002",
        CourseName = "HTML",
        TrainerName = "Ravi",
        CourseDuration = 2,
        SeatsAvailable = 5
    };

    CourseDetails course3 = new CourseDetails()
    {
        CourseID = "CS2003",
        CourseName = "CSS",
        TrainerName = "Priyadharshin",
        CourseDuration = 2,
        SeatsAvailable = 3
    };

    CourseDetails course4 = new CourseDetails()
    {
        CourseID = "CS2004",
        CourseName = "JS",
        TrainerName = "Baskaran",
        CourseDuration = 3,
        SeatsAvailable = 1
    };

    CourseDetails course5 = new CourseDetails()
    {
        CourseID = "CS2005",
        CourseName = "TS",
        TrainerName = "Ravi",
        CourseDuration = 1,
        SeatsAvailable = 2
    };

    public void AddInitialCourses()
    {
        coursesList.Add(course1);
        coursesList.Add(course2);
        coursesList.Add(course3);
        coursesList.Add(course4);
        coursesList.Add(course5);
    }

    public void DisplayCourses()
    {
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("AVAILABLE COURSES");
        Console.WriteLine("----------------------------------------------------------------------");

        foreach (CourseDetails course in coursesList)
        {
            Console.WriteLine($"COURSE ID : {course.CourseID}\nCOURSE NAME : {course.CourseName}\nTRAINER NAME : {course.TrainerName}\nCOURSE DURATION : {course.CourseDuration}\nSEATS AVAILABLE : {course.SeatsAvailable}\n");
        }
        Console.WriteLine("----------------------------------------------------------------------");
    }

    List<EnrollmentDetails> enrollmentDetails = new List<EnrollmentDetails>();

    EnrollmentDetails enrollment1 = new EnrollmentDetails()
    {
        EnrollmentID = "EMT3001",
        CourseID = "CS2001",
        RegistrationID = "SYNC1001",
        EnrollmentDate = Convert.ToDateTime("28/01/2024")
    };

    EnrollmentDetails enrollment2 = new EnrollmentDetails()
    {
        EnrollmentID = "EMT3002",
        CourseID = "CS2003",
        RegistrationID = "SYNC1001",
        EnrollmentDate = Convert.ToDateTime("15/02/2024")
    };
    EnrollmentDetails enrollment3 = new EnrollmentDetails()
    {
        EnrollmentID = "EMT3003",
        CourseID = "CS2004",
        RegistrationID = "SYNC1002",
        EnrollmentDate = Convert.ToDateTime("18/02/2024")
    };

    EnrollmentDetails enrollment4 = new EnrollmentDetails()
    {
        EnrollmentID = "EMT3004",
        CourseID = "CS2002",
        RegistrationID = "SYNC1002",
        EnrollmentDate = Convert.ToDateTime("20/02/2024")
    };

    public void AddEnrollment()
    {
        enrollmentDetails.Add(enrollment1);
        enrollmentDetails.Add(enrollment2);
        enrollmentDetails.Add(enrollment3);
        enrollmentDetails.Add(enrollment4);
    }


}
