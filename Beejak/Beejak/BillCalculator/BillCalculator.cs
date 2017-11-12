using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beejak.DataLayer.Interfaces;
using Beejak.DI;

namespace Beejak
{
    public class BillCalculator
    {
        static Dictionary<string, string> categoryToTaxMapping = DependancyManager.Resolve<ITaxProvider>().GetCategoryAndTaxMapping();

        static Dictionary<string, string> categoryToRateMapping = DependancyManager.Resolve<IRateProvider>().GetCategoryAndRateMapping();

        public static double CalculateBill(List<string> inputProducts, Dictionary<string, string> categoryToProductsMapping)
        {
            double totalBill = 0, totalTax = 0, totalAmount = 0.0;

            if (categoryToRateMapping != null && categoryToRateMapping.Count > 0 && categoryToTaxMapping.Count > 0)
            {
                foreach (var inputProduct in inputProducts)
                {
                    var categoryOfCurrentProduct = categoryToProductsMapping.First(x => x.Value.Contains(inputProduct)).Key;
                    if (!string.IsNullOrEmpty(categoryOfCurrentProduct))
                    {
                        if (categoryToRateMapping.ContainsKey(categoryOfCurrentProduct) && categoryToTaxMapping.ContainsKey(categoryOfCurrentProduct))
                        {
                            double amount = 0.0;
                            double.TryParse(categoryToRateMapping[categoryOfCurrentProduct], out amount);

                            totalAmount += amount;
                            totalBill += amount;

                            double taxPercent = 0.0;
                            double.TryParse(categoryToTaxMapping[categoryOfCurrentProduct], out taxPercent);

                            var taxAmount = amount * (taxPercent / 100);

                            totalTax += taxAmount;

                            totalBill += taxAmount;
                        }
                        else
                            Printer.PrintWarning(string.Format("Tax Or Rates were not configured for: {0}", categoryOfCurrentProduct));

                    }
                }
                Printer.PrintBill(totalBill, totalAmount, totalTax);
            }
            else
                Printer.PrintWarning(string.Format("Tax Or Rates are not configured"));

            return totalBill;
        }
    }
}
