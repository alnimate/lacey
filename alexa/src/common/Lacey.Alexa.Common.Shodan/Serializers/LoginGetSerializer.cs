using System;
using Lacey.Alexa.Common.Shodan.Extensions;
using Lacey.Medusa.Common.Api.Core.Custom.Serializers;

namespace Lacey.Alexa.Common.Shodan.Serializers
{
    internal sealed class LoginGetSerializer : WebFormsToJsonSerializer
    {
        public override T Deserialize<T>(string input)
        {
            return (T)Convert.ChangeType(input.ToLoginGet().Result, typeof(T));
        }
    }
}