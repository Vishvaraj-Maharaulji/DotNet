using System;
using System.Collections.Generic;
using System.Linq;

namespace Wrox.ProCSharp.Collections
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\nName :- Maharaulji Vishvarajsinhji Dilipsinh");
            Console.WriteLine($"\nTime :- {DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")}\n");

            Console.WriteLine("\n--------------------- LOOK UP SAMPLE ----------------------\n");

            var racers = new List<Racer>();
            racers.Add(new Racer(26, "Jacques", "Villeneuve", "Canada", 11));
            racers.Add(new Racer(18, "Alan", "Jones", "Australia", 12));
            racers.Add(new Racer(11, "Jackie", "Stewart", "United Kingdom", 27));
            racers.Add(new Racer(15, "James", "Hunt", "United Kingdom", 10));
            racers.Add(new Racer(5, "Jack", "Brabham", "Australia", 14));

            //I think It matched racer name with country
            var lookupRacers = racers.ToLookup(r => r.Country);

            Console.WriteLine("\nRacers From Australia - \n");
            foreach (Racer r in lookupRacers["Australia"])
            {
                Console.WriteLine(r);
            }

            Console.WriteLine();
        }
    }
}
