using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LFM.MainGame.Report
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void btnReportMovie_Click(object sender, EventArgs e)
        {
            FormReport frmReport = new FormReport();
            frmReport.ShowDialog();
        }

        private void bntRapportiConAttori_Click(object sender, EventArgs e)
        {

        }

        private void btnRapportiConRegisti_Click(object sender, EventArgs e)
        {

        }

        private void btnFinance_Click(object sender, EventArgs e)
        {

        }
    }
}
