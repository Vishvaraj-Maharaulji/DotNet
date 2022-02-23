using System;
using System.Collections.Generic;

namespace SetSample
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\nName :- Maharaulji Vishvarajsinhji Dilipsinh");
            Console.WriteLine($"\nTime :- {DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")}\n");

            Console.WriteLine("\n--------------------- SET SAMPLE ----------------------\n");

            //Set is-collection that contains no duplicate elements, and whose elements are in no particular order
            //HashSet is used to make them
            var companyTeams = new HashSet<string>() { "Ferrari", "McLaren", "Toyota", "BMW", "Renault" };
            var traditionalTeams = new HashSet<string>() { "Ferrari", "McLaren" };
            var privateTeams = new HashSet<string>() { "Red Bull", "Toro Rosso", "Force India", "Brawn GP" };

            if (privateTeams.Add("Williams"))
                Console.WriteLine("Williams added");
            if (!companyTeams.Add("McLaren"))
                Console.WriteLine("McLaren was already in this set");

            if (traditionalTeams.IsSubsetOf(companyTeams))
            {
                Console.WriteLine("Traditional Teams is subset of CompanyTeams");
            }

            if (companyTeams.IsSupersetOf(traditionalTeams))
            {
                Console.WriteLine("Company Teams is a superset of Traditional Teams");
            }

            traditionalTeams.Add("Williams");
            //Overlap method -: 
            // used to check whether the current HashSet object and a specified collection share common elements
            if (privateTeams.Overlaps(traditionalTeams))
            {
                Console.WriteLine("At least one team is the same with the Traditional " +
                      "and Private Teams");
            }

            var allTeams = new SortedSet<string>(companyTeams);
            allTeams.UnionWith(privateTeams);
            allTeams.UnionWith(traditionalTeams);

            Console.WriteLine();
            Console.WriteLine("All Teams");
            foreach (var team in allTeams)
            {
                Console.WriteLine(team);
            }

            allTeams.ExceptWith(privateTeams);
            Console.WriteLine();
            Console.WriteLine("No Private Team Left");
            foreach (var team in allTeams)
            {
                Console.WriteLine(team);
            }

            Console.WriteLine();
        }
    }
}
