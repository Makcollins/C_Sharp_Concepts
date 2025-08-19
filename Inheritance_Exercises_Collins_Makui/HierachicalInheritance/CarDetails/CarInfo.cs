using System;

namespace CarDetails;

public class CarInfo
{
    public string RCBookNumber
    {
        get
        {
            counter++;
            return $"RCBN{counter}";
        }
    }
    public string? EngineNumber { get; set; }
    public string? ChasisNumber { get; set; }
    public double Milage
    {
        get { return CalculateMilage(); }
        set { Milage = value; }
    }
    public double TankCapacity { get; set; }
    public int NumberOfSeats { get; set; }
    public double NumberOfKmDriven { get; set; }
    public DateTime DateOfPurchase { get; set; }

    private static int counter = 1001;

    public double CalculateMilage()
    {
        return Math.Round(NumberOfKmDriven / TankCapacity, 2);
    }

}
