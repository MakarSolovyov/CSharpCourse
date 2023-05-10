namespace WinFormsApp1
{
    /// <summary>
    /// 
    /// </summary>
    internal static class StringExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        internal static string ReplaceByComma(this string str)
        {
            return str.Replace(".", ",");
        }
    }
}
