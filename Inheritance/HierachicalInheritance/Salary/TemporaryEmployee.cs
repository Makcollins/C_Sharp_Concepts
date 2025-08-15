using System;

namespace Salary;

public class TemporaryEmployee : SalaryInfo
{
    public string EmployeeID
    {
        get { return  "TE" + counter++; }
    }
    public EmployeeType EmpType { get; set; }
    public decimal DA
    {
        get { return Math.Round(BasicSalary * (decimal)(0.15 / 100),2); }
        set { DA = value; }
    }
    public decimal HRA
    {
        get { return Math.Round(BasicSalary * (decimal)(0.13 / 100),2); }
        set { HRA = value; }
    }
    public decimal PF
    {
        get { return Math.Round(BasicSalary * (decimal)(0.2 / 100),2); }
        set { PF = value; }
    }
    public decimal TotalSalary
    {
        get { return CalculateTotalSalary(); }
    }

    public decimal CalculateTotalSalary()
    {
        return Math.Round(BasicSalary + DA + HRA - PF,2);
    }
    private static int counter = 2001;
}
