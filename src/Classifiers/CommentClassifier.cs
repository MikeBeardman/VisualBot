using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace VisualBot.Classifiers
{
    #region Provider definition
    /// <summary>
    /// This class causes a classifier to be added to the set of classifiers. Since 
    /// the content type is set to "text", this classifier applies to all text files
    /// </summary>
    [Export(typeof(IClassifierProvider))]
    [ContentType("text")]
    internal class CommentProvider : IClassifierProvider
    {
        /// <summary>
        /// Import the classification registry to be used for getting a reference
        /// to the custom classification type later.
        /// </summary>
        [Import]
        internal IClassificationTypeRegistryService ClassificationRegistry = null; // Set via MEF

        public IClassifier GetClassifier(ITextBuffer buffer)
        {
            return buffer.Properties.GetOrCreateSingletonProperty(() => new CommentClassifier(ClassificationRegistry));
        }
    }
    #endregion //provider def

    #region Classifier
    /// <summary>
    /// Classifier that classifies all text as an instance of the OrinaryClassifierType
    /// </summary>
    internal class CommentClassifier : RegexBasedClassifier
    {
        public CommentClassifier(IClassificationTypeRegistryService classificationRegistry)
            : base(classificationRegistry) { }

        public override string FormatterName
        {
            get { return CommentFormat.Name; }
        }

        public override IEnumerable<Regex> Regexs
        {
            get { yield return new Regex(@"\*\*\*(?:(?!\*\*\*).)*\*\*\*"); }
        }
    }
    #endregion //Classifier
}
