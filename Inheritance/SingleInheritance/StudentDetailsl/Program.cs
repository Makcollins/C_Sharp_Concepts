using System;

namespace StudentDetailsl
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonalInfo person1 = new PersonalInfo()
            {
                Name = "Wilson Kimanthi",
                FatherName = "Musyoka",
                Phone = "0178927483",
                MailID = "wilson@yahoo.com",
                DOB = Convert.ToDateTime("11/6/2000"),
                Gender = Gender.Male
            };
            PersonalInfo person2 = new PersonalInfo()
            {
                Name = "Miriam Mukuhi",
                FatherName = "Maina",
                Phone = "0110356785",
                MailID = "mukuhi@yahoo.com",
                DOB = Convert.ToDateTime("25/2/2002"),
                Gender = Gender.Male
            };

            StudentInfo student1 = new StudentInfo()
            {
                Name = "Henry Mutua",
                FatherName = "Nyamai",
                Phone = "0718927483",
                MailID = "henry@yahoo.com",
                DOB = Convert.ToDateTime("11/6/2010"),
                Gender = Gender.Male,
                Standard = "Seven",
                Branch = "East",
                AcademicYear = "2024"
            };

            StudentInfo student2 = new StudentInfo()
            {
                Name = "Sharon Cherop",
                FatherName = "Kiptoo",
                Phone = "0745123266",
                MailID = "cherop@yahoo.com",
                DOB = Convert.ToDateTime("14/10/2011"),
                Gender = Gender.Male,
                Standard = "Six",
                Branch = "west",
                AcademicYear = "2024"
            };

            Console.WriteLine(new String('-', 60), "{0}\n \n{0}");
            person1.Display();
            person2.Display();
            Console.WriteLine(new String('-', 60), "{0}\n STUDENT\n{0}");
            student1.Display();
            student2.Display();
        }
    }
}