using Ninject;
using Ninject.Parameters;

namespace Lacey.Medusa.Common.DI.Infrastructure
{
    public sealed class ManualDependencyResolver
    {
        private static StandardKernel kernel;

        public static void SetKernel(StandardKernel krnl)
        {
            kernel = krnl;
        }

        public static TService Get<TService>()
        {
            return kernel.Get<TService>();
        }

        public static TService Get<TService>(params IParameter[] parameters)
        {
            return kernel.Get<TService>(parameters);
        }
    }
}