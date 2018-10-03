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

namespace LFM.MainGame.Operativita
{
    public partial class Operativita : Form
    {
        public long TotalPrice { get; set; }
        public long Balance { get; set; }
        public Movie MyMovie { get; set; }
        public Serial MySerial { get; set; }

        public Operativita()
        {
            InitializeComponent();
        }

        private void btnProduceFilm_Click(object sender, EventArgs e)
        {
            GenreSelector frmScelta = new GenreSelector();
            frmScelta.Balance = Balance;
            this.Hide();
            DialogResult Res = frmScelta.ShowDialog();
            if (Res == DialogResult.OK)
            {
                if (frmScelta.blnIsMovie)
                    MyMovie = frmScelta.MyMovie;
                else
                    MySerial = frmScelta.MySerial;
                TotalPrice = frmScelta.TotalPrice;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
