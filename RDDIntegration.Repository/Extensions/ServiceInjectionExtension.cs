using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RDDIntegration.API.Extensions
{
    public static class ServiceInjectionExtension
    {
        public static T DeserializeEmbeddedJsonP<T>(Stream stream)
        {

            using (var textReader = new StreamReader(stream))
                return DeserializeEmbeddedJsonP<T>(textReader);
        }

        public static T DeserializeEmbeddedJsonP<T>(TextReader textReader)
        {
            using (var jsonReader = new JsonTextReader(textReader.SkipPast('(')))
            {
                var settings = new JsonSerializerSettings
                {
                    CheckAdditionalContent = false,
                };
                return JsonSerializer.CreateDefault(settings).Deserialize<T>(jsonReader);
            }
        }

    }


    public static class TextReaderExtensions
    {
        public static TTextReader SkipPast<TTextReader>(this TTextReader reader, char ch) where TTextReader : TextReader
        {
            while (true)
            {
                var c = reader.Read();
                if (c == -1 || c == ch)
                    return reader;
            }
        }
    }
}
