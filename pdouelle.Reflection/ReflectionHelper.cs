using System;
using System.Reflection;
using Ardalis.GuardClauses;
using pdouelle.Errors;

namespace pdouelle.Reflection
{
    public static class ReflectionHelper
    {
        public static PropertyInfo GetProperty<T>(string propertyName)
        {
            Guard.Against.Null(propertyName, nameof(propertyName));
            
            PropertyInfo property = typeof(T).GetProperty(propertyName);
            
            Guard.Against.Null(property, nameof(property), new ResourceNotFound(typeof(T), nameof(propertyName), propertyName));

            return property;
        }
        
        private static void SetValue<T>(this T resource, PropertyInfo property, object value)
        {
            Type t = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
            var safeValue = Convert.ChangeType(value, t);
        
            property.SetValue(resource, safeValue);
        }
    }
}