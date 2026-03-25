using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Services
{
    public abstract class BasePrintableDocument
    {
        protected Font HeaderFont { get; } = new Font("Arial", 14, FontStyle.Bold);
        protected Font SubHeaderFont { get; } = new Font("Arial", 10, FontStyle.Regular);
        protected Font BodyFont { get; } = new Font("Arial", 9);
        protected Font FooterFont { get; } = new Font("Arial", 9, FontStyle.Italic);

        public abstract string Title { get; }

        public virtual void BeginPrint() { }

        public abstract bool RenderPage(Graphics graphics, Rectangle marginBounds, int pageNumber);

        public virtual void EndPrint() { }
    }
}
