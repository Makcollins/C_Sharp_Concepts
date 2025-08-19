using System;
using Microsoft.VisualBasic;
namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            // query syntax

            List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];        //data source

            IEnumerable<int> evenNumbers = from obj in numbers where obj % 2 == 0 select obj;  //Query

            // //Execution
            // foreach (var item in evenNumbers)
            // {
            //     Console.Write(item + " ");
            // }

            //METHOD SYNTAX

            IQueryable<int> oddNumbers = numbers.AsQueryable().Where(obj => obj % 2 == 1);

            // Console.WriteLine();
            // foreach (var item in oddNumbers)
            // {
            //     Console.Write(item + " ");
            // }

            //MIXED SYNTAX
            var largest = (from obj in numbers select obj).Max();

            Console.WriteLine();
            // Console.WriteLine("largest : " + largest);


            List<Person> people = new List<Person>()
            {
                new Person() { Name = ["Mak", "Collins", "Makui"], Age = 40, Gender = "Male"},
                new Person() { Name = ["Victor", "Otieno", "Odongo"], Age = 30, Gender = "Female"},
                new Person() { Name = ["Andrew", "Nyamweya","Obuya"], Age = 20, Gender = "Male"},
                new Person() { Name = ["Dorothy","Muthoni", "Wanjiku"], Age = 19, Gender = "Female"},
                new Person() { Name = ["Nevins", "Waldo","Ochora"], Age = 35, Gender = "Male" }
            };
            // selects a field
            var name = (from obj in people select obj.Name).ToList();
            var name2 = people.Select(x => x.Name);

            //selects specific fields
            var ages = (from obj in people select new Person() { Name = obj.Name, Age = obj.Age }).ToList();

            // assign to another class

            // var selectQuery = people.Select(obj => new Student() { StudentName = obj.Name, StudentAge = obj.Age, Gender = obj.Gender }).ToList();

            //select using index

            var usingIndex = people.Select((obj, index) => new { Index = index, Name = obj.Name }).ToList();

            List<string> list1 = new List<string>() {"Mango", "Orange","Pineapple"};
            List<string> list2 = new List<string>() { "Wheat", "maize", "beans" };
            int[] arr = new int[] { 1, 2, 3, 4, 5, 2, 5, 3, 6, 21, 67 };

            //select many

            var newList = people.SelectMany(x => x.Name);

            var newlist = (from obj in people from names in obj.Name select names).ToList();

            var alist = new List<object> { "money", "car", "house", 16, 10, 6, 22 };

            //OfType operator (Filtering)
            var alistText = alist.OfType<int>().Where(obj=>obj >=10);

            var alistNumbers = from obj in alist where obj is int select obj;
            //Reverse() operator
            var arr2 = arr.Reverse();
            var list3 = list1.AsEnumerable().Reverse();
            // var list4 = list2.AsQueryable().Reverse();

            var check = arr.All(x => x > 10);
            if (check)
            {
                System.Console.WriteLine("");
            }
            else
            {
                System.Console.WriteLine("");
            }

            //
            List<Student> students = new List<Student>()
            {
            new Student(){StudentName = "Mark", Gender = "Male", StudentAge = 14},
            new Student(){StudentName = "Mark", Gender = "Male", StudentAge = 14},
            new Student(){StudentName = "Mary", Gender = "Female", StudentAge = 21},
            new Student(){StudentName = "Nicholus", Gender = "Male", StudentAge = 28},
            new Student(){StudentName = "Mary", Gender = "Female", StudentAge = 20},
            };

            var list4 = students.Select(n=>n.StudentName).Distinct();


            foreach (var item in list4)
            {
                Console.WriteLine(item);
            }

        }

    }
}