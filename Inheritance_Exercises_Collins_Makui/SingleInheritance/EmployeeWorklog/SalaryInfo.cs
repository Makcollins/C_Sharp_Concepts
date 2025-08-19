using System;

namespace EmployeeWorklog;

public class SalaryInfo
{
    static int counter = 101;
    public string SalaryID { get { return $"DAY{counter++}"; } }
    public decimal SalaryOfTheMonth { get; set; }

}
