namespace LFM.MainGame.Operativita
{
    partial class GenreSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenreSelector));
            this.gbxTipo = new System.Windows.Forms.GroupBox();
            this.gbxGenre = new System.Windows.Forms.GroupBox();
            this.rbtMovie = new System.Windows.Forms.RadioButton();
            this.rbtSerial = new System.Windows.Forms.RadioButton();
            this.ddlType4 = new System.Windows.Forms.ComboBox();
            this.ddlType3 = new System.Windows.Forms.ComboBox();
            this.ddlType2 = new System.Windows.Forms.ComboBox();
            this.ddlType1 = new System.Windows.Forms.ComboBox();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbxTipo.SuspendLayout();
            this.gbxGenre.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxTipo
            // 
            this.gbxTipo.Controls.Add(this.rbtSerial);
            this.gbxTipo.Controls.Add(this.rbtMovie);
            this.gbxTipo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxTipo.Location = new System.Drawing.Point(0, 0);
            this.gbxTipo.Name = "gbxTipo";
            this.gbxTipo.Size = new System.Drawing.Size(271, 76);
            this.gbxTipo.TabIndex = 0;
            this.gbxTipo.TabStop = false;
            // 
            // gbxGenre
            // 
            this.gbxGenre.Controls.Add(this.ddlType4);
            this.gbxGenre.Controls.Add(this.ddlType3);
            this.gbxGenre.Controls.Add(this.ddlType2);
            this.gbxGenre.Controls.Add(this.ddlType1);
            this.gbxGenre.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxGenre.Location = new System.Drawing.Point(0, 76);
            this.gbxGenre.Name = "gbxGenre";
            this.gbxGenre.Size = new System.Drawing.Size(271, 100);
            this.gbxGenre.TabIndex = 1;
            this.gbxGenre.TabStop = false;
            // 
            // rbtMovie
            // 
            this.rbtMovie.AutoSize = true;
            this.rbtMovie.Location = new System.Drawing.Point(30, 30);
            this.rbtMovie.Name = "rbtMovie";
            this.rbtMovie.Size = new System.Drawing.Size(54, 21);
            this.rbtMovie.TabIndex = 0;
            this.rbtMovie.TabStop = true;
            this.rbtMovie.Text = "Film";
            this.rbtMovie.UseVisualStyleBackColor = true;
            this.rbtMovie.CheckedChanged += new System.EventHandler(this.rbtMovie_CheckedChanged);
            // 
            // rbtSerial
            // 
            this.rbtSerial.AutoSize = true;
            this.rbtSerial.Location = new System.Drawing.Point(171, 30);
            this.rbtSerial.Name = "rbtSerial";
            this.rbtSerial.Size = new System.Drawing.Size(65, 21);
            this.rbtSerial.TabIndex = 1;
            this.rbtSerial.TabStop = true;
            this.rbtSerial.Text = "Serial";
            this.rbtSerial.UseVisualStyleBackColor = true;
            this.rbtSerial.CheckedChanged += new System.EventHandler(this.rbtSerial_CheckedChanged);
            // 
            // ddlType4
            // 
            this.ddlType4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlType4.FormattingEnabled = true;
            this.ddlType4.Location = new System.Drawing.Point(159, 52);
            this.ddlType4.Name = "ddlType4";
            this.ddlType4.Size = new System.Drawing.Size(103, 24);
            this.ddlType4.TabIndex = 58;
            // 
            // ddlType3
            // 
            this.ddlType3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlType3.FormattingEnabled = true;
            this.ddlType3.Location = new System.Drawing.Point(12, 52);
            this.ddlType3.Name = "ddlType3";
            this.ddlType3.Size = new System.Drawing.Size(103, 24);
            this.ddlType3.TabIndex = 57;
            // 
            // ddlType2
            // 
            this.ddlType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlType2.FormattingEnabled = true;
            this.ddlType2.Location = new System.Drawing.Point(159, 21);
            this.ddlType2.Name = "ddlType2";
            this.ddlType2.Size = new System.Drawing.Size(103, 24);
            this.ddlType2.TabIndex = 56;
            // 
            // ddlType1
            // 
            this.ddlType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlType1.FormattingEnabled = true;
            this.ddlType1.Location = new System.Drawing.Point(12, 22);
            this.ddlType1.Name = "ddlType1";
            this.ddlType1.Size = new System.Drawing.Size(103, 24);
            this.ddlType1.TabIndex = 55;
            // 
            // btnForward
            // 
            this.btnForward.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnForward.Location = new System.Drawing.Point(0, 176);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(115, 66);
            this.btnForward.TabIndex = 2;
            this.btnForward.Text = "Avanti";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(159, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 66);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancella";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // GenreSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 242);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.gbxGenre);
            this.Controls.Add(this.gbxTipo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenreSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GenreSelector";
            this.Load += new System.EventHandler(this.GenreSelector_Load);
            this.gbxTipo.ResumeLayout(false);
            this.gbxTipo.PerformLayout();
            this.gbxGenre.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxTipo;
        private System.Windows.Forms.RadioButton rbtSerial;
        private System.Windows.Forms.RadioButton rbtMovie;
        private System.Windows.Forms.GroupBox gbxGenre;
        private System.Windows.Forms.ComboBox ddlType4;
        private System.Windows.Forms.ComboBox ddlType3;
        private System.Windows.Forms.ComboBox ddlType2;
        private System.Windows.Forms.ComboBox ddlType1;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnCancel;
    }
}