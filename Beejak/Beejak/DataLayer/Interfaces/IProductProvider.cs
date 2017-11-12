using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beejak.DataLayer.Interfaces
{
    public interface IProductProvider
    {
        Dictionary<string, string> GetCategoryAndProductsMapping();
    }
}
