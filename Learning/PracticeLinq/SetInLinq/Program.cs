using System;

namespace SetInLinq
{
    class Program
    {

        static void Main(string[] args)
        {
            List<string> dataSource1 = new List<string>() { "A", "B", "C", "D" };

            List<string> dataSource2 = new List<string>() { "C", "D", "E", "F" };


            var dataExcept = dataSource1.Except(dataSource2).ToList();

            var dataIntersect = dataSource1.Intersect(dataSource2);

            var dataUnion = dataSource1.Union(dataSource2);

            List<Person> people = new List<Person>()
            {
                new Person { Name = "Ezra", Age = 41, Occupation = "Doctor" },
                new Person { Name = "Winfred", Age = 40, Occupation = "Teacher" },
                new Person { Name = "Emma", Age = 36, Occupation = "Accountant" },
                new Person { Name = "David", Age = 22, Occupation = "Software Engineer" },
                new Person { Name = "Vincent", Age = 33, Occupation = "Nurse" },
                new Person { Name = "Eunice", Age = 41, Occupation = "Teacher" },
                new Person { Name = "Geofrey", Age = 38, Occupation = "Teacher" },
                new Person { Name = "Everlyne", Age = 33, Occupation = "Accountant" },
                new Person { Name = "Jacob", Age = 45, Occupation = "Civil Engineer" },
                new Person { Name = "Vincent", Age = 34, Occupation = "Farmer" },
                new Person { Name = "Emma", Age = 36, Occupation = "Accountant" },
                new Person { Name = "David", Age = 22, Occupation = "Software Engineer" },
                new Person { Name = "Vincent", Age = 33, Occupation = "Nurse" },
                new Person { Name = "Henry", Age = 41, Occupation = "Teacher" }
            };

            var distinctPpl = people.Select(n => n.Name).Distinct();

            var take1 = people.Take(5);
            var takeWhile2 = people.TakeWhile(n => n.Age < 45);

            var skip1 = people.Skip(4);

            var skipwhile2 = people.SkipWhile(n => n.Occupation != "Farmer");

            //Paging
            do
            {
                Console.Write("Enter Page Number: ");
    
                if (int.TryParse(Console.ReadLine(), out int pageNumber))
                {
                    var currentPage = people.Skip((pageNumber - 1) * 5).Take(5);
                    foreach (var item in currentPage)
                    {
                        // Console.WriteLine(item);
                        Console.WriteLine($"{item.Name,-10}\t{item.Age,-10}\t{item.Occupation}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid entry!");
                }
    
    
            } while (true);
        }

    }
}