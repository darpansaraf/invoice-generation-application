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
    public class ConfigRateProvider : IRateProvider
    {
        public Dictionary<string, string> GetCategoryAndRateMapping()
        {
            Dictionary<string, string> categoryToRateMapping = null;
            try
            {
                var section = ConfigurationManager.AppSettings["CategoriesToRateMapping"];

                var categoryToRateMappings = section.ToString().Split('|');
                if (categoryToRateMappings != null && categoryToRateMappings.Count() > 0)
                {
                    categoryToRateMapping = new Dictionary<string, string>();
                    foreach (var mapping in categoryToRateMappings)
                    {
                        var tokens = mapping.Split(':');
                        if (tokens.Count() > 1)
                            categoryToRateMapping.Add(tokens[0], tokens[1]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some Error Occurred while fetching configured product rates..!");
                Console.ReadLine();
            }
            
            return categoryToRateMapping;
        }
    }
}
