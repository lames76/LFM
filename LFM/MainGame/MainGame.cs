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
    public partial class MainGame : Form
    {
        public MainGame()
        {
            InitializeComponent();
        }

        private void btnOperatività_Click(object sender, EventArgs e)
        {
            Operativita.Operativita frmOp = new Operativita.Operativita();
            frmOp.ShowDialog();
        }

        private void btnGestione_Click(object sender, EventArgs e)
        {
            Gestione.Gestione frmGest = new Gestione.Gestione();
            frmGest.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Report.Report frmRep = new Report.Report();
            frmRep.ShowDialog();
        }
    }
}
