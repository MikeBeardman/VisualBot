
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Text.Classification;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Text;

namespace VisualBot.Classifiers
{
    internal abstract class RegexBasedClassifier : IClassifier
    {
        public event System.EventHandler<ClassificationChangedEventArgs> ClassificationChanged;

        public abstract string FormatterName { get; }

        public abstract IEnumerable<Regex> Regexs { get; }

        private readonly IClassificationTypeRegistryService _classificationRegistry;

        protected RegexBasedClassifier(IClassificationTypeRegistryService classificationRegistry)
        {
            _classificationRegistry = classificationRegistry;
        }

        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            //if (!span.IsInQueryTag()) return Enumerable.Empty<ClassificationSpan>().ToList();
            var startline = span.Start.GetContainingLine();
            var endline = (span.End - 1).GetContainingLine();
            var text = span.Snapshot.GetText(new SnapshotSpan(startline.Start, endline.End));

            return (from regex in Regexs
                    from match in regex.Matches(text).OfType<Match>()
                    select CreateSpan(span, match))
                   .ToList();
        }

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
