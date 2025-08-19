using System;
using System.Dynamic;

namespace EmployeeWorklog;

public class Attendance
{
    static int counter = 1001;
    public string DayID { get{ return $"DAY{counter++}"; }}
    public DateTime Date { get; set; }
    public int NumberOfHoursWorked { get; set; }

    public Attendance(DateTime dt, int hoursWorked)
    {
        Date = dt;
        NumberOfHoursWorked = hoursWorked;
    }
}



public enum Gender { Male, Female }