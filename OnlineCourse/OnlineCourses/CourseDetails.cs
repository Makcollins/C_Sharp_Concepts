using System;

namespace OnlineCourses;

public class CourseDetails
{
public required string CourseID { get; set; }
public required string CourseName { get; set; }
public required string TrainerName { get; set; }
public int CourseDuration { get; set; }
public int SeatsAvailable { get; set; }
}
