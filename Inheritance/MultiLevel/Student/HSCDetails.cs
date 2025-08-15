using System;

namespace Student;

public class HSCDetails : StudentInfo
{
    public string HSCMarksheetID
    {
        get
        {
            counter++;
            return "HSC" + counter;
        }
        set
        {
            HSCMarksheetID = value;
        }
    }
    public int Physics { get; set; }
    public int Chemistry { get; set; }
    public int Maths { get; set; }
    public int Total { get; set; }
    public double Percentage { get; set; }

    public HSCDetails(string name, string fatherName, string phone, string mail, DateTime dob, Gender gen) : base(name, fatherName, phone, mail, dob, gen)
    {

    }
    public void Calculate()
    {
        Total = Physics + Chemistry + Maths;
        Percentage = Total / 3;
    }
    private static int counter = 1000;

    public void Display()
    {
        Console.WriteLine("HSC Marksheet ID: {0}\n", HSCMarksheetID);
        Console.WriteLine($"{"Physics",10}{"Chemistry",10}{"Maths",10}{"Total",10}{"Percentage",15}");
        Console.WriteLine($"{Physics,10}{Chemistry,10}{Maths,10}{Total,10}{Percentage,15}");
    }
}
