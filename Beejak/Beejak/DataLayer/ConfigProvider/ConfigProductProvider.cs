using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Beejak.DataLayer.Interfaces;

namespace Beejak.DataLayer.ConfigProvider
{
    public class ConfigProductProvider : IProductProvider
    {
        public Dictionary<string, string> GetCategoryAndProductsMapping()
        {
            Dictionary<string, string> categoryToProductMapping = null;
            try
            {
                var section = ConfigurationManager.AppSettings["CategoriesToProductsMapping"];

                var categoryToProductMappings = section.ToString().Split('|');
                if (categoryToProductMappings != null && categoryToProductMappings.Count() > 0)
                {
                    categoryToProductMapping = new Dictionary<string, string>();
                    foreach (var mapping in categoryToProductMappings)
                    {
                        var tokens = mapping.Split(':');
                        if (tokens.Count() > 1)
                            categoryToProductMapping.Add(tokens[0], tokens[1]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some Error Occurred while fetching configured products..!");
                Console.ReadLine();
            }
            
            return categoryToProductMapping;
        }
    }
}
