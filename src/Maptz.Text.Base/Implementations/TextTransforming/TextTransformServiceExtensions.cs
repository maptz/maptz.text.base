using System.IO;
namespace Maptz.Text
{
    /// <summary>
    /// Contains extension methods for ITextTransformServices
    /// </summary>
    public static class TextTransformServiceExtensions
    {
        /// <summary>
        /// Transform file. 
        /// </summary>
        /// <param name="textReplacementService"></param>
        /// <param name="fileInfo"></param>
        /// <param name="hasReplaced"></param>
        public static void TransformFile(this ITextTransformService textReplacementService, FileInfo fileInfo, out bool hasReplaced)
        {
            var fileContents = string.Empty;
            using (var streamReader = fileInfo.OpenText())
            { fileContents = streamReader.ReadToEnd(); }

            bool hasChanged;
            fileContents = textReplacementService.Transform(fileContents, out hasChanged);

            hasReplaced = hasChanged;
            if (hasChanged)
            {
                fileInfo.Delete();
                using (var streamWriter = fileInfo.CreateText())
                { streamWriter.Write(fileContents); }
            }
        }
    }
}