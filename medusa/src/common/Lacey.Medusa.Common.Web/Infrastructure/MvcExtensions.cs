using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace Lacey.Medusa.Common.Web.Infrastructure
{
    public static class MvcExtensions
    {
        public static IMvcBuilder UseCamelCaseJson(
            this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver =
                        new CamelCasePropertyNamesContractResolver();
                });


            return mvcBuilder;
        }
    }
}