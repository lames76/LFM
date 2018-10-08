namespace LFM.MainGame.Gestione
{
    partial class DisplayChar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayChar));
            this.charDisplayer1 = new CharacterDiplaySelector.CharDisplayer();
            this.SuspendLayout();
            // 
            // charDisplayer1
            // 
            this.charDisplayer1.AC = DbRuler.AgeClass.NoValue;
            this.charDisplayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.charDisplayer1.Gener = null;
            this.charDisplayer1.IsAgingOn = false;
            this.charDisplayer1.IsMovie = false;
            this.charDisplayer1.Location = new System.Drawing.Point(0, 0);
            this.charDisplayer1.MyMovie = null;
            this.charDisplayer1.MySerial = null;
            this.charDisplayer1.Name = "charDisplayer1";
            this.charDisplayer1.Price = ((long)(0));
            this.charDisplayer1.Size = new System.Drawing.Size(295, 598);
            this.charDisplayer1.TabIndex = 0;
            this.charDisplayer1.Year = 0;
            // 
            // DisplayChar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 598);
            this.Controls.Add(this.charDisplayer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DisplayChar";
            this.Text = "DisplayChar";
            this.Load += new System.EventHandler(this.DisplayChar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CharacterDiplaySelector.CharDisplayer charDisplayer1;
    }
}