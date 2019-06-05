using Lacey.Medusa.Common.Configuration.EmbeddedResource.Providers;
using Microsoft.Extensions.Configuration;

namespace Lacey.Medusa.Common.Configuration.EmbeddedResource.Sources
{
    public class JsonEmbeddedResourceConfigurationSource : EmbeddedResourceConfigurationSource
    {
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return (IConfigurationProvider)new JsonEmbeddedResourceConfigurationProvider(this);
        }
    }
}