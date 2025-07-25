using System;

namespace BillCalculator;

    public class Bill
    {
        public string MeterID
        {
            get; set;
        }

        public string UserName
        {
            get; set;
        }

        public string PhoneNumber
        {
            get; set;
        }

        public string MailID
        {
            get; set;
        }
        public Double UnitsUsed
        {
            get; set;
        }
   
        public void CalculateAmount()
        {
            Console.WriteLine("_____________________________________________________");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"Hello {UserName}, Please enter Amount below.");
            Console.Write("Amount: ");
            double amt = double.Parse(Console.ReadLine());
            double units = amt / 5;
            var randomID = new System.Random();
            string transID = "TRA" + randomID.Next().ToString();
            Console.WriteLine("............................................");
            Console.WriteLine($"Bill ID: {transID}.--- Dear {UserName}, You have successfully purchased {units} at Rs {amt}");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("_____________________________________________________");
        }

        public void DisplayDetails()
        {
            Console.WriteLine("_____________________________________________________");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"METER ID: {MeterID}");
            Console.WriteLine($"USER NAME: {UserName}");
            Console.WriteLine($"PHONE NO: {PhoneNumber}");
            Console.WriteLine($"MAILD ID: {MailID}");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("_____________________________________________________");
        }

    }