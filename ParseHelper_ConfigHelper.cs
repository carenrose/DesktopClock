using System;
using System.Configuration;
using System.Linq;

namespace Clock
{
    // grabbed these from NITE

    public static class ConfigHelper
    {
        public static bool KeyExists(string key)
        {
            return ConfigurationManager.AppSettings.AllKeys.Contains(key);
        }

        public static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings.Get(key);
        }

        public static bool GetValueBool(string key, bool defaultTo = false)
        {
            return GetValue(key).ToBool(defaultTo);
        }

        public static DateTime? GetValueDate(string key)
        {
            return GetValue(key).ToDate();
        }

        public static int? GetValueInt(string key)
        {
            return GetValue(key).ToInt();
        }
    }


    public static class ParseHelper
    {
        #region Numeric and Bool

        public static int? ToInt(this string input)
        {
            return int.TryParse(input, out var output)
                ? output 
                : (int?)null;
        }

        public static long? ToLong(this string input)
        {
            return long.TryParse(input, out var output)
                ? output
                : (long?)null;
        }

        public static double? ToDouble(this string input)
        {
            return double.TryParse(input, out var output)
                ? output 
                : (double?)null;
        }

        public static decimal? ToDecimal(this string input)
        {
            return decimal.TryParse(input, out var output)
                ? output 
                : (decimal?)null;
        }


        //public static bool ToBool(this object input, bool @default = false)
        //{
        //    if (input != null)
        //    {
        //        return ToBool(input.ToString(), @default);
        //    }
        //    return @default;
        //}

        public static bool ToBool(this string input, bool @default = false)
        {
            if (!bool.TryParse(input, out var output))
            {
                output = @default;
            }
            return output;
        }

        #endregion


        #region Date

        public static DateTime? ToDate(this string input)
        {
            return DateTime.TryParse(input, out var output) 
                ? (DateTime?)output 
                : null;
        }

        public static DateTime? ToDate(this string input, string format)
        {
            return DateTime.TryParseExact(input, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeLocal, out var output) 
                ? (DateTime?)output 
                : null;
        }


        // https://stackoverflow.com/a/250400/
        public static DateTime? UnixTimestampToDateTime(long? timestamp)
        {
            if (timestamp.HasValue)
            {
                var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                return unixEpoch.AddSeconds(timestamp.Value / 1000).ToLocalTime();
            }

            return null;
        }

        #endregion


        #region String

        public static string NullIfEmpty(this string s)
        {
            return string.IsNullOrEmpty(s) ? null : s;
        }
        public static string NullIfWhiteSpace(this string s)
        {
            return string.IsNullOrWhiteSpace(s) ? null : s;
        }

        #endregion

    }

}