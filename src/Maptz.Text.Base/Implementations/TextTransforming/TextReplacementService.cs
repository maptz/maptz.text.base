using System.Linq;
using System.Text.RegularExpressions;
namespace Maptz.Text
{
    public class TextReplacementService : ITextReplacmentService
    {
        public TextReplacementService(ITextReplacementServiceSettings settings)
        {
            this.Settings = settings;
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        public ITextReplacementServiceSettings Settings { get; private set; }


        /// <summary>
        /// Replaces all pattern matches with transformed matches. 
        /// </summary>
        /// <param name="fileContents"></param>
        /// <param name="hasReplaced"></param>
        /// <returns></returns>
        public string Transform(string fileContents, out bool hasReplaced)
        {
            hasReplaced = false;
            foreach (var replacement in this.Settings.TextReplacementPatterns)
            {
                var matches = Regex.Matches(fileContents, replacement.Pattern).Cast<Match>();
                var replacementCount = 0;
                if (matches.Any())
                {
                    foreach (Match match in matches.OrderByDescending(p => p.Index).ToArray())
                    {
                        var replacementText = replacement.TranformFunction(fileContents, match);
                        fileContents = fileContents.Substring(0, match.Index) + replacementText + fileContents.Substring(match.Index + match.Length);
                        replacementCount++;
                        hasReplaced = true;
                    }
                }
            }
            return fileContents;
        }
    }
}