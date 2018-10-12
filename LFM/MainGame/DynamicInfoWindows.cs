using CharacterDiplaySelector;
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

namespace LFM.MainGame
{
    public partial class DynamicInfoWindows : Form
    {
        public Movie MyMovie { get; set; }
        public Serial MySerial { get; set; }
        public bool IsAMovie { get; set; }
        public string Testo { get; set; }

        public DynamicInfoWindows()
        {
            InitializeComponent();
        }

        private void DynamicInfoWindows_Load(object sender, EventArgs e)
        {
            txtTesto.Text = Testo;
            MovieInfo MyControl = new MovieInfo();
            MyControl.IsAMovie = IsAMovie;
            MyControl.MyMovie = MyMovie;
            MyControl.MySerial = MySerial;
            MyControl.Dock = DockStyle.Fill;
            this.Controls.Add(MyControl);            
        }
    }
}
