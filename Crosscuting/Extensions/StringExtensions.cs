namespace Crosscuting.Extensions
{
    public static class StringExtensions
    {
        public static bool HasValue(this string value) => string.IsNullOrEmpty(value);

        public static string TrySubstring(this string value, int length)
         => (length > value.Length) ? value.Substring(0,value.Length) : value.Substring(0,length);
    }
}
