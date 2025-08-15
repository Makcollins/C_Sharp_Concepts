using System;

namespace StudentMarksheet
{
    class Program
    {
        static void Main(string[] args)
        {
            TheoryExamMarks marks = new TheoryExamMarks();
            Marksheet sheet1 = new Marksheet()
            {
                Name = "Eliud Mogere",
                FatherName = "Charles Ongeri",
                phone = "0712345678",
                DOB = Convert.ToDateTime("12/12/2004"),
                Gen = Gender.Male,
                Sem1 = new int[6] { 50, 50, 50, 50, 50, 50 },
                Sem2 = new int[6] { 55, 55, 55, 55, 55, 55 },
                Sem3 = new int[6] { 60, 60, 60, 60, 60, 60 },
                Sem4 = new int[6] { 65, 65, 65, 65, 65, 65 },
                ProjectMark = 76,
                DateOfIssue = DateTime.Now
            };
            sheet1.CalculateUGMarksheet();

            Marksheet sheet2 = new Marksheet()
            {
                Name = "Mary Atieno",
                FatherName = "Daniel Ochieng",
                phone = "0768473623",
                DOB = Convert.ToDateTime("08/1/2006"),
                Gen = Gender.Male,
                Sem1 = new int[6] { 52, 53, 90, 74, 67, 87 },
                Sem2 = new int[6] { 60, 55, 55, 82, 55, 55 },
                Sem3 = new int[6] { 70, 60, 50, 60, 98, 60 },
                Sem4 = new int[6] { 52, 65, 74, 65, 63, 65 },
                ProjectMark = 87,
                DateOfIssue = DateTime.Now
            };
            sheet2.CalculateUGMarksheet();

            List<Marksheet> marksheet = new List<Marksheet>();
            marksheet.Add(sheet1);
            marksheet.Add(sheet2);

            foreach (var item in marksheet)
            {
                Console.WriteLine("\n\nRegistration Number: " + item.RegistrationNumber);
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Father Name: " + item.FatherName);
                Console.WriteLine("Phone: " + item.phone);
                Console.WriteLine("DOB: " + item.DOB.ToShortDateString());
                Console.WriteLine("Gender: " + item.Gen);
                item.DisplayMarksheet();
            }

        }
    }
}