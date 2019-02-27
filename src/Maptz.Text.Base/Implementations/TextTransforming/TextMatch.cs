namespace Maptz.Text
{

    /// <summary>
    /// A transform used to transform items matching a pattern. 
    /// </summary>
    public class TextTransform : ITextReplacementPattern
    {
        /// <summary>
        /// The pattern used to transform the text. 
        /// </summary>
        public string Pattern { get; set; }
        
        /// <summary>
        /// The transform function used to transform matches. 
        /// </summary>
        public StringTransformDelegate TranformFunction
        {
            get;set;
        }
    }
}