using System;
namespace Maptz.Text.DelimitedText
{
    /// <summary>
    /// An attribute describing which column in a delimited text line the propery represents. 
    /// </summary>
    public class DelimitedTextAttribute : Attribute
    {
        public DelimitedTextAttribute(int index)
        {
            this.Index = index;
        }

        /// <summary>
        /// Gets the column number of the attached property in the delimited text serialization.
        /// </summary>
        public int Index { get; set; }
    }
}