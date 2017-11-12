using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beejak.DI
{
    public static class DependancyManager
    {
        private static IDependancyResolver _depResolver = DependancyResolverFactory.GetDependancyResolver();

        public static T Resolve<T>()
        {
            return _depResolver.Resolve<T>();
        }

        public static T Resolve<T>(string name)
        {
            return _depResolver.Resolve<T>(name);
        }
    }
}
