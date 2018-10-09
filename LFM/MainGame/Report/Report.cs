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

namespace LFM.MainGame.Report
{
    public partial class Report : Form
    {
        public LG_CashMovement Bank { private get; set; }

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
            TypeOfCharacters t1 = new TypeOfCharacters(4);
            TypeOfCharacters t2 = new TypeOfCharacters(5);
            List<GenericCharacters> ListGen = Retriever.GetWhoPlayForMeInThePast(t1, t2);
            FormCharAffinity frmAct = new FormCharAffinity();
            frmAct.ListGen = ListGen;
            frmAct.ShowDialog();
        }

        private void btnRapportiConRegisti_Click(object sender, EventArgs e)
        {
            TypeOfCharacters t = new TypeOfCharacters(2);
            List<GenericCharacters> ListGen = Retriever.GetWhoPlayForMeInThePast(t);
            FormCharAffinity frmAct = new FormCharAffinity();
            frmAct.ListGen = ListGen;
            frmAct.ShowDialog();
        }

        private void btnFinance_Click(object sender, EventArgs e)
        {
            FormReport frmReport = new FormReport();
            frmReport.IsSimpleDisplayer = true;
            frmReport.tblDatiReport = LFMReportManager.GetBankMovementDatatable();
            frmReport.ShowDialog();
        }
    }
}
