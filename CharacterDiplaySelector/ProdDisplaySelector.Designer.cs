namespace CharacterDiplaySelector
{
    partial class ProdDisplaySelector
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
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblCounter = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblUniverse = new System.Windows.Forms.Label();
            this.txtUniverse = new System.Windows.Forms.TextBox();
            this.lblDirector = new System.Windows.Forms.Label();
            this.lblWriter = new System.Windows.Forms.Label();
            this.btnGoToDirector = new System.Windows.Forms.Button();
            this.btnGotoWriter = new System.Windows.Forms.Button();
            this.txtWriter = new System.Windows.Forms.TextBox();
            this.txtDirector = new System.Windows.Forms.TextBox();
            this.txtCitation = new System.Windows.Forms.TextBox();
            this.ddlSpecialEffect = new System.Windows.Forms.ComboBox();
            this.ddlTheatre = new System.Windows.Forms.ComboBox();
            this.ddlType4 = new System.Windows.Forms.ComboBox();
            this.ddlType3 = new System.Windows.Forms.ComboBox();
            this.ddlType2 = new System.Windows.Forms.ComboBox();
            this.ddlType1 = new System.Windows.Forms.ComboBox();
            this.lblHumor = new System.Windows.Forms.Label();
            this.lblSexappeal = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lstActors = new System.Windows.Forms.ListView();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMovie)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.dgMovie);
            this.groupBox8.Controls.Add(this.btnClearFilter);
            this.groupBox8.Controls.Add(this.btnFilter);
            this.groupBox8.Controls.Add(this.txtFilter);
            this.groupBox8.Controls.Add(this.lblCounter);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox8.Location = new System.Drawing.Point(308, 0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(725, 398);
            this.groupBox8.TabIndex = 66;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "groupBox1";
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
            this.dgMovie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgMovie.Location = new System.Drawing.Point(3, 62);
            this.dgMovie.Name = "dgMovie";
            this.dgMovie.RowTemplate.Height = 24;
            this.dgMovie.Size = new System.Drawing.Size(719, 333);
            this.dgMovie.TabIndex = 67;
            this.dgMovie.DoubleClick += new System.EventHandler(this.dgMovie_DoubleClick);
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
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblUniverse);
            this.groupBox7.Controls.Add(this.txtUniverse);
            this.groupBox7.Controls.Add(this.lblDirector);
            this.groupBox7.Controls.Add(this.lblWriter);
            this.groupBox7.Controls.Add(this.btnGoToDirector);
            this.groupBox7.Controls.Add(this.btnGotoWriter);
            this.groupBox7.Controls.Add(this.txtWriter);
            this.groupBox7.Controls.Add(this.txtDirector);
            this.groupBox7.Controls.Add(this.txtCitation);
            this.groupBox7.Controls.Add(this.ddlSpecialEffect);
            this.groupBox7.Controls.Add(this.ddlTheatre);
            this.groupBox7.Controls.Add(this.ddlType4);
            this.groupBox7.Controls.Add(this.ddlType3);
            this.groupBox7.Controls.Add(this.ddlType2);
            this.groupBox7.Controls.Add(this.ddlType1);
            this.groupBox7.Controls.Add(this.lblHumor);
            this.groupBox7.Controls.Add(this.lblSexappeal);
            this.groupBox7.Controls.Add(this.lblAction);
            this.groupBox7.Controls.Add(this.label25);
            this.groupBox7.Controls.Add(this.label31);
            this.groupBox7.Controls.Add(this.label32);
            this.groupBox7.Controls.Add(this.label33);
            this.groupBox7.Controls.Add(this.txtAge);
            this.groupBox7.Controls.Add(this.txtDescription);
            this.groupBox7.Controls.Add(this.txtTitle);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(308, 654);
            this.groupBox7.TabIndex = 65;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "groupBox2";
            // 
            // lblUniverse
            // 
            this.lblUniverse.AutoSize = true;
            this.lblUniverse.Location = new System.Drawing.Point(8, 147);
            this.lblUniverse.Name = "lblUniverse";
            this.lblUniverse.Size = new System.Drawing.Size(22, 17);
            this.lblUniverse.TabIndex = 87;
            this.lblUniverse.Text = "U:";
            // 
            // txtUniverse
            // 
            this.txtUniverse.Location = new System.Drawing.Point(36, 144);
            this.txtUniverse.Name = "txtUniverse";
            this.txtUniverse.ReadOnly = true;
            this.txtUniverse.Size = new System.Drawing.Size(266, 22);
            this.txtUniverse.TabIndex = 86;
            // 
            // lblDirector
            // 
            this.lblDirector.AutoSize = true;
            this.lblDirector.Location = new System.Drawing.Point(8, 627);
            this.lblDirector.Name = "lblDirector";
            this.lblDirector.Size = new System.Drawing.Size(27, 17);
            this.lblDirector.TabIndex = 85;
            this.lblDirector.Text = "Dr:";
            // 
            // lblWriter
            // 
            this.lblWriter.AutoSize = true;
            this.lblWriter.Location = new System.Drawing.Point(8, 590);
            this.lblWriter.Name = "lblWriter";
            this.lblWriter.Size = new System.Drawing.Size(30, 17);
            this.lblWriter.TabIndex = 84;
            this.lblWriter.Text = "Wr:";
            // 
            // btnGoToDirector
            // 
            this.btnGoToDirector.Location = new System.Drawing.Point(260, 620);
            this.btnGoToDirector.Name = "btnGoToDirector";
            this.btnGoToDirector.Size = new System.Drawing.Size(42, 31);
            this.btnGoToDirector.TabIndex = 83;
            this.btnGoToDirector.Text = "Go";
            this.btnGoToDirector.UseVisualStyleBackColor = true;
            this.btnGoToDirector.Click += new System.EventHandler(this.btnGoToDirector_Click);
            // 
            // btnGotoWriter
            // 
            this.btnGotoWriter.Location = new System.Drawing.Point(260, 583);
            this.btnGotoWriter.Name = "btnGotoWriter";
            this.btnGotoWriter.Size = new System.Drawing.Size(42, 31);
            this.btnGotoWriter.TabIndex = 82;
            this.btnGotoWriter.Text = "Go";
            this.btnGotoWriter.UseVisualStyleBackColor = true;
            this.btnGotoWriter.Click += new System.EventHandler(this.btnGotoWriter_Click);
            // 
            // txtWriter
            // 
            this.txtWriter.Location = new System.Drawing.Point(48, 587);
            this.txtWriter.Name = "txtWriter";
            this.txtWriter.ReadOnly = true;
            this.txtWriter.Size = new System.Drawing.Size(206, 22);
            this.txtWriter.TabIndex = 81;
            // 
            // txtDirector
            // 
            this.txtDirector.Location = new System.Drawing.Point(48, 624);
            this.txtDirector.Name = "txtDirector";
            this.txtDirector.ReadOnly = true;
            this.txtDirector.Size = new System.Drawing.Size(206, 22);
            this.txtDirector.TabIndex = 80;
            // 
            // txtCitation
            // 
            this.txtCitation.Location = new System.Drawing.Point(6, 374);
            this.txtCitation.Multiline = true;
            this.txtCitation.Name = "txtCitation";
            this.txtCitation.ReadOnly = true;
            this.txtCitation.Size = new System.Drawing.Size(296, 57);
            this.txtCitation.TabIndex = 79;
            // 
            // ddlSpecialEffect
            // 
            this.ddlSpecialEffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSpecialEffect.FormattingEnabled = true;
            this.ddlSpecialEffect.Location = new System.Drawing.Point(6, 557);
            this.ddlSpecialEffect.Name = "ddlSpecialEffect";
            this.ddlSpecialEffect.Size = new System.Drawing.Size(296, 24);
            this.ddlSpecialEffect.TabIndex = 78;
            // 
            // ddlTheatre
            // 
            this.ddlTheatre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTheatre.FormattingEnabled = true;
            this.ddlTheatre.Location = new System.Drawing.Point(6, 527);
            this.ddlTheatre.Name = "ddlTheatre";
            this.ddlTheatre.Size = new System.Drawing.Size(296, 24);
            this.ddlTheatre.TabIndex = 77;
            // 
            // ddlType4
            // 
            this.ddlType4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlType4.FormattingEnabled = true;
            this.ddlType4.Location = new System.Drawing.Point(154, 106);
            this.ddlType4.Name = "ddlType4";
            this.ddlType4.Size = new System.Drawing.Size(148, 24);
            this.ddlType4.TabIndex = 76;
            // 
            // ddlType3
            // 
            this.ddlType3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlType3.FormattingEnabled = true;
            this.ddlType3.Location = new System.Drawing.Point(6, 106);
            this.ddlType3.Name = "ddlType3";
            this.ddlType3.Size = new System.Drawing.Size(148, 24);
            this.ddlType3.TabIndex = 75;
            // 
            // ddlType2
            // 
            this.ddlType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlType2.FormattingEnabled = true;
            this.ddlType2.Location = new System.Drawing.Point(154, 76);
            this.ddlType2.Name = "ddlType2";
            this.ddlType2.Size = new System.Drawing.Size(148, 24);
            this.ddlType2.TabIndex = 74;
            // 
            // ddlType1
            // 
            this.ddlType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlType1.FormattingEnabled = true;
            this.ddlType1.Location = new System.Drawing.Point(6, 76);
            this.ddlType1.Name = "ddlType1";
            this.ddlType1.Size = new System.Drawing.Size(148, 24);
            this.ddlType1.TabIndex = 73;
            // 
            // lblHumor
            // 
            this.lblHumor.AutoSize = true;
            this.lblHumor.Location = new System.Drawing.Point(49, 501);
            this.lblHumor.Name = "lblHumor";
            this.lblHumor.Size = new System.Drawing.Size(54, 17);
            this.lblHumor.TabIndex = 63;
            this.lblHumor.Text = "label11";
            // 
            // lblSexappeal
            // 
            this.lblSexappeal.AutoSize = true;
            this.lblSexappeal.Location = new System.Drawing.Point(49, 471);
            this.lblSexappeal.Name = "lblSexappeal";
            this.lblSexappeal.Size = new System.Drawing.Size(54, 17);
            this.lblSexappeal.TabIndex = 62;
            this.lblSexappeal.Text = "label10";
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Location = new System.Drawing.Point(49, 440);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(46, 17);
            this.lblAction.TabIndex = 61;
            this.lblAction.Text = "label9";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(200, 440);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(37, 17);
            this.label25.TabIndex = 59;
            this.label25.Text = "Age:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(9, 501);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(30, 17);
            this.label31.TabIndex = 56;
            this.label31.Text = "Hu:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(9, 471);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(29, 17);
            this.label32.TabIndex = 55;
            this.label32.Text = "Sh:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(9, 440);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(28, 17);
            this.label33.TabIndex = 54;
            this.label33.Text = "Ac:";
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(243, 437);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(59, 22);
            this.txtAge.TabIndex = 51;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(6, 172);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(299, 196);
            this.txtDescription.TabIndex = 42;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(6, 22);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(296, 48);
            this.txtTitle.TabIndex = 41;
            // 
            // lstActors
            // 
            this.lstActors.LabelWrap = false;
            this.lstActors.Location = new System.Drawing.Point(314, 401);
            this.lstActors.MultiSelect = false;
            this.lstActors.Name = "lstActors";
            this.lstActors.Size = new System.Drawing.Size(713, 250);
            this.lstActors.TabIndex = 67;
            this.lstActors.UseCompatibleStateImageBehavior = false;
            this.lstActors.View = System.Windows.Forms.View.List;
            this.lstActors.DoubleClick += new System.EventHandler(this.lstActors_DoubleClick);
            // 
            // ProdDisplaySelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstActors);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Name = "ProdDisplaySelector";
            this.Size = new System.Drawing.Size(1033, 654);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMovie)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBox8;
        public System.Windows.Forms.Button btnClearFilter;
        public System.Windows.Forms.Button btnFilter;
        public System.Windows.Forms.TextBox txtFilter;
        public System.Windows.Forms.Label lblCounter;
        public System.Windows.Forms.GroupBox groupBox7;
        public System.Windows.Forms.Label lblHumor;
        public System.Windows.Forms.Label lblSexappeal;
        public System.Windows.Forms.Label lblAction;
        public System.Windows.Forms.Label label25;
        public System.Windows.Forms.Label label31;
        public System.Windows.Forms.Label label32;
        public System.Windows.Forms.Label label33;
        public System.Windows.Forms.TextBox txtAge;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.DataGridView dgMovie;
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
        private System.Windows.Forms.ComboBox ddlType4;
        private System.Windows.Forms.ComboBox ddlType3;
        private System.Windows.Forms.ComboBox ddlType2;
        private System.Windows.Forms.ComboBox ddlType1;
        private System.Windows.Forms.ComboBox ddlSpecialEffect;
        private System.Windows.Forms.ComboBox ddlTheatre;
        private System.Windows.Forms.TextBox txtCitation;
        private System.Windows.Forms.Label lblDirector;
        private System.Windows.Forms.Label lblWriter;
        private System.Windows.Forms.Button btnGoToDirector;
        private System.Windows.Forms.Button btnGotoWriter;
        private System.Windows.Forms.TextBox txtWriter;
        private System.Windows.Forms.TextBox txtDirector;
        private System.Windows.Forms.ListView lstActors;
        private System.Windows.Forms.Label lblUniverse;
        private System.Windows.Forms.TextBox txtUniverse;
    }
}
