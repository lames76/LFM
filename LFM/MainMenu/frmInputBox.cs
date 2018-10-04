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
    public partial class frmInputBox : Form
    {
        public string strTesto = "";
        public string strOutPut { get; set; } = "";

        public bool IsNumeric = false;

        public frmInputBox()
        {
            InitializeComponent();
        }

        private void frmInputBox_Load(object sender, EventArgs e)
        {
            lblText.Text = strTesto;
            if (!strTesto.Contains(":"))
                lblText.Text += ":";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtInputBox.Text.Length == 0)
                MessageBox.Show("Devi inserire un testo!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (IsNumeric)
                {
                    bool blnIsNumber = int.TryParse(txtInputBox.Text, out int n);
                    if (blnIsNumber)
                    {
                        strOutPut = txtInputBox.Text;
                        this.DialogResult = DialogResult.OK;                        
                    }
                    else
                        MessageBox.Show("Devi inserire un numero", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtInputBox.Text.Contains(@"\") || txtInputBox.Text.Contains(@"/") ||
                        txtInputBox.Text.Contains(@"?") || txtInputBox.Text.Contains(@"*"))
                        MessageBox.Show("La stringa contiene caratteri invalidi", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        strOutPut = txtInputBox.Text;
                        this.DialogResult = DialogResult.OK;                        
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            strOutPut = "";
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
