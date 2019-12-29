using System;
using System.IO;
using System.Xml.Serialization;
using Lacey.Medusa.Common.Api.Core.Base;
using Lacey.Medusa.Common.Core.Extensions;

namespace Lacey.Medusa.Common.Core.Serializers
{
    public class WebFormsToXmlSerializer : ISerializer
    {
        public string Format => "x-www-form-urlencoded";

        public virtual void Serialize(object obj, Stream target)
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

        public virtual string Serialize(object obj)
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

        public virtual T Deserialize<T>(string input)
        {
            var sr = new XmlSerializer(typeof(T));
            T result;
            using (var reader = new StringReader(input))
            {
                result = (T)sr.Deserialize(reader);
            }

            return result;
        }

        public virtual object Deserialize(string input, Type type)
        {
            var sr = new XmlSerializer(type);
            object result;
            using (var reader = new StringReader(input))
            {
                result = sr.Deserialize(reader);
            }

            return result;
        }

        public virtual T Deserialize<T>(Stream input)
        {
            var sr = new XmlSerializer(typeof(T));
            T result = (T)sr.Deserialize(input);
            return result;
        }

        private static void Serialize(TextWriter writer, object obj)
        {
            var queryString = obj.GetXmlQueryString();
            writer.Write(queryString);
        }
    }
}