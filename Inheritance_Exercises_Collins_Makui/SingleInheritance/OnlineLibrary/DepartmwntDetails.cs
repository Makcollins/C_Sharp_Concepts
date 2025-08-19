using System;

namespace OnlineLibrary;

public class DepartmentDetails
{
    static int counter = 1001;
    public string DepartmentID { get { return $"DEPT{counter++}"; } }
    public string? DepartmentName { get; set; }
    public string? Degree { get; set; }
}

public class BookInfo : DepartmentDetails
{
    static int counter = 2001;
    public string BookID { get { return $"BK{counter++}"; } }
    public string? BookName { get; set; }
    public string? AuthorName { get; set; }
    public decimal Price { get; set; }
}