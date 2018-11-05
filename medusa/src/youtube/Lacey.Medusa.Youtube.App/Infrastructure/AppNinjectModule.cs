using Lacey.Medusa.Common.Dal.Infrastructure;
using Lacey.Medusa.Common.Dal.Infrastructure.Concrete;
using Lacey.Medusa.Youtube.Api.Services.Auth;
using Lacey.Medusa.Youtube.Api.Services.Auth.Concrete;
using Lacey.Medusa.Youtube.Api.Services.Videos;
using Lacey.Medusa.Youtube.Api.Services.Videos.Concrete;
using Lacey.Medusa.Youtube.Dal.Infrastructure;
using Ninject.Modules;

namespace Lacey.Medusa.Youtube.App.Infrastructure
{
    internal class AppNinjectModule : NinjectModule
    {
        public override void Load()
        {
            // Entity Framework
            this.Bind<IUnitOfWork>().To<UnitOfWork>().InTransientScope();
            this.Bind<IUnitOfWorkFactory>().To<UnitOfWorkFactory>().InTransientScope();
            this.Bind<ISessionFactory>().To<YoutubeSessionFactory>().InTransientScope();

            // API
            this.Bind<IAuthProvider>().To<SimpleAuthProvider>()
                .InTransientScope()
                .WithConstructorArgument("apiKeyFile", 
                    "c:\\lacey\\projects\\lacey\\medusa\\src\\secrets\\google_api_key.txt");

            // Services
            this.Bind<IVideosService>().To<VideosService>().InTransientScope();
        }
    }
}