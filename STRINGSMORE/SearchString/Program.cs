using System;

namespace SearchString
{
    class Program
    {
        static void Main(string[] args)
        {
            string originalString = "this is a string";
            string insertStr = "Test"+" ";
            string searchWord = "a";

            int insertIndex = originalString.IndexOf(searchWord);

            string newText = originalString.Insert(insertIndex, insertStr);

            Console.WriteLine(newText);

        }
    }

}