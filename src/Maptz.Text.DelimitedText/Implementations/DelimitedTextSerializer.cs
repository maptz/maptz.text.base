using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Maptz.Text.DelimitedText
{

    /// <summary>
    /// A serializer used to serialize items as delimited text. 
    /// </summary>
    public static class DelimitedTextSerializer
    {
        /* #region Private Static Methods */
        private static bool TryDeserializeLine<T>(string[] lineSplit, out T t) where T : new()
        {
            t = new T();

            bool hasAddedAny = false;
            foreach (var property in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var attributes = (property.GetCustomAttributes(typeof(DelimitedTextAttribute), false) as IEnumerable<DelimitedTextAttribute>);
                if (!attributes.Any())
                    continue;
                var csvAttribute = attributes.First();
                if (csvAttribute.Index >= lineSplit.Length)
                    continue;

                hasAddedAny = true;
                var value = lineSplit[csvAttribute.Index];

                var parseFunction = property.PropertyType.GetMethods(BindingFlags.Public | System.Reflection.BindingFlags.Static).Where(p => p.Name == "Parse").Where(p => p.GetParameters().Count() == 1).FirstOrDefault();
                if (parseFunction != null)
                {

                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        var parseResult = parseFunction.Invoke(null, new object[] { value });
                        property.SetValue(t, parseResult);
                    }



                }
                else
                    property.SetValue(t, value);
            }


            return hasAddedAny;
        }
        /* #endregion Private Static Methods */
        /* #region Public Static Methods */

        /// <summary>
        /// Deserializes a 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static IEnumerable<T> Deserialize<T>(string content, string delimiter) where T : new()
        {
            var lines = content.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            List<T> retval = new List<T>();
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                var lineSplit = line.Split(new string[] { delimiter }, StringSplitOptions.None);

                T t;
                var wasSuccessful = TryDeserializeLine(lineSplit, out t);
                if (wasSuccessful)
                    retval.Add(t);

            }
            return retval;
        }
        /// <summary>
        /// Serializes an enumerable into a delimited string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string Serialize<T>(IEnumerable<T> values, string delimiter)
        {
            StringBuilder outputBuilder = new StringBuilder();
            foreach (var value in values)
                outputBuilder.AppendLine(ToDelimitedLine(value, delimiter));

            return outputBuilder.ToString();
        }

        /// <summary>
        /// Gets a delimited line as described by an object decorated with DelimitedTextAttribute. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string ToDelimitedLine<T>(T t, string delimiter)
        {
            Dictionary<int, PropertyInfo> properties = new Dictionary<int, PropertyInfo>();

            foreach (var property in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var csvAttribute = (property.GetCustomAttributes(typeof(DelimitedTextAttribute), false) as IEnumerable<DelimitedTextAttribute>).First();
                properties.Add(csvAttribute.Index, property);
            }

            var maxIndex = properties.Keys.Max();
            var components = new List<String>();
            for (int i = 0; i <= maxIndex; i++)
            {
                if (properties.ContainsKey(i))
                {
                    var val = properties[i].GetValue(t).ToString();
                    components.Add(val);
                }
                else
                    components.Add(string.Empty);
            }
            var retval = string.Join(delimiter, components.Cast<Object>().ToArray());
            return retval;

        }
        /* #endregion Public Static Methods */
    }
}
