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

namespace LFM
{
    public partial class UniverseManager : Form
    {
        public int SelectedID { get; set; } = 0;
        public string NewUniverse { get; set; }

        public UniverseManager()
        {
            InitializeComponent();
        }


        private void Universe_Manager_Load(object sender, EventArgs e)
        {
            if (NewUniverse.Length > 0)
            {
                Universes Uni = new Universes(NewUniverse);
                if (Uni.ID > 0)
                    SelectedID = Uni.ID;
                else
                    Uni.Save();
                txtFilter.Text = Uni.Name;
            }
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            lblCounter.Text = "";
            if (txtFilter.Text.Length > 0)
                dgUniverses.DataSource = Retriever.GetUniverseFromName(txtFilter.Text);
            else
                dgUniverses.DataSource = Retriever.GetUniverses();
            lblCounter.Text = dgUniverses.Rows.Count.ToString();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";            
            RefreshGrid();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string strName = txtFilter.Text;
            Universes Uni = new Universes(strName);
            if (Uni.ID > 0)
                MessageBox.Show("Universo già esistente!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Uni.Save();
                RefreshGrid();
            }
        }

        private void dgUniverses_DoubleClick(object sender, EventArgs e)
        {
            int selectedrowindex = dgUniverses.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgUniverses.Rows[selectedrowindex];
            SelectedID = Convert.ToInt32(selectedRow.Cells[0].Value);
            this.DialogResult = DialogResult.OK;
        }

        private void UniverseManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SelectedID > 0)
                this.DialogResult = DialogResult.OK;
        }
    }
}
