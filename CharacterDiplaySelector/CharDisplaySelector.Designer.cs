namespace CharacterDiplaySelector
{
    partial class CharDisplaySelector
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.charDisplayer1 = new CharacterDiplaySelector.CharDisplayer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.ddlActorOrOthers = new System.Windows.Forms.ComboBox();
            this.ddlSexFilter = new System.Windows.Forms.ComboBox();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblCounter = new System.Windows.Forms.Label();
            this.dgChars = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgChars)).BeginInit();
            this.SuspendLayout();
            // 
            // charDisplayer1
            // 
            this.charDisplayer1.AC = DbRuler.AgeClass.NoValue;
            this.charDisplayer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.charDisplayer1.Gener = null;
            this.charDisplayer1.IsAgingOn = false;
            this.charDisplayer1.IsMovie = false;
            this.charDisplayer1.Location = new System.Drawing.Point(3, 18);
            this.charDisplayer1.MyMovie = null;
            this.charDisplayer1.MySerial = null;
            this.charDisplayer1.Name = "charDisplayer1";
            this.charDisplayer1.Price = ((long)(0));
            this.charDisplayer1.Size = new System.Drawing.Size(297, 606);
            this.charDisplayer1.TabIndex = 0;
            this.charDisplayer1.Year = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.charDisplayer1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 685);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(10, 639);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(108, 33);
            this.btnClear.TabIndex = 71;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(188, 639);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(101, 33);
            this.btnSelect.TabIndex = 70;
            this.btnSelect.Text = "Seleziona";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.ddlActorOrOthers);
            this.groupBox8.Controls.Add(this.ddlSexFilter);
            this.groupBox8.Controls.Add(this.btnClearFilter);
            this.groupBox8.Controls.Add(this.btnFilter);
            this.groupBox8.Controls.Add(this.txtFilter);
            this.groupBox8.Controls.Add(this.lblCounter);
            this.groupBox8.Controls.Add(this.dgChars);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox8.Location = new System.Drawing.Point(303, 0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(723, 398);
            this.groupBox8.TabIndex = 67;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "groupBox1";
            // 
            // ddlActorOrOthers
            // 
            this.ddlActorOrOthers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlActorOrOthers.FormattingEnabled = true;
            this.ddlActorOrOthers.Items.AddRange(new object[] {
            "Actors",
            "Sports",
            "Singer"});
            this.ddlActorOrOthers.Location = new System.Drawing.Point(142, 27);
            this.ddlActorOrOthers.Name = "ddlActorOrOthers";
            this.ddlActorOrOthers.Size = new System.Drawing.Size(106, 24);
            this.ddlActorOrOthers.TabIndex = 66;
            this.ddlActorOrOthers.SelectedIndexChanged += new System.EventHandler(this.ddlActorOrOthers_SelectedIndexChanged);
            // 
            // ddlSexFilter
            // 
            this.ddlSexFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSexFilter.FormattingEnabled = true;
            this.ddlSexFilter.Items.AddRange(new object[] {
            "M",
            "F"});
            this.ddlSexFilter.Location = new System.Drawing.Point(254, 27);
            this.ddlSexFilter.Name = "ddlSexFilter";
            this.ddlSexFilter.Size = new System.Drawing.Size(67, 24);
            this.ddlSexFilter.TabIndex = 65;
            this.ddlSexFilter.SelectedIndexChanged += new System.EventHandler(this.ddlSexFilter_SelectedIndexChanged);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Location = new System.Drawing.Point(684, 28);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(27, 25);
            this.btnClearFilter.TabIndex = 62;
            this.btnClearFilter.Text = "x";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(592, 28);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(102, 25);
            this.btnFilter.TabIndex = 61;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(327, 29);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(259, 22);
            this.txtFilter.TabIndex = 60;
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Location = new System.Drawing.Point(12, 24);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(46, 17);
            this.lblCounter.TabIndex = 59;
            this.lblCounter.Text = "label1";
            // 
            // dgChars
            // 
            this.dgChars.AllowUserToAddRows = false;
            this.dgChars.AllowUserToDeleteRows = false;
            this.dgChars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgChars.Location = new System.Drawing.Point(15, 59);
            this.dgChars.Name = "dgChars";
            this.dgChars.RowTemplate.Height = 24;
            this.dgChars.Size = new System.Drawing.Size(696, 313);
            this.dgChars.TabIndex = 58;
            this.dgChars.DoubleClick += new System.EventHandler(this.dgChars_DoubleClick);
            // 
            // CharDisplaySelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox1);
            this.Name = "CharDisplaySelector";
            this.Size = new System.Drawing.Size(1026, 685);
            this.groupBox1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgChars)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CharDisplayer charDisplayer1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Button btnSelect;
        public System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ComboBox ddlActorOrOthers;
        private System.Windows.Forms.ComboBox ddlSexFilter;
        public System.Windows.Forms.Button btnClearFilter;
        public System.Windows.Forms.Button btnFilter;
        public System.Windows.Forms.TextBox txtFilter;
        public System.Windows.Forms.Label lblCounter;
        public System.Windows.Forms.DataGridView dgChars;
    }
}
