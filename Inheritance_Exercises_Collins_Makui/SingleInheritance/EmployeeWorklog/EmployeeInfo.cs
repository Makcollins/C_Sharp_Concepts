using System;

namespace EmployeeWorklog;

public class EmployeeInfo : SalaryInfo
{
    static int counter = 1001;
    public string EmployeeID { get { return $"DAY{counter++}"; } }
    public string? Name { get; set; }
    public string? Fathername { get; set; }
    public Gender Gender { get; set; }
    public string? Mobile { get; set; }
    public DateTime DOB { get; set; }
    public string? Branch { get; set; }
    public List<Attendance> Attendance = new List<Attendance>();

    public void LogAttendace(Attendance attendance)
    {
        Attendance.Add(attendance);
    }
    public void CalculateSalary()
    {
        decimal salary = 0;

        foreach (var item in Attendance)
        {
            if (item.NumberOfHoursWorked < 8)
            {
                salary += (decimal)item.NumberOfHoursWorked / 8 * 500;
            }
            else
            {
                salary += 500;
            }
        }

        SalaryOfTheMonth = Math.Round(salary, 2);
    }

}
