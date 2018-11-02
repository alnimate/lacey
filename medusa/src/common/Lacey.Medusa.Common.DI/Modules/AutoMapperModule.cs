using AutoMapper;
using Ninject;
using Ninject.Modules;

namespace Lacey.Medusa.Common.DI.Modules
{
    public class AutoMapperModule : NinjectModule
    {
        private readonly Profile[] profiles = new Profile[0];

        public AutoMapperModule()
        {            
        }

        public AutoMapperModule(params Profile[] profiles)
        {
            this.profiles = profiles;
        }

        public override void Load()
        {
            this.Bind<IMapper>().ToMethod(this.AutoMapper).InSingletonScope();
        }

        private IMapper AutoMapper(
            global::Ninject.Activation.IContext context)
        {
            Mapper.Initialize(config =>
                {
                    config.ConstructServicesUsing(type => context.Kernel.Get(type));

                    // .... other mappings, Profiles, etc.  
                    foreach (var profile in this.profiles)
                    {
                        config.AddProfile(profile);
                    }
                });

            Mapper.AssertConfigurationIsValid(); // optional
            return Mapper.Instance;
        }
    }
}