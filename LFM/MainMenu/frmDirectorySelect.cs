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

namespace LFM.MainMenu
{
    public partial class frmDirectorySelect : Form
    {
        public string strSelected { get; set; } = "";

        public frmDirectorySelect()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lstBox_DoubleClick_1(object sender, EventArgs e)
        {
            if (lstBox.SelectedIndices.Count == 1)
            {
                strSelected = lstBox.Items[lstBox.SelectedIndices[0]].Text;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (strSelected.Length > 0)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                if (lstBox.SelectedIndices.Count == 1)
                {
                    strSelected = lstBox.Items[lstBox.SelectedIndices[0]].Text;
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Prima selezionare un gioco", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmDirectorySelect_Load(object sender, EventArgs e)
        {
            string[] strGames = LFMUtils.GetGamesName();
            foreach (string s in strGames)
                lstBox.Items.Add(s);
        }
    }
}
