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
    public class ConfigTaxProvider : ITaxProvider
    {
        public Dictionary<string, string> GetCategoryAndTaxMapping()
        {
            Dictionary<string, string> categoryToTaxMapping = null;
            try
            {
                var section = ConfigurationManager.AppSettings["CategoriesToTaxMapping"];

                var categoryToTaxMappings = section.ToString().Split('|');
                if (categoryToTaxMappings != null && categoryToTaxMappings.Count() > 0)
                {
                    categoryToTaxMapping = new Dictionary<string, string>();
                    foreach (var mapping in categoryToTaxMappings)
                    {
                        var tokens = mapping.Split(':');
                        if (tokens.Count() > 1)
                            categoryToTaxMapping.Add(tokens[0], tokens[1]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some Error Occurred while fetching configured taxes..!");
                Console.ReadLine();

            }
            return categoryToTaxMapping;
        }
    }
}
