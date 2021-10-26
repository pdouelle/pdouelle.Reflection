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
    }
}