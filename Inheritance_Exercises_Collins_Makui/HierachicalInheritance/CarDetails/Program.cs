using System;

namespace CarDetails
{
    class Program
    {
        static void Main(string[] args)
        {
            Tata tata1 = new Tata()
            {
                CarModelName = "Vista",
                CarModelNumber = "1.4 75HP",
                EngineNumber = "162.215",
                ChasisNumber = "FMDA5146TBC22506",
                TankCapacity = 44,
                NumberOfSeats = 4,
                NumberOfKmDriven = 42000,
                DateOfPurchase = Convert.ToDateTime("14/6/2006")
            };
            Tata tata2 = new Tata()
            {
                CarModelName = "Tata Bolt",
                CarModelNumber = "Revotron XE",
                EngineNumber = "1.215",
                ChasisNumber = "1B3HB48B67D562726",
                TankCapacity = 43,
                NumberOfSeats = 4,
                NumberOfKmDriven = 2000,
                DateOfPurchase = Convert.ToDateTime("21/2/2011")
            };

            Suzuki suzuki1 = new Suzuki()
            {
                CarModelName = "Suzuki Jimny",
                CarModelNumber = "Jimny 05-door",
                EngineNumber = "162.215",
                ChasisNumber = "FMDA5146TBC22506",
                TankCapacity = 48,
                NumberOfSeats = 4,
                NumberOfKmDriven = 500,
                DateOfPurchase = Convert.ToDateTime("14/6/2006")
            };
            Suzuki suzuki2 = new Suzuki()
            {
                CarModelName = "Suzuki Swift",
                CarModelNumber = "New-Swift",
                EngineNumber = "1.215",
                ChasisNumber = "JS2AE35S1R5104441",
                TankCapacity = 37,
                NumberOfSeats = 4,
                NumberOfKmDriven = 1400,
                DateOfPurchase = Convert.ToDateTime("21/2/2011")
            };

            List<Tata> tatas = new List<Tata>();
            tatas.Add(tata1);
            tatas.Add(tata2);

            List<Suzuki> suzuki = new List<Suzuki>();
            suzuki.Add(suzuki1);
            suzuki.Add(suzuki2);

            Console.WriteLine("{0}\nTATA MODELS", new String('_', 100));
            foreach (var item in tatas)
            {
                Console.WriteLine($"{new String('`', 100)}\nCar Model Name:{item.CarModelName}\nCar Modele Number: {item.CarModelNumber}\nRC Book number: {item.RCBookNumber}\nEngine Number: {item.EngineNumber}\nChasis number: {item.ChasisNumber}\nMilage: {item.Milage} km/l.\nTank Capacity: {item.TankCapacity}\nNumber of Seats: {item.NumberOfSeats}\n Number of kilometers driven: {item.NumberOfKmDriven} km.\nDate 0f purchase: {item.DateOfPurchase.ToLongDateString()}\n{new String('`', 100)}");
            }
            Console.WriteLine("{0}\nSUZUKI MODELS",new String('_',100));
            foreach (var item in suzuki)
            {
                Console.WriteLine($"{new String('`', 100)}\nCar Model Name:{item.CarModelName}\nCar Modele Number: {item.CarModelNumber}\nRC Book number: {item.RCBookNumber}\nEngine Number: {item.EngineNumber}\nChasis number: {item.ChasisNumber}\nMilage: {item.Milage} km/l.\nTank Capacity: {item.TankCapacity}\nNumber of Seats: {item.NumberOfSeats}\n Number of kilometers driven: {item.NumberOfKmDriven} km.\nDate 0f purchase: {item.DateOfPurchase.ToLongDateString()}\n{new String('`', 100)}");
            }
        }
    }
}