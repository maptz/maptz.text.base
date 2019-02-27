using System.Collections.Generic;
namespace Maptz.Text.Templating
{
    /// <summary>
    /// A template service used to replace template strings in text documents.
    /// </summary>
    public interface ITemplateService
    {
        /// <summary>
        /// Replace template strings in the template using values specified in the dictionary. 
        /// </summary>
        /// <param name="template"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        string FillTemplate(string template, IDictionary<string, string> values);
    }
}