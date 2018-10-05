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
        public bool IsAgingOn {get;set;}
        public List<LastCashMovement> ListTotalCost { get; set; }
        public long TotalPrice { get; set; }
        public long Balance { get; set; }
        public bool IsMovie { get; set; } = true;
        public Movie MyMovie { get; set; }
        public Serial MySerial { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Week { get; set; }

        public Operativita()
        {
            InitializeComponent();
        }

        private void btnProduceFilm_Click(object sender, EventArgs e)
        {
            GenreSelector frmScelta = new GenreSelector();
            frmScelta.Balance = Balance;
            frmScelta.Year = Year;
            frmScelta.Month = Month;
            frmScelta.Week = Week;
            frmScelta.IsAgingOn = IsAgingOn;
            this.Hide();
            DialogResult Res = frmScelta.ShowDialog();
            if (Res == DialogResult.OK)
            {
                if (frmScelta.blnIsMovie)
                    MyMovie = frmScelta.MyMovie;
                else
                    MySerial = frmScelta.MySerial;
                TotalPrice = frmScelta.TotalPrice;
                IsMovie = frmScelta.blnIsMovie;
                ListTotalCost = frmScelta.ListTotalCost;
                this.DialogResult = DialogResult.OK;
            }
            else
                this.DialogResult = DialogResult.Cancel;
        }

        private void btnContinueSerial_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented!");
        }

        private void btnSequelAndReboot_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented!");
        }
    }
}
