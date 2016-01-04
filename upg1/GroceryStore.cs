using System;

namespace upg1
{
    internal class GroceryStore
    {
        private static void Main()
        {
            Console.Title = "Sebastians Store";
            Console.WriteLine("Welcome to sebastians Store");
            var prod = new Product();
            prod.Start();


            Console.WriteLine("press enter to exit");
            Console.ReadLine();
        }
    }
}