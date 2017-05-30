namespace TeamScreen.Plugin.Base.Extensions
{
    public static class StringExtensions
    {
        public static string Recover(this string text)
        {
            return text ?? string.Empty;
        }
    }
}