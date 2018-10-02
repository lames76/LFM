namespace LFM
{
    partial class CreateC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateC));
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.ddlSex = new System.Windows.Forms.ComboBox();
            this.ddlTypeOfCharacter = new System.Windows.Forms.ComboBox();
            this.txtSkill = new System.Windows.Forms.TextBox();
            this.txtAction = new System.Windows.Forms.TextBox();
            this.txtSexappeal = new System.Windows.Forms.TextBox();
            this.txtHumor = new System.Windows.Forms.TextBox();
            this.txtPopularity = new System.Windows.Forms.TextBox();
            this.txtTalent = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.dgChars = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.txtImDbLink = new System.Windows.Forms.TextBox();
            this.btnGetFromImdb = new System.Windows.Forms.Button();
            this.txtImDb_Link = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgFilmografia = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Citation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCounter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblActionName = new System.Windows.Forms.Label();
            this.lblSexappealName = new System.Windows.Forms.Label();
            this.lblHumorName = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.ddlAction = new System.Windows.Forms.ComboBox();
            this.ddlHumor = new System.Windows.Forms.ComboBox();
            this.ddlSexappeal = new System.Windows.Forms.ComboBox();
            this.lstSpecials = new System.Windows.Forms.ListView();
            this.lstAllSpecials = new System.Windows.Forms.ListView();
            this.btnAddSpecials = new System.Windows.Forms.Button();
            this.btnRemoveSpecials = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.ddlAgeClass = new System.Windows.Forms.ComboBox();
            this.btnCheckAgeClass = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgChars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFilmografia)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(45, 24);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(224, 22);
            this.txtName.TabIndex = 0;
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(45, 59);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(223, 22);
            this.txtSurname.TabIndex = 1;
            // 
            // ddlSex
            // 
            this.ddlSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSex.FormattingEnabled = true;
            this.ddlSex.Items.AddRange(new object[] {
            "M",
            "F",
            "A"});
            this.ddlSex.Location = new System.Drawing.Point(48, 100);
            this.ddlSex.Name = "ddlSex";
            this.ddlSex.Size = new System.Drawing.Size(221, 24);
            this.ddlSex.TabIndex = 2;
            // 
            // ddlTypeOfCharacter
            // 
            this.ddlTypeOfCharacter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTypeOfCharacter.FormattingEnabled = true;
            this.ddlTypeOfCharacter.Location = new System.Drawing.Point(47, 146);
            this.ddlTypeOfCharacter.Name = "ddlTypeOfCharacter";
            this.ddlTypeOfCharacter.Size = new System.Drawing.Size(220, 24);
            this.ddlTypeOfCharacter.TabIndex = 3;
            this.ddlTypeOfCharacter.SelectedIndexChanged += new System.EventHandler(this.ddlTypeOfCharacter_SelectedIndexChanged);
            // 
            // txtSkill
            // 
            this.txtSkill.Location = new System.Drawing.Point(48, 178);
            this.txtSkill.Name = "txtSkill";
            this.txtSkill.Size = new System.Drawing.Size(221, 22);
            this.txtSkill.TabIndex = 4;
            // 
            // txtAction
            // 
            this.txtAction.Location = new System.Drawing.Point(48, 226);
            this.txtAction.Name = "txtAction";
            this.txtAction.ReadOnly = true;
            this.txtAction.Size = new System.Drawing.Size(40, 22);
            this.txtAction.TabIndex = 5;
            // 
            // txtSexappeal
            // 
            this.txtSexappeal.Location = new System.Drawing.Point(46, 275);
            this.txtSexappeal.Name = "txtSexappeal";
            this.txtSexappeal.ReadOnly = true;
            this.txtSexappeal.Size = new System.Drawing.Size(42, 22);
            this.txtSexappeal.TabIndex = 6;
            // 
            // txtHumor
            // 
            this.txtHumor.Location = new System.Drawing.Point(46, 329);
            this.txtHumor.Name = "txtHumor";
            this.txtHumor.ReadOnly = true;
            this.txtHumor.Size = new System.Drawing.Size(42, 22);
            this.txtHumor.TabIndex = 7;
            // 
            // txtPopularity
            // 
            this.txtPopularity.Location = new System.Drawing.Point(46, 358);
            this.txtPopularity.Name = "txtPopularity";
            this.txtPopularity.Size = new System.Drawing.Size(221, 22);
            this.txtPopularity.TabIndex = 8;
            // 
            // txtTalent
            // 
            this.txtTalent.Location = new System.Drawing.Point(45, 395);
            this.txtTalent.Name = "txtTalent";
            this.txtTalent.Size = new System.Drawing.Size(221, 22);
            this.txtTalent.TabIndex = 9;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(55, 425);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(212, 22);
            this.txtAge.TabIndex = 10;
            // 
            // dgChars
            // 
            this.dgChars.AllowUserToAddRows = false;
            this.dgChars.AllowUserToDeleteRows = false;
            this.dgChars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgChars.Location = new System.Drawing.Point(291, 39);
            this.dgChars.Name = "dgChars";
            this.dgChars.RowTemplate.Height = 24;
            this.dgChars.Size = new System.Drawing.Size(784, 313);
            this.dgChars.TabIndex = 11;
            this.dgChars.DoubleClick += new System.EventHandler(this.dgChars_DoubleClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(129, 611);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 33);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(15, 611);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(108, 33);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(291, 358);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(463, 361);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(98, 34);
            this.btnBrowse.TabIndex = 16;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(530, 592);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(432, 24);
            this.webBrowser1.TabIndex = 21;
            this.webBrowser1.Visible = false;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // txtImDbLink
            // 
            this.txtImDbLink.Location = new System.Drawing.Point(530, 622);
            this.txtImDbLink.Name = "txtImDbLink";
            this.txtImDbLink.Size = new System.Drawing.Size(464, 22);
            this.txtImDbLink.TabIndex = 19;
            this.txtImDbLink.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtImDbLink_KeyDown);
            // 
            // btnGetFromImdb
            // 
            this.btnGetFromImdb.Location = new System.Drawing.Point(427, 611);
            this.btnGetFromImdb.Name = "btnGetFromImdb";
            this.btnGetFromImdb.Size = new System.Drawing.Size(97, 35);
            this.btnGetFromImdb.TabIndex = 18;
            this.btnGetFromImdb.Text = "ImDb";
            this.btnGetFromImdb.UseVisualStyleBackColor = true;
            this.btnGetFromImdb.Click += new System.EventHandler(this.btnGetFromImdb_Click);
            // 
            // txtImDb_Link
            // 
            this.txtImDb_Link.Location = new System.Drawing.Point(55, 463);
            this.txtImDb_Link.Name = "txtImDb_Link";
            this.txtImDb_Link.Size = new System.Drawing.Size(214, 22);
            this.txtImDb_Link.TabIndex = 22;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(982, 358);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 140);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgFilmografia
            // 
            this.dgFilmografia.AllowUserToAddRows = false;
            this.dgFilmografia.AllowUserToDeleteRows = false;
            this.dgFilmografia.AllowUserToResizeColumns = false;
            this.dgFilmografia.AllowUserToResizeRows = false;
            this.dgFilmografia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgFilmografia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFilmografia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.Age,
            this.Citation,
            this.ID});
            this.dgFilmografia.Location = new System.Drawing.Point(574, 363);
            this.dgFilmografia.Name = "dgFilmografia";
            this.dgFilmografia.ReadOnly = true;
            this.dgFilmografia.RowTemplate.Height = 24;
            this.dgFilmografia.Size = new System.Drawing.Size(402, 98);
            this.dgFilmografia.TabIndex = 24;
            this.dgFilmografia.DoubleClick += new System.EventHandler(this.dgFilmografia_DoubleClick);
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Age
            // 
            this.Age.DataPropertyName = "Age";
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            // 
            // Citation
            // 
            this.Citation.DataPropertyName = "Citation";
            this.Citation.HeaderText = "Role";
            this.Citation.Name = "Citation";
            this.Citation.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Location = new System.Drawing.Point(288, 4);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(46, 17);
            this.lblCounter.TabIndex = 25;
            this.lblCounter.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Sk:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Ac:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "Sh:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "Hu:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 361);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 17);
            this.label5.TabIndex = 30;
            this.label5.Text = "Po:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 398);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 17);
            this.label6.TabIndex = 31;
            this.label6.Text = "Ta:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 428);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 17);
            this.label7.TabIndex = 32;
            this.label7.Text = "Age:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 466);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 17);
            this.label8.TabIndex = 33;
            this.label8.Text = "Lnk:";
            // 
            // lblActionName
            // 
            this.lblActionName.AutoSize = true;
            this.lblActionName.Location = new System.Drawing.Point(94, 241);
            this.lblActionName.Name = "lblActionName";
            this.lblActionName.Size = new System.Drawing.Size(46, 17);
            this.lblActionName.TabIndex = 34;
            this.lblActionName.Text = "label9";
            // 
            // lblSexappealName
            // 
            this.lblSexappealName.AutoSize = true;
            this.lblSexappealName.Location = new System.Drawing.Point(94, 288);
            this.lblSexappealName.Name = "lblSexappealName";
            this.lblSexappealName.Size = new System.Drawing.Size(54, 17);
            this.lblSexappealName.TabIndex = 35;
            this.lblSexappealName.Text = "label10";
            // 
            // lblHumorName
            // 
            this.lblHumorName.AutoSize = true;
            this.lblHumorName.Location = new System.Drawing.Point(94, 338);
            this.lblHumorName.Name = "lblHumorName";
            this.lblHumorName.Size = new System.Drawing.Size(54, 17);
            this.lblHumorName.TabIndex = 36;
            this.lblHumorName.Text = "label11";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(236, 611);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 33);
            this.btnDelete.TabIndex = 37;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ddlAction
            // 
            this.ddlAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAction.FormattingEnabled = true;
            this.ddlAction.Location = new System.Drawing.Point(94, 214);
            this.ddlAction.Name = "ddlAction";
            this.ddlAction.Size = new System.Drawing.Size(191, 24);
            this.ddlAction.TabIndex = 38;
            this.ddlAction.SelectedIndexChanged += new System.EventHandler(this.ddlAction_SelectedIndexChanged);
            // 
            // ddlHumor
            // 
            this.ddlHumor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlHumor.FormattingEnabled = true;
            this.ddlHumor.Location = new System.Drawing.Point(94, 311);
            this.ddlHumor.Name = "ddlHumor";
            this.ddlHumor.Size = new System.Drawing.Size(191, 24);
            this.ddlHumor.TabIndex = 39;
            this.ddlHumor.SelectedIndexChanged += new System.EventHandler(this.ddlHumor_SelectedIndexChanged);
            // 
            // ddlSexappeal
            // 
            this.ddlSexappeal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSexappeal.FormattingEnabled = true;
            this.ddlSexappeal.Location = new System.Drawing.Point(94, 261);
            this.ddlSexappeal.Name = "ddlSexappeal";
            this.ddlSexappeal.Size = new System.Drawing.Size(191, 24);
            this.ddlSexappeal.TabIndex = 40;
            this.ddlSexappeal.SelectedIndexChanged += new System.EventHandler(this.ddlSexappeal_SelectedIndexChanged);
            // 
            // lstSpecials
            // 
            this.lstSpecials.LabelWrap = false;
            this.lstSpecials.Location = new System.Drawing.Point(15, 504);
            this.lstSpecials.MultiSelect = false;
            this.lstSpecials.Name = "lstSpecials";
            this.lstSpecials.Size = new System.Drawing.Size(502, 88);
            this.lstSpecials.TabIndex = 41;
            this.lstSpecials.UseCompatibleStateImageBehavior = false;
            this.lstSpecials.View = System.Windows.Forms.View.List;
            // 
            // lstAllSpecials
            // 
            this.lstAllSpecials.LabelWrap = false;
            this.lstAllSpecials.Location = new System.Drawing.Point(573, 504);
            this.lstAllSpecials.MultiSelect = false;
            this.lstAllSpecials.Name = "lstAllSpecials";
            this.lstAllSpecials.Size = new System.Drawing.Size(502, 88);
            this.lstAllSpecials.TabIndex = 42;
            this.lstAllSpecials.UseCompatibleStateImageBehavior = false;
            this.lstAllSpecials.View = System.Windows.Forms.View.List;
            // 
            // btnAddSpecials
            // 
            this.btnAddSpecials.Location = new System.Drawing.Point(523, 509);
            this.btnAddSpecials.Name = "btnAddSpecials";
            this.btnAddSpecials.Size = new System.Drawing.Size(38, 27);
            this.btnAddSpecials.TabIndex = 43;
            this.btnAddSpecials.Text = "<<";
            this.btnAddSpecials.UseVisualStyleBackColor = true;
            this.btnAddSpecials.Click += new System.EventHandler(this.btnAddSpecials_Click);
            // 
            // btnRemoveSpecials
            // 
            this.btnRemoveSpecials.Location = new System.Drawing.Point(523, 559);
            this.btnRemoveSpecials.Name = "btnRemoveSpecials";
            this.btnRemoveSpecials.Size = new System.Drawing.Size(38, 27);
            this.btnRemoveSpecials.TabIndex = 44;
            this.btnRemoveSpecials.Text = ">>";
            this.btnRemoveSpecials.UseVisualStyleBackColor = true;
            this.btnRemoveSpecials.Click += new System.EventHandler(this.btnRemoveSpecials_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(671, 7);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(263, 22);
            this.txtFilter.TabIndex = 45;
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(952, 8);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(106, 25);
            this.btnFilter.TabIndex = 46;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Location = new System.Drawing.Point(634, 4);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(31, 25);
            this.btnClearFilter.TabIndex = 52;
            this.btnClearFilter.Text = "x";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // ddlAgeClass
            // 
            this.ddlAgeClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAgeClass.FormattingEnabled = true;
            this.ddlAgeClass.Items.AddRange(new object[] {
            "NoValue",
            "Child",
            "Teen",
            "Average",
            "Mature",
            "Old",
            "TimeLord",
            "Elf"});
            this.ddlAgeClass.Location = new System.Drawing.Point(424, 474);
            this.ddlAgeClass.Name = "ddlAgeClass";
            this.ddlAgeClass.Size = new System.Drawing.Size(93, 24);
            this.ddlAgeClass.TabIndex = 53;
            this.ddlAgeClass.SelectedIndexChanged += new System.EventHandler(this.ddlAgeClass_SelectedIndexChanged);
            // 
            // btnCheckAgeClass
            // 
            this.btnCheckAgeClass.Location = new System.Drawing.Point(1000, 598);
            this.btnCheckAgeClass.Name = "btnCheckAgeClass";
            this.btnCheckAgeClass.Size = new System.Drawing.Size(83, 59);
            this.btnCheckAgeClass.TabIndex = 54;
            this.btnCheckAgeClass.Text = "Check Age Class";
            this.btnCheckAgeClass.UseVisualStyleBackColor = true;
            this.btnCheckAgeClass.Click += new System.EventHandler(this.btnCheckAgeClass_Click);
            // 
            // CreateC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 656);
            this.ControlBox = false;
            this.Controls.Add(this.btnCheckAgeClass);
            this.Controls.Add(this.ddlAgeClass);
            this.Controls.Add(this.btnClearFilter);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.btnRemoveSpecials);
            this.Controls.Add(this.btnAddSpecials);
            this.Controls.Add(this.lstAllSpecials);
            this.Controls.Add(this.lstSpecials);
            this.Controls.Add(this.ddlSexappeal);
            this.Controls.Add(this.ddlHumor);
            this.Controls.Add(this.ddlAction);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblHumorName);
            this.Controls.Add(this.lblSexappealName);
            this.Controls.Add(this.lblActionName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.dgFilmografia);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtImDb_Link);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.txtImDbLink);
            this.Controls.Add(this.btnGetFromImdb);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgChars);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtTalent);
            this.Controls.Add(this.txtPopularity);
            this.Controls.Add(this.txtHumor);
            this.Controls.Add(this.txtSexappeal);
            this.Controls.Add(this.txtAction);
            this.Controls.Add(this.txtSkill);
            this.Controls.Add(this.ddlTypeOfCharacter);
            this.Controls.Add(this.ddlSex);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateC";
            this.Load += new System.EventHandler(this.CreateC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgChars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFilmografia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.ComboBox ddlSex;
        private System.Windows.Forms.ComboBox ddlTypeOfCharacter;
        private System.Windows.Forms.TextBox txtSkill;
        private System.Windows.Forms.TextBox txtAction;
        private System.Windows.Forms.TextBox txtSexappeal;
        private System.Windows.Forms.TextBox txtHumor;
        private System.Windows.Forms.TextBox txtPopularity;
        private System.Windows.Forms.TextBox txtTalent;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.DataGridView dgChars;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox txtImDbLink;
        private System.Windows.Forms.Button btnGetFromImdb;
        private System.Windows.Forms.TextBox txtImDb_Link;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgFilmografia;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblActionName;
        private System.Windows.Forms.Label lblSexappealName;
        private System.Windows.Forms.Label lblHumorName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox ddlAction;
        private System.Windows.Forms.ComboBox ddlHumor;
        private System.Windows.Forms.ComboBox ddlSexappeal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn Citation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.ListView lstSpecials;
        private System.Windows.Forms.ListView lstAllSpecials;
        private System.Windows.Forms.Button btnAddSpecials;
        private System.Windows.Forms.Button btnRemoveSpecials;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.ComboBox ddlAgeClass;
        private System.Windows.Forms.Button btnCheckAgeClass;
    }
}