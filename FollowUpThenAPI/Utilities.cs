using System;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace FollowUpThenAPI
{
    public static class Utilities
    {
        public static void CopyPropertiesToObject<T>(T target, T source)
        {
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                property.SetValue(target, property.GetValue(source));

                if (!property.PropertyType.IsPrimitive)
                {
                    CopyPropertiesToObject(property.GetValue(target), property.GetValue(source));
                }
            }
        }

        public static bool IsEmpty(this JToken token)
        {
            return (token == null) ||
                   (token.Type == JTokenType.Array && !token.HasValues) ||
                   (token.Type == JTokenType.Object && !token.HasValues) ||
                   (token.Type == JTokenType.String && token.ToString() == String.Empty) ||
                   (token.Type == JTokenType.Null);
        }
    }
}
