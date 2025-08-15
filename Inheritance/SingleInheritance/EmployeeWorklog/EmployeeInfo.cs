using System;

namespace EmployeeWorklog;

public class EmployeeInfo : SalaryInfo
{
    public string EmployeeID { get; set; }
    public string? Name { get; set; }
    public string? Fathername { get; set; }
    public Gender Gender { get; set; }
    public string? Mobile { get; set; }
    public DateTime DOB { get; set; }
    public string? Branch { get; set; }
    public List<Attendance>? Attendance { get; set; }

    public void LogAttendace(Attendance attendance)
    {
        Attendance.Add(attendance);
    }
    public decimal CalculateSalary(string dayID)
    {
        decimal salary = 0;
        var res = Attendance.Find(x => x.DayID == dayID)!;
        salary = 500 * res.NumberOfHoursWorked / 8;
        
        return salary;
    }
}
