using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Maptz.Text
{

    /// <summary>
    /// A text cleaner service which removes ellipses and accents from a text input. 
    /// </summary>
    public class DefaultTextCleanerService : ITextCleanerService
    {
        /* #region Public Properties */
        public ILogger Logger { get; private set; }
        public DefaultTextCleanerServiceSettings Settings { get; private set; }
        /* #endregion Public Properties */
        /* #region Public Constructors */
        public DefaultTextCleanerService(IOptions<DefaultTextCleanerServiceSettings> settings, ILoggerFactory loggerFactory)
        {
            this.Settings = settings.Value;
            this.Logger = loggerFactory.CreateLogger(typeof(DefaultTextCleanerService).Name);
        }
        /* #endregion Public Constructors */
        /* #region Interface: 'Maptz.Text.ITextCleanerService' Methods */

        /// <summary>
        /// Clean the text. 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string CleanText(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            var outputLines = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var cleanLine = line.Trim();
                    //Replace double spaces...
                    cleanLine = Regex.Replace(cleanLine, "\\s(\\s)+", " ");
                    //Replace Elipsis  (see https://www.cl.cam.ac.uk/~mgk25/ucs/quotes.html)
                    cleanLine = cleanLine.Replace("\u2026", "...");
                    //Replace quotes (see https://www.cl.cam.ac.uk/~mgk25/ucs/quotes.html)
                    cleanLine = cleanLine.Replace("\u201C", "\"");
                    cleanLine = cleanLine.Replace("\u201D", "\"");
                    cleanLine = cleanLine.Replace("\u2018", "'");
                    cleanLine = cleanLine.Replace("\u2019", "'");
                    cleanLine = cleanLine.Replace("\u0060", "'");
                    cleanLine = cleanLine.Replace("\u00B4", "'");
                    outputLines.Add(cleanLine);
                }
            }
            //Return with newline character.  //"\x0a"
            var retval = string.Join(Environment.NewLine, outputLines);
            return retval;

        }
        /* #endregion Interface: 'Maptz.Text.ITextCleanerService' Methods */
    }
}