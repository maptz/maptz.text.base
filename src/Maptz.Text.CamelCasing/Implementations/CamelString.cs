using System.Collections.Generic;
using System.Text;

namespace Maptz.Text.CamelCasing
{

    /// <summary>
    /// An ordered list of <see cref="CamelComponents"/> that represent a string broken down into its camel components. 
    /// </summary>
    public class CamelString : ICamelString
    {
        #region Private Variables
        private List<ICamelComponent> _camelComponents = new List<ICamelComponent>();

        #endregion Private Variables

        #region Public Properties
        /// <summary>
        /// Gets the camel components that make up the string. 
        /// </summary>
        public IEnumerable<ICamelComponent> CamelComponents
        {
            get { return _camelComponents; }
        }

        protected IList<ICamelComponent> CamelComponentsInternal
        {
            get { return _camelComponents; }
        }

        #endregion Public Properties

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CamelString"/> class.
        /// </summary>
        /// <param name="sourceString">The source string.</param>
        public CamelString(string sourceString)
        {
            if (string.IsNullOrEmpty(sourceString))
                //If the sourceString is null or empty, just return out of the constructor. 
                return;

            //Initialize the CamelComponents list. 
            this._camelComponents = new List<ICamelComponent>();

            //Create a new CamelComponent.
            CamelComponent lastCamelComponent = new CamelComponent();
            this.CamelComponentsInternal.Add(lastCamelComponent);
            for (int i = 0; i < sourceString.Length; i++)
            {
                //Walk through each character in the source string. 
                //Try to add the character to the existing 
                bool hasAddedCharacter = lastCamelComponent.TryAddChar(sourceString[i]);
                if (!hasAddedCharacter)
                {
                    //If we haven't been able to add the character, we'll have to start a new CamelComponent. 
                    lastCamelComponent = new CamelComponent();
                    //Add the new camelComponent to the internal list.
                    this.CamelComponentsInternal.Add(lastCamelComponent);
                    //Add the character to the new camel component. 
                    lastCamelComponent.AddChar(sourceString[i]);
                }
            }

        }

        #endregion Constructors

        #region Public Override Functions
        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            //Create a StringBuilder to build the output string. 
            StringBuilder stringBuilder = new StringBuilder();

            //Walk through each camel component. 
            foreach (CamelComponent camelComponent in this.CamelComponents)
            {
                //Add each camelComponent's Text to the StringBuilder. 
                stringBuilder.Append(camelComponent.Text);
            }
            //Return the StringBuilder's output text. 
            return stringBuilder.ToString();
        }

        #endregion Public Override Functions

    }


}
