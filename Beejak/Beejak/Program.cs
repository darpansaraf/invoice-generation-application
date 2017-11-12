using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beejak.DataLayer.ConfigProvider;
using Beejak.DataLayer.Interfaces;
using Beejak.DI;
using Unity;

namespace Beejak
{
    class Program
    {
        static void Main(string[] args)
        {
            var productsProvider = DependancyManager.Resolve<IProductProvider>();
            var categoryToProductsMapping = productsProvider.GetCategoryAndProductsMapping();

            if (categoryToProductsMapping != null)
            {
                var availableProducts = Helper.GetProductsOfAllCategories(categoryToProductsMapping);

                DisplayDashboard(categoryToProductsMapping);

                Console.WriteLine("\nEnter Comma separated values of Products To be added in Cart:");
                var inputProducts = Console.ReadLine().Split(',').ToList();

                var invalidProducts = Helper.GetInvalidProductsIfPresent(inputProducts, availableProducts);

                if (invalidProducts.Count > 0)
                {
                    Console.WriteLine("Following are the invalid products added in cart:");
                    foreach (var invalidProduct in invalidProducts)
                        Console.WriteLine(invalidProduct);
                }

                inputProducts = inputProducts.Except(invalidProducts).ToList();

                BillCalculator.CalculateBill(inputProducts, categoryToProductsMapping);

                Console.ReadLine();
            }



        }

        private static void DisplayDashboard(Dictionary<string, string> categoryToProductsMapping)
        {
            Console.WriteLine("NOTE/Assumption: All the products of the same category will have the same rate.");

            Console.WriteLine("\nCategory and Products Information:");
            Printer.PrintInformation(categoryToProductsMapping);

            var categoryToRateMapping = DependancyManager.Resolve<IRateProvider>().GetCategoryAndRateMapping();
            Console.WriteLine("\nCategory and Rate Information(Rates in $)");
            Printer.PrintInformation(categoryToRateMapping);

            var categoryToTaxMapping = DependancyManager.Resolve<ITaxProvider>().GetCategoryAndTaxMapping();
            Console.WriteLine("\nCategory and Tax Information(TaxRate in %)");
            Printer.PrintInformation(categoryToTaxMapping);
        }


    }
}
