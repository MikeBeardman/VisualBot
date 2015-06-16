
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Text.Classification;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Text;

namespace VisualBot.Classifiers
{
    /// <summary>
    /// Create a classifier that finds spans using RegEx
    /// </summary>
    internal abstract class RegexBasedClassifier : IClassifier
    {
        /// <summary>
        /// The classification registry
        /// </summary>
        private readonly IClassificationTypeRegistryService _classificationRegistry;

        /// <summary>
        /// The classification changed event handler
        /// </summary>
        public event System.EventHandler<ClassificationChangedEventArgs> ClassificationChanged;

        /// <summary>
        /// The formatter name
        /// </summary>
        public abstract string FormatterName { get; }

        /// <summary>
        /// RegExs from which to pull matches
        /// </summary>
        public abstract IEnumerable<Regex> Regexs { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegexBasedClassifier"/> class
        /// </summary>
        /// <param name="classificationRegistry">The classification registry</param>
        protected RegexBasedClassifier(IClassificationTypeRegistryService classificationRegistry)
        {
            _classificationRegistry = classificationRegistry;
        }

        /// <summary>
        /// Get classification spans
        /// </summary>
        /// <param name="span">The current span</param>
        /// <returns>Generic list of ClassificationSpan</returns>
        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            var startline = span.Start.GetContainingLine();
            var endline = (span.End - 1).GetContainingLine();
            var text = span.Snapshot.GetText(new SnapshotSpan(startline.Start, endline.End));

            return (from regex in Regexs
                    from match in regex.Matches(text).OfType<Match>()
                    select CreateSpan(span, match))
                   .ToList();
        }

        /// <summary>
        /// Create a span for a regex match
        /// </summary>
        /// <param name="span">The span to get the match from</param>
        /// <param name="match">The match to create the new span from</param>
        /// <returns>Matching classification span</returns>
        private ClassificationSpan CreateSpan(SnapshotSpan span, Capture match)
        {
            var snapshotSpan = new SnapshotSpan(span.Snapshot,
                                                span.Start.Position + match.Index,
                                                match.Length);
            return new ClassificationSpan(
                snapshotSpan,
                _classificationRegistry.GetClassificationType(FormatterName));
        }

    }
}
