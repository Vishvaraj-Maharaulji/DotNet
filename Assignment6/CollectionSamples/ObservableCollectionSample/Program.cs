using System;
using System.Collections.ObjectModel;

namespace Wrox.ProCSharp.Collections
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\nName :- Maharaulji Vishvarajsinhji Dilipsinh");
            Console.WriteLine($"\nTime :- {DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")}\n");

            Console.WriteLine("\n--------------------- OBSERVABLE COLLECTION SAMPLE ----------------------\n");

            //Represents a dynamic data collection that provides notifications when
            // items get added or removed, or when the whole list is refreshed.
            var data = new ObservableCollection<string>();
            data.CollectionChanged += Data_CollectionChanged!;
            data.Add("One");
            data.Add("Two");
            data.Insert(1, "Three");
            data.Remove("One");
        }
        //Function executing notfication event whenever item add then 2nd if statment run and removed then 1st if statement run
        static void Data_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Action: {0}", e.Action.ToString());

            if (e.OldItems != null)
            {
                Console.WriteLine("Starting index for old item(s): {0}", e.OldStartingIndex);
                Console.WriteLine("Old item(s):");
                foreach (var item in e.OldItems)
                {
                    Console.WriteLine(item);
                }
            }
            if (e.NewItems != null)
            {
                Console.WriteLine("Starting index for new item(s): {0}", e.NewStartingIndex);
                Console.WriteLine("New item(s): ");
                foreach (var item in e.NewItems)
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine();
        }
    }
}
