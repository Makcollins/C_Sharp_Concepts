using System;

namespace PersonDetails
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterPerson person1 = new RegisterPerson()
            {
                Name = "Nancy Nyabonyi",
                Gen = Gender.Female,
                DOB = Convert.ToDateTime("21/3/1998"),
                Phone = "0112345678",
                MaritalStatus = MaritalStatus.Married,
                FatherName = "Vincent Osoro",
                MotherName = "Elizabeth Nyakundi",
                HouseAdress = "HSE210",
                NoOfSiblings = 3,
                DateofRegistration = Convert.ToDateTime("16/4/2025")
            };
            RegisterPerson person2 = new RegisterPerson()
            {
                Name = "Wilson Oluoch",
                Gen = Gender.Male,
                DOB = Convert.ToDateTime("08/4/2001"),
                Phone = "0768946322",
                MaritalStatus = MaritalStatus.Single,
                FatherName = "Winston Odongo",
                MotherName = "Linda  Achieng'",
                HouseAdress = "HSE210",
                NoOfSiblings = 4,
                DateofRegistration = Convert.ToDateTime("16/4/2025")
            };

            Console.WriteLine(new string('_', 60));
            person1.Display();
            Console.WriteLine(new string('_', 60));
            person2.Display();
        }
    }
}