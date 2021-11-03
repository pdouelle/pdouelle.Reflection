using System;
using System.Reflection;
using Ardalis.GuardClauses;

namespace pdouelle.Reflection
{
    public static class ReflectionHelper
    {
        public static PropertyInfo GetProperty<T>(string propertyName)
        {
            Guard.Against.Null(propertyName, nameof(propertyName));
            
            PropertyInfo property = typeof(T).GetProperty(propertyName);

            return property;
        }
        
        public static void SetValue<T>(this T resource, PropertyInfo property, object value)
        {
            Guard.Against.Null(resource, nameof(resource));
            Guard.Against.Null(property, nameof(property));

            Type t = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
            var safeValue = Convert.ChangeType(value, t);
        
            property.SetValue(resource, safeValue);
        }
    }
}