using System.Web.Http.Dependencies;
using Ninject;

namespace Lacey.Medusa.Common.DI.Web.Infrastructure
{
    using IDependencyResolver = System.Web.Mvc.IDependencyResolver;

    public sealed class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(this.kernel.BeginBlock());
        }
    }
}