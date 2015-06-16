using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Language.Intellisense;

namespace VisualBot.Intellisense
{
    class QuickInfoSource : IQuickInfoSource
    {
        public void AugmentQuickInfoSession(IQuickInfoSession session, IList<object> quickInfoContent, out Microsoft.VisualStudio.Text.ITrackingSpan applicableToSpan)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
