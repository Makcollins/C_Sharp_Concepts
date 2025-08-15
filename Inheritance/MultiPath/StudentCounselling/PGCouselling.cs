using System;
using System.Numerics;

namespace StudentCounselling;

public class PGCouselling : IHSCInfo, IUGInfo
{
    //counters to auto increment ID's
    private static int pgcounter = 1000;
    private static int hsccounter = 1000;
    private static int ugcounter = 1000;
    public string ApllicationID
    {
        get { return "PG" + pgcounter++; }
        set { }
    }
    public DateTime DateOfApplication { get; set; }
    public bool FeeStatus { get; set; }

    public void PayFees(decimal fee)
    {
        if (fee == 500)
        {
            FeeStatus = true;
        }
        else
        {
            FeeStatus = false;
        }
    }

    //Implement interface Personal info
    public string AadharNumber { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    public string FatherName { get; set; } = String.Empty;
    public string Phone { get; set; } = String.Empty;
    public DateTime DOB { get; set; }
    public Gender Gen { get; set; }

    //Implement IHSCInfo members
    public string HSCMarksheetNumber
    {
        get { return "HSC" + hsccounter++; }
        set { }
    }
    public int Physics { get; set; }
    public int Chemistry { get; set; }
    public int Maths { get; set; }
    public int HSCTotal { get; set; }
    public double HSCPercentage { get; set; }

    public void CalculateHSC()
    {
        HSCTotal = Physics + Chemistry + Maths;
        HSCPercentage = HSCTotal / 3;
    }

    void IHSCInfo.Display()
    {
        Console.WriteLine($"HSC Marksheet number: {HSCMarksheetNumber}");
        Console.WriteLine($"{"Physics",10}{"Chemistry",10}{"Marks",10}{"HSCTotal",10}{"HSCPercentage",15}");
        Console.WriteLine($"{Physics,10}{Chemistry,10}{Maths,10}{HSCTotal,10}{HSCPercentage,15}");
    }

    //implement IUGInfo members
    public string UGMarksheetNumber
    {
        get { return "HSC" + ugcounter++; }
        set { }
    }
    public int Sem1Mark { get; set; }
    public int Sem2Mark { get; set; }
    public int Sem3Mark { get; set; }
    public int Sem4Mark { get; set; }
    public int UGTotal
    {
        get; set;
    }
    public double UGPercentage { get; set; }
    public void CalculateUG()
    {
        UGTotal = Sem1Mark + Sem2Mark + Sem3Mark + Sem4Mark;
        UGPercentage = UGTotal / 4;
    }

    void IUGInfo.Display()
    {
        Console.WriteLine($"UG Marksheet number: {UGMarksheetNumber}");
        Console.WriteLine($"{"Sem1Mark",10}{"Sem2Mark",10}{"Sem3Mark",10}{"Sem4Mark",10}{"UGTotal",10}{"UGPercentage",15}");
        Console.WriteLine($"{Sem1Mark,10}{Sem2Mark,10}{Sem3Mark,10}{Sem4Mark,10}{UGTotal,10}{UGPercentage,15}");
    }

}
