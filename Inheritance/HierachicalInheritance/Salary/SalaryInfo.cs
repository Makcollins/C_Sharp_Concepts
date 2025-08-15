using System;

namespace Salary;

public class SalaryInfo
{
    public string SalaryID
    {
        get { return "SAL" + counter++; }
    }
    public decimal BasicSalary { get; set; }
    public string? Month { get; set; }

    private static int counter = 1001;
}
