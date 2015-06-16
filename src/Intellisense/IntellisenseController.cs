using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Language.Intellisense;

namespace VisualBot.Intellisense
{
    public class IntellisenseController : IIntellisenseController
    {
        private ControllerProvider controllerProvider;
        private Microsoft.VisualStudio.Text.ITextBuffer textBuffer;

        public IntellisenseController(ControllerProvider controllerProvider, Microsoft.VisualStudio.Text.ITextBuffer textBuffer)
        {
            // TODO: Complete member initialization
            this.controllerProvider = controllerProvider;
            this.textBuffer = textBuffer;
        }

        public void ConnectSubjectBuffer(Microsoft.VisualStudio.Text.ITextBuffer subjectBuffer)
        {
            throw new NotImplementedException();
        }

        public void Detach(Microsoft.VisualStudio.Text.Editor.ITextView textView)
        {
            throw new NotImplementedException();
        }

        public void DisconnectSubjectBuffer(Microsoft.VisualStudio.Text.ITextBuffer subjectBuffer)
        {
            throw new NotImplementedException();
        }
    }
}
