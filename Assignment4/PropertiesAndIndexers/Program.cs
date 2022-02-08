// See https://aka.ms/new-console-template for more information

using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nName :- Maharaulji Vishvarajsinhji Dilipsinh");
            Console.WriteLine($"\nDateTime :- {DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")}\n");

            Console.WriteLine("\n-------------------- PROPERTIES -------------------\n");
            Console.WriteLine("\n1] TimePeriod Example\n");
            TimePeriod t = new TimePeriod();
            t.Hours = 7;
            Console.WriteLine($"Time in hours: {t.Hours}");

            Console.WriteLine("\n2] Person Example\n");
            var person = new Person("Vishvaraj", "Maharaulji");
            Console.WriteLine($"Name of Person: {person.Name}");

            Console.WriteLine("\n3] SaleItem Example\n");
            var item = new SaleItem("Shoes", 19.95m);
            Console.WriteLine($"{item.Name}: sells for {item.Price}");

            Console.WriteLine("\n4] SaleItem Example-2\n");
            var item2 = new SaleItem2 { Name = "Shoes", Price = 19.95m };
            Console.WriteLine($"{item2.Name}: sells for {item2.Price}");

            Console.WriteLine("\n-------------------- INDEXERS ---------------------\n");
            Console.WriteLine("\n1] TempRecord Example\n");
            var tempRecord = new TempRecord();
            tempRecord[3] = 58.3F;
            tempRecord[5] = 60.1F;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Element #{i} = {tempRecord[i]}");
            }

            Console.WriteLine("\n2] DayCollection Example\n");
            var week = new DayCollection();
            Console.WriteLine(week["Fri"]);

            try
            {
                Console.WriteLine(week["Made-up day"]);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Not supported input: {e.Message}");
            }

            Console.WriteLine("\n");
        }
    }

    class TimePeriod
    {
        private double _seconds;

        public double Hours
        {
            get { return _seconds / 3600; }
            set
            {
                if (value < 0 || value > 24)
                    throw new ArgumentOutOfRangeException(
                          $"{nameof(value)} must be between 0 and 24.");

                _seconds = value * 3600;
            }
        }
    }

    public class Person
    {
        private string _firstName;
        private string _lastName;

        public Person(string first, string last)
        {
            _firstName = first;
            _lastName = last;
        }

        public string Name => $"{_firstName} {_lastName}";
    }

    public class SaleItem
    {
        string _name;
        decimal _cost;

        public SaleItem(string name, decimal cost)
        {
            _name = name;
            _cost = cost;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public decimal Price
        {
            get => _cost;
            set => _cost = value;
        }
    }

    public class SaleItem2
    {
        public string Name
        { get; set; }

        public decimal Price
        { get; set; }
    }

    public class TempRecord
    {
        // Array of temperature values
        float[] temps = new float[10]
        {
        56.2F, 56.7F, 56.5F, 56.9F, 58.8F,
        61.3F, 65.9F, 62.1F, 59.2F, 57.5F
        };

        // To enable client code to validate input
        // when accessing your indexer.
        public int Length => temps.Length;

        // Indexer declaration.
        // If index is out of range, the temps array will throw the exception.
        public float this[int index]
        {
            get => temps[index];
            set => temps[index] = value;
        }
    }

    class DayCollection
    {
        string[] days = { "Sun", "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat" };

        // Indexer with only a get accessor with the expression-bodied definition:
        public int this[string day] => FindDayIndex(day);

        private int FindDayIndex(string day)
        {
            for (int j = 0; j < days.Length; j++)
            {
                if (days[j] == day)
                {
                    return j;
                }
            }

            throw new ArgumentOutOfRangeException(
                nameof(day),
                $"Day {day} is not supported.\nDay input must be in the form \"Sun\", \"Mon\", etc");
        }
    }
}