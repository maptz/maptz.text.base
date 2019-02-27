using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace Maptz.Text.Templating
{
    /// <summary>
    /// A default template service, used to fill out templates of the for &gt;%= SomeTemplate %&lt;.
    /// </summary>
    public class TemplateService : ITemplateService
    {
        /// <summary>
        /// Fills out a template. 
        /// </summary>
        /// <param name="template"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public string FillTemplate(string template, IDictionary<string, string> values)
        {

            var regex = new Regex("<%=\\s+(?<name>[a-zA-Z0-9]*)\\s+%>", RegexOptions.IgnoreCase);
            var matches = regex.Matches(template).Cast<Match>().OrderByDescending(p => p.Index).ToArray();
            var outputString = template;
            foreach (Match match in matches)
            {
                var name = match.Groups["name"].Value;
                if (values.ContainsKey(name))
                {
                    var replacement = values[name] as string;
                    var prefix = outputString.Substring(0, match.Index);
                    var suffix = outputString.Substring(match.Index + match.Length);
                    outputString = prefix + replacement + suffix;
                }
            }
            return outputString;
        }

    }
}