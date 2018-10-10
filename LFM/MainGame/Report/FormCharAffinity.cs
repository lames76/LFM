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
    public partial class FormCharAffinity : Form
    {
        public LG_MainGameData MainGameData { private get;  set; }
        public List<GenericCharacters> ListGen { get; set; }
        public FormCharAffinity()
        {
            InitializeComponent();
        }

        private void FormCharAffinity_Load(object sender, EventArgs e)
        {
            foreach (GenericCharacters G in ListGen)
            {
                lstChars.Items.Add(G.Name + " " + G.Surname);
            }
        }

        private void lstChars_DoubleClick(object sender, EventArgs e)
        {
            if (lstChars.SelectedIndices.Count == 1)
            {
                LG_CharPlayerAffinity Link = new LG_CharPlayerAffinity(ListGen[lstChars.SelectedIndices[0]].ID);
                Gestione.DisplayChar frmDispl = new Gestione.DisplayChar();
                frmDispl.Gener = ListGen[lstChars.SelectedIndices[0]];
                frmDispl.IsAgingOn = MainGameData.AgingOn;
                frmDispl.Year = MainGameData.Year;
                string ValueName = LFMGamePlay.GetAffinityNameFromValue(Link.Affinity);
                string strMessage = "I miei rapporti con te sono " + ValueName;
                frmDispl.Show();
                MessageBox.Show(strMessage);
                frmDispl.Close();
            }
        }
    }
}
