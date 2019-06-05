using System.IO;
using System.Reflection;
using Lacey.Medusa.Common.Configuration.EmbeddedResource.Sources;
using Microsoft.Extensions.Configuration;

namespace Lacey.Medusa.Common.Configuration.EmbeddedResource.Providers
{
    public abstract class EmbeddedResourceConfigurationProvider : ConfigurationProvider
    {
        protected EmbeddedResourceConfigurationProvider(EmbeddedResourceConfigurationSource source)
        {
            this.Source = source;
        }

        public EmbeddedResourceConfigurationSource Source { get; }

        public override void Load()
        {
            var assembly = Assembly.GetEntryAssembly();
            if (assembly == null)
            {
                return;
            }

            var resourceStream = assembly.GetManifestResourceStream(this.Source.Path);
            this.Load(resourceStream);
        }

        public abstract void Load(Stream stream);
    }
}