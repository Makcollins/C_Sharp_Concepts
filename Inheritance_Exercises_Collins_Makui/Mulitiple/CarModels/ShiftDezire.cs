using System;

namespace CarModels;

public class ShiftDezire : Car, IBrand
{
    private static int counter = 1001;
    public string MakingID
    {
        get { return "Mk" + counter++; }
        set { }
    }
    public string? EngineNumber { get; set; }
    public string? ChasisNumber { get; set; }

    //implement IBrand members
    public string BrandName { get; set; } = String.Empty;
    public string ModelName { get; set; } = String.Empty;

    public void Display()
    {
        Console.WriteLine(new string('_',60));
        Console.WriteLine($"Brand: {BrandName} {ModelName}");
        Console.WriteLine($"FuelType: {FuelType}\nNumber of seats: {NumberOfSeats}\nColor: {Color}\nTank Capacity: {TankCapacity}\nNumber of Km Driven: {NumberOfKmDriven}\nMilage: {CalculateMilage()}");
        Console.WriteLine($"Making ID: {MakingID}\nEngine NUmber: {EngineNumber}\nChasis Number: {ChasisNumber}\n");
    }
}
