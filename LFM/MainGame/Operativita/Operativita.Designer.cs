﻿namespace LFM.MainGame.Operativita
{
    partial class Operativita
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Operativita));
            this.btnProduci = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProduci
            // 
            this.btnProduci.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProduci.Location = new System.Drawing.Point(24, 12);
            this.btnProduci.Name = "btnProduci";
            this.btnProduci.Size = new System.Drawing.Size(191, 100);
            this.btnProduci.TabIndex = 1;
            this.btnProduci.Text = "Produci";
            this.btnProduci.UseVisualStyleBackColor = true;
            this.btnProduci.Click += new System.EventHandler(this.btnProduceFilm_Click);
            // 
            // Operativita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 235);
            this.Controls.Add(this.btnProduci);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Operativita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Operativita";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProduci;
    }
}