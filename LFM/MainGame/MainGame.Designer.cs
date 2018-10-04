namespace LFM.MainGame
{
    partial class MainGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGame));
            this.btnOperatività = new System.Windows.Forms.Button();
            this.btnGestione = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.lblStudios = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.txtStudiosName = new System.Windows.Forms.RichTextBox();
            this.txtBalance = new System.Windows.Forms.RichTextBox();
            this.txtPlayerName = new System.Windows.Forms.RichTextBox();
            this.txtYear = new System.Windows.Forms.RichTextBox();
            this.txtMonth = new System.Windows.Forms.RichTextBox();
            this.txtWeek = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOperatività
            // 
            this.btnOperatività.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOperatività.Location = new System.Drawing.Point(12, 106);
            this.btnOperatività.Name = "btnOperatività";
            this.btnOperatività.Size = new System.Drawing.Size(690, 100);
            this.btnOperatività.TabIndex = 0;
            this.btnOperatività.Text = "Operatività";
            this.btnOperatività.UseVisualStyleBackColor = true;
            this.btnOperatività.Click += new System.EventHandler(this.btnOperatività_Click);
            // 
            // btnGestione
            // 
            this.btnGestione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGestione.Location = new System.Drawing.Point(12, 222);
            this.btnGestione.Name = "btnGestione";
            this.btnGestione.Size = new System.Drawing.Size(690, 100);
            this.btnGestione.TabIndex = 1;
            this.btnGestione.Text = "Gestione";
            this.btnGestione.UseVisualStyleBackColor = true;
            this.btnGestione.Click += new System.EventHandler(this.btnGestione_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Location = new System.Drawing.Point(12, 340);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(690, 100);
            this.btnReport.TabIndex = 2;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtWeek);
            this.groupBox1.Controls.Add(this.txtMonth);
            this.groupBox1.Controls.Add(this.txtYear);
            this.groupBox1.Controls.Add(this.txtPlayerName);
            this.groupBox1.Controls.Add(this.txtBalance);
            this.groupBox1.Controls.Add(this.txtStudiosName);
            this.groupBox1.Controls.Add(this.lblBalance);
            this.groupBox1.Controls.Add(this.lblStudios);
            this.groupBox1.Controls.Add(this.lblPlayer);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game Data:";
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer.Location = new System.Drawing.Point(12, 27);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(68, 20);
            this.lblPlayer.TabIndex = 0;
            this.lblPlayer.Text = "Player:";
            // 
            // lblStudios
            // 
            this.lblStudios.AutoSize = true;
            this.lblStudios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudios.Location = new System.Drawing.Point(12, 65);
            this.lblStudios.Name = "lblStudios";
            this.lblStudios.Size = new System.Drawing.Size(78, 20);
            this.lblStudios.TabIndex = 1;
            this.lblStudios.Text = "Studios:";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(368, 29);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(83, 20);
            this.lblBalance.TabIndex = 2;
            this.lblBalance.Text = "Balance:";
            // 
            // txtStudiosName
            // 
            this.txtStudiosName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStudiosName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudiosName.Location = new System.Drawing.Point(98, 65);
            this.txtStudiosName.Multiline = false;
            this.txtStudiosName.Name = "txtStudiosName";
            this.txtStudiosName.ReadOnly = true;
            this.txtStudiosName.Size = new System.Drawing.Size(250, 22);
            this.txtStudiosName.TabIndex = 4;
            this.txtStudiosName.Text = "";
            this.txtStudiosName.WordWrap = false;
            // 
            // txtBalance
            // 
            this.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.Location = new System.Drawing.Point(457, 29);
            this.txtBalance.Multiline = false;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(250, 22);
            this.txtBalance.TabIndex = 5;
            this.txtBalance.Text = "";
            this.txtBalance.WordWrap = false;
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlayerName.Location = new System.Drawing.Point(98, 27);
            this.txtPlayerName.Multiline = false;
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.ReadOnly = true;
            this.txtPlayerName.Size = new System.Drawing.Size(250, 22);
            this.txtPlayerName.TabIndex = 6;
            this.txtPlayerName.Text = "";
            this.txtPlayerName.WordWrap = false;
            // 
            // txtYear
            // 
            this.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYear.Location = new System.Drawing.Point(497, 65);
            this.txtYear.Multiline = false;
            this.txtYear.Name = "txtYear";
            this.txtYear.ReadOnly = true;
            this.txtYear.Size = new System.Drawing.Size(50, 22);
            this.txtYear.TabIndex = 7;
            this.txtYear.Text = "YYYY";
            this.txtYear.WordWrap = false;
            // 
            // txtMonth
            // 
            this.txtMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonth.Location = new System.Drawing.Point(372, 65);
            this.txtMonth.Multiline = false;
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.ReadOnly = true;
            this.txtMonth.Size = new System.Drawing.Size(110, 22);
            this.txtMonth.TabIndex = 8;
            this.txtMonth.Text = "SETTEMBRE";
            this.txtMonth.WordWrap = false;
            // 
            // txtWeek
            // 
            this.txtWeek.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeek.Location = new System.Drawing.Point(677, 65);
            this.txtWeek.Multiline = false;
            this.txtWeek.Name = "txtWeek";
            this.txtWeek.ReadOnly = true;
            this.txtWeek.Size = new System.Drawing.Size(25, 22);
            this.txtWeek.TabIndex = 9;
            this.txtWeek.Text = "4";
            this.txtWeek.WordWrap = false;
            // 
            // MainGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 454);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnGestione);
            this.Controls.Add(this.btnOperatività);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainGame_FormClosing);
            this.Load += new System.EventHandler(this.MainGame_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOperatività;
        private System.Windows.Forms.Button btnGestione;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtBalance;
        private System.Windows.Forms.RichTextBox txtStudiosName;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblStudios;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.RichTextBox txtPlayerName;
        private System.Windows.Forms.RichTextBox txtYear;
        private System.Windows.Forms.RichTextBox txtWeek;
        private System.Windows.Forms.RichTextBox txtMonth;
    }
}