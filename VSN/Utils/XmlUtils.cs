using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace VSN.Utils
{
    public static class XmlUtils
    {
        public static string Serialize<T>(this T value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            var serializer = new XmlSerializer(typeof(T));
            var stringWriter = new StringWriter();
            using (var writer = XmlWriter.Create(stringWriter))
            {
                serializer.Serialize(writer, value);
                return stringWriter.ToString();
            }
        }

    }
}