using System;

namespace StudentCounselling
{
    class Program
    {
        static void Main(string[] args)
        {
            IHSCInfo hscStudent1 = new PGCouselling()
            {
                AadharNumber = "1001 2012 1122",
                Name = "Samwel Ochieng",
                FatherName = "Ouko",
                Phone = "0789564738",
                DOB = Convert.ToDateTime("14/2/2008"),
                Gen = Gender.Male,
                Physics = 76,
                Chemistry = 71,
                Maths = 69,
            };
            hscStudent1.CalculateHSC();
            // hscStudent1.Display();

            IHSCInfo hscStudent2 = new PGCouselling()
            {
                AadharNumber = "1011 3102 1134",
                Name = "Becky Marion",
                FatherName = "Mutua",
                Phone = "0713456278",
                DOB = Convert.ToDateTime("03/4/2008"),
                Gen = Gender.Female,
                Physics = 68,
                Chemistry = 69,
                Maths = 86,
            };
            hscStudent2.CalculateHSC();

            // objects for UGInfo
            IUGInfo uGInfo1 = new PGCouselling()
            {
                AadharNumber = "1000 1102 1005",
                Name = "Mary Wanjiru",
                FatherName = "Mwangi",
                Phone = "0110456789",
                DOB = Convert.ToDateTime("11/4/2001"),
                Gen = Gender.Female,
                Sem1Mark = 63,
                Sem2Mark = 62,
                Sem3Mark = 60,
                Sem4Mark = 66
            };
            uGInfo1.CalculateUG();

            IUGInfo uGInfo2 = new PGCouselling()
            {
                AadharNumber = "1000 1102 1023",
                Name = "Abdulahi Musa",
                FatherName = "Karim",
                Phone = "0110456789",
                DOB = Convert.ToDateTime("11/4/2001"),
                Gen = Gender.Female,
                Sem1Mark = 68,
                Sem2Mark = 62,
                Sem3Mark = 63,
                Sem4Mark = 71
            };
            uGInfo2.CalculateUG();

            PGCouselling pgCounseling1 = new PGCouselling();
            pgCounseling1.DateOfApplication = Convert.ToDateTime("22/4/2025");
            pgCounseling1.PayFees(500);

            PGCouselling pGCouselling2 = new PGCouselling();
            pGCouselling2.DateOfApplication = Convert.ToDateTime("11/5/2025");
            pGCouselling2.PayFees(0);


            List<IHSCInfo> hSCInfos = new List<IHSCInfo>();
            hSCInfos.Add(hscStudent1);
            hSCInfos.Add(hscStudent2);

            List<IUGInfo> uGInfos = new List<IUGInfo>();
            uGInfos.Add(uGInfo1);
            uGInfos.Add(uGInfo2);
            Console.WriteLine("{0}\nHSC INFORMATION\n{0}", new String('_',60));
            foreach (var item in hSCInfos)
            {
                Console.WriteLine($"Name: {item.Name} {item.FatherName}");
                Console.WriteLine($"Aadhar Number: {item.AadharNumber}");
                Console.WriteLine($"Phone: {item.Phone}\t\tDOB: {item.DOB.ToShortDateString()}\t\tGender: {item.Gen}\n");
                item.Display();
                Console.WriteLine($"\nApplication ID: {pgCounseling1.ApllicationID}");
                Console.WriteLine($"Date of Appliction: {pgCounseling1.DateOfApplication.ToShortDateString()}");
                Console.WriteLine($"Fee Status : {pgCounseling1.FeeStatus}\n {new String('-',60)}");
            }

            Console.WriteLine("{0}\nUG INFORMATION\n{0}", new String('_',60));
            foreach (var item in uGInfos)
            {
                Console.WriteLine($"Name: {item.Name} {item.FatherName}");
                Console.WriteLine($"Aadhar Number: {item.AadharNumber}");
                Console.WriteLine($"Phone: {item.Phone}\t\tDOB: {item.DOB.ToShortDateString()}\t\tGender: {item.Gen}\n");
                item.Display();
                Console.WriteLine($"\nApplication ID: {pGCouselling2.ApllicationID}");
                Console.WriteLine($"Date of Appliction: {pGCouselling2.DateOfApplication.ToShortDateString()}");
                Console.WriteLine($"Fee Status : {pGCouselling2.FeeStatus}\n{new String('-',60)}");
            }
        }
    }
}