using System;

namespace Library;

public class DepartmentDetails
{
    public string? DepartmentID
    {
        get
        {
            counter++;
            return "DEPT" + counter;
        }
        set { }
    }
    public string? DepartmentName { get; set; }
    public string? Degree { get; set; }
    private static int counter = 1000;
}
