using System;

namespace Collaege
{
    class Program
    {
        static void Main(string[] args)
        {
            // Teacher Objects
            Teacher teacher1 = new Teacher("Steve", "Ezekiel", Convert.ToDateTime("28/4/1996"), "0714678594", Gender.Male, "steven254@gmail.com")
            {
                Department = "Computer Science",
                SubjectTeaching = "Data Structures and Algorithms",
                Qualification = "MSc Computer Science",
                YearOfExperience = 5,
                DateOfJoining = Convert.ToDateTime("14/5/2023"),
            };
            Teacher teacher2 = new Teacher("Elizabeth", "Eliud", Convert.ToDateTime("17/7/1999"), "0112345678", Gender.Female, "elizabeth254@gmail.com")
            {
                Department = "Computer Science",
                SubjectTeaching = "Digital Electronics",
                Qualification = "MSc Computer Science",
                YearOfExperience = 6,
                DateOfJoining = Convert.ToDateTime("22/3/2021"),
            };

            //Student Objects
            StudentInfo student1 = new StudentInfo("Mathew", "Victor", Convert.ToDateTime("21/8/2005"), "0714678594", Gender.Male, "mathew254@gmail.com")
            {
                Degree = "Bachelor of Science in Computer Science",
                Department = "Computer Science",
                Semester = "Two"
            };
            StudentInfo student2 = new StudentInfo("Juliet", "Daniel", Convert.ToDateTime("14/7/2005"), "0112345678", Gender.Female, "juliet254@gmail.com")
            {
                Degree = "Bachelor of Information Technology",
                Department = "Information Techology",
                Semester = "Two"
            };

            // Teacher Objects
            PrincipalInfo principal1 = new PrincipalInfo("Raphael", "Michael", Convert.ToDateTime("06/10/1988"), "0778849378", Gender.Male, "raphael254@gmail.com")
            {
                Qualification = "Phd Computer Science",
                YearOfExperience = 10,
                DateOfJoining = Convert.ToDateTime("2/6/2009"),
            };
            PrincipalInfo principal2 = new PrincipalInfo("Dorcas", "Collins", Convert.ToDateTime("20/1/1990"), "0110756832", Gender.Female, "dorcas254@gmail.com")
            {
                Qualification = "Phd information Technology",
                YearOfExperience = 9,
                DateOfJoining = Convert.ToDateTime("1/1/2011"),
            };

            //Teachers list
            List<Teacher> teachers = new List<Teacher>();
            teachers.Add(teacher1);
            teachers.Add(teacher2);
            //Students list
            List<StudentInfo> students = new List<StudentInfo>();
            students.Add(student1);
            students.Add(student2);
            //Principals list
            List<PrincipalInfo> principals = new List<PrincipalInfo>();
            principals.Add(principal1);
            principals.Add(principal2);

            Console.WriteLine("{0}\nTEACHERS \n{0}", new String('-', 100));

            foreach (var item in teachers)
            {
                Console.WriteLine($"TeacherID: {item.UserID}\nName: {item.Name}\nFatherName: {item.FatherName}\nDOB: {item.DOB}\nPhone: {item.Phone}\nGender: {item.Gen}\nMail ID: {item.MailID}\nDepartMent: {item.Department}\nSubject Teaching: {item.SubjectTeaching}\nQualification: {item.Qualification}\nYears Of Experience: {item.YearOfExperience}\nDate of Joining: {item.DateOfJoining.ToShortDateString()}");
                Console.WriteLine($"\n{new String('`', 100)}");
            }
            Console.WriteLine(new String('-', 100));

            Console.WriteLine("\nSTUDENTS \n{0}", new String('-', 100));

            foreach (var item in students)
            {
                Console.WriteLine($"StudentID: {item.UserID}\nName: {item.Name}\nFatherName: {item.FatherName}\nDOB: {item.DOB}\nPhone: {item.Phone}\nGender: {item.Gen}\nMail ID: {item.MailID}\nDegree: {item.Degree}\nDepartment: {item.Department}\nSemester: {item.Semester}");
                Console.WriteLine($"\n{new String('`', 100)}");
            }
            Console.WriteLine(new String('-', 100));

             Console.WriteLine("\nPRINCIPALS\n{0}", new String('-', 100));

            foreach (var item in principals)
            {
                Console.WriteLine($"Principal: {item.UserID}\nName: {item.Name}\nFatherName: {item.FatherName}\nDOB: {item.DOB}\nPhone: {item.Phone}\nGender: {item.Gen}\nMail ID: {item.MailID}\nQualification: {item.Qualification}\nYears Of Experience: {item.YearOfExperience}\nDate of Joining: {item.DateOfJoining.ToShortDateString()}");
                Console.WriteLine($"\n{new String('`', 100)}");
            }
            Console.WriteLine(new String('-', 100));
        }        
    }
}