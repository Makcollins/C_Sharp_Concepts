using System;
using System.Collections.Specialized;
using InneJoin;

namespace InnerJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
                new Student(){Id=1,Name = "Victor", AddressId =1},
                new Student(){Id=2,Name = "Elvis", AddressId =2},
                new Student(){Id=3,Name = "Marion"},
                new Student(){Id=4,Name = "Stacy", AddressId =3},
                new Student(){Id=5,Name = "Evans", AddressId =5},
            };

            List<Address> addresses = new List<Address>()
            {
                new Address(){Id = 1, AdressLine = "Line 1"},
                new Address(){Id = 2, AdressLine = "Line 2"},
                new Address(){Id = 3, AdressLine = "Line 3"},
            };

            List<Marks> marks = new List<Marks>()
            {
                new Marks(){Id = 1, studentId = 1, marks = 80},
                new Marks(){Id = 2, studentId = 2, marks = 85},
                new Marks(){Id = 3, studentId = 3, marks = 90},
            };

            // InnerJoin using query syntax
            var joinedList = from student in students join address in addresses on student.AddressId equals address.Id select new { StudentName = student.Name, Line = address.AdressLine };
            //inner join for multiple data sources
            var joinMultiple = from student in students join address in addresses on student.AddressId equals address.Id join mark in marks on student.Id equals mark.studentId select new { StudentName = student.Name, Line = address.AdressLine, TotalMarks = mark.marks };

            var msJoinedList = students.Join(addresses, std => std.AddressId, address => address.Id, (std, address) => new { StudentName = std.Name, Line = address.AdressLine }).ToList();

            var joinLeft = from student in students join address in addresses on student.AddressId equals address.Id into studentAddresses from stdAdress in studentAddresses select new {StudentName = student.Name, Line = stdAdress.AdressLine };

            foreach (var item in joinLeft)
            {
                Console.WriteLine($"{item.StudentName}\t{item.Line}");
            }
        }
    }
}