using System;
using System.Web.Http;
using Lacey.Medusa.Common.DI.Infrastructure;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Lacey.Medusa.Common.DI.Web.Infrastructure
{
    public static class NinjectWebCommonUtils
    {
        /// <summary>
        ///     Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        public static IKernel CreateKernel(params INinjectModule[] modules)
        {
            var kernel = new StandardKernel(modules);
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);

                ManualDependencyResolver.SetKernel(kernel); // Manual
                // ReSharper disable once AccessToDisposedClosure
                ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(kernel)); // Log4Net
                GlobalConfiguration.Configuration.DependencyResolver =
                    new global::Ninject.Web.WebApi.NinjectDependencyResolver(kernel); // Web API

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }
    }
}