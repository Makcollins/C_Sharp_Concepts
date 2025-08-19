using System;
using System.Runtime.CompilerServices;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            BookInfo book1 = new BookInfo()
            {
                DepartmentName = "Computer Science",
                Degree = "BSc Computer Science",
                ColumnNumber = 2,
                BookName = "Data Structures and Algorithms made easier",
                AuthorName = "Narasimha Karumanchi",
                Price = 2000
            };
            BookInfo book2 = new BookInfo()
            {
                DepartmentName = "Computer Science",
                Degree = "BSc Computer Science",
                ColumnNumber = 2,
                BookName = "Core Java",
                AuthorName = "Cay S. Horstmann",
                Price = 1500
            };

            book1.Display();
            Console.WriteLine(new string('_', 60));
            book2.Display();
        }
    }
}