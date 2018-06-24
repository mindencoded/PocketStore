using System;

namespace SchoolExpress.WebService.Domain
{
    public class EnumUtil
    {
        public static T Parse<T>(string value)
        {
            return (T) Enum.Parse(typeof(T), value, true);
        }

        public static T TryParse<T>(string value, T defaultValue) where T : struct
        {
            if (string.IsNullOrEmpty(value))
                return defaultValue;

            return Enum.TryParse(value, true, out T result) ? result : defaultValue;
        }
    }
}