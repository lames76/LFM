namespace LFM.MainGame.Report
{
    partial class FormCharAffinity
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCharAffinity));
            this.lstChars = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstChars
            // 
            this.lstChars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstChars.FormattingEnabled = true;
            this.lstChars.ItemHeight = 16;
            this.lstChars.Location = new System.Drawing.Point(0, 0);
            this.lstChars.Name = "lstChars";
            this.lstChars.Size = new System.Drawing.Size(800, 450);
            this.lstChars.TabIndex = 0;
            this.lstChars.DoubleClick += new System.EventHandler(this.lstChars_DoubleClick);
            // 
            // FormCharAffinity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstChars);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCharAffinity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Affinity";
            this.Load += new System.EventHandler(this.FormCharAffinity_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstChars;
    }
}