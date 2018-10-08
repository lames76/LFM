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
    public partial class DisplayChar : Form
    {
        public GenericCharacters Gener { get; set; }
        public bool IsAgingOn { get; set; }
        public int Year { get; set; }
        public AgeClass AC { get; set; }
        public long Price { get; set; }
        public Movie MyMovie { get; set; }
        public Serial MySerial { get; set; }
        public bool IsMovie { get; set; }

        public DisplayChar()
        {
            InitializeComponent();
        }

        private void DisplayChar_Load(object sender, EventArgs e)
        {
            charDisplayer1.Gener = Gener;
            charDisplayer1.AC = AC;
            charDisplayer1.MyMovie = MyMovie;
            charDisplayer1.MySerial = MySerial;
            charDisplayer1.IsMovie = IsMovie;
            charDisplayer1.Year = Year;
            charDisplayer1.IsAgingOn = IsAgingOn;
            charDisplayer1.Price = Price;
            charDisplayer1.CharacterTypeInternal = (CharTypeEnum)Gener.TypeOf.ID;
            charDisplayer1.LoadDataAfterClick(Gener.ID);
        }
    }
}
