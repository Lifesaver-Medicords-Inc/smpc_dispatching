namespace smpc_dispatching.UI.Shared {
    partial class MapLocPinForm {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.MapControl = new GMap.NET.WindowsForms.GMapControl();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MapControl
            // 
            this.MapControl.Bearing = 0F;
            this.MapControl.CanDragMap = true;
            this.MapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.MapControl.GrayScaleMode = false;
            this.MapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MapControl.LevelsKeepInMemory = 5;
            this.MapControl.Location = new System.Drawing.Point(0, 0);
            this.MapControl.MarkersEnabled = true;
            this.MapControl.MaxZoom = 2;
            this.MapControl.MinZoom = 2;
            this.MapControl.MouseWheelZoomEnabled = true;
            this.MapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MapControl.Name = "MapControl";
            this.MapControl.NegativeMode = false;
            this.MapControl.PolygonsEnabled = true;
            this.MapControl.RetryLoadTile = 0;
            this.MapControl.RoutesEnabled = true;
            this.MapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.MapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MapControl.ShowTileGridLines = false;
            this.MapControl.Size = new System.Drawing.Size(1119, 670);
            this.MapControl.TabIndex = 0;
            this.MapControl.Zoom = 0D;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.ConfirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ConfirmButton.Location = new System.Drawing.Point(995, 623);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ConfirmButton.Size = new System.Drawing.Size(112, 35);
            this.ConfirmButton.TabIndex = 1;
            this.ConfirmButton.Text = "CONFIRM";
            this.ConfirmButton.UseVisualStyleBackColor = false;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // MapLocPinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 670);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.MapControl);
            this.Name = "MapLocPinForm";
            this.Text = "MapLocPinForm";
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl MapControl;
        private System.Windows.Forms.Button ConfirmButton;
    }
}