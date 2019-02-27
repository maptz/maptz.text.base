using System;
using System.Linq;

namespace Maptz.Text.CamelCasing
{
    /// <summary>
    /// Represents a string of data that constitutes a run of letters that cannot be broken down into camel-case components. 
    /// </summary>
    public class CamelComponent : ICamelComponent
    {
        #region Private Variables
        private string _text;

        #endregion Private Variables

        #region Public Properties
        /// <summary>
        /// Gets a value indicating whether all the characters in this <see cref="CamelComponent"/> are spaces. 
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is space; otherwise, <c>false</c>.
        /// </value>
        public bool IsSpaceComponent
        {
            get
            {
                if (this.Text.Length == 0)
                    //If the word is zero-length return false. 
                    return false;
                //Get whether all the characters in this word are spaces. 
                bool areAllCharactersSpace = !this.Text.Any(p => p != ' ');
                //Return true if all the characters are spaces, otherwise false. 
                return areAllCharactersSpace;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance consists of only symbols
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is symbols; otherwise, <c>false</c>.
        /// </value>
        public bool IsSymbolComponent
        {
            get
            {
                if (this.Text.Length == 0)
                    //If the word is zero-length return false. 
                    return false;
                bool isAllSymbols = !this.Text.Any(p => char.IsLetterOrDigit(p) || p == ' ');
                return isAllSymbols;
            }
        }

        public bool IsAllUpper
        {
            get
            {
                if (this.Text.Length == 0)
                    //If the word is of zero-length, return false. 
                    return false;
                //Get a value indicating whether every character is a letter or a word. 
                bool areAllUpper = this.Text.All(p => char.IsLetter(p) && char.IsUpper(p));
                return areAllUpper;
            }
        }

        public bool AreAllCharsLettersOrDigits { get
            {

                if (this.Text.Length == 0)
                    //If the word is of zero-length, return false. 
                    return false;

                //Get a value indicating whether every character is a letter or a word. 
                bool areAllCharsLettersOrDigits = this.Text.All(p => char.IsLetterOrDigit(p));
                return areAllCharsLettersOrDigits;
            }
        }

        /// <summary>
        /// Gets a value indicating whether is a primitive camel word component. i.e. a word that cannot be broken down into camel parts. 
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is letter word; otherwise, <c>false</c>.
        /// </value>
        public bool IsWordComponent
        {
            get
            {
                if (this.Text.Length == 0)
                    //If the word is of zero-length, return false. 
                    return false;

                //Get a value indicating whether every character is a letter or a word. 
                bool areAllCharsLettersOrDigits = this.Text.Any(p => !char.IsLetterOrDigit(p));

                if (this.Text.Length == 1)
                    //if this is a one-letter word, then this is a letter word if the single character is a letter or a digit. 
                    //Return this value.
                    return areAllCharsLettersOrDigits;

                //Get all the letters except the first letter. 
                string remainder = this.Text.Substring(1);

                //Get a value indicating if the first letter is uppercase. 
                bool isFirstLetterUpperCase = char.IsUpper(this.Text[0]);

                //Get a value indicating whether all the character other than the first letter are lower case or digits. 
                bool remainderIsLowerCaseOrDigits = !remainder.Any(p => !(char.IsLower(p) || char.IsDigit(p)));
                //Get a value indicating whether the remainder is all upper. 
                bool remainderIsUpper = !remainder.Any(p => !char.IsUpper(p));

                //This is a letter word if and only if all the letters are digits and letters or digits and either (the remainder is lower case or digit or (the whole string is upper case).
                return areAllCharsLettersOrDigits && (remainderIsLowerCaseOrDigits || (remainderIsUpper && isFirstLetterUpperCase));
            }
        }

        /// <summary>
        /// Gets the text that constitutes this component. 
        /// </summary>
        public string Text
        {
            get { return _text; }
            private set
            {
                if (_text != value)
                    _text = value;
            }
        }

        #endregion Public Properties

        #region Public Functions
        internal void AddChar(char c)
        {
            //Get a value indicating if you are allowed to add the 
            bool canAddChar = CanAddChar(c);
            if (!canAddChar)
                //If you are not allowed to add the character throw an exception.
                throw new InvalidOperationException(string.Format("Cannot add the character '{0}' to the word '{1}'.",c, this.Text));

            //Otherwise, add the character to the word. 
            this.Text += c;
        }

        /// <summary>
        /// Tries to add a character to the <see cref="CamelComponent"/>. If adding the component would cause the component to stop being valid no addition takes place and the method returns false.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns></returns>
        internal bool TryAddChar(char c)
        { 
            //Get a value indicating if you are allowed to add the 
            bool canAddChar = CanAddChar(c);
            if (!canAddChar)
                //If adding this character would cause an invalid term, return false. 
                return false;
            //Otherwise, add the character and return true. 
            this.Text += c;
            return true;
        }



        /// <summary>
        /// Determines whether this instance would still be valid if you added the specified char to the word. 
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns>
        ///   <c>true</c> if this instance [can add char] the specified c; otherwise, <c>false</c>.
        /// </returns>
        internal bool CanAddChar(char c)
        {
            if (this.Text == null || this.Text.Length == 0)
                //If the current word length is zero, then return true. 
                return true;

            if (this.IsSpaceComponent)
                //If this is a space word, then return true if and only if the specified character is a space. 
                return c == ' ';

            if (this.IsSymbolComponent)
                //If this word is a symbol word, then return true if and only if the specified character is a symbol of the same kind
                return (c != ' ') && (!char.IsLetterOrDigit(c)) && this.Text[0] == c;

            //Otherwise this is a CamelPrimitve. 
            bool isAllUpper = !this.Text.Any(p => !char.IsUpper(p));

            if (isAllUpper)
            {
                //If this is all upper case, then you can add any upper case letter. 
                if (char.IsUpper(c))
                    //If the specified char is upper case, return true. 
                    return true;

                if (char.IsLower(c) || char.IsNumber(c))
                {
                    //WRONG: If the character is a letter or a number, we can only add another letter if this word is one upper case letter long or zero-length.
                    //NOTE we've already encountered the zero case. 
                    return true;
                    //return this.Text.Length == 1;
                }
            }
            //If this is a valid word consisting of lower case elements and digits. Allow addition of any lower case character or number but nothing else. 
            return char.IsLower(c) || char.IsNumber(c);

        }

        #endregion Public Functions

    }
}
