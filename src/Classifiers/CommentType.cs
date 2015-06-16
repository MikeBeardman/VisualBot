using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace VisualBot.Classifiers
{
    internal static class CommentClassificationDefinition
    {
        /// <summary>
        /// Defines the "VisualBot" classification type.
        /// </summary>
        [Export(typeof(ClassificationTypeDefinition))]
        [Name(CommentFormat.Name)]
        internal static ClassificationTypeDefinition CommentType = null;
    }
}
