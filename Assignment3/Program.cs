// See https://aka.ms/new-console-template for more information

using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n----------------------- DO THE MATH ------------------------\n");
            DoTheMath.doTheMath();

            Console.WriteLine("\n-------------------- PLAY WITH STRINGS ---------------------\n");
            PlayWithStrings.strings1();
            PlayWithStrings.strings2();
            PlayWithStrings.strings3();

            Console.WriteLine("\n-------------------- FLAGS ENUM EXAMPLE --------------------\n");
            FlagsEnumExample.flagsEnumExample();
        }
    }

    static class DoTheMath
    {
        public static void doTheMath()
        {
            // Calculating the Result of Division :-
            Console.WriteLine("\nCalculating the Result of Division :-\n");

            int a = 0;
            int b = 0;
            double result = 0;
            int remainder = 0;

            Console.WriteLine("\nPlease Enter the Numerator : ");
            a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nPlease Enter the Denominator : ");
            b = Convert.ToInt32(Console.ReadLine());

            result = (double)a / b;
            remainder = a % b;

            Console.WriteLine($"\nInteger Division result = {a / b} with a remainder {remainder}");
            Console.WriteLine($"\nFloating point division result = {result}");
            Console.WriteLine($"\nThe result as a mixed fraction is {a / b} {remainder}/{b}\n");
        }
    }

    static class PlayWithStrings
    {
        public static void strings1()
        {
            // 1] Calculating the Length of String :-
            Console.WriteLine("\n1] Calculating the Length of String :-\n");

            int length = 0;
            string? s = "";

            Console.WriteLine("\nPlease Enter the String : ");
            s = Console.ReadLine();

            length = s.Length;

            Console.WriteLine($"\nThe Length of String {s} = {length}");
        }

        public static void strings2()
        {
            // 2] Checking the Type of Sentence :-
            Console.WriteLine("\n2] Checking the Type of Sentence :-\n");

            int length = 0;
            int choice = 0;
            string? s = "";

            do
            {
                Console.WriteLine("\nPlease Enter the Sentence : ");
                s = Console.ReadLine();

                length = s.Length;

                char endChar = s[length - 1];
                if (endChar.Equals('.'))
                {
                    Console.WriteLine($"\nIt is a Declarative Sentence.");
                }
                else if (endChar.Equals('?'))
                {
                    Console.WriteLine($"\nIt is an Interrogatory Sentence.");
                }
                else if (endChar.Equals('!'))
                {
                    Console.WriteLine($"\nIt is an Exclamation.");
                }
                else
                {
                    Console.WriteLine($"\nIt is not a Sentence.");
                }

                Console.WriteLine("\nDo you want to Continue (1 if Yes, 0 if No): ");
                choice = Convert.ToInt32(Console.ReadLine());
            } while (choice == 1);
        }

        public static void strings3()
        {
            // 3] Printing the Name :-
            Console.WriteLine("\n3] Printing the Name :-\n");

            int length = 0;
            int choice = 0;
            string? s = "";

            do
            {
                Console.WriteLine("\nPlease Enter Your Whole Name : ");
                s = Console.ReadLine();

                length = s.Length;

                if (s.IndexOf(" ") == -1)
                {
                    Console.WriteLine($"\n{s}");
                }
                else
                {
                    string? firstName = s.Substring(0, s.IndexOf(" "));
                    string? lastName = s.Substring(s.IndexOf(" ") + 1);

                    Console.WriteLine($"\n{lastName}, {firstName}");
                }

                Console.WriteLine("\nDo you want to Continue (1 if Yes, 0 if No): ");
                choice = Convert.ToInt32(Console.ReadLine());
            } while (choice == 1);
        }
    }

    [Flags]
    public enum Days
    {
        None = 0b_0000_0000, // 0
        Monday = 0b_0000_0001, // 1
        Tuesday = 0b_0000_0010, // 2
        Wednesday = 0b_0000_0100, // 4
        Thursday = 0b_0000_1000, // 8
        Friday = 0b_0001_0000, // 16
        Saturday = 0b_0010_0000, // 32
        Sunday = 0b_0100_0000, // 64
        Weekend = Saturday | Sunday
    }

    static class FlagsEnumExample
    {
        public static void flagsEnumExample()
        {
            //Flags Enum Example :-
            Console.WriteLine("\nFlags Enum Example :-\n");

            Days meetingDays = Days.Monday | Days.Wednesday | Days.Friday;
            Console.WriteLine(meetingDays);

            Days workingFromHomeDays = Days.Thursday | Days.Friday;
            Console.WriteLine($"\nJoin a meeting by phone on {meetingDays & workingFromHomeDays}");

            bool isMeetingOnTuesday = (meetingDays & Days.Tuesday) == Days.Tuesday;
            Console.WriteLine($"\nIs there a meeting on Tuesday: {isMeetingOnTuesday}");

            var a = (Days)62;
            Console.WriteLine($"\n62 is {a}\n");
        }
    }
}