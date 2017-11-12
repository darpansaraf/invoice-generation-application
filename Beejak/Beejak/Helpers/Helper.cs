using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beejak
{
    public static class Helper
    {
        public static List<string> GetInvalidProductsIfPresent(List<string> inputProducts, List<string> availableProducts)
        {
            var invalidProducts = new List<string>();
            foreach (var inputProduct in inputProducts)
            {
                if (!availableProducts.Contains(inputProduct))
                {
                    invalidProducts.Add(inputProduct);
                }
            }
            return invalidProducts;
        }

        public static List<string> GetProductsOfAllCategories(Dictionary<string, string> categoryToProductsMapping)
        {
            var products = new List<string>();
            if (categoryToProductsMapping != null && categoryToProductsMapping.Count > 0)
            {
                foreach (var mapping in categoryToProductsMapping)
                {
                    var productsOfCurrentCategory = mapping.Value != null ? mapping.Value.Split(',') : null;
                    if (productsOfCurrentCategory != null && productsOfCurrentCategory.Length > 0)
                        products.AddRange(productsOfCurrentCategory.ToList());
                }
                return products;
            }
            return null;
        }
    }
}
