using System;
using System.Linq;

namespace Hub.Retailer.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNotNullOrEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static string GenerateStringWithPrefix(int length, string prefix)
        {
            const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZx0123456789";
            var random = new Random();
            return prefix + new string(Enumerable.Repeat(chars, length - prefix.Length).Select(s => s[random.Next(1, s.Length)]).ToArray());
        }

        public static int GetStateCodeBy(this string stateName)
        {
            switch (stateName)
            {
                case "NSW":
                    return 301;
                case "QLD":
                    return 303;
                case "VIC":
                    return 306;
                case "WA":
                    return 307;
                case "SA":
                    return 304;
                case "TAS":
                    return 305;
                case "ACT":
                    return 300;
                case "NT":
                    return 302;
                default:
                    return 0;
            }
        }
    }
}
