using System;

namespace EmployeeSystem;

enum Gender
{
    male,
    female
}
enum WorkLocation
{
    Remote,
    Hybrid,
    Onsite
}
public class Employee
{
    public string EmployeeID
    {
        get; set;
    }

    public string EmployeeName
    {
        get; set;
    }

    public string EmployeeRole
    {
        get; set;
    }

    public string WorkLocation
    {
        get; set;
    }

    public string TeamName
    {
        get; set;
    }

    public DateTime DateOfJoining
    {
        get; set;
    }

    public int WorkingDaysInAMonth
    {
        get; set;
    }

    public int NoOfLeaveTaken
    {
        get; set;
    }

    public string CustomerGender
    {
        get; set;
    }

    //SALARY CALCULATION
    public double SalaryCalculation()
    {
        int payableDays = WorkingDaysInAMonth - NoOfLeaveTaken;
        double salary = payableDays * 500;
        return salary;
    }

    // DISPLAY DETAILS
    public void EmployeeDetails()
    {
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine($"EMPLOYEE ID: {EmployeeID}");
        Console.WriteLine($"EMPLOYEE NAME: {EmployeeName}");
        Console.WriteLine($"WORK LOCATION: {WorkLocation}");
        Console.WriteLine($"TEAM NAME: {TeamName}");
        Console.WriteLine($"DATE OF JOINING: {DateOfJoining}");
        Console.WriteLine($"NUMBER OF WORKING DAYS IN A MONTH: {WorkingDaysInAMonth}");
        Console.WriteLine($"NUMBER OF LEAVES TAKEN: {NoOfLeaveTaken}");
        Console.WriteLine($"GENDER: {CustomerGender}");
        Console.WriteLine("-----------------------------------------------");
    }


}
