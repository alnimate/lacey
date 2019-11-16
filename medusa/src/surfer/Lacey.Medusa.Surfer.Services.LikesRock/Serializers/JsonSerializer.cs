using System;
using System.Text.RegularExpressions;
using Lacey.Medusa.Common.Api.Core.Custom.Serializers;
using Newtonsoft.Json;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Serializers
{
    public sealed class JsonSerializer<TResponse> : WebFormsToJsonSerializer
    {
        public override T Deserialize<T>(string input)
        {
            var json = string.Empty;

            var match = Regex.Match(input, @".*JSON.stringify\((.*)\)\).*", RegexOptions.Multiline);
            if (match.Groups.Count > 1)
            {
                json = match.Groups[1].Value;
            }

            try
            {
                return (T)Convert.ChangeType(JsonConvert.DeserializeObject<TResponse>(json), typeof(T));
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}