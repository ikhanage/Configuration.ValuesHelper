using System;
using System.Configuration;

namespace Configuration.ValuesHelper
{
    public static class ConfigValue
    {
        public static AppSettingsReader reader;
        static ConfigValue()
        {
            reader = new AppSettingsReader();            
        }
        public static string GetAsString(string key)
        {
            return reader.GetValue(key, typeof(string)) as string;
        }

        public static bool GetAsBool(string key)
        {
            var nullBool = reader.GetValue(key, typeof(bool?)) as bool?;

            if (!nullBool.HasValue)
                throw new ConfigurationException(string.Format("The value of {0} was not a bool.", key));

            return nullBool.Value;
        }

        public static bool? GetAsNullableBool(string key)
        {
            return reader.GetValue(key, typeof(bool?)) as bool?;
        }

        public static int GetAsInt(string key)
        {
            var nullString = reader.GetValue(key, typeof(string)) as string;

            int @int;
            var isBool = Int32.TryParse(nullString, out @int);

            if (!isBool)
                throw new ConfigurationException(string.Format("The value of {0} was not an int.", key));

            return @int;
        }

        public static int? GetAsNullableInt(string key)
        {
            var nullString = reader.GetValue(key, typeof(string)) as string;

            int @int;
            if (!Int32.TryParse(nullString, out @int)) return null;

            return @int;
        }

        public static double GetAsDouble(string key)
        {
            var nullString = reader.GetValue(key, typeof(string)) as string;

            double @double;
            if (!double.TryParse(nullString, out @double))
                throw new ConfigurationException(string.Format("The value of {0} was not a double.", key));

            return @double;
        }

        public static double? GetAsNullableDouble(string key)
        {
            var nullString = reader.GetValue(key, typeof(string)) as string;

            double @double;
            if (!double.TryParse(nullString, out @double)) return null;

            return @double;
        }

        public static DateTime GetAsDateTime(string key)
        {
            var dateTimeString = reader.GetValue(key, typeof(string)) as string;

            DateTime dateTime;

            if(!DateTime.TryParse(dateTimeString, out dateTime))
                throw new ConfigurationException(string.Format("The value of {0} was not a datetime.", key));

            return dateTime;
        }

        public static DateTime? GetAsNullableDateTime(string key)
        {
            var dateTimeString = reader.GetValue(key, typeof(string)) as string;

            DateTime dateTime;

            if (!DateTime.TryParse(dateTimeString, out dateTime))
                return null;

            return dateTime;
        }
    }
}
