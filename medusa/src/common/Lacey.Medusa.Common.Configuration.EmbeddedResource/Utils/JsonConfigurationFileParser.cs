using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Lacey.Medusa.Common.Configuration.EmbeddedResource.Utils
{
    internal class JsonConfigurationFileParser
    {
        private readonly IDictionary<string, string> data = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private readonly Stack<string> context = new Stack<string>();
        private string currentPath;
        private JsonTextReader reader;

        private JsonConfigurationFileParser()
        {
        }

        public static IDictionary<string, string> Parse(Stream input)
        {
            return new JsonConfigurationFileParser().ParseStream(input);
        }

        private IDictionary<string, string> ParseStream(Stream input)
        {
            this.data.Clear();
            this.reader = new JsonTextReader(new StreamReader(input));
            this.reader.DateParseHandling = DateParseHandling.None;
            this.VisitJObject(JObject.Load(this.reader));
            return this.data;
        }

        private void VisitJObject(JObject jObject)
        {
            foreach (var property in jObject.Properties())
            {
                this.EnterContext(property.Name);
                this.VisitProperty(property);
                this.ExitContext();
            }
        }

        private void VisitProperty(JProperty property)
        {
            this.VisitToken(property.Value);
        }

        private void VisitToken(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Object:
                    this.VisitJObject(token.Value<JObject>());
                    break;
                case JTokenType.Array:
                    this.VisitArray(token.Value<JArray>());
                    break;
                case JTokenType.Integer:
                case JTokenType.Float:
                case JTokenType.String:
                case JTokenType.Boolean:
                case JTokenType.Null:
                case JTokenType.Raw:
                case JTokenType.Bytes:
                    this.VisitPrimitive(token.Value<JValue>());
                    break;
                default:
                    throw new FormatException(
                        $"Unsupported JSON token '{(object) this.reader.TokenType}' was found. Path '{(object) this.reader.Path}', line {(object) this.reader.LineNumber} position {(object) this.reader.LinePosition}.");
            }
        }

        private void VisitArray(JArray array)
        {
            for (int index = 0; index < array.Count; ++index)
            {
                this.EnterContext(index.ToString());
                this.VisitToken(array[index]);
                this.ExitContext();
            }
        }

        private void VisitPrimitive(JValue d)
        {
            string path = this.currentPath;
            if (this.data.ContainsKey(path))
                throw new FormatException($"A duplicate key '{(object) path}' was found.");
            this.data[path] = d.ToString(CultureInfo.InvariantCulture);
        }

        private void EnterContext(string ctx)
        {
            this.context.Push(ctx);
            this.currentPath = ConfigurationPath.Combine(this.context.Reverse());
        }

        private void ExitContext()
        {
            this.context.Pop();
            this.currentPath = ConfigurationPath.Combine(this.context.Reverse());
        }
    }
}
