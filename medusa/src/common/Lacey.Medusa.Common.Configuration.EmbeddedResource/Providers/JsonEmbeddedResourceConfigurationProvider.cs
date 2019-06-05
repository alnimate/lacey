using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lacey.Medusa.Common.Configuration.EmbeddedResource.Sources;
using Lacey.Medusa.Common.Configuration.EmbeddedResource.Utils;
using Newtonsoft.Json;

namespace Lacey.Medusa.Common.Configuration.EmbeddedResource.Providers
{
    public class JsonEmbeddedResourceConfigurationProvider : EmbeddedResourceConfigurationProvider
    {
        /// <summary>Initializes a new instance with the specified source.</summary>
        /// <param name="source">The source settings.</param>
        public JsonEmbeddedResourceConfigurationProvider(JsonEmbeddedResourceConfigurationSource source)
            : base(source)
        {
        }

        /// <summary>Loads the JSON data from a stream.</summary>
        /// <param name="stream">The stream to read.</param>
        public override void Load(Stream stream)
        {
            try
            {
                this.Data = JsonConfigurationFileParser.Parse(stream);
            }
            catch (JsonReaderException ex)
            {
                var str = string.Empty;
                if (stream.CanSeek)
                {
                    stream.Seek(0L, SeekOrigin.Begin);
                    using var streamReader = new StreamReader(stream);
                    var fileContent = ReadLines(streamReader);
                    str = RetrieveErrorContext(ex, fileContent);
                }
                throw new FormatException(
                    $"Could not parse the JSON file. Error on line number '{(object) ex.LineNumber}': '{(object) str}'", ex);
            }
        }

        private static string RetrieveErrorContext(
            JsonReaderException e,
            IEnumerable<string> fileContent)
        {
            var str = (string)null;
            var enumerable = fileContent as string[] ?? fileContent.ToArray();
            if (e.LineNumber >= 2)
            {
                var list = enumerable.Skip(e.LineNumber - 2).Take<string>(2).ToList<string>();
                if (list.Count<string>() >= 2)
                    str = list[0].Trim() + Environment.NewLine + list[1].Trim();
            }
            if (string.IsNullOrEmpty(str))
                str = enumerable.Skip(e.LineNumber - 1).FirstOrDefault<string>() ?? string.Empty;
            return str;
        }

        private static IEnumerable<string> ReadLines(TextReader streamReader)
        {
            string line;
            do
            {
                line = streamReader.ReadLine();
                yield return line;
            }
            while (line != null);
        }
    }
}