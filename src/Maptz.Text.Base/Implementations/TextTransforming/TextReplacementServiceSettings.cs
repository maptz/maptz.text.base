using System;
using System.Collections.Generic;

namespace Maptz.Text
{
    /// <summary>
    /// Settings for transforming tetx. 
    /// </summary>
    public class TextReplacementServiceSettings : ITextReplacementServiceSettings
    {
        public TextReplacementServiceSettings()
        {
            this.TextReplacementPatterns = new ITextReplacementPattern[0];
        }

        public IEnumerable<ITextReplacementPattern> TextReplacementPatterns
        {
            get;set;
        }
    }
}