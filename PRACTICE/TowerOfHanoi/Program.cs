// using System;
// using System.Transactions;

// namespace TowerOfHanoi
// {
//     class Program
//     {
//         static void TowerOfHanoi(int n, Stack<int> A, Stack<int> B, Stack<int>C)
//         {
//             if (n == 0)
//             {
//                 return;
//             }

//             TowerOfHanoi(n - 1, A, C, B);
//             A.Pop();
//             C.Push(n);
//             Console.Write("Container A : [");
//             foreach (var item in A)
//             {
//                 Console.Write("{0}, ", item);
//             }
//             Console.Write("]\n");

//             Console.Write("Container B : [");
//             foreach (var item in B)
//             {
//                 Console.Write("{0}, ", item);
//             }
//             Console.Write("]\n");

//             Console.Write("Container C: [");
//             foreach (var item in C)
//             {
//                 Console.Write("{0}, ", item);
//             }
//             Console.Write($"]\n\n");
            
//             TowerOfHanoi(n - 1, B, A, C);


//         }
//         static void Main(string[] args)
//         {
//             Console.Write("Enter number of Disks: ");
//             int n = int.Parse(Console.ReadLine()!);

//             Stack<int> A = new Stack<int>();
//             Stack<int> B = new Stack<int>();
//             Stack<int> C = new Stack<int>();
//             for (int i = n; i >= 1; i--)
//             {
//                 A.Push(i);
//             }

//             Console.WriteLine(new string('-', 50) + "\n ORIGINAL STACK:");
//              Console.Write("Container A : [");
//             foreach (var item in A)
//             {
//                 Console.Write("{0}, ", item);
//             }
//             Console.Write("]\n");

//             Console.Write("Container B : [");
//             foreach (var item in B)
//             {
//                 Console.Write("{0}, ", item);
//             }
//             Console.Write("]\n");

//             Console.Write("Container C: [");
//             foreach (var item in C)
//             {
//                 Console.Write("{0}, ", item);
//             }
//             Console.Write("]\n\n");
//             Console.WriteLine(new string('-', 50));

//             Console.WriteLine($"SOLUTION\n{new String('-',50)}");
//             TowerOfHanoi(n, A, B, C);
            


//         }
//     }
// }