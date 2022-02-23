using System;
using System.Threading;

namespace Wrox.ProCSharp.Collections
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\nName :- Maharaulji Vishvarajsinhji Dilipsinh");
            Console.WriteLine($"\nTime :- {DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")}\n");

            Console.WriteLine("\n--------------------- QUEUE SAMPLE ----------------------\n");

            var dm = new DocumentManager();

            ProcessDocuments.Start(dm);

            // Create documents and add them to the DocumentManager
            for (int i = 0; i < 15; i++)
            {
                Document doc = new Document("Doc " + i.ToString(), "content");
                dm.AddDocument(doc);
                Console.WriteLine("Added document {0}", doc.Title);
                Thread.Sleep(new Random().Next(20));
            }

        }
    }
}
