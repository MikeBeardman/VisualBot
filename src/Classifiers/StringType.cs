using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace VisualBot.Classifiers
{
    internal static class StringClassificationDefinition
    {
        /// <summary>
        /// Defines the "VisualBot" classification type.
        /// </summary>
        [Export(typeof(ClassificationTypeDefinition))]
        [Name(StringFormat.Name)]
        internal static ClassificationTypeDefinition StringType = null;
    }
}
