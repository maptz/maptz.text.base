namespace Maptz.Text
{

    /// <summary>
    /// A service used to transform text.
    /// </summary>
    public interface ITextTransformService
    {

        /// <summary>
        /// Transform the text. 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="hasReplaced"></param>
        /// <returns></returns>
        string Transform(string source, out bool hasReplaced);
    }
}