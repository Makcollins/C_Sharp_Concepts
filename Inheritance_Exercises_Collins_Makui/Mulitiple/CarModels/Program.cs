using System;

namespace CarModels
{
    class Program
    {
        static void Main(string[] args)
        {
            ShiftDezire shiftDezire1 = new ShiftDezire()
            {
                FuelType = "Diesel",
                NumberOfSeats = 4,
                Color = "Blue",
                TankCapacity = 44,
                NumberOfKmDriven = 42000,
                BrandName = "Suzuki",
                ModelName = "Jimmy",
                EngineNumber = "162.215",
                ChasisNumber = "FMDA5146TBC22506"
            };

            ShiftDezire shiftDezire2 = new ShiftDezire()
            {
                FuelType = "Diesel",
                NumberOfSeats = 4,
                Color = "Black",
                TankCapacity = 37,
                NumberOfKmDriven = 1000,
                BrandName = "Suzuki",
                ModelName = "Swift",
                EngineNumber = "2.115",
                ChasisNumber = "JS2AE35S1R5104441"
            };

            Eco eco1 = new Eco()
            {
                FuelType = "Petrol",
                NumberOfSeats = 4,
                Color = "Black",
                TankCapacity = 37,
                NumberOfKmDriven = 420,
                BrandName = "Toyota",
                ModelName = "RAV4",
                EngineNumber = "1.220",
                ChasisNumber = "TR2AE35S1R5104768"
            };
            Eco eco2 = new Eco()
            {
                FuelType = "Petrol",
                NumberOfSeats = 5,
                Color = "White",
                TankCapacity = 37,
                NumberOfKmDriven = 1178,
                BrandName = "Toyota",
                ModelName = "Harrier",
                EngineNumber = "2.231",
                ChasisNumber = "HA2AE35S1R5132461"
            };

            
            shiftDezire1.Display();
            shiftDezire2.Display();
            eco1.Display();
            eco2.Display();
        }
    }
}