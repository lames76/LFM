namespace LFM
{
    partial class TestMC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestMC));
            this.ddlType1 = new System.Windows.Forms.ComboBox();
            this.dgWriters = new System.Windows.Forms.DataGridView();
            this.btnSetType = new System.Windows.Forms.Button();
            this.lblType = new System.Windows.Forms.Label();
            this.lblWriter = new System.Windows.Forms.Label();
            this.btnGenScriptMovie = new System.Windows.Forms.Button();
            this.dgGenMovie = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.ddlType2 = new System.Windows.Forms.ComboBox();
            this.ddlType3 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgWriters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgGenMovie)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlType1
            // 
            this.ddlType1.FormattingEnabled = true;
            this.ddlType1.Location = new System.Drawing.Point(12, 12);
            this.ddlType1.Name = "ddlType1";
            this.ddlType1.Size = new System.Drawing.Size(93, 24);
            this.ddlType1.TabIndex = 2;
            // 
            // dgWriters
            // 
            this.dgWriters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWriters.Location = new System.Drawing.Point(275, 12);
            this.dgWriters.Name = "dgWriters";
            this.dgWriters.RowTemplate.Height = 24;
            this.dgWriters.Size = new System.Drawing.Size(513, 113);
            this.dgWriters.TabIndex = 3;
            this.dgWriters.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // btnSetType
            // 
            this.btnSetType.Location = new System.Drawing.Point(12, 51);
            this.btnSetType.Name = "btnSetType";
            this.btnSetType.Size = new System.Drawing.Size(56, 35);
            this.btnSetType.TabIndex = 4;
            this.btnSetType.Text = ">>";
            this.btnSetType.UseVisualStyleBackColor = true;
            this.btnSetType.Click += new System.EventHandler(this.btnSetType_Click);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(75, 68);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(46, 17);
            this.lblType.TabIndex = 5;
            this.lblType.Text = "label1";
            // 
            // lblWriter
            // 
            this.lblWriter.AutoSize = true;
            this.lblWriter.Location = new System.Drawing.Point(78, 107);
            this.lblWriter.Name = "lblWriter";
            this.lblWriter.Size = new System.Drawing.Size(46, 17);
            this.lblWriter.TabIndex = 6;
            this.lblWriter.Text = "label1";
            // 
            // btnGenScriptMovie
            // 
            this.btnGenScriptMovie.Location = new System.Drawing.Point(22, 152);
            this.btnGenScriptMovie.Name = "btnGenScriptMovie";
            this.btnGenScriptMovie.Size = new System.Drawing.Size(154, 33);
            this.btnGenScriptMovie.TabIndex = 7;
            this.btnGenScriptMovie.Text = "Gen Script";
            this.btnGenScriptMovie.UseVisualStyleBackColor = true;
            this.btnGenScriptMovie.Click += new System.EventHandler(this.btnGenScriptMovie_Click);
            // 
            // dgGenMovie
            // 
            this.dgGenMovie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGenMovie.Location = new System.Drawing.Point(22, 202);
            this.dgGenMovie.Name = "dgGenMovie";
            this.dgGenMovie.RowTemplate.Height = 24;
            this.dgGenMovie.Size = new System.Drawing.Size(766, 85);
            this.dgGenMovie.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Cost:";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(221, 166);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(46, 17);
            this.lblCost.TabIndex = 10;
            this.lblCost.Text = "label2";
            // 
            // ddlType2
            // 
            this.ddlType2.FormattingEnabled = true;
            this.ddlType2.Location = new System.Drawing.Point(111, 12);
            this.ddlType2.Name = "ddlType2";
            this.ddlType2.Size = new System.Drawing.Size(93, 24);
            this.ddlType2.TabIndex = 11;
            // 
            // ddlType3
            // 
            this.ddlType3.FormattingEnabled = true;
            this.ddlType3.Location = new System.Drawing.Point(162, 42);
            this.ddlType3.Name = "ddlType3";
            this.ddlType3.Size = new System.Drawing.Size(93, 24);
            this.ddlType3.TabIndex = 12;
            // 
            // TestMC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 742);
            this.Controls.Add(this.ddlType3);
            this.Controls.Add(this.ddlType2);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgGenMovie);
            this.Controls.Add(this.btnGenScriptMovie);
            this.Controls.Add(this.lblWriter);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnSetType);
            this.Controls.Add(this.dgWriters);
            this.Controls.Add(this.ddlType1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestMC";
            this.Text = "TestMC";
            this.Load += new System.EventHandler(this.TestMC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgWriters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgGenMovie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlType1;
        private System.Windows.Forms.DataGridView dgWriters;
        private System.Windows.Forms.Button btnSetType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblWriter;
        private System.Windows.Forms.Button btnGenScriptMovie;
        private System.Windows.Forms.DataGridView dgGenMovie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.ComboBox ddlType2;
        private System.Windows.Forms.ComboBox ddlType3;
    }
}