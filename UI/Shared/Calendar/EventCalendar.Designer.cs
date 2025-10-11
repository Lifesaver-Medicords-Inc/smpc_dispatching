namespace smpc_dispatching.UI.Shared.Calendar {
    partial class EventCalendar {
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
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.HeaderTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CalendarTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainer
            // 
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitContainer.Location = new System.Drawing.Point(10, 10);
            this.SplitContainer.Name = "SplitContainer";
            this.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.HeaderTableLayoutPanel);
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.CalendarTableLayoutPanel);
            this.SplitContainer.Size = new System.Drawing.Size(960, 507);
            this.SplitContainer.SplitterDistance = 44;
            this.SplitContainer.TabIndex = 0;
            // 
            // HeaderTableLayoutPanel
            // 
            this.HeaderTableLayoutPanel.ColumnCount = 1;
            this.HeaderTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.HeaderTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.HeaderTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeaderTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.HeaderTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderTableLayoutPanel.Name = "HeaderTableLayoutPanel";
            this.HeaderTableLayoutPanel.RowCount = 1;
            this.HeaderTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.HeaderTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.HeaderTableLayoutPanel.Size = new System.Drawing.Size(960, 44);
            this.HeaderTableLayoutPanel.TabIndex = 0;
            // 
            // CalendarTableLayoutPanel
            // 
            this.CalendarTableLayoutPanel.AutoScroll = true;
            this.CalendarTableLayoutPanel.ColumnCount = 1;
            this.CalendarTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CalendarTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CalendarTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CalendarTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.CalendarTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.CalendarTableLayoutPanel.Name = "CalendarTableLayoutPanel";
            this.CalendarTableLayoutPanel.RowCount = 1;
            this.CalendarTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CalendarTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CalendarTableLayoutPanel.Size = new System.Drawing.Size(960, 459);
            this.CalendarTableLayoutPanel.TabIndex = 0;
            // 
            // EventCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.SplitContainer);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "EventCalendar";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(980, 527);
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.TableLayoutPanel HeaderTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel CalendarTableLayoutPanel;
    }
}
