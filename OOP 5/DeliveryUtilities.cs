using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_5
{
    internal static class DeliveryUtilities
    {
        public static void PrintSepararor()
        {
            Console.WriteLine("===========================");
        }

        public static void PrintSystemTitle(string title)
        {
            PrintSepararor();
            Console.WriteLine(title);
            PrintSepararor();
        }
    }
}
