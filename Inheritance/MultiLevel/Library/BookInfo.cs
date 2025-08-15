using System;

namespace Library;

public class BookInfo : RackInfo
{
    public string? BookID
    {
         get
        {
            counter++;
            return "BK" + counter;
        }
        set { }
    }
    public string? BookName { get; set; }
    public string? AuthorName { get; set; }
    public decimal Price { get; set; }
    private static int counter = 1000;

    public void Display()
    {
        Console.WriteLine($"Department Name:{DepartmentName}\nDepartment ID: {DepartmentID}\nDegree: {Degree}\n");
        Console.WriteLine($"RackID: {RackID}\nColumn Number: {ColumnNumber}\n");
        Console.WriteLine($"BookName: {BookName}\nBook ID: {BookID}\nAuthor Name: {AuthorName}\nPrice: {Price}\n");
    }
}
