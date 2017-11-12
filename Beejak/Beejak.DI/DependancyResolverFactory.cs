using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beejak.DI
{
    public class DependancyResolverFactory
    {
        public static IDependancyResolver GetDependancyResolver()
        {
            return new UnityDependancyResolver();
        }
    }
}
