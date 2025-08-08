using System;

namespace Salary;

public class SalaryInfo
{
    public string SalaryID
    {
        get { string gid = "SAL" + counter; return gid; }
        set { SalaryID = value; }
    }
    public decimal BasicSalary { get; set; }
    public string? Month { get; set; }

    private static int counter = 1001;
}
