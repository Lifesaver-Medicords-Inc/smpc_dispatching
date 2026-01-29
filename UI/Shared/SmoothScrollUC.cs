using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class SmoothScrollUserControl : UserControl
{
    public SmoothScrollUserControl()
    {
        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            return;

        this.AutoScroll = true;

        // Subscribe to events safely at runtime only
        this.ControlAdded += SmoothScrollUserControl_ControlAdded;
        this.Load += SmoothScrollUserControl_Load;
    }

    private void SmoothScrollUserControl_Load(object sender, EventArgs e)
    {
        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
        AttachEnterEventsRecursive(this);
    }

    private void SmoothScrollUserControl_ControlAdded(object sender, ControlEventArgs e)
    {
        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
        AttachEnterEventsRecursive(e.Control);
    }

    private void AttachEnterEventsRecursive(Control parent)
    {
        foreach (Control ctrl in parent.Controls)
        {
            ctrl.Enter += (s, e) => ScrollControlIntoView((Control)s);
            if (ctrl.HasChildren)
                AttachEnterEventsRecursive(ctrl);
        }
    }

    protected override Point ScrollToControl(Control activeControl)
    {
        if (activeControl != null)
        {
            Rectangle visible = new Rectangle(
                -this.AutoScrollPosition.X,
                -this.AutoScrollPosition.Y,
                this.ClientSize.Width,
                this.ClientSize.Height);

            if (visible.Contains(activeControl.Bounds))
                return this.AutoScrollPosition;
        }

        return base.ScrollToControl(activeControl);
    }
}
