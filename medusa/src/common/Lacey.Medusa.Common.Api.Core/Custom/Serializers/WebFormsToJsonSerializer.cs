using System;
using System.IO;
using Lacey.Medusa.Common.Api.Core.Base;
using Lacey.Medusa.Common.Api.Core.Base.Json;
using Lacey.Medusa.Common.Api.Core.Custom.Extensions;

namespace Lacey.Medusa.Common.Api.Core.Custom.Serializers
{
    public class WebFormsToJsonSerializer : ISerializer
    {
        private readonly ISerializer jsonSerializer;

        public WebFormsToJsonSerializer()
        {
            this.jsonSerializer = new NewtonsoftJsonSerializer();
        }

        public string Format => "x-www-form-urlencoded";

        public void Serialize(object obj, Stream target)
        {
            using (var writer = new StreamWriter(target))
            {
                if (obj == null)
                {
                    obj = string.Empty;
                }
                Serialize(writer, obj);
            }
        }

        public string Serialize(object obj)
        {
            using (TextWriter tw = new StringWriter())
            {
                if (obj == null)
                {
                    obj = string.Empty;
                }
                Serialize(tw, obj);
                return tw.ToString();
            }
        }

        public T Deserialize<T>(string input)
        {
            return this.jsonSerializer.Deserialize<T>(input);
        }

        public object Deserialize(string input, Type type)
        {
            return this.jsonSerializer.Deserialize(input, type);
        }

        public T Deserialize<T>(Stream input)
        {
            return this.jsonSerializer.Deserialize<T>(input);
        }

        private static void Serialize(TextWriter writer, object obj)
        {
            var queryString = obj.GetQueryString();
            writer.WriteLine(queryString);
        }
    }
}