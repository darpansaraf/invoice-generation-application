using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beejak
{
    public static class Printer
    {
        public static void PrintWarning(string warning)
        {
            Console.WriteLine(string.Format("!!!Warning:{0}", warning));
        }

        public static void PrintBill(double totalBill, double totalAmount, double totalTax)
        {
            Console.WriteLine("\n\n\nPrintingBill:");
            Console.WriteLine(string.Format("\nSub Total:  {0}", totalAmount));
            Console.WriteLine(string.Format("\nTotal Tax:  {0}", totalTax));
            Console.WriteLine(string.Format("\nGrandTotal: {0}", totalBill));
        }

        public static void PrintInformation(Dictionary<string, string> mappings)
        {
            foreach (var mapping in mappings)
            {
                Console.WriteLine(mapping.Key + ":\t" + mapping.Value);
            }
        }
    }
}
