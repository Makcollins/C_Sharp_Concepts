using System;

namespace Student
{
    class Program
    {
        static void Main(string[] args)
        {
            HSCDetails student1 = new HSCDetails("Victor Kimani","Munene","0123435467","victorm@gmail.com",Convert.ToDateTime("14/12/2008"),Gender.Male)
            {
                Standard = "8",
                Branch = "West",
                AcademicYear = "2023",
                Physics = 80,
                Chemistry = 65,
                Maths = 91
            };
            student1.Calculate();

            HSCDetails student2 = new HSCDetails("Ruth Nekesa","Wanjala","0754362431","ruthnekesa@gmail.com",Convert.ToDateTime("05/2/2010"),Gender.Female)
            {
                Standard = "8",
                Branch = "East",
                AcademicYear = "2023",
                Physics = 74,
                Chemistry = 75,
                Maths = 82
            };
            student2.Calculate();

            List<HSCDetails> students = new List<HSCDetails>();
            students.Add(student1);
            students.Add(student2);

            foreach (var item in students)
            {
                Console.WriteLine(new string('`', 100));
                Console.WriteLine($"UserID: {item.UserID}\nName: {item.Name} {item.FatherName}");
                Console.WriteLine($"Phone: {item.Phone}\nMail: {item.Mail}");
                Console.WriteLine($"DOB: {item.DOB.ToShortDateString()}\nGender: {item.Gen}\n");
                Console.WriteLine($"Standard: {item.Standard} {item.Branch} \tAcademic Year: {item.AcademicYear}");
                item.Display();
                Console.WriteLine(new string('`',100));
            }
       }
        
    }
}