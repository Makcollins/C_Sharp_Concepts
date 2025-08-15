using System;
using System.Dynamic;

namespace EmployeeWorklog;

public class Attendance
{
    public string DayID { get; set; }
    public DateTime Date { get; set; }
    public int NumberOfHoursWorked { get; set; }
}



public enum Gender { Male, Female }