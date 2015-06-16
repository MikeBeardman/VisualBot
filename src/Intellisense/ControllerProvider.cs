using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;

namespace VisualBot.Intellisense
{
    [Export(typeof(IIntellisenseControllerProvider))]
    [Name(" Test Controller Provider")]
    [Order(Before = "default")]
    [ContentType("text")]
    public class ControllerProvider : IIntellisenseControllerProvider
    {
        private ITextBuffer textBuffer;
        private List<Completion> completionsList;

        public IIntellisenseController TryCreateIntellisenseController(ITextView textView, IList<ITextBuffer> subjectBuffers)
        {
            return new IntellisenseController(this, textBuffer);
        }
    }
}