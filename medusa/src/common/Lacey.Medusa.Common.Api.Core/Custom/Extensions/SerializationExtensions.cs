﻿using System.Linq;
using System.Reflection;
using System.Web;
using Newtonsoft.Json;

namespace Lacey.Medusa.Common.Api.Core.Custom.Extensions
{
    internal static class SerializationExtensions
    {
        public static string GetQueryString(this object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                where p.GetValue(obj, null) != null
                select GetPropertyName(p) + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return string.Join("&", properties.ToArray());
        }

        private static string GetPropertyName(PropertyInfo p)
        {
            var attr = p.GetCustomAttributes().FirstOrDefault(a => a is JsonPropertyAttribute);
            if (attr != null)
            {
                return ((JsonPropertyAttribute) attr).PropertyName;
            }

            return p.Name;
        }
    }
}