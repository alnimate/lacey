using System;
using Lacey.Medusa.Common.Api.Core.Custom.Serializers;
using Lacey.Medusa.Surfer.Services.LikesRock.Extensions;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Serializers
{
    internal sealed class GetTasksSerializer : WebFormsToJsonSerializer
    {
        public override T Deserialize<T>(string input)
        {
            return (T)Convert.ChangeType(input.GetTasksResponse().Result, typeof(T));
        }
    }
}