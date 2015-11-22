using System.Text.RegularExpressions;

namespace Tie.Core
{
    public static class Slug
    {
        /// <summary>
        /// Generates the slug.
        /// </summary>
        /// <param name="phrase">The phrase.</param>
        /// <returns></returns>
        public static string GenerateSlug(string phrase)
        {
            string str = Slug.RemoveAccent(phrase).ToLower();

            str = Regex.Replace(str, @"[^a-z0-9\s-]", ""); // invalid chars           
            str = Regex.Replace(str, @"\s+", " ").Trim(); // convert multiple spaces into one space   
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim(); // cut and trim it   
            str = Regex.Replace(str, @"\s", "-"); // hyphens   

            return str;
        }

        /// <summary>
        /// Removes the accent.
        /// </summary>
        /// <param name="txt">The TXT.</param>
        /// <returns></returns>
        private static string RemoveAccent(string txt)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
    }
}
