namespace LFM.MainGame.Report
{
    partial class Report
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
            this.btnReportMovie = new System.Windows.Forms.Button();
            this.btnFinance = new System.Windows.Forms.Button();
            this.bntRapportiConAttori = new System.Windows.Forms.Button();
            this.btnRapportiConRegisti = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReportMovie
            // 
            this.btnReportMovie.Location = new System.Drawing.Point(195, 12);
            this.btnReportMovie.Name = "btnReportMovie";
            this.btnReportMovie.Size = new System.Drawing.Size(177, 87);
            this.btnReportMovie.TabIndex = 0;
            this.btnReportMovie.Text = "Report Movie";
            this.btnReportMovie.UseVisualStyleBackColor = true;
            this.btnReportMovie.Click += new System.EventHandler(this.btnReportMovie_Click);
            // 
            // btnFinance
            // 
            this.btnFinance.Location = new System.Drawing.Point(12, 12);
            this.btnFinance.Name = "btnFinance";
            this.btnFinance.Size = new System.Drawing.Size(177, 87);
            this.btnFinance.TabIndex = 1;
            this.btnFinance.Text = "Finanze";
            this.btnFinance.UseVisualStyleBackColor = true;
            this.btnFinance.Click += new System.EventHandler(this.btnFinance_Click);
            // 
            // bntRapportiConAttori
            // 
            this.bntRapportiConAttori.Location = new System.Drawing.Point(12, 105);
            this.bntRapportiConAttori.Name = "bntRapportiConAttori";
            this.bntRapportiConAttori.Size = new System.Drawing.Size(177, 87);
            this.bntRapportiConAttori.TabIndex = 2;
            this.bntRapportiConAttori.Text = "Rapporti Attori";
            this.bntRapportiConAttori.UseVisualStyleBackColor = true;
            this.bntRapportiConAttori.Click += new System.EventHandler(this.bntRapportiConAttori_Click);
            // 
            // btnRapportiConRegisti
            // 
            this.btnRapportiConRegisti.Location = new System.Drawing.Point(12, 198);
            this.btnRapportiConRegisti.Name = "btnRapportiConRegisti";
            this.btnRapportiConRegisti.Size = new System.Drawing.Size(177, 87);
            this.btnRapportiConRegisti.TabIndex = 3;
            this.btnRapportiConRegisti.Text = "Rapporti Registi";
            this.btnRapportiConRegisti.UseVisualStyleBackColor = true;
            this.btnRapportiConRegisti.Click += new System.EventHandler(this.btnRapportiConRegisti_Click);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRapportiConRegisti);
            this.Controls.Add(this.bntRapportiConAttori);
            this.Controls.Add(this.btnFinance);
            this.Controls.Add(this.btnReportMovie);
            this.Name = "Report";
            this.Text = "Report";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReportMovie;
        private System.Windows.Forms.Button btnFinance;
        private System.Windows.Forms.Button bntRapportiConAttori;
        private System.Windows.Forms.Button btnRapportiConRegisti;
    }
}