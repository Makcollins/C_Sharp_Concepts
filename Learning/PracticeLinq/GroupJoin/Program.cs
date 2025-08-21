using System;
using System.Security.Cryptography.X509Certificates;

namespace GroupJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>()
            {
                new Student(){Id = 1, Name = "Elvis", CategoryId=1 },
                new Student(){Id = 2, Name = "Marion", CategoryId=1 },
                new Student(){Id = 3, Name = "Grace", CategoryId=2 },
                new Student(){Id = 4, Name = "Junior", CategoryId=2 },
                new Student(){Id = 5, Name = "Dan", CategoryId=3 },
            };

            var categories = new List<Category>()
            {
                new Category(){Id =1, Name="Monitor"},
                new Category(){Id =2, Name="Discipline"},
                new Category(){Id =3, Name="Nothing"}
            };

            var joinGroup = categories.GroupJoin(students, cat => cat.Id, stu => stu.CategoryId, (cat, stu) => new { cat, stu });

            foreach (var item in joinGroup)
            {
                Console.WriteLine(item.cat.Name);
                foreach (var i in item.stu)
            {
                Console.WriteLine("==>"+i.Name);
            }
            }
        }
    }
}