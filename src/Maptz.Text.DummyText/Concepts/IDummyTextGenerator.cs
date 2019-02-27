using System.Collections.Generic;
namespace Maptz.Text.DummyText
{
    public interface IDummyTextGenerator
    {
        string GetDummySentence(int minSentenceLength, int maxSentenceLength, int? seed);
        IEnumerable<string> GetDummyWords(int wordCount);
    }
}