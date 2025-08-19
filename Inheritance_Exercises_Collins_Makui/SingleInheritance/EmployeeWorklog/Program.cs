using System;
using System.Runtime.CompilerServices;

namespace EmployeeWorklog
{
    class Program
    {
        static void Main(string[] args)
        {
            // SalaryInfo salaryInfo;

            EmployeeInfo employeeInfo = new EmployeeInfo()
            {
                Name = "Mark Oloo",
                Fathername = "Otieno",
                Gender = Gender.Male,
                Mobile = "0799588345",
                DOB = Convert.ToDateTime("22/3/2000"),
                Branch = "Kisumu"
            };

            List<Attendance> attendances = new List<Attendance>();

            employeeInfo.LogAttendace(new Attendance(Convert.ToDateTime("11/8/2025"), 9));
            employeeInfo.LogAttendace(new Attendance(Convert.ToDateTime("12/8/2025"), 7));
            employeeInfo.LogAttendace(new Attendance(Convert.ToDateTime("13/8/2025"), 8));
            employeeInfo.LogAttendace(new Attendance(Convert.ToDateTime("14/8/2025"), 8));
            employeeInfo.LogAttendace(new Attendance(Convert.ToDateTime("15/8/2025"), 8));

            employeeInfo.CalculateSalary();

            Console.WriteLine($"Name: {employeeInfo.Name} {employeeInfo.Fathername} ");
            Console.WriteLine($"Gender: {employeeInfo.Gender}\nMobile: {employeeInfo.Mobile}");
            Console.WriteLine($"DOB: {employeeInfo.DOB.ToShortDateString()}\nBranch: {employeeInfo.Branch}");

            Console.WriteLine("Employee Attendance:");
            foreach (var item in employeeInfo.Attendance)
            {
                Console.WriteLine($"Date: {item.Date.ToShortDateString()}\t\tDay ID: {item.DayID}\t\tHours worked: {item.NumberOfHoursWorked}");
            }
            Console.WriteLine($"\nSalary: {employeeInfo.SalaryOfTheMonth}");
            Console.WriteLine("\nSalary ID: {0}",employeeInfo.SalaryID);

        }
    }
}