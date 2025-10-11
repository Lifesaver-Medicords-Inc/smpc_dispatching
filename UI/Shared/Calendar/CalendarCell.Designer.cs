namespace smpc_dispatching.UI.Shared.Calendar {
    partial class CalendarCell {
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
            this.labelDay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelDay
            // 
            this.labelDay.AutoSize = true;
            this.labelDay.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDay.Location = new System.Drawing.Point(13, 10);
            this.labelDay.Name = "labelDay";
            this.labelDay.Padding = new System.Windows.Forms.Padding(4);
            this.labelDay.Size = new System.Drawing.Size(27, 28);
            this.labelDay.TabIndex = 0;
            this.labelDay.Text = "0";
            // 
            // CalendarCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelDay);
            this.Name = "CalendarCell";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(195, 179);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDay;
    }
}
