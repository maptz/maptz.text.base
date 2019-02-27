namespace Maptz.Text
{
    /// <summary>
    /// A service used to clean text input. For example, text cleaners can be used to remove accented letters
    /// </summary>
    public interface ITextCleanerService
    {
        /// <summary>
        /// Clean text input. 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string CleanText(string input);  
    }
}