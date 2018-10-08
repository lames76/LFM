namespace LFM.MainGame.Gestione
{
    partial class Gestione
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
            this.btnMoviesInProduction = new System.Windows.Forms.Button();
            this.btnSerialsInProduction = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMoviesInProduction
            // 
            this.btnMoviesInProduction.Location = new System.Drawing.Point(12, 12);
            this.btnMoviesInProduction.Name = "btnMoviesInProduction";
            this.btnMoviesInProduction.Size = new System.Drawing.Size(165, 101);
            this.btnMoviesInProduction.TabIndex = 0;
            this.btnMoviesInProduction.Text = "Film in Produzione";
            this.btnMoviesInProduction.UseVisualStyleBackColor = true;
            this.btnMoviesInProduction.Click += new System.EventHandler(this.btnMoviesInProduction_Click);
            // 
            // btnSerialsInProduction
            // 
            this.btnSerialsInProduction.Location = new System.Drawing.Point(12, 119);
            this.btnSerialsInProduction.Name = "btnSerialsInProduction";
            this.btnSerialsInProduction.Size = new System.Drawing.Size(165, 101);
            this.btnSerialsInProduction.TabIndex = 1;
            this.btnSerialsInProduction.Text = "Serial in Produzione";
            this.btnSerialsInProduction.UseVisualStyleBackColor = true;
            this.btnSerialsInProduction.Click += new System.EventHandler(this.btnSerialsInProduction_Click);
            // 
            // Gestione
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSerialsInProduction);
            this.Controls.Add(this.btnMoviesInProduction);
            this.Name = "Gestione";
            this.Text = "Gestione";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMoviesInProduction;
        private System.Windows.Forms.Button btnSerialsInProduction;
    }
}