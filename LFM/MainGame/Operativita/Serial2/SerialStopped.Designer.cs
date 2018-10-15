namespace LFM.MainGame.Operativita.Serial2
{
    partial class SerialStopped
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerialStopped));
            this.dgSerials = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgSerials)).BeginInit();
            this.SuspendLayout();
            // 
            // dgSerials
            // 
            this.dgSerials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSerials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSerials.Location = new System.Drawing.Point(0, 0);
            this.dgSerials.Name = "dgSerials";
            this.dgSerials.RowTemplate.Height = 24;
            this.dgSerials.Size = new System.Drawing.Size(800, 450);
            this.dgSerials.TabIndex = 0;
            this.dgSerials.DoubleClick += new System.EventHandler(this.dgSerials_DoubleClick);
            // 
            // SerialStopped
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgSerials);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SerialStopped";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SerialStopped";
            this.Load += new System.EventHandler(this.SerialStopped_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSerials)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgSerials;
    }
}