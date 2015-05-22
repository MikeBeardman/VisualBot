using System.ComponentModel.Composition;
using System.Windows;
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
    [Name(Name)]
    [UserVisible(true)]
    [Order(Before = Priority.Default)]
    internal sealed class VariableFormat : ClassificationFormatDefinition
    {
        public const string Name = "VariableFormat";

        /// <summary>
        /// Defines the visual format for the "VisualBot" classification type
        /// </summary>
        public VariableFormat()
        {
            DisplayName = Name;
            ForegroundColor = Colors.BlueViolet;
            
        }
    }

    #endregion
}
