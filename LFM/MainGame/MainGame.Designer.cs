namespace LFM.MainGame
{
    partial class MainGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGame));
            this.btnOperatività = new System.Windows.Forms.Button();
            this.btnGestione = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOperatività
            // 
            this.btnOperatività.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOperatività.Location = new System.Drawing.Point(12, 12);
            this.btnOperatività.Name = "btnOperatività";
            this.btnOperatività.Size = new System.Drawing.Size(200, 100);
            this.btnOperatività.TabIndex = 0;
            this.btnOperatività.Text = "Operatività";
            this.btnOperatività.UseVisualStyleBackColor = true;
            this.btnOperatività.Click += new System.EventHandler(this.btnOperatività_Click);
            // 
            // btnGestione
            // 
            this.btnGestione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGestione.Location = new System.Drawing.Point(12, 118);
            this.btnGestione.Name = "btnGestione";
            this.btnGestione.Size = new System.Drawing.Size(200, 100);
            this.btnGestione.TabIndex = 1;
            this.btnGestione.Text = "Gestione";
            this.btnGestione.UseVisualStyleBackColor = true;
            this.btnGestione.Click += new System.EventHandler(this.btnGestione_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Location = new System.Drawing.Point(12, 224);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(200, 100);
            this.btnReport.TabIndex = 2;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // MainGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 338);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnGestione);
            this.Controls.Add(this.btnOperatività);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainGame";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOperatività;
        private System.Windows.Forms.Button btnGestione;
        private System.Windows.Forms.Button btnReport;
    }
}