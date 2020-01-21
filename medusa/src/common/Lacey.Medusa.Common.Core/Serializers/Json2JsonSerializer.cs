using System;
using System.IO;
using Lacey.Medusa.Common.Api.Core.Base;
using Lacey.Medusa.Common.Api.Core.Base.Json;

namespace Lacey.Medusa.Common.Core.Serializers
{
    public class Json2JsonSerializer : ISerializer
    {
        private readonly ISerializer jsonSerializer;

        public Json2JsonSerializer()
        {
            this.jsonSerializer = new NewtonsoftJsonSerializer();
        }

        public string Format => "json";

        public virtual void Serialize(object obj, Stream target)
        {
            this.jsonSerializer.Serialize(obj, target);
        }

        public virtual string Serialize(object obj)
        {
            return this.jsonSerializer.Serialize(obj);
        }

        public virtual T Deserialize<T>(string input)
        {
            return this.jsonSerializer.Deserialize<T>(input);
        }

        public virtual object Deserialize(string input, Type type)
        {
            return this.jsonSerializer.Deserialize(input, type);
        }

        public virtual T Deserialize<T>(Stream input)
        {
            return this.jsonSerializer.Deserialize<T>(input);
        }
    }
}