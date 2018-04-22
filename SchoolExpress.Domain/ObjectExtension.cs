using System;
using System.Reflection;

namespace SchoolExpress.Domain
{
    public static class ObjectExtension
    {
        public static object GetPropValue(this object src, string propName)
        {
            PropertyInfo property = src.GetType().GetProperty(propName);
            if (property != null)
            {
                return property.GetValue(src, null);
            }
            return null;
        }
    }
}