using System;
using System.Linq;
namespace Maptz.Text
{
    /// <summary>
    /// Helper methods for strings. 
    /// </summary>
    public static class StringExtensions
    {

        /// <summary>
        /// Indent all lines in a string. 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="indentation"></param>
        /// <returns></returns>
        public static string IndentLines(this string str, string indentation)
        {
            var lines = str.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            var newLines = lines.Select(p => indentation + p);
            return string.Join(Environment.NewLine, newLines);
        }

    }
}