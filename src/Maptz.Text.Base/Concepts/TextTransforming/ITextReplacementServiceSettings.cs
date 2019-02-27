using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Maptz.Text
{public interface ITextReplacementServiceSettings : ITextTransformServiceSettings
    {
        /// <summary>
        /// Gets the replacements. 
        /// </summary>
        IEnumerable<ITextReplacementPattern> TextReplacementPatterns { get; }
    }
}