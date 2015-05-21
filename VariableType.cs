using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace VisualBot
{
    internal static class VariableClassificationDefinition
    {
        /// <summary>
        /// Defines the "VisualBot" classification type.
        /// </summary>
        [Export(typeof(ClassificationTypeDefinition))]
        [Name("Variable")]
        internal static ClassificationTypeDefinition VariableType = null;
    }
}
