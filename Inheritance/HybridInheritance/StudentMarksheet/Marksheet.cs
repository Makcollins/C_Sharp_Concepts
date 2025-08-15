using System;

namespace StudentMarksheet;

public class Marksheet : TheoryExamMarks, ICalculate
{
    public string MarksheetNumber
    {
        get
        {
            counter++;
            return $"MSN_{counter}";
        }
        set{}
    }
    public DateTime DateOfIssue { get; set; }
    public int ProjectMark { get; set; }
    public int Total { get; set; }
    public double Percentage{get;set;}

    public void CalculateUGMarksheet()
    {
        Total = Sem1.Sum() + Sem2.Sum() + Sem3.Sum() + Sem4.Sum()+ProjectMark;
        Percentage = Total / 25;
    }

    public void DisplayMarksheet()
    {
        Console.WriteLine($"MarkSheet number: {MarksheetNumber}\t Date of Issue: {DateOfIssue.ToShortDateString()}\n");
        Console.WriteLine($"{"Session",-10}{"Subject1",-10}{"Subject2",-10}{"Subject3",-10}{"Subject4",-10}{"Subject5",-10}{"Subject6",-10}{"Sum",-10}{"Average",-10}\n{new String('-', 90)}");
        Console.Write($"{"Sem 1",-10}"); displaySemResults(Sem1);
        Console.Write($"{Sem1.Sum(),-10}{Sem1.Sum() / 6,-10}\n");
        Console.Write($"{"Sem 2",-10}"); displaySemResults(Sem2);
        Console.Write($"{Sem2.Sum(),-10}{Sem2.Sum() / 6,-10}\n");
        Console.Write($"{"Sem 3",-10}"); displaySemResults(Sem3);
        Console.Write($"{Sem3.Sum(),-10}{Sem3.Sum() / 6,-10}\n");
        Console.Write($"{"Sem 4",-10}"); displaySemResults(Sem4);
        Console.Write($"{Sem4.Sum(),-10}{Sem4.Sum() / 6,-10}\n");

        Console.WriteLine($"Project Marks: {ProjectMark}");

        Console.WriteLine($"{new String('_', 50)}\nGrandTotal: {Total}\tGrand Average: {Percentage}\n{new String('_', 50)}");

    }

    public void displaySemResults(int[] arr)
    {
        foreach (int item in arr)
        {
            Console.Write($"{item,-10}");
        }
    }

    private static int counter = 1000;
 

}
