using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace Task8Files
{
    class Converter : IConverter
    {
        public Converter()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        }

        public object Convert(string typeName, string value)
        {
            switch (typeName)
            {
                case "Name":
                    return ConvertToStringType(value);
                case "Ozone":
                    return ConvertToIntN(value);
                case "SolarR":
                    return ConvertToDoubleN(value);
                case "Wind":
                    return ConvertToDoubleType(value);
                case "Temp":
                    return ConvertToDoubleType(value);
                case "Month":
                    return ConvertToIntType(value);
                case "Day":
                    return ConvertToIntType(value);
                default:
                    throw new NotImplementedException();
            }
        }

        private static string ConvertToStringType(string value)
            => IsEmpty(value) ? null : value;

        private static int? ConvertToIntN(string value)
            => ConvertTo<int>(value, (v)
                => System.Convert.ToInt32(value, CultureInfo.CurrentCulture));

        private static double? ConvertToDoubleN(string value)
            => ConvertTo<double>(value, (v)
                => System.Convert.ToDouble(value, CultureInfo.CurrentCulture));

        private static int ConvertToIntType(string value)
            => ConvertTo<int>(value, (v)
                => System.Convert.ToInt32(value, CultureInfo.CurrentCulture), true).Value;

        private static double ConvertToDoubleType(string value)
            => ConvertTo<double>(value, (v)
                => System.Convert.ToDouble(value, CultureInfo.CurrentCulture), true).Value;

        private static T? ConvertTo<T>(string value, Func<string, T?> function, bool notNull = false) where T : struct
        {
            if (notNull && value == null)
                throw new ArgumentException("This value can't contain NA value");

            return IsEmpty(value) ? null : function(value);
        }

        private static bool IsEmpty(string value)
        {
            return "NA".Equals(value);
        }


    }
}
