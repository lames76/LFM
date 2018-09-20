namespace LFM
{
    partial class CreateM
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
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.ddlType1 = new System.Windows.Forms.ComboBox();
            this.txtUniverse = new System.Windows.Forms.TextBox();
            this.txtAction = new System.Windows.Forms.TextBox();
            this.txtSex = new System.Windows.Forms.TextBox();
            this.txtHumor = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtCitation = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnGetFromImdb = new System.Windows.Forms.Button();
            this.dgMovie = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Success = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Citation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkUniverse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImDB_Link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Base_Audience = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.T_Success = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtImDbLink = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtImDb_Link = new System.Windows.Forms.TextBox();
            this.txtDirector = new System.Windows.Forms.TextBox();
            this.txtWriter = new System.Windows.Forms.TextBox();
            this.btnGotoWriter = new System.Windows.Forms.Button();
            this.btnGoToDirector = new System.Windows.Forms.Button();
            this.lstActors = new System.Windows.Forms.ListView();
            this.btnAddActor = new System.Windows.Forms.Button();
            this.txtActor = new System.Windows.Forms.TextBox();
            this.btnRemoveActor = new System.Windows.Forms.Button();
            this.lblCounter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblHumorName = new System.Windows.Forms.Label();
            this.lblSexappealName = new System.Windows.Forms.Label();
            this.lblActionName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCalculateSuccess = new System.Windows.Forms.Button();
            this.txtSuccess = new System.Windows.Forms.TextBox();
            this.txtBase_Audience = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnCalculatePrice = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.ddlType2 = new System.Windows.Forms.ComboBox();
            this.ddlType3 = new System.Windows.Forms.ComboBox();
            this.ddlType4 = new System.Windows.Forms.ComboBox();
            this.btnCalcInnerValuesFromWriter = new System.Windows.Forms.Button();
            this.btnRemoveWriter = new System.Windows.Forms.Button();
            this.btnRemoveDirector = new System.Windows.Forms.Button();
            this.ddlTheatre = new System.Windows.Forms.ComboBox();
            this.ddlSpecialEffect = new System.Windows.Forms.ComboBox();
            this.btnMngUniv = new System.Windows.Forms.Button();
            this.lblUniverse = new System.Windows.Forms.Label();
            this.cbxShowReport = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgMovie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(45, 31);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(252, 22);
            this.txtTitle.TabIndex = 0;
            // 
            // ddlType1
            // 
            this.ddlType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlType1.FormattingEnabled = true;
            this.ddlType1.Location = new System.Drawing.Point(45, 59);
            this.ddlType1.Name = "ddlType1";
            this.ddlType1.Size = new System.Drawing.Size(103, 24);
            this.ddlType1.TabIndex = 1;
            // 
            // txtUniverse
            // 
            this.txtUniverse.Location = new System.Drawing.Point(45, 121);
            this.txtUniverse.Name = "txtUniverse";
            this.txtUniverse.Size = new System.Drawing.Size(151, 22);
            this.txtUniverse.TabIndex = 2;
            // 
            // txtAction
            // 
            this.txtAction.Location = new System.Drawing.Point(45, 157);
            this.txtAction.Name = "txtAction";
            this.txtAction.Size = new System.Drawing.Size(167, 22);
            this.txtAction.TabIndex = 3;
            this.txtAction.TextChanged += new System.EventHandler(this.txtAction_TextChanged);
            // 
            // txtSex
            // 
            this.txtSex.Location = new System.Drawing.Point(45, 185);
            this.txtSex.Name = "txtSex";
            this.txtSex.Size = new System.Drawing.Size(167, 22);
            this.txtSex.TabIndex = 4;
            this.txtSex.TextChanged += new System.EventHandler(this.txtSex_TextChanged);
            // 
            // txtHumor
            // 
            this.txtHumor.Location = new System.Drawing.Point(45, 214);
            this.txtHumor.Name = "txtHumor";
            this.txtHumor.Size = new System.Drawing.Size(167, 22);
            this.txtHumor.TabIndex = 5;
            this.txtHumor.TextChanged += new System.EventHandler(this.txtHumor_TextChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(45, 242);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(252, 117);
            this.txtDescription.TabIndex = 6;
            // 
            // txtCitation
            // 
            this.txtCitation.Location = new System.Drawing.Point(45, 379);
            this.txtCitation.Multiline = true;
            this.txtCitation.Name = "txtCitation";
            this.txtCitation.Size = new System.Drawing.Size(252, 75);
            this.txtCitation.TabIndex = 7;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(45, 483);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(252, 22);
            this.txtAge.TabIndex = 8;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(33, 550);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(97, 35);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(207, 550);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 35);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnGetFromImdb
            // 
            this.btnGetFromImdb.Location = new System.Drawing.Point(355, 691);
            this.btnGetFromImdb.Name = "btnGetFromImdb";
            this.btnGetFromImdb.Size = new System.Drawing.Size(97, 35);
            this.btnGetFromImdb.TabIndex = 12;
            this.btnGetFromImdb.Text = "ImDb";
            this.btnGetFromImdb.UseVisualStyleBackColor = true;
            this.btnGetFromImdb.Click += new System.EventHandler(this.btnGetFromImdb_Click);
            // 
            // dgMovie
            // 
            this.dgMovie.AllowUserToAddRows = false;
            this.dgMovie.AllowUserToDeleteRows = false;
            this.dgMovie.AllowUserToOrderColumns = true;
            this.dgMovie.AllowUserToResizeColumns = false;
            this.dgMovie.AllowUserToResizeRows = false;
            this.dgMovie.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMovie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMovie.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Title,
            this.fkType,
            this.A,
            this.S,
            this.H,
            this.Success,
            this.Status,
            this.Age,
            this.Description,
            this.Citation,
            this.fkUniverse,
            this.ImDB_Link,
            this.Base_Audience,
            this.T_Success});
            this.dgMovie.Location = new System.Drawing.Point(338, 36);
            this.dgMovie.Name = "dgMovie";
            this.dgMovie.RowTemplate.Height = 24;
            this.dgMovie.Size = new System.Drawing.Size(880, 332);
            this.dgMovie.TabIndex = 13;
            this.dgMovie.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgMovie_CellFormatting);
            this.dgMovie.DoubleClick += new System.EventHandler(this.dbMovie_DoubleClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            // 
            // fkType
            // 
            this.fkType.DataPropertyName = "fkType.TypeOfMovie";
            this.fkType.HeaderText = "Genre";
            this.fkType.Name = "fkType";
            // 
            // A
            // 
            this.A.DataPropertyName = "DbRules.Inner_Values.Action";
            this.A.HeaderText = "A";
            this.A.Name = "A";
            // 
            // S
            // 
            this.S.DataPropertyName = "DbRules.Inner_Values.Sexappeal";
            this.S.HeaderText = "S";
            this.S.Name = "S";
            // 
            // H
            // 
            this.H.DataPropertyName = "DbRules.Inner_Values.Humor";
            this.H.HeaderText = "H";
            this.H.Name = "H";
            // 
            // Success
            // 
            this.Success.DataPropertyName = "Success";
            this.Success.HeaderText = "Success";
            this.Success.Name = "Success";
            this.Success.Visible = false;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // Age
            // 
            this.Age.DataPropertyName = "Age";
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.Visible = false;
            // 
            // Citation
            // 
            this.Citation.DataPropertyName = "Citation";
            this.Citation.HeaderText = "Citation";
            this.Citation.Name = "Citation";
            this.Citation.Visible = false;
            // 
            // fkUniverse
            // 
            this.fkUniverse.DataPropertyName = "fkUniverse";
            this.fkUniverse.HeaderText = "Universe";
            this.fkUniverse.Name = "fkUniverse";
            this.fkUniverse.Visible = false;
            // 
            // ImDB_Link
            // 
            this.ImDB_Link.DataPropertyName = "ImDB_Link";
            this.ImDB_Link.HeaderText = "ImDB_Link";
            this.ImDB_Link.Name = "ImDB_Link";
            this.ImDB_Link.Visible = false;
            // 
            // Base_Audience
            // 
            this.Base_Audience.DataPropertyName = "Base_Audience";
            this.Base_Audience.HeaderText = "Base_Audience";
            this.Base_Audience.Name = "Base_Audience";
            this.Base_Audience.Visible = false;
            // 
            // T_Success
            // 
            this.T_Success.HeaderText = "T_Success";
            this.T_Success.Name = "T_Success";
            // 
            // txtImDbLink
            // 
            this.txtImDbLink.Location = new System.Drawing.Point(472, 704);
            this.txtImDbLink.Name = "txtImDbLink";
            this.txtImDbLink.Size = new System.Drawing.Size(464, 22);
            this.txtImDbLink.TabIndex = 14;
            this.txtImDbLink.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtImDbLink_KeyDown);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(472, 674);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(432, 24);
            this.webBrowser1.TabIndex = 16;
            this.webBrowser1.Visible = false;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(338, 384);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 149);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // txtImDb_Link
            // 
            this.txtImDb_Link.Location = new System.Drawing.Point(45, 511);
            this.txtImDb_Link.Name = "txtImDb_Link";
            this.txtImDb_Link.Size = new System.Drawing.Size(252, 22);
            this.txtImDb_Link.TabIndex = 18;
            // 
            // txtDirector
            // 
            this.txtDirector.Location = new System.Drawing.Point(505, 439);
            this.txtDirector.Name = "txtDirector";
            this.txtDirector.Size = new System.Drawing.Size(206, 22);
            this.txtDirector.TabIndex = 20;
            // 
            // txtWriter
            // 
            this.txtWriter.Location = new System.Drawing.Point(505, 393);
            this.txtWriter.Name = "txtWriter";
            this.txtWriter.Size = new System.Drawing.Size(206, 22);
            this.txtWriter.TabIndex = 21;
            // 
            // btnGotoWriter
            // 
            this.btnGotoWriter.Location = new System.Drawing.Point(747, 389);
            this.btnGotoWriter.Name = "btnGotoWriter";
            this.btnGotoWriter.Size = new System.Drawing.Size(68, 31);
            this.btnGotoWriter.TabIndex = 22;
            this.btnGotoWriter.Text = "Go To";
            this.btnGotoWriter.UseVisualStyleBackColor = true;
            this.btnGotoWriter.Click += new System.EventHandler(this.btnGotoWriter_Click);
            // 
            // btnGoToDirector
            // 
            this.btnGoToDirector.Location = new System.Drawing.Point(747, 435);
            this.btnGoToDirector.Name = "btnGoToDirector";
            this.btnGoToDirector.Size = new System.Drawing.Size(68, 31);
            this.btnGoToDirector.TabIndex = 23;
            this.btnGoToDirector.Text = "Go To";
            this.btnGoToDirector.UseVisualStyleBackColor = true;
            this.btnGoToDirector.Click += new System.EventHandler(this.btnGoToDirector_Click);
            // 
            // lstActors
            // 
            this.lstActors.LabelWrap = false;
            this.lstActors.Location = new System.Drawing.Point(888, 392);
            this.lstActors.MultiSelect = false;
            this.lstActors.Name = "lstActors";
            this.lstActors.Size = new System.Drawing.Size(330, 250);
            this.lstActors.TabIndex = 24;
            this.lstActors.UseCompatibleStateImageBehavior = false;
            this.lstActors.View = System.Windows.Forms.View.List;
            this.lstActors.DoubleClick += new System.EventHandler(this.lstActors_DoubleClick_1);
            this.lstActors.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstActors_KeyDown);
            // 
            // btnAddActor
            // 
            this.btnAddActor.Location = new System.Drawing.Point(814, 479);
            this.btnAddActor.Name = "btnAddActor";
            this.btnAddActor.Size = new System.Drawing.Size(68, 31);
            this.btnAddActor.TabIndex = 26;
            this.btnAddActor.Text = ">>";
            this.btnAddActor.UseVisualStyleBackColor = true;
            this.btnAddActor.Click += new System.EventHandler(this.btnAddActor_Click);
            // 
            // txtActor
            // 
            this.txtActor.Location = new System.Drawing.Point(578, 483);
            this.txtActor.Name = "txtActor";
            this.txtActor.Size = new System.Drawing.Size(206, 22);
            this.txtActor.TabIndex = 25;
            // 
            // btnRemoveActor
            // 
            this.btnRemoveActor.Location = new System.Drawing.Point(814, 515);
            this.btnRemoveActor.Name = "btnRemoveActor";
            this.btnRemoveActor.Size = new System.Drawing.Size(68, 31);
            this.btnRemoveActor.TabIndex = 27;
            this.btnRemoveActor.Text = "<<";
            this.btnRemoveActor.UseVisualStyleBackColor = true;
            this.btnRemoveActor.Click += new System.EventHandler(this.btnRemoveActor_Click);
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Location = new System.Drawing.Point(335, 9);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(46, 17);
            this.lblCounter.TabIndex = 28;
            this.lblCounter.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "U:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "Ac:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 17);
            this.label3.TabIndex = 31;
            this.label3.Text = "Sh:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 17);
            this.label4.TabIndex = 32;
            this.label4.Text = "Hu:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 486);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 33;
            this.label5.Text = "Age:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 514);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 17);
            this.label6.TabIndex = 34;
            this.label6.Text = "Lnk:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(465, 396);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 17);
            this.label7.TabIndex = 35;
            this.label7.Text = "Wr:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(465, 442);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 17);
            this.label8.TabIndex = 36;
            this.label8.Text = "Dr:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(538, 486);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 17);
            this.label9.TabIndex = 37;
            this.label9.Text = "Ar:";
            // 
            // lblHumorName
            // 
            this.lblHumorName.AutoSize = true;
            this.lblHumorName.Location = new System.Drawing.Point(218, 216);
            this.lblHumorName.Name = "lblHumorName";
            this.lblHumorName.Size = new System.Drawing.Size(54, 17);
            this.lblHumorName.TabIndex = 40;
            this.lblHumorName.Text = "label11";
            // 
            // lblSexappealName
            // 
            this.lblSexappealName.AutoSize = true;
            this.lblSexappealName.Location = new System.Drawing.Point(218, 188);
            this.lblSexappealName.Name = "lblSexappealName";
            this.lblSexappealName.Size = new System.Drawing.Size(54, 17);
            this.lblSexappealName.TabIndex = 39;
            this.lblSexappealName.Text = "label10";
            // 
            // lblActionName
            // 
            this.lblActionName.AutoSize = true;
            this.lblActionName.Location = new System.Drawing.Point(218, 160);
            this.lblActionName.Name = "lblActionName";
            this.lblActionName.Size = new System.Drawing.Size(46, 17);
            this.lblActionName.TabIndex = 38;
            this.lblActionName.Text = "label9";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 683);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 17);
            this.label10.TabIndex = 43;
            this.label10.Text = "Success:";
            // 
            // btnCalculateSuccess
            // 
            this.btnCalculateSuccess.Location = new System.Drawing.Point(222, 699);
            this.btnCalculateSuccess.Name = "btnCalculateSuccess";
            this.btnCalculateSuccess.Size = new System.Drawing.Size(75, 31);
            this.btnCalculateSuccess.TabIndex = 42;
            this.btnCalculateSuccess.Text = "Calculate";
            this.btnCalculateSuccess.UseVisualStyleBackColor = true;
            this.btnCalculateSuccess.Click += new System.EventHandler(this.btnCalculateSuccess_Click);
            // 
            // txtSuccess
            // 
            this.txtSuccess.Location = new System.Drawing.Point(5, 703);
            this.txtSuccess.Name = "txtSuccess";
            this.txtSuccess.Size = new System.Drawing.Size(206, 22);
            this.txtSuccess.TabIndex = 41;
            // 
            // txtBase_Audience
            // 
            this.txtBase_Audience.Location = new System.Drawing.Point(5, 644);
            this.txtBase_Audience.Name = "txtBase_Audience";
            this.txtBase_Audience.Size = new System.Drawing.Size(206, 22);
            this.txtBase_Audience.TabIndex = 44;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 625);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 17);
            this.label11.TabIndex = 45;
            this.label11.Text = "Base Audience:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(219, 625);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 17);
            this.label12.TabIndex = 47;
            this.label12.Text = "Price:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(222, 644);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(230, 22);
            this.txtPrice.TabIndex = 46;
            // 
            // btnCalculatePrice
            // 
            this.btnCalculatePrice.Location = new System.Drawing.Point(458, 640);
            this.btnCalculatePrice.Name = "btnCalculatePrice";
            this.btnCalculatePrice.Size = new System.Drawing.Size(75, 31);
            this.btnCalculatePrice.TabIndex = 48;
            this.btnCalculatePrice.Text = "Calculate";
            this.btnCalculatePrice.UseVisualStyleBackColor = true;
            this.btnCalculatePrice.Click += new System.EventHandler(this.btnCalculatePrice_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(1112, 5);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(106, 25);
            this.btnFilter.TabIndex = 50;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(831, 4);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(263, 22);
            this.txtFilter.TabIndex = 49;
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Location = new System.Drawing.Point(794, 1);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(31, 25);
            this.btnClearFilter.TabIndex = 51;
            this.btnClearFilter.Text = "x";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // ddlType2
            // 
            this.ddlType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlType2.FormattingEnabled = true;
            this.ddlType2.Location = new System.Drawing.Point(194, 59);
            this.ddlType2.Name = "ddlType2";
            this.ddlType2.Size = new System.Drawing.Size(103, 24);
            this.ddlType2.TabIndex = 52;
            this.ddlType2.SelectedIndexChanged += new System.EventHandler(this.ddlType2_SelectedIndexChanged);
            // 
            // ddlType3
            // 
            this.ddlType3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlType3.FormattingEnabled = true;
            this.ddlType3.Location = new System.Drawing.Point(45, 91);
            this.ddlType3.Name = "ddlType3";
            this.ddlType3.Size = new System.Drawing.Size(103, 24);
            this.ddlType3.TabIndex = 53;
            this.ddlType3.SelectedIndexChanged += new System.EventHandler(this.ddlType3_SelectedIndexChanged);
            // 
            // ddlType4
            // 
            this.ddlType4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlType4.FormattingEnabled = true;
            this.ddlType4.Location = new System.Drawing.Point(194, 89);
            this.ddlType4.Name = "ddlType4";
            this.ddlType4.Size = new System.Drawing.Size(103, 24);
            this.ddlType4.TabIndex = 54;
            this.ddlType4.SelectedIndexChanged += new System.EventHandler(this.ddlType4_SelectedIndexChanged);
            // 
            // btnCalcInnerValuesFromWriter
            // 
            this.btnCalcInnerValuesFromWriter.Location = new System.Drawing.Point(292, 157);
            this.btnCalcInnerValuesFromWriter.Name = "btnCalcInnerValuesFromWriter";
            this.btnCalcInnerValuesFromWriter.Size = new System.Drawing.Size(40, 79);
            this.btnCalcInnerValuesFromWriter.TabIndex = 55;
            this.btnCalcInnerValuesFromWriter.Text = "Calc";
            this.btnCalcInnerValuesFromWriter.UseVisualStyleBackColor = true;
            this.btnCalcInnerValuesFromWriter.Click += new System.EventHandler(this.btnCalcInnerValuesFromWriter_Click);
            // 
            // btnRemoveWriter
            // 
            this.btnRemoveWriter.Location = new System.Drawing.Point(717, 389);
            this.btnRemoveWriter.Name = "btnRemoveWriter";
            this.btnRemoveWriter.Size = new System.Drawing.Size(24, 31);
            this.btnRemoveWriter.TabIndex = 56;
            this.btnRemoveWriter.Text = "x";
            this.btnRemoveWriter.UseVisualStyleBackColor = true;
            this.btnRemoveWriter.Click += new System.EventHandler(this.btnRemoveWriter_Click);
            // 
            // btnRemoveDirector
            // 
            this.btnRemoveDirector.Location = new System.Drawing.Point(717, 435);
            this.btnRemoveDirector.Name = "btnRemoveDirector";
            this.btnRemoveDirector.Size = new System.Drawing.Size(24, 31);
            this.btnRemoveDirector.TabIndex = 57;
            this.btnRemoveDirector.Text = "x";
            this.btnRemoveDirector.UseVisualStyleBackColor = true;
            this.btnRemoveDirector.Click += new System.EventHandler(this.btnRemoveDirector_Click);
            // 
            // ddlTheatre
            // 
            this.ddlTheatre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTheatre.FormattingEnabled = true;
            this.ddlTheatre.Location = new System.Drawing.Point(338, 556);
            this.ddlTheatre.Name = "ddlTheatre";
            this.ddlTheatre.Size = new System.Drawing.Size(226, 24);
            this.ddlTheatre.TabIndex = 58;
            // 
            // ddlSpecialEffect
            // 
            this.ddlSpecialEffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSpecialEffect.FormattingEnabled = true;
            this.ddlSpecialEffect.Location = new System.Drawing.Point(578, 556);
            this.ddlSpecialEffect.Name = "ddlSpecialEffect";
            this.ddlSpecialEffect.Size = new System.Drawing.Size(206, 24);
            this.ddlSpecialEffect.TabIndex = 59;
            // 
            // btnMngUniv
            // 
            this.btnMngUniv.Location = new System.Drawing.Point(257, 119);
            this.btnMngUniv.Name = "btnMngUniv";
            this.btnMngUniv.Size = new System.Drawing.Size(75, 24);
            this.btnMngUniv.TabIndex = 60;
            this.btnMngUniv.Text = "Un Mg";
            this.btnMngUniv.UseVisualStyleBackColor = true;
            this.btnMngUniv.Click += new System.EventHandler(this.btnMngUniv_Click);
            // 
            // lblUniverse
            // 
            this.lblUniverse.AutoSize = true;
            this.lblUniverse.Location = new System.Drawing.Point(205, 123);
            this.lblUniverse.Name = "lblUniverse";
            this.lblUniverse.Size = new System.Drawing.Size(46, 17);
            this.lblUniverse.TabIndex = 61;
            this.lblUniverse.Text = "label9";
            // 
            // cbxShowReport
            // 
            this.cbxShowReport.AutoSize = true;
            this.cbxShowReport.Location = new System.Drawing.Point(552, 650);
            this.cbxShowReport.Name = "cbxShowReport";
            this.cbxShowReport.Size = new System.Drawing.Size(104, 21);
            this.cbxShowReport.TabIndex = 62;
            this.cbxShowReport.Text = "show report";
            this.cbxShowReport.UseVisualStyleBackColor = true;
            // 
            // CreateM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 742);
            this.Controls.Add(this.cbxShowReport);
            this.Controls.Add(this.lblUniverse);
            this.Controls.Add(this.btnMngUniv);
            this.Controls.Add(this.ddlSpecialEffect);
            this.Controls.Add(this.ddlTheatre);
            this.Controls.Add(this.btnRemoveDirector);
            this.Controls.Add(this.btnRemoveWriter);
            this.Controls.Add(this.btnCalcInnerValuesFromWriter);
            this.Controls.Add(this.ddlType4);
            this.Controls.Add(this.ddlType3);
            this.Controls.Add(this.ddlType2);
            this.Controls.Add(this.btnClearFilter);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.btnCalculatePrice);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtBase_Audience);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnCalculateSuccess);
            this.Controls.Add(this.txtSuccess);
            this.Controls.Add(this.lblHumorName);
            this.Controls.Add(this.lblSexappealName);
            this.Controls.Add(this.lblActionName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.btnRemoveActor);
            this.Controls.Add(this.btnAddActor);
            this.Controls.Add(this.txtActor);
            this.Controls.Add(this.lstActors);
            this.Controls.Add(this.btnGoToDirector);
            this.Controls.Add(this.btnGotoWriter);
            this.Controls.Add(this.txtWriter);
            this.Controls.Add(this.txtDirector);
            this.Controls.Add(this.txtImDb_Link);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.txtImDbLink);
            this.Controls.Add(this.dgMovie);
            this.Controls.Add(this.btnGetFromImdb);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtCitation);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtHumor);
            this.Controls.Add(this.txtSex);
            this.Controls.Add(this.txtAction);
            this.Controls.Add(this.txtUniverse);
            this.Controls.Add(this.ddlType1);
            this.Controls.Add(this.txtTitle);
            this.Name = "CreateM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateM";
            this.Load += new System.EventHandler(this.CreateM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMovie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ComboBox ddlType1;
        private System.Windows.Forms.TextBox txtUniverse;
        private System.Windows.Forms.TextBox txtAction;
        private System.Windows.Forms.TextBox txtSex;
        private System.Windows.Forms.TextBox txtHumor;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtCitation;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGetFromImdb;
        private System.Windows.Forms.DataGridView dgMovie;
        private System.Windows.Forms.TextBox txtImDbLink;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtImDb_Link;
        private System.Windows.Forms.TextBox txtDirector;
        private System.Windows.Forms.TextBox txtWriter;
        private System.Windows.Forms.Button btnGotoWriter;
        private System.Windows.Forms.Button btnGoToDirector;
        private System.Windows.Forms.ListView lstActors;
        private System.Windows.Forms.Button btnAddActor;
        private System.Windows.Forms.TextBox txtActor;
        private System.Windows.Forms.Button btnRemoveActor;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblHumorName;
        private System.Windows.Forms.Label lblSexappealName;
        private System.Windows.Forms.Label lblActionName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCalculateSuccess;
        private System.Windows.Forms.TextBox txtSuccess;
        private System.Windows.Forms.TextBox txtBase_Audience;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkType;
        private System.Windows.Forms.DataGridViewTextBoxColumn A;
        private System.Windows.Forms.DataGridViewTextBoxColumn S;
        private System.Windows.Forms.DataGridViewTextBoxColumn H;
        private System.Windows.Forms.DataGridViewTextBoxColumn Success;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Citation;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkUniverse;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImDB_Link;
        private System.Windows.Forms.DataGridViewTextBoxColumn Base_Audience;
        private System.Windows.Forms.DataGridViewTextBoxColumn T_Success;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnCalculatePrice;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.ComboBox ddlType2;
        private System.Windows.Forms.ComboBox ddlType3;
        private System.Windows.Forms.ComboBox ddlType4;
        private System.Windows.Forms.Button btnCalcInnerValuesFromWriter;
        private System.Windows.Forms.Button btnRemoveWriter;
        private System.Windows.Forms.Button btnRemoveDirector;
        private System.Windows.Forms.ComboBox ddlTheatre;
        private System.Windows.Forms.ComboBox ddlSpecialEffect;
        private System.Windows.Forms.Button btnMngUniv;
        private System.Windows.Forms.Label lblUniverse;
        private System.Windows.Forms.CheckBox cbxShowReport;
    }
}