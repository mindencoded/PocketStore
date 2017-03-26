using System;

namespace SchoolExpress.Domain
{
    public static class ObjectExtension
    {
        public static object GetPropValue(this object src, string propName)
        {
            try
            {
                return src.GetType().GetProperty(propName).GetValue(src, null);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
