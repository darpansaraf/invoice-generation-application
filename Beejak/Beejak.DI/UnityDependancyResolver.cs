using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using Microsoft.Practices.Unity.Configuration;
using Unity;

namespace Beejak.DI
{
    public class UnityDependancyResolver : ServiceLocatorImplBase, IDependancyResolver
    {
        private static IUnityContainer Container { get; set; }


        public UnityDependancyResolver()
        {
            var container = new UnityContainer();

            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            if (section != null)
            {
                section.Configure(container);
            }
            Container = container;
        }


        public T Resolve<T>()
        {
            T ret = Container.Resolve<T>();

            return ret;
        }

        public T Resolve<T>(string name)
        {
            T ret = Container.Resolve<T>(name);
            return ret;
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return Container.ResolveAll<T>();
        }


        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return Container.ResolveAll(serviceType);
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            return Container.Resolve(serviceType, key);
        }
    }
}
