using Microsoft.Extensions.Configuration;

namespace Lacey.Medusa.Common.Configuration.EmbeddedResource.Sources
{
    public abstract class EmbeddedResourceConfigurationSource : IConfigurationSource
    {
        public string Path { get; set; }

        public abstract IConfigurationProvider Build(IConfigurationBuilder builder);
    }
}