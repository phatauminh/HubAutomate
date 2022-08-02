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

        public static int GetStateCodeBy(string stateName)
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
