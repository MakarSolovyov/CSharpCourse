namespace WinFormsApp1
{
    /// <summary>
    /// Class StringExtension.
    /// </summary>
    internal static class StringExtension
    {
        /// <summary>
        /// Replace dot by comma.
        /// </summary>
        /// <param name="str">String value.</param>
        /// <returns>String value without dot.</returns>
        internal static string ReplaceByComma(this string str)
        {
            return str.Replace(".", ",");
        }
    }
}
