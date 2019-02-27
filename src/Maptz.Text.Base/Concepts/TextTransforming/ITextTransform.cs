using System;
using System.Text.RegularExpressions;
namespace Maptz.Text
{
    

    /// <summary>
    /// Used to transform instances of text matches. 
    /// </summary>
    public interface ITextReplacementPattern
    {
        /// <summary>
        /// Gets the regex pattern which this transform applies to.
        /// </summary>
        string Pattern { get; }

        /// <summary>
        /// Gets the transform function which transforms matches in the incoming string.
        /// </summary>
        StringTransformDelegate TranformFunction { get; }
    }
}