using System;

namespace ArrayPlus
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] marks = { 20, 30, 13, 43, 23, 53, 23 };

            Array.Sort(marks);
            Array.Reverse(marks);

            foreach (int mark in marks)
            {
                Console.Write("{0} ", mark);
            }
            Console.WriteLine();
            Console.WriteLine("Copied marks");
            int[] copiedMarks = new int[marks.Length];

            Array.Copy(marks, copiedMarks, marks.Length);

            foreach (int mark in copiedMarks)
            {
                Console.Write("{0} ", mark);
            }

            Console.WriteLine();
            Console.WriteLine("Cloned marks");
            int[] clonedMarks = (int[])marks.Clone();

            foreach (int mark in clonedMarks)
            {
                Console.Write("{0} ", mark);
            }

            // Console.ReadKey();
        }

    }
}