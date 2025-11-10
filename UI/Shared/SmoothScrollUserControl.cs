using System;
using System.Drawing;
using System.Windows.Forms;

public class SmoothScrollUserControl : UserControl {
    public SmoothScrollUserControl() {
        this.AutoScroll = true;
        this.ControlAdded += SmoothScrollUserControl_ControlAdded;
        this.Load += SmoothScrollUserControl_Load;
    }

    // Attach Enter event to all children on load
    private void SmoothScrollUserControl_Load(object sender, EventArgs e) {
        AttachEnterEventsRecursive(this);
    }

    // Attach events dynamically when controls are added
    private void SmoothScrollUserControl_ControlAdded(object sender, ControlEventArgs e) {
        AttachEnterEventsRecursive(e.Control);
    }

    // Recursively attach Enter events to all child controls
    private void AttachEnterEventsRecursive(Control ctrl) {
        ctrl.Enter += Child_Enter;

        foreach (Control child in ctrl.Controls) {
            AttachEnterEventsRecursive(child);
        }
    }

    // Restore scroll position whenever a child gains focus
    private void Child_Enter(object sender, EventArgs e) {
        Point scrollPos = this.AutoScrollPosition;

        // Use BeginInvoke to restore scroll after the focus event finishes
        this.BeginInvoke(new Action(() => {
            this.AutoScrollPosition = new Point(-scrollPos.X, -scrollPos.Y);
        }));
    }
}
