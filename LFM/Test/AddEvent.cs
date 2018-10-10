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


namespace LFM.Test
{
    public partial class AddEvent : Form
    {
        public AddEvent()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LG_RandomEventClass Lg = new LG_RandomEventClass(-1);
            long lngValue = Convert.ToInt64(txtValue.Text);
            Lg.Name = txtName.Text;
            Lg.Description = txtDescription.Text;
            Lg.Value = lngValue;
            Lg.isBonus = cbxIsBonus.Checked;
            if (Lg.AddEvent())
            {
                MessageBox.Show("ok");
                ClearAll();
            }
        }

        private void ClearAll()
        {
            txtDescription.Text = "";
            txtName.Text = "";
            txtValue.Text = "";
            cbxIsBonus.Checked = false;
        }
    }
}
