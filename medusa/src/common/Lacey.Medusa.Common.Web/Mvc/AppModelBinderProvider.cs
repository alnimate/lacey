using Lacey.Medusa.Common.DataAnnotations.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Lacey.Medusa.Common.Web.Mvc
{
    public sealed class AppModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            var modelType = context.Metadata.ModelType;
            if (modelType.IsPrimitiveGeneric())
                return new CommaSeparatedModelBinder();

            return null;
        }
    }
}