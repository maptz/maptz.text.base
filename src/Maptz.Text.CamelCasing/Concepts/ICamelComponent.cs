namespace Maptz.Text.CamelCasing
{
    /// <summary>
    /// A component in a camel string.
    /// </summary>
    public interface ICamelComponent
    {

        bool AreAllCharsLettersOrDigits { get; }
        /// <summary>
        /// Indicates if this is a space character, or set of space characters.
        /// </summary>
        bool IsSpaceComponent { get; }

        /// <summary>
        /// Indicates if this is a symbol, i.e. made up of non alphanumeric characters.
        /// </summary>
        bool IsSymbolComponent { get; }
        /// <summary>
        /// Gets a value indicating if it is a word compoent, i.e. made up of alphanumeric characters. 
        /// </summary>
        bool IsWordComponent { get; }
        /// <summary>
        /// The text for this camel component.
        /// </summary>
        string Text { get; }
    }
}