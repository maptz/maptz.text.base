using System;
using System.Collections.Generic;
using System.Linq;

namespace Maptz.Text.CamelCasing
{

    /// <summary>
    /// Provides helper methods to find the camel components of a string. 
    /// </summary>
    public static class CamelCasingStringExtensions
    {



        /// <summary>
        /// Gets the camel associated with a string. 
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetCamelWords(this string source, bool useCSMode = false)
        {
            if (source == null)
                //If the source is null, throw an exception.
                throw new ArgumentNullException("source");
            //Create a new CamelString containing the source string. 
            CamelString camelString = new CamelString(source);
            if (useCSMode)
            {
                camelString = (CamelString) InterfaceStringHelpers.TransformCS(camelString);
            }
            return camelString.CamelComponents.Select(p => p.Text).ToList();
        }

        /// <summary>
        /// Gets the index of the first camel component of a string. 
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>The index of the first camel component of the length of the string if there is only one camel component. </returns>
        public static int IndexOfCamelComponent(this string source, bool useCSMode = false)
        {
            if (source == null)
                //If the source is null, throw an exception.
                throw new ArgumentNullException("source");
            //Create a new CamelString containing the source string. 
            CamelString camelString = new CamelString(source);
            if (useCSMode)
            {
                camelString = (CamelString)InterfaceStringHelpers.TransformCS(camelString);
            }
            if (camelString.CamelComponents.Count() == 1)
                //If there are fewer than two camelComponents, just return the length of the string
                return source.Length;
            else
                //Otherwise, return the length of the first camel component (i.e. the index of the first CamelComponent)
                return camelString.CamelComponents.ElementAt(0).Text.Length;
        }

        /// <summary>
        /// Gets the index of the last camel component of a string. 
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static int LastIndexOfCamelComponent(this string source, bool useCSMode = false)
        {

            if (source == null)
                //If the source is null, throw an exception.
                throw new ArgumentNullException("source");

            //Create a new CamelString containing the source string. 
            CamelString camelString = new CamelString(source);
            if (useCSMode)
            {
                camelString = (CamelString)InterfaceStringHelpers.TransformCS(camelString);
            }
            if (camelString.CamelComponents.Count() == 1)
                //If there are fewer than two camelComponents, just return zero.
                return 0;
            else
                //Otherwise, return the length of the text minus the length of the last camel component.
                return source.Length - camelString.CamelComponents.ElementAt(camelString.CamelComponents.Count() - 1).Text.Length;
        }
    }
}
