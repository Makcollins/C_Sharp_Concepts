using System;

namespace OnlineCourses;

public class EnrollmentDetails
{
    public string EnrollmentID { get; set; } = string.Empty;
    public string CourseID { get; set; } = string.Empty;

    public string RegistrationID { get; set; } = string.Empty;

    public DateTime EnrollmentDate { get; set; }

    public int idCounter;
    
}
