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
        public Operativita()
        {
            InitializeComponent();
        }

        private void btnProduceFilm_Click(object sender, EventArgs e)
        {
            Produzione frmProd = new Produzione();
            frmProd.IsMovie = true;
            frmProd.ShowDialog();
        }

        private void btnProduceSerial_Click(object sender, EventArgs e)
        {
            Produzione frmProd = new Produzione();
            frmProd.IsMovie = false;
            frmProd.ShowDialog();
        }
    }
}
