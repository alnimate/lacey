using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace Lacey.Medusa.Common.DI.Infrastructure
{
    public class NinjectServiceLocator : ServiceLocatorImplBase
    {
        public NinjectServiceLocator(StandardKernel kernel)
        {
            this.Kernel = kernel;
        }

        public StandardKernel Kernel { get; }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            if (key == null)
            {
                return this.Kernel.Get(serviceType);
            }

            return this.Kernel.Get(serviceType, key);
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return this.Kernel.GetAll(serviceType);
        }
    }
}