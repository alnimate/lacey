using System;
using Lacey.Medusa.Common.Configuration.EmbeddedResource.Sources;
using Microsoft.Extensions.Configuration;

namespace Lacey.Medusa.Common.Configuration.EmbeddedResource.Extensions
{
    public static class JsonConfigurationExtensions
    {
        public static IConfigurationBuilder AddJsonEmbeddedResource(
            this IConfigurationBuilder builder,
            string path)
        {
            return builder.Add((Action<JsonEmbeddedResourceConfigurationSource>)(s =>
            {
                s.Path = path;
            }));
        }
    }
}