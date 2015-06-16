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
    [ClassificationType(ClassificationTypeNames = "Comment")]
    [Name(Name)]
    [UserVisible(true)]
    [Order(Before = VariableFormat.Name)]
    internal sealed class CommentFormat : ClassificationFormatDefinition
    {
        public const string Name = "CommentFormat";

        /// <summary>
        /// Defines the visual format for the "VisualBot" classification type
        /// </summary>
        public CommentFormat()
        {
            DisplayName = Name;
            ForegroundColor = Colors.ForestGreen;

        }
    }

    #endregion
}
