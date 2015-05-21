using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace VisualBot
{
    #region Format definition

    /// <summary>
    /// Defines an editor format for the VisualBot type that has a purple background
    /// and is underlined.
    /// </summary>
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "Variable")]
    [Name("Variable")]
    [UserVisible(true)] //this should be visible to the end user
    [Order(Before = Priority.Default)] //set the priority to be after the default classifiers
    internal sealed class VariableFormat : ClassificationFormatDefinition
    {
        /// <summary>
        /// Defines the visual format for the "VisualBot" classification type
        /// </summary>
        public VariableFormat()
        {
            DisplayName = "Variable"; //human readable version of the name
            BackgroundColor = Colors.BlueViolet;
            TextDecorations = System.Windows.TextDecorations.Underline;
        }
    }

    #endregion
}
