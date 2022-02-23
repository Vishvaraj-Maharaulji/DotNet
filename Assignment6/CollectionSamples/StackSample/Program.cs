using System;
using System.Collections.Generic;

namespace Wrox.ProCSharp.Collections
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\nName :- Maharaulji Vishvarajsinhji Dilipsinh");
            Console.WriteLine($"\nTime :- {DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")}\n");

            Console.WriteLine("\n--------------------- STACK SAMPLE ----------------------\n");

            var alphabet = new Stack<char>();
            alphabet.Push('A');
            alphabet.Push('B');
            alphabet.Push('C');

            Console.Write("First iteration: ");
            foreach (char item in alphabet)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            Console.Write("Second iteration: ");
            while (alphabet.Count > 0)
            {
                Console.Write(alphabet.Pop());
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
