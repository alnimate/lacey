using System;
using Lacey.Medusa.Common.Api.Core.Custom.Serializers;
using Lacey.Medusa.Surfer.Services.LikesRock.Extensions;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Serializers
{
    internal sealed class SignInBvbSerializer : WebFormsToJsonSerializer
    {
        public override object Deserialize(string input, Type type)
        {
            return input.GetSignInResponse();
        }
    }
}