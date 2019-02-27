using System;
using System.Collections.Generic;

namespace Maptz.Text.DummyText
{

    public class DummyTextGenerator : IDummyTextGenerator
    {
        /* #region Public Properties */
        public IDummyWordGenerator DummmyWordGenerator { get; }
        /* #endregion Public Properties */
        /* #region Public Constructors */
        public DummyTextGenerator(IDummyWordGenerator dummmyWordGenerator)
        {
            this.DummmyWordGenerator = dummmyWordGenerator;

        }
        /* #endregion Public Constructors */
        /* #region Interface: 'Unscrypt.Text.Dummy.IDummyTextGenerator' Methods */
        public string GetDummySentence(int minSentenceLength = 4, int maxSentenceLength = 30, int? seed = null)
        {
            Random random = seed.HasValue ? new Random(seed.Value) : new Random();
            var sentenceLength = minSentenceLength + random.Next(maxSentenceLength - minSentenceLength);
            var sentenceParts = GetDummyWords(sentenceLength);
            var dummy = string.Join(" ", sentenceParts) + ".";
            var retval = char.ToUpper(dummy[0]) + dummy.Substring(1);
            return retval;
        }
        public IEnumerable<string> GetDummyWords(int wordCount)
        {

            List<string> retval = new List<string>();
            for (int i = 0; i < wordCount; i++)
            {
                var nextWord = this.DummmyWordGenerator.NextWord();
                retval.Add(nextWord);
            }
            return retval;
        }
        /* #endregion Interface: 'Unscrypt.Text.Dummy.IDummyTextGenerator' Methods */
    }
}
