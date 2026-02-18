using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class SmoothScrollUserControl : UserControl
{
    public SmoothScrollUserControl()
    {
        if (IsInDesignMode()) return;

        AutoScroll = true;

        // Subscribe to events safely at runtime only
        ControlAdded += SmoothScrollUserControl_ControlAdded;
        Load += SmoothScrollUserControl_Load;
    }

    private bool IsInDesignMode()
    {
        return LicenseManager.UsageMode == LicenseUsageMode.Designtime
               || DesignMode
               || (Site?.DesignMode ?? false);
    }

    private void SmoothScrollUserControl_Load(object sender, EventArgs e)
    {
        if (IsInDesignMode()) return;
        AttachEnterEventsRecursive(this);
    }

    private void SmoothScrollUserControl_ControlAdded(object sender, ControlEventArgs e)
    {
        if (IsInDesignMode()) return;
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
                -AutoScrollPosition.X,
                -AutoScrollPosition.Y,
                ClientSize.Width,
                ClientSize.Height);

            if (visible.Contains(activeControl.Bounds))
                return AutoScrollPosition;
        }

        return base.ScrollToControl(activeControl);
    }
}
