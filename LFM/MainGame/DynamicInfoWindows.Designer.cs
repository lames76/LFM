namespace LFM.MainGame
{
    partial class DynamicInfoWindows
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DynamicInfoWindows));
            this.txtTesto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtTesto
            // 
            this.txtTesto.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTesto.Location = new System.Drawing.Point(0, 0);
            this.txtTesto.Multiline = true;
            this.txtTesto.Name = "txtTesto";
            this.txtTesto.ReadOnly = true;
            this.txtTesto.Size = new System.Drawing.Size(800, 48);
            this.txtTesto.TabIndex = 43;
            // 
            // DynamicInfoWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtTesto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DynamicInfoWindows";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Info";
            this.Load += new System.EventHandler(this.DynamicInfoWindows_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtTesto;
    }
}