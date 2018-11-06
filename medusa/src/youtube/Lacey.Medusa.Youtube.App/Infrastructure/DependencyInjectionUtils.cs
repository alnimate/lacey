using System.Collections.Generic;
using AutoMapper;
using Lacey.Medusa.Common.DI.Infrastructure;
using Lacey.Medusa.Common.DI.Modules;
using Lacey.Medusa.Youtube.Services.Database.Infrastructure;
using Ninject;

namespace Lacey.Medusa.Youtube.App.Infrastructure
{
    internal static class DependencyInjectionUtils
    {
        internal static void Initialize(params Profile[] profiles)
        {
            var profilesList = new List<Profile>
            {
                new YoutubeProfile(),
                new AppResourcesProfile()
            };
            profilesList.AddRange(profiles);

            var kernel = new StandardKernel(
                new AppNinjectModule(),
                new AutoMapperModule(profilesList.ToArray()));

            ManualDependencyResolver.SetKernel(kernel);
        }
    }
}