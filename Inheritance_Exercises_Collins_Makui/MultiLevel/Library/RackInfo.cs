using System;

namespace Library;

public class RackInfo : DepartmentDetails
{
    public string? RackID
    {
        get
        {
            counter++;
            return "RACK" + counter;
        }
        set { }
    }
    public int ColumnNumber { get; set; }
    private static int counter = 1000;
}
