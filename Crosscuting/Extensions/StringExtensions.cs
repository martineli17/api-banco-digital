using System;

namespace Crosscuting.Extensions
{
    public static class StringExtensions
    {
        private static Random _random = new Random();
        public static bool HasValue(this string value) => string.IsNullOrEmpty(value);

        public static string TrySubstring(this string value, int length)
         => (length > value.Length) ? value.Substring(0,value.Length) : value.Substring(0,length);

        public static string RandonsNumbers(this string value, int minValue = 0, int maxValue = 10) =>
            _random.Next(minValue, maxValue).ToString();
    }
}
