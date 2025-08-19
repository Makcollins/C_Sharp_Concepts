using System;

namespace OnlineLibrary
{
    class Program
    {

        static void Main(string[] args)
        {
            DepartmentDetails departmentDetails = new DepartmentDetails()
            {
                DepartmentName = "Computer Science",
                Degree = "BSc. Computer Science"
            };

            BookInfo bookInfo = new BookInfo()
            {
                DepartmentName = "Computer Science",
                Degree = "BSc. Computer Science",
                BookName = "Head First C",
                AuthorName = "David Grifffiths",
                Price = 2000
            };

            Console.WriteLine("Department Details");
            Console.WriteLine($"Department Name: {departmentDetails.DepartmentName}\nDegre: {departmentDetails.Degree}\n");

            Console.WriteLine($"Department Name: {bookInfo.DepartmentName}\nDegre: {bookInfo.Degree}");
            Console.WriteLine($"Book Name: {bookInfo.BookName}\nAuthor Name: {bookInfo.AuthorName}\nPrice: {bookInfo.Price}");

        }

    }
}