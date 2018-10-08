using DbRuler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LFM.MainGame.Gestione
{
    public partial class MovieProd : Form
    {
        public bool IsMovie { get; set; }
        public bool IsAgingOn { get; set; }
        public int Year { get; set; }

        public MovieProd()
        {
            InitializeComponent();
            
            prodDisplaySelector1.onActorSelected += new EventHandler(OnCharSelectedActor);
            prodDisplaySelector1.onWriterSelected += new EventHandler(OnCharSelectedWriter);
            prodDisplaySelector1.onDirectorSelected += new EventHandler(OnCharSelectedDirector);
        }

        protected void OnCharSelectedActor(object sender, EventArgs e)
        {
            GenericCharacters Actor = new GenericCharacters(prodDisplaySelector1.Actor.ID);
            DisplayChar frmDispl = new DisplayChar();
            frmDispl.Gener = Actor;
            frmDispl.IsAgingOn = IsAgingOn;
            frmDispl.Year = Year;
            frmDispl.AC = AgeClass.Average;
            frmDispl.Price = prodDisplaySelector1.Price;
            frmDispl.MyMovie = prodDisplaySelector1.MyMovie;
            frmDispl.MySerial = prodDisplaySelector1.MySerial;
            frmDispl.IsMovie = IsMovie;
            frmDispl.ShowDialog();
        }
        protected void OnCharSelectedWriter(object sender, EventArgs e)
        {
            GenericCharacters Writer = new GenericCharacters(prodDisplaySelector1.Writer.ID);
            DisplayChar frmDispl = new DisplayChar();
            frmDispl.Gener = Writer;
            frmDispl.IsAgingOn = IsAgingOn;
            frmDispl.Year = Year;
            frmDispl.AC = AgeClass.Average;
            frmDispl.Price = prodDisplaySelector1.Price;
            frmDispl.MyMovie = prodDisplaySelector1.MyMovie;
            frmDispl.MySerial = prodDisplaySelector1.MySerial;
            frmDispl.IsMovie = IsMovie;
            frmDispl.ShowDialog();
        }
        protected void OnCharSelectedDirector(object sender, EventArgs e)
        {
            GenericCharacters Director = new GenericCharacters(prodDisplaySelector1.Director.ID);
            DisplayChar frmDispl = new DisplayChar();
            frmDispl.Gener = Director;
            frmDispl.IsAgingOn = IsAgingOn;
            frmDispl.Year = Year;
            frmDispl.AC = AgeClass.Average;
            frmDispl.Price = prodDisplaySelector1.Price;
            frmDispl.MyMovie = prodDisplaySelector1.MyMovie;
            frmDispl.MySerial = prodDisplaySelector1.MySerial;
            frmDispl.IsMovie = IsMovie;
            frmDispl.ShowDialog();
        }

        private void MovieProd_Load(object sender, EventArgs e)
        {
            prodDisplaySelector1.IsMovie = IsMovie;
            prodDisplaySelector1.IsAgingOn = IsAgingOn;
            prodDisplaySelector1.Year = Year;
        }
    }
}
