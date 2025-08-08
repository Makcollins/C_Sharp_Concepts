using System;

namespace Salary;

public class TemporaryEmployee : SalaryInfo
{
    public string EmployeeID
    {
        get { string gid = "TE" + counter; return gid; }
        set { EmployeeID = value; }
    }
    public EmployeeType EmpType { get; set; }
    public decimal DA
    {
        get { return BasicSalary * (decimal)(0.15 / 100); }
        set { DA = value; }
    }
    public decimal HRA
    {
        get { return BasicSalary * (decimal)(0.13 / 100); }
        set { HRA = value; }
    }
    public decimal PF
    {
        get { return BasicSalary * (decimal)(0.2 / 100); }
        set { PF = value; }
    }
    public decimal TotalSalary
    {
        get { return BasicSalary; }
        set { TotalSalary = value; }
    }

    public decimal CalculateTotalSalary()
    {
        return BasicSalary + DA + HRA + PF;
    }
    private static int counter = 2001;
}
