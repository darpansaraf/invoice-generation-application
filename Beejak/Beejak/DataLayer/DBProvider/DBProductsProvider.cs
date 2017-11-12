using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beejak.DataLayer.Interfaces;

namespace Beejak.DataLayer.DBProvider
{
    public class DBProductsProvider : IProductProvider
    {

        public Dictionary<string, string> GetCategoryAndProductsMapping()
        {
            //TODO: Entity Framework can be used here to fetch Products data from DB
            throw new NotImplementedException();
        }
    }
}
