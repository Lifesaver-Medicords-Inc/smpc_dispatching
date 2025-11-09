namespace smpc_dispatching.UI.Shared.CalendarEvent {
    partial class CalendarScheduleControllerUserControl {
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
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.EventSplitContainer = new System.Windows.Forms.SplitContainer();
            this.CalendarSplitContainer = new System.Windows.Forms.SplitContainer();
            this.HeaderFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.CalendarTitleLabel = new System.Windows.Forms.Label();
            this.HeaderBtnsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.PrevBtn = new System.Windows.Forms.Button();
            this.DateLabel = new System.Windows.Forms.Label();
            this.NextBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CalendarSwitchViewBtn = new System.Windows.Forms.Button();
            this.ScheduleDetailsPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EventSplitContainer)).BeginInit();
            this.EventSplitContainer.Panel1.SuspendLayout();
            this.EventSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CalendarSplitContainer)).BeginInit();
            this.CalendarSplitContainer.Panel1.SuspendLayout();
            this.CalendarSplitContainer.SuspendLayout();
            this.HeaderFlowLayoutPanel.SuspendLayout();
            this.HeaderBtnsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.BackColor = System.Drawing.SystemColors.Control;
            this.MainSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.EventSplitContainer);
            this.MainSplitContainer.Panel1MinSize = 820;
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.MainSplitContainer.Panel2.Controls.Add(this.ScheduleDetailsPanel);
            this.MainSplitContainer.Panel2MinSize = 300;
            this.MainSplitContainer.Size = new System.Drawing.Size(1242, 946);
            this.MainSplitContainer.SplitterDistance = 846;
            this.MainSplitContainer.SplitterWidth = 2;
            this.MainSplitContainer.TabIndex = 0;
            // 
            // EventSplitContainer
            // 
            this.EventSplitContainer.BackColor = System.Drawing.SystemColors.Control;
            this.EventSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EventSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.EventSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.EventSplitContainer.Name = "EventSplitContainer";
            this.EventSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // EventSplitContainer.Panel1
            // 
            this.EventSplitContainer.Panel1.Controls.Add(this.CalendarSplitContainer);
            // 
            // EventSplitContainer.Panel2
            // 
            this.EventSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.EventSplitContainer.Size = new System.Drawing.Size(846, 946);
            this.EventSplitContainer.SplitterDistance = 677;
            this.EventSplitContainer.SplitterWidth = 1;
            this.EventSplitContainer.TabIndex = 0;
            // 
            // CalendarSplitContainer
            // 
            this.CalendarSplitContainer.BackColor = System.Drawing.SystemColors.Control;
            this.CalendarSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalendarSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CalendarSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.CalendarSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.CalendarSplitContainer.Name = "CalendarSplitContainer";
            this.CalendarSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // CalendarSplitContainer.Panel1
            // 
            this.CalendarSplitContainer.Panel1.Controls.Add(this.HeaderFlowLayoutPanel);
            this.CalendarSplitContainer.Panel1MinSize = 49;
            // 
            // CalendarSplitContainer.Panel2
            // 
            this.CalendarSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.CalendarSplitContainer.Size = new System.Drawing.Size(846, 677);
            this.CalendarSplitContainer.SplitterDistance = 61;
            this.CalendarSplitContainer.SplitterWidth = 1;
            this.CalendarSplitContainer.TabIndex = 0;
            // 
            // HeaderFlowLayoutPanel
            // 
            this.HeaderFlowLayoutPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.HeaderFlowLayoutPanel.Controls.Add(this.CalendarTitleLabel);
            this.HeaderFlowLayoutPanel.Controls.Add(this.HeaderBtnsPanel);
            this.HeaderFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeaderFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.HeaderFlowLayoutPanel.Name = "HeaderFlowLayoutPanel";
            this.HeaderFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(4);
            this.HeaderFlowLayoutPanel.Size = new System.Drawing.Size(844, 59);
            this.HeaderFlowLayoutPanel.TabIndex = 1;
            this.HeaderFlowLayoutPanel.WrapContents = false;
            // 
            // CalendarTitleLabel
            // 
            this.CalendarTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CalendarTitleLabel.AutoSize = true;
            this.CalendarTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CalendarTitleLabel.Location = new System.Drawing.Point(7, 19);
            this.CalendarTitleLabel.Margin = new System.Windows.Forms.Padding(3, 0, 50, 0);
            this.CalendarTitleLabel.Name = "CalendarTitleLabel";
            this.CalendarTitleLabel.Size = new System.Drawing.Size(138, 17);
            this.CalendarTitleLabel.TabIndex = 0;
            this.CalendarTitleLabel.Text = "CALENDAR TITLE";
            // 
            // HeaderBtnsPanel
            // 
            this.HeaderBtnsPanel.Controls.Add(this.PrevBtn);
            this.HeaderBtnsPanel.Controls.Add(this.DateLabel);
            this.HeaderBtnsPanel.Controls.Add(this.NextBtn);
            this.HeaderBtnsPanel.Controls.Add(this.label1);
            this.HeaderBtnsPanel.Controls.Add(this.CalendarSwitchViewBtn);
            this.HeaderBtnsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderBtnsPanel.Location = new System.Drawing.Point(198, 7);
            this.HeaderBtnsPanel.MinimumSize = new System.Drawing.Size(700, 0);
            this.HeaderBtnsPanel.Name = "HeaderBtnsPanel";
            this.HeaderBtnsPanel.Size = new System.Drawing.Size(800, 42);
            this.HeaderBtnsPanel.TabIndex = 1;
            this.HeaderBtnsPanel.WrapContents = false;
            // 
            // PrevBtn
            // 
            this.PrevBtn.Image = global::smpc_dispatching.Properties.Resources.icons8_previous_20;
            this.PrevBtn.Location = new System.Drawing.Point(3, 3);
            this.PrevBtn.Name = "PrevBtn";
            this.PrevBtn.Size = new System.Drawing.Size(80, 30);
            this.PrevBtn.TabIndex = 2;
            this.PrevBtn.UseVisualStyleBackColor = true;
            this.PrevBtn.Click += new System.EventHandler(this.PrevBtn_Click);
            // 
            // DateLabel
            // 
            this.DateLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DateLabel.AutoSize = true;
            this.DateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLabel.Location = new System.Drawing.Point(126, 9);
            this.DateLabel.Margin = new System.Windows.Forms.Padding(40, 0, 40, 0);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(49, 17);
            this.DateLabel.TabIndex = 1;
            this.DateLabel.Text = "DATE";
            // 
            // NextBtn
            // 
            this.NextBtn.BackgroundImage = global::smpc_dispatching.Properties.Resources.icons8_next_20;
            this.NextBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.NextBtn.Location = new System.Drawing.Point(218, 3);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(80, 30);
            this.NextBtn.TabIndex = 3;
            this.NextBtn.UseVisualStyleBackColor = true;
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(341, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(40, 0, 10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "VIEW:";
            // 
            // CalendarSwitchViewBtn
            // 
            this.CalendarSwitchViewBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CalendarSwitchViewBtn.Location = new System.Drawing.Point(400, 3);
            this.CalendarSwitchViewBtn.Name = "CalendarSwitchViewBtn";
            this.CalendarSwitchViewBtn.Size = new System.Drawing.Size(80, 30);
            this.CalendarSwitchViewBtn.TabIndex = 4;
            this.CalendarSwitchViewBtn.Text = "View";
            this.CalendarSwitchViewBtn.UseVisualStyleBackColor = true;
            this.CalendarSwitchViewBtn.Click += new System.EventHandler(this.CalendarSwitchViewBtn_Click);
            // 
            // ScheduleDetailsPanel
            // 
            this.ScheduleDetailsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ScheduleDetailsPanel.Location = new System.Drawing.Point(0, 0);
            this.ScheduleDetailsPanel.Name = "ScheduleDetailsPanel";
            this.ScheduleDetailsPanel.Size = new System.Drawing.Size(392, 664);
            this.ScheduleDetailsPanel.TabIndex = 0;
            // 
            // CalendarEventControllerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.MainSplitContainer);
            this.Name = "CalendarEventControllerUserControl";
            this.Size = new System.Drawing.Size(1242, 946);
            this.Load += new System.EventHandler(this.CalendarEventController_Load);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.EventSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EventSplitContainer)).EndInit();
            this.EventSplitContainer.ResumeLayout(false);
            this.CalendarSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CalendarSplitContainer)).EndInit();
            this.CalendarSplitContainer.ResumeLayout(false);
            this.HeaderFlowLayoutPanel.ResumeLayout(false);
            this.HeaderFlowLayoutPanel.PerformLayout();
            this.HeaderBtnsPanel.ResumeLayout(false);
            this.HeaderBtnsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.SplitContainer EventSplitContainer;
        private System.Windows.Forms.SplitContainer CalendarSplitContainer;
        private System.Windows.Forms.FlowLayoutPanel HeaderFlowLayoutPanel;
        private System.Windows.Forms.Label CalendarTitleLabel;
        private System.Windows.Forms.FlowLayoutPanel HeaderBtnsPanel;
        private System.Windows.Forms.Button PrevBtn;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.Panel ScheduleDetailsPanel;
        private System.Windows.Forms.Button CalendarSwitchViewBtn;
        private System.Windows.Forms.Label label1;
    }
}
