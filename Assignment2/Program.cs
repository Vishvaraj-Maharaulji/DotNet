// See https://aka.ms/new-console-template for more information

using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n------------------------- NUMBERS --------------------------\n");
            Numbers.number1();
            Numbers.number2();
            Numbers.number3();
            Numbers.number4();
            Numbers.number5();
            Numbers.number6();

            Console.WriteLine("\n-------------------- BRANCHES AND LOOP ---------------------\n");
            BranchesAndLoop.bal1();
            BranchesAndLoop.bal2();
            BranchesAndLoop.bal3();
            BranchesAndLoop.bal4();
            BranchesAndLoop.bal5();
            BranchesAndLoop.bal6();
        }
    }

    static class Numbers
    {
        public static void number1()
        {
            // 1] Explore Integer Math
            Console.WriteLine("\n1] Explore Integer Math\n");

            int a = 18;
            int b = 6;

            int c = a + b;
            Console.WriteLine($"{a} + {b} = {c}");

            c = a - b;
            Console.WriteLine($"{a} - {b} = {c}");

            c = a * b;
            Console.WriteLine($"{a} * {b} = {c}");

            c = a / b;
            Console.WriteLine($"{a} / {b} = {c}");
        }

        public static void number2()
        {
            // 2] Explore Order of Operation
            Console.WriteLine("\n2] Explore Order of Operation\n");

            int a = 5;
            int b = 4;
            int c = 2;

            int d = a + b * c;
            Console.WriteLine($"{a} + {b} * {c} = {d}");

            d = (a + b) - 6 * c + (12 * 4) / 3 + 12;
            Console.WriteLine($"({a} + {b}) - 6 * {c} + (12 * 4) / 3 + 12 = {d}");

            d = (a + b) / c;
            Console.WriteLine($"({a} + {b}) / {c} = {d}");
        }

        public static void number3()
        {
            // 3] Explore Integer Precision and Limits
            Console.WriteLine("\n3] Explore Integer Precision and Limits\n");

            int a = 7;
            int b = 4;
            int c = 3;
            int d = (a + b) / c;
            int e = (a + b) % c;
            Console.WriteLine($"Quotient of ({a} + {b}) / {c} : {d}");
            Console.WriteLine($"Remainder of ({a} + {b}) % {c} : {e}");

            // Range of 'int' Data-Type
            int maxInt = int.MaxValue;
            int minInt = int.MinValue;
            Console.WriteLine($"\nThe range of integers is {minInt} to {maxInt}");

            // Example of Overflow
            int what = maxInt + 3;
            Console.WriteLine($"An example of overflow : {maxInt} + 3 = {what}");
        }

        public static void number4()
        {
            // 4] Working With the Double Type
            Console.WriteLine("\n4] Working With the Double Type\n");

            double x = 19;
            double y = 23;
            double z = 8;
            double w = (x + y) / z;
            Console.WriteLine($"({x} + {y}) / {z} = {w}");

            // Range of 'double' Data-Type
            double maxDouble = double.MaxValue;
            double minDouble = double.MinValue;
            Console.WriteLine($"The range of double is {minDouble} to {maxDouble}");
        }

        public static void number5()
        {
            // 5] Working With Decimal Types
            Console.WriteLine("\n5] Working With Decimal Type\n");

            decimal minDecimal = decimal.MinValue;
            decimal maxDecimal = decimal.MaxValue;
            Console.WriteLine($"The range of the decimal type is {minDecimal} to {maxDecimal}");

            // Comparison of 'double' and 'decimal' data-type
            Console.WriteLine("\nComparing precision of 'double' and 'decimal' data-type - \n");
            double x = 1.0;
            double y = 3.0;
            Console.WriteLine($"For 'double' data-type, 1/3 = {x / y}");

            decimal i = 1.0M;
            decimal j = 3.0M;
            Console.WriteLine($"For 'decimal' data-type, 1/3 = {i / j}");
        }

        public static void number6()
        {
            // 6] Area of Circle[Challenge] -
            Console.WriteLine("\n6] Calculating the Area of Circle\n");
            double radius = 2.50;
            double area = Math.PI * radius * radius;
            Console.WriteLine($"Area of Circle With Radius {radius} is {area}\n");
        }
    }

    static class BranchesAndLoop
    {
        public static void bal1()
        {
            // 1] Make Decisions Using the 'if' Statement
            Console.WriteLine("\n1] Make Decisions Using the 'if' Statement\n");

            int a = 5;
            int b = 6;
            int ans = a + b;
            Console.WriteLine($"{a} + {b} = {ans}");
            if (ans > 10)
                Console.WriteLine($"The ans = {ans} is greater than 10.");
        }

        public static void bal2()
        {
            // 2] Make 'if' and 'else' Work Together
            Console.WriteLine("\n2] Make 'if' and 'else' Work Together\n");

            int a = 5;
            int b = 3;
            int c = 4;
            int ans = a + b;
            Console.WriteLine($"{a} + {b} = {ans}");
            if (ans > 10)
                Console.WriteLine($"The ans = {ans} is greater than 10");
            else
                Console.WriteLine($"The ans = {ans} is not greater than 10");

            // Using Logical And Operator
            Console.WriteLine("\nUsing Logical And Operator\n");

            ans = a + b + c;
            Console.WriteLine($"{a} + {b} + {c} = {ans}");
            if ((ans > 10) && (a == b))
            {
                Console.WriteLine($"The ans = {ans} is greater than 10");
                Console.WriteLine($"And the first number ({a}) is equal to the second ({b})");
            }
            else
            {
                Console.WriteLine($"The ans = {ans} is not greater than 10");
                Console.WriteLine($"Or the first number ({a}) is not equal to the second ({b})");
            }

            // Using Logical Or Operator
            Console.WriteLine("\nUsing Logical Or Operator\n");

            Console.WriteLine($"{a} + {b} + {c} = {ans}");
            if ((a + b + c > 10) || (a == b))
            {
                Console.WriteLine($"The ans = {ans} is greater than 10");
                Console.WriteLine($"Or the first number ({a}) is equal to the second ({b})");
            }
            else
            {
                Console.WriteLine($"The ans = {ans} is not greater than 10");
                Console.WriteLine($"And the first number ({a}) is not equal to the second ({b})");
            }
        }

        public static void bal3()
        {
            // 3] Use Loops to Repeat Operations
            Console.WriteLine("\n3] Use Loops to Repeat Operations\n");

            // Using 'while' Loop
            Console.WriteLine("\nUsing 'while' Loop\n");
            int counter = 0;
            while (counter < 10)
            {
                Console.WriteLine($"The counter is {counter}");
                counter++;
            }

            // Using 'do...while' Loop
            Console.WriteLine("\nUsing 'do...while' Loop\n");
            counter = 0;
            do
            {
                Console.WriteLine($"The counter is {counter}");
                counter++;
            } while (counter < 10);
        }

        public static void bal4()
        {
            // 4] Work With the 'for' Loop
            Console.WriteLine("\n4] Work With the 'for' Loop\n");

            // Using 'for' Loop
            Console.WriteLine("\nUsing 'for' Loop\n");

            for (int counter = 0; counter < 10; counter++)
            {
                Console.WriteLine($"The counter is {counter}");
            }
        }

        public static void bal5()
        {
            // 5] Creating Nested Loop
            Console.WriteLine("\n5] Creating Nested Loop\n");

            for (int row = 1; row < 5; row++)
            {
                for (char column = 'a'; column < 'e'; column++)
                {
                    Console.WriteLine($"The cell is ({row}, {column})");
                }
            }
        }

        public static void bal6()
        {
            // 6] Finding Sum of Integer 1 to 20 Which are Divisible by 3
            Console.WriteLine("\n6] Finding Sum of Integer 1 to 20 Which are Divisible by 3\n");

            int sum = 0;
            Console.WriteLine("\nThe Numbers are : ");
            for (int n = 1; n < 21; n++)
            {
                if (n % 3 == 0)
                {
                    sum = sum + n;
                    Console.WriteLine($"{n}");
                }
            }
            Console.WriteLine($"\nTherefore, The Sum is {sum}\n");
        }
    }
}