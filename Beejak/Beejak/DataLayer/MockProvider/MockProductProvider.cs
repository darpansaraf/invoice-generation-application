using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beejak.DataLayer.Interfaces;

namespace Beejak.DataLayer.MockProvider
{
    public class MockProductProvider : IProductProvider
    {
        public Dictionary<string, string> GetCategoryAndProductsMapping()
        {
            return new Dictionary<string, string>()
            {
                {"CategoryA","1,2,3"},
                {"CategoryB","4,5,6"},
                {"CategoryC","7,8,9"}
            };
        }
    }
}
