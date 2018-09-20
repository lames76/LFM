namespace LFM
{
    partial class UniverseManager
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
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblCounter = new System.Windows.Forms.Label();
            this.dgUniverses = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgUniverses)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Location = new System.Drawing.Point(468, 9);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(31, 25);
            this.btnClearFilter.TabIndex = 56;
            this.btnClearFilter.Text = "x";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(786, 13);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(106, 25);
            this.btnFilter.TabIndex = 55;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(505, 12);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(263, 22);
            this.txtFilter.TabIndex = 54;
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Location = new System.Drawing.Point(11, 17);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(46, 17);
            this.lblCounter.TabIndex = 53;
            this.lblCounter.Text = "label1";
            // 
            // dgUniverses
            // 
            this.dgUniverses.AllowUserToAddRows = false;
            this.dgUniverses.AllowUserToDeleteRows = false;
            this.dgUniverses.AllowUserToOrderColumns = true;
            this.dgUniverses.AllowUserToResizeColumns = false;
            this.dgUniverses.AllowUserToResizeRows = false;
            this.dgUniverses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgUniverses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUniverses.Location = new System.Drawing.Point(14, 44);
            this.dgUniverses.Name = "dgUniverses";
            this.dgUniverses.RowTemplate.Height = 24;
            this.dgUniverses.Size = new System.Drawing.Size(880, 332);
            this.dgUniverses.TabIndex = 52;
            this.dgUniverses.DoubleClick += new System.EventHandler(this.dgUniverses_DoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(213, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(106, 25);
            this.btnAdd.TabIndex = 57;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // UniverseManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 385);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClearFilter);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.dgUniverses);
            this.Name = "UniverseManager";
            this.Text = "Universe_Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UniverseManager_FormClosing);
            this.Load += new System.EventHandler(this.Universe_Manager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgUniverses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.DataGridView dgUniverses;
        private System.Windows.Forms.Button btnAdd;
    }
}