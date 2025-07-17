using System;

namespace Grades;

class Program {

    static void Main(string[] args)
    {
        Console.WriteLine("Enter a grade (A,B,C,D)");

        string grade = Console.ReadLine();

        if (grade == "A")
        {
            Console.WriteLine("Grade {0} denotes 9 Points", grade);
        }
        else if (grade == "B")
        {
            Console.WriteLine("Grade {0} denotes 8 Points", grade);
        }
        else if (grade == "C")
        {
            Console.WriteLine("Grade {0} denotes 7 Points", grade);
        }
        else if (grade == "D")
        {
            Console.WriteLine("Grade {0} denotes 6 Points", grade);
        }
        else
        {
            Console.WriteLine("This is not a valid Grade");
        }

    }
}
