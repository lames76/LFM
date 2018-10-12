namespace CharacterDiplaySelector
{
    partial class MovieInfo
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lstControls = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTitle.Location = new System.Drawing.Point(0, 0);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(450, 48);
            this.txtTitle.TabIndex = 42;
            // 
            // lstControls
            // 
            this.lstControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstControls.Location = new System.Drawing.Point(0, 48);
            this.lstControls.Name = "lstControls";
            this.lstControls.Size = new System.Drawing.Size(450, 227);
            this.lstControls.TabIndex = 43;
            // 
            // MovieInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstControls);
            this.Controls.Add(this.txtTitle);
            this.Name = "MovieInfo";
            this.Size = new System.Drawing.Size(450, 275);
            this.Load += new System.EventHandler(this.MovieInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.FlowLayoutPanel lstControls;
    }
}
