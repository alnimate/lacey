using Lacey.Medusa.Common.Dal.Infrastructure;
using Lacey.Medusa.Common.Dal.Infrastructure.Concrete;
using Lacey.Medusa.Youtube.Dal.Infrastructure;
using Lacey.Medusa.Youtube.Services.Api.Services.Auth;
using Lacey.Medusa.Youtube.Services.Api.Services.Auth.Concrete;
using Lacey.Medusa.Youtube.Services.Api.Services.Videos;
using Lacey.Medusa.Youtube.Services.Api.Services.Videos.Concrete;
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
            this.Bind<IYoutubeAuthProvider>().To<SimpleYoutubeAuthProvider>()
                .InTransientScope()
                .WithConstructorArgument("apiKeyFile", "google_api_key.secret");

            // Services
            this.Bind<IYoutubeVideosService>().To<YoutubeVideosService>().InTransientScope();
        }
    }
}