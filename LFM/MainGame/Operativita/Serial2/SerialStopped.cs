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

namespace LFM.MainGame.Operativita.Serial2
{
    public partial class SerialStopped : Form
    {
        public Serial MySerial { get; set; }
        public long Balance { get; set; }
        public List<LastCashMovement> ListTotalCost { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Week { get; set; }
        public bool IsAgingOn { get; set; }
        public long TotalPrice { get; set; }

        public SerialStopped()
        {
            InitializeComponent();
        }

        private void SerialStopped_Load(object sender, EventArgs e)
        {
            List<Serial> GenLista = LFMGamePlay.GetSerialsOfPlayer(false);
            dgSerials.DataSource = GenLista;
        }

        private void dgSerials_DoubleClick(object sender, EventArgs e)
        {
            int selectedrowindex = dgSerials.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgSerials.Rows[selectedrowindex];
            int intID = Convert.ToInt32(selectedRow.Cells[0].Value);
            OtherSeasons frmOther = new OtherSeasons();
            frmOther.MySerialID = intID;
            frmOther.IsAgingOn = IsAgingOn;
                 frmOther.Balance = Balance;
            frmOther.ListTotalCost = ListTotalCost;
            frmOther.Year = Year;
            frmOther.Month = Month;
            frmOther.Week = Week;
            frmOther.lngTOTALPrice = 0;
            this.Hide();
            DialogResult Res = frmOther.ShowDialog();
            if (Res == DialogResult.OK)
            {
                TotalPrice = frmOther.lngTOTALPrice;
                MySerial = new Serial(intID);
                ListTotalCost = frmOther.ListTotalCost;
            }
            this.Close();
        }
    }
}
