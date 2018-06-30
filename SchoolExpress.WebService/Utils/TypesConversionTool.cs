using System;
using System.Globalization;

namespace SchoolExpress.WebService.Utils
{
    public class TypesConversionTool
    {
        public static DateTime ConvertDateTime(string value)
        {
            DateTime dateTime = DateTime.Now;
            if (!string.IsNullOrEmpty(value))
            {
                string[] strDateTime = value.Split('.');
                DateTime.TryParse(strDateTime[0], out dateTime);
            }

            return dateTime;
        }

        public static DateTime? ConvertNullbleDateTime(string value)
        {          
            if (!string.IsNullOrEmpty(value))
            {
                DateTime dateTime;
                if (DateTime.TryParse(value, out dateTime))
                {
                    return dateTime;
                }

            }

            return null;
        }

        public static bool ConvertBoolean(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            switch (value)
            {
                case "1":
                    return true;
                case "0":
                    return false;
            }

            bool boolean;
            bool.TryParse(value, out boolean);
            return boolean;

        }

        public static bool? ConvertNullableBoolean(string value)
        {
            if (string.IsNullOrEmpty(value)) return null;

            switch (value)
            {
                case "1":
                    return true;
                case "0":
                    return false;
            }

            bool boolean;
            if (bool.TryParse(value, out boolean))
            {
                return boolean;
            }
            return null;
        }

        public static TimeSpan ConvertTimeSpan(string value)
        {
            TimeSpan time;
            if (!string.IsNullOrEmpty(value))
            {
                string[] strTime = value.Split('.');
                if (TimeSpan.TryParse(strTime[0], out time))
                {
                    return time;
                }
            }

            return DateTime.Now.TimeOfDay;
        }

        public static TimeSpan? ConvertNullableTimeSpan(string value)
        {
            TimeSpan time;
            if (!string.IsNullOrEmpty(value))
            {
                string[] strTime = value.Split('.');
                if (TimeSpan.TryParse(strTime[0], out time))
                {
                    return time;
                }
            }

            return null;
        }
    }
}
