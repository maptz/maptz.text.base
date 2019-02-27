using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
namespace Maptz.Text.DelimitedText
{public static class DelimitedStringExtensions
    {
        /// <summary>
        /// Gets a tab delimited string from an enumerable. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static string ToTabDelimitedString<T>(this IEnumerable<T> enumerable)
        {
            return DelimitedTextSerializer.Serialize(enumerable, "\t");
        }

        /// <summary>
        /// Gets a comma delimited string from an enumerable. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static string ToCommaDelimitedString<T>(this IEnumerable<T> enumerable)
        {
            return DelimitedTextSerializer.Serialize(enumerable, ",");
        }

        /// <summary>
        /// Gets a space delimited string from an enumerable. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static string ToSpaceDelimitedString<T>(this IEnumerable<T> enumerable)
        {
            return DelimitedTextSerializer.Serialize(enumerable, " ");
        }
    }
}