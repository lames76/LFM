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
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblCounter = new System.Windows.Forms.Label();
            this.dgChars = new System.Windows.Forms.DataGridView();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.lstSpecials = new System.Windows.Forms.ListView();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblHumor = new System.Windows.Forms.Label();
            this.lblSexappeal = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txtImDb_Link = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtPopularity = new System.Windows.Forms.TextBox();
            this.ddlSex = new System.Windows.Forms.ComboBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.ddlActorOrOthers = new System.Windows.Forms.ComboBox();
            this.ddlSexFilter = new System.Windows.Forms.ComboBox();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgChars)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.groupBox8.Location = new System.Drawing.Point(308, 0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(725, 398);
            this.groupBox8.TabIndex = 66;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "groupBox1";
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
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.txtCost);
            this.groupBox7.Controls.Add(this.lstSpecials);
            this.groupBox7.Controls.Add(this.btnClear);
            this.groupBox7.Controls.Add(this.btnSelect);
            this.groupBox7.Controls.Add(this.pictureBox1);
            this.groupBox7.Controls.Add(this.lblHumor);
            this.groupBox7.Controls.Add(this.lblSexappeal);
            this.groupBox7.Controls.Add(this.lblAction);
            this.groupBox7.Controls.Add(this.label22);
            this.groupBox7.Controls.Add(this.label25);
            this.groupBox7.Controls.Add(this.label30);
            this.groupBox7.Controls.Add(this.label31);
            this.groupBox7.Controls.Add(this.label32);
            this.groupBox7.Controls.Add(this.label33);
            this.groupBox7.Controls.Add(this.txtImDb_Link);
            this.groupBox7.Controls.Add(this.txtAge);
            this.groupBox7.Controls.Add(this.txtPopularity);
            this.groupBox7.Controls.Add(this.ddlSex);
            this.groupBox7.Controls.Add(this.txtSurname);
            this.groupBox7.Controls.Add(this.txtName);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(308, 654);
            this.groupBox7.TabIndex = 65;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "groupBox2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 455);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 17);
            this.label6.TabIndex = 72;
            this.label6.Text = "$$:";
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(52, 452);
            this.txtCost.Name = "txtCost";
            this.txtCost.ReadOnly = true;
            this.txtCost.Size = new System.Drawing.Size(214, 22);
            this.txtCost.TabIndex = 71;
            // 
            // lstSpecials
            // 
            this.lstSpecials.LabelWrap = false;
            this.lstSpecials.Location = new System.Drawing.Point(3, 497);
            this.lstSpecials.MultiSelect = false;
            this.lstSpecials.Name = "lstSpecials";
            this.lstSpecials.Size = new System.Drawing.Size(279, 90);
            this.lstSpecials.TabIndex = 70;
            this.lstSpecials.UseCompatibleStateImageBehavior = false;
            this.lstSpecials.View = System.Windows.Forms.View.List;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(3, 606);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(108, 33);
            this.btnClear.TabIndex = 69;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(181, 606);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(101, 33);
            this.btnSelect.TabIndex = 68;
            this.btnSelect.Text = "Seleziona";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(175, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 67;
            this.pictureBox1.TabStop = false;
            // 
            // lblHumor
            // 
            this.lblHumor.AutoSize = true;
            this.lblHumor.Location = new System.Drawing.Point(49, 281);
            this.lblHumor.Name = "lblHumor";
            this.lblHumor.Size = new System.Drawing.Size(54, 17);
            this.lblHumor.TabIndex = 63;
            this.lblHumor.Text = "label11";
            // 
            // lblSexappeal
            // 
            this.lblSexappeal.AutoSize = true;
            this.lblSexappeal.Location = new System.Drawing.Point(49, 239);
            this.lblSexappeal.Name = "lblSexappeal";
            this.lblSexappeal.Size = new System.Drawing.Size(54, 17);
            this.lblSexappeal.TabIndex = 62;
            this.lblSexappeal.Text = "label10";
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Location = new System.Drawing.Point(49, 190);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(46, 17);
            this.lblAction.TabIndex = 61;
            this.lblAction.Text = "label9";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(9, 391);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 17);
            this.label22.TabIndex = 60;
            this.label22.Text = "Lnk:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(9, 353);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(37, 17);
            this.label25.TabIndex = 59;
            this.label25.Text = "Age:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(9, 322);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(29, 17);
            this.label30.TabIndex = 57;
            this.label30.Text = "Po:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(9, 281);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(30, 17);
            this.label31.TabIndex = 56;
            this.label31.Text = "Hu:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(9, 239);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(29, 17);
            this.label32.TabIndex = 55;
            this.label32.Text = "Sh:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(9, 190);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(28, 17);
            this.label33.TabIndex = 54;
            this.label33.Text = "Ac:";
            // 
            // txtImDb_Link
            // 
            this.txtImDb_Link.Location = new System.Drawing.Point(52, 388);
            this.txtImDb_Link.Name = "txtImDb_Link";
            this.txtImDb_Link.ReadOnly = true;
            this.txtImDb_Link.Size = new System.Drawing.Size(214, 22);
            this.txtImDb_Link.TabIndex = 52;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(52, 350);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(212, 22);
            this.txtAge.TabIndex = 51;
            // 
            // txtPopularity
            // 
            this.txtPopularity.Location = new System.Drawing.Point(52, 319);
            this.txtPopularity.Name = "txtPopularity";
            this.txtPopularity.ReadOnly = true;
            this.txtPopularity.Size = new System.Drawing.Size(212, 22);
            this.txtPopularity.TabIndex = 49;
            // 
            // ddlSex
            // 
            this.ddlSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSex.FormattingEnabled = true;
            this.ddlSex.Items.AddRange(new object[] {
            "M",
            "F",
            "A"});
            this.ddlSex.Location = new System.Drawing.Point(12, 144);
            this.ddlSex.Name = "ddlSex";
            this.ddlSex.Size = new System.Drawing.Size(125, 24);
            this.ddlSex.TabIndex = 43;
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(3, 76);
            this.txtSurname.Multiline = true;
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.ReadOnly = true;
            this.txtSurname.Size = new System.Drawing.Size(163, 52);
            this.txtSurname.TabIndex = 42;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(3, 22);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(163, 48);
            this.txtName.TabIndex = 41;
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
            // CharDisplaySelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Name = "CharDisplaySelector";
            this.Size = new System.Drawing.Size(1033, 654);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgChars)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBox8;
        public System.Windows.Forms.Button btnClearFilter;
        public System.Windows.Forms.Button btnFilter;
        public System.Windows.Forms.TextBox txtFilter;
        public System.Windows.Forms.Label lblCounter;
        public System.Windows.Forms.DataGridView dgChars;
        public System.Windows.Forms.GroupBox groupBox7;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtCost;
        public System.Windows.Forms.ListView lstSpecials;
        public System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Button btnSelect;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label lblHumor;
        public System.Windows.Forms.Label lblSexappeal;
        public System.Windows.Forms.Label lblAction;
        public System.Windows.Forms.Label label22;
        public System.Windows.Forms.Label label25;
        public System.Windows.Forms.Label label30;
        public System.Windows.Forms.Label label31;
        public System.Windows.Forms.Label label32;
        public System.Windows.Forms.Label label33;
        public System.Windows.Forms.TextBox txtImDb_Link;
        public System.Windows.Forms.TextBox txtAge;
        public System.Windows.Forms.TextBox txtPopularity;
        public System.Windows.Forms.ComboBox ddlSex;
        public System.Windows.Forms.TextBox txtSurname;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox ddlActorOrOthers;
        private System.Windows.Forms.ComboBox ddlSexFilter;
    }
}
