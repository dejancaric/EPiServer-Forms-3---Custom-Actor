using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CustomActorDemo.FormHelpers
{
    public static class ObjectMapper
    {
        public static T ToObject<T>(this List<KeyValuePair<string, object>> source)
            where T : class, new()
        {
            var newObject = new T();
            var newObjectType = newObject.GetType();

            var properties = newObjectType.GetProperties();
            foreach (var property in properties)
            {
                string friendlyName = GetFriendlyName(property);
                string key = !string.IsNullOrWhiteSpace(friendlyName)
                    ? friendlyName
                    : property.Name;

                SetPropertyValue(newObject, property, key, source);
            }

            return newObject;
        }

        private static string GetFriendlyName(PropertyInfo property)
        {
            var customAttributes = property.GetCustomAttributes(true);

            foreach (var customAttribute in customAttributes)
            {
                var formFieldNameAttribute = customAttribute as FriendlyNameAttribute;
                if (formFieldNameAttribute != null)
                {
                    return formFieldNameAttribute.Name;
                }
            }

            return string.Empty;
        }

        private static void SetPropertyValue<T>(
            T targetObject,
            PropertyInfo property,
            string key,
            IReadOnlyCollection<KeyValuePair<string, object>> source)
        {
            if (source.Any(x => x.Key == key))
            {
                property?.SetValue(targetObject, source.First(x => x.Key == key).Value, null);
            }
        }
    }
}