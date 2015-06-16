using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace VisualBot.Classifiers
{
    #region Format definition

    /// <summary>
    /// Defines an editor format for the VisualBot type that has a purple background
    /// and is underlined.
    /// </summary>
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "String")]
    [Name(Name)]
    [UserVisible(true)]
    [Order(Before = VariableFormat.Name)]
    internal sealed class StringFormat : ClassificationFormatDefinition
    {
        public const string Name = "StringFormat";

        /// <summary>
        /// Defines the visual format for the "VisualBot" classification type
        /// </summary>
        public StringFormat()
        {
            DisplayName = Name;
            ForegroundColor = Colors.Yellow;

        }
    }

    #endregion
}
