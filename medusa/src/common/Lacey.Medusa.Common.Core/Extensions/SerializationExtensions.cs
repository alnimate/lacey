using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml.Serialization;

namespace Lacey.Medusa.Common.Core.Extensions
{
    internal static class SerializationExtensions
    {
        public static string GetXmlQueryString(this object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            var properties = from p in obj.GetType().GetProperties()
                where p.GetValue(obj, null) != null
                select GetXmlPropertyName(p) + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return string.Join("&", properties.ToArray());
        }

        private static string GetXmlPropertyName(PropertyInfo p)
        {
            var attr = p.GetCustomAttributes().FirstOrDefault(a => a is XmlElementAttribute);
            if (attr != null)
            {
                return ((XmlElementAttribute)attr).ElementName;
            }

            return p.Name;
        }
    }
}