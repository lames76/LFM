namespace LFM.MainGame.Gestione
{
    partial class MovieProd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieProd));
            this.prodDisplaySelector1 = new CharacterDiplaySelector.ProdDisplaySelector();
            this.SuspendLayout();
            // 
            // prodDisplaySelector1
            // 
            this.prodDisplaySelector1.Actor = null;
            this.prodDisplaySelector1.Director = null;
            this.prodDisplaySelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prodDisplaySelector1.Gener = null;
            this.prodDisplaySelector1.HideBusy = false;
            this.prodDisplaySelector1.IsAgingOn = false;
            this.prodDisplaySelector1.IsMovie = false;
            this.prodDisplaySelector1.ListOfTypes = null;
            this.prodDisplaySelector1.Location = new System.Drawing.Point(0, 0);
            this.prodDisplaySelector1.MyMovie = null;
            this.prodDisplaySelector1.MySerial = null;
            this.prodDisplaySelector1.Name = "prodDisplaySelector1";
            this.prodDisplaySelector1.Price = ((long)(0));
            this.prodDisplaySelector1.Size = new System.Drawing.Size(1025, 654);
            this.prodDisplaySelector1.TabIndex = 0;
            this.prodDisplaySelector1.Writer = null;
            this.prodDisplaySelector1.Year = 0;
            // 
            // MovieProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 654);
            this.Controls.Add(this.prodDisplaySelector1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MovieProd";
            this.Text = "Movie Prod";
            this.Load += new System.EventHandler(this.MovieProd_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CharacterDiplaySelector.ProdDisplaySelector prodDisplaySelector1;
    }
}