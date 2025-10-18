namespace smpc_dispatching.UI.Shared.Calendar {
    partial class EventCalendarUserControl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.CalendarHarness = new WindowsFormsCalendar.Calendar();
            this.SuspendLayout();
            // 
            // CalendarHarness
            // 
            this.CalendarHarness.AllowItemEdit = false;
            this.CalendarHarness.AllowNew = false;
            this.CalendarHarness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CalendarHarness.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CalendarHarness.ItemsBackgroundColor = System.Drawing.Color.AliceBlue;
            this.CalendarHarness.ItemsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CalendarHarness.ItemsForeColor = System.Drawing.Color.Black;
            this.CalendarHarness.Location = new System.Drawing.Point(10, 10);
            this.CalendarHarness.Name = "CalendarHarness";
            this.CalendarHarness.Scrollbars = WindowsFormsCalendar.CalendarScrollBars.Both;
            this.CalendarHarness.Size = new System.Drawing.Size(960, 507);
            this.CalendarHarness.TabIndex = 0;
            this.CalendarHarness.Text = "Calendar";
            // 
            // EventCalendarUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.CalendarHarness);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "EventCalendarUserControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(980, 527);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsFormsCalendar.Calendar CalendarHarness;
    }
}
