using System;

namespace CarModels;

public class Car
{
    public string? FuelType { get; set; }
    public int NumberOfSeats { get; set; }
    public string? Color { get; set; }
    public double TankCapacity { get; set; }
    public double NumberOfKmDriven { get; set; }

    public double CalculateMilage()
    {
        return Math.Round(NumberOfKmDriven / TankCapacity, 2);
    }
}
