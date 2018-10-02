namespace LFM
{
    partial class FormReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReport));
            this.dgReport = new System.Windows.Forms.DataGridView();
            this.A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dgReport
            // 
            this.dgReport.AllowUserToAddRows = false;
            this.dgReport.AllowUserToDeleteRows = false;
            this.dgReport.AllowUserToOrderColumns = true;
            this.dgReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgReport.ColumnHeadersVisible = false;
            this.dgReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.A,
            this.B,
            this.C,
            this.D,
            this.E,
            this.F});
            this.dgReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgReport.Location = new System.Drawing.Point(0, 0);
            this.dgReport.Name = "dgReport";
            this.dgReport.ReadOnly = true;
            this.dgReport.RowTemplate.Height = 24;
            this.dgReport.Size = new System.Drawing.Size(800, 450);
            this.dgReport.TabIndex = 0;
            // 
            // A
            // 
            this.A.DataPropertyName = "A";
            this.A.HeaderText = "A";
            this.A.Name = "A";
            this.A.ReadOnly = true;
            // 
            // B
            // 
            this.B.DataPropertyName = "B";
            this.B.HeaderText = "B";
            this.B.Name = "B";
            this.B.ReadOnly = true;
            // 
            // C
            // 
            this.C.DataPropertyName = "C";
            this.C.HeaderText = "C";
            this.C.Name = "C";
            this.C.ReadOnly = true;
            // 
            // D
            // 
            this.D.DataPropertyName = "D";
            this.D.HeaderText = "D";
            this.D.Name = "D";
            this.D.ReadOnly = true;
            // 
            // E
            // 
            this.E.DataPropertyName = "E";
            this.E.HeaderText = "E";
            this.E.Name = "E";
            this.E.ReadOnly = true;
            // 
            // F
            // 
            this.F.DataPropertyName = "F";
            this.F.HeaderText = "F";
            this.F.Name = "F";
            this.F.ReadOnly = true;
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormReport";
            this.Text = "FormReport";
            this.Load += new System.EventHandler(this.FormReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn A;
        private System.Windows.Forms.DataGridViewTextBoxColumn B;
        private System.Windows.Forms.DataGridViewTextBoxColumn C;
        private System.Windows.Forms.DataGridViewTextBoxColumn D;
        private System.Windows.Forms.DataGridViewTextBoxColumn E;
        private System.Windows.Forms.DataGridViewTextBoxColumn F;
    }
}