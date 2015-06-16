using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace VisualBot.Classifiers
{
    internal static class VariableClassificationDefinition
    {
        /// <summary>
        /// Defines the "VisualBot" classification type.
        /// </summary>
        [Export(typeof(ClassificationTypeDefinition))]
        [Name(VariableFormat.Name)]
        internal static ClassificationTypeDefinition VariableType = null;
    }
}
