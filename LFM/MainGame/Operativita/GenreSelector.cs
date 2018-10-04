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
    public partial class GenreSelector : Form
    {
        public bool IsAgingOn { get; set; }
        public List<LastCashMovement> ListTotalCost { get; set; }
        public bool blnIsMovie { get; set; }
        public long TotalPrice { get; set; }
        public long Balance { get; set; }
        public Movie MyMovie { get; set; }
        public Serial MySerial { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Week { get; set; }

        public GenreSelector()
        {
            InitializeComponent();
        }

        private void rbtMovie_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbtMovie.Checked)
            {
                ddlType3.Visible = false;
                ddlType3.SelectedIndex = -1;
                ddlType4.Visible = false;
                ddlType4.SelectedIndex = -1;
            }
        }

        private void rbtSerial_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtSerial.Checked)
            {
                ddlType3.Visible = false;
                ddlType3.SelectedIndex = -1;
                ddlType4.Visible = false;
                ddlType4.SelectedIndex = -1;
            }
        }

        private void GenreSelector_Load(object sender, EventArgs e)
        {
            DataTable MyList = DbRuler.Retriever.GetTypeOfMoviesTable(true);

            ddlType1.DisplayMember = "TypeOf";
            ddlType1.ValueMember = "ID";
            ddlType1.DataSource = MyList;

            MyList = new DataTable();
            MyList = DbRuler.Retriever.GetTypeOfMoviesTable(true);
            ddlType2.DisplayMember = "TypeOf";
            ddlType2.ValueMember = "ID";
            ddlType2.DataSource = MyList;

            MyList = new DataTable();
            MyList = DbRuler.Retriever.GetTypeOfMoviesTable(true);
            ddlType3.DisplayMember = "TypeOf";
            ddlType3.ValueMember = "ID";
            ddlType3.DataSource = MyList;

            MyList = new DataTable();
            MyList = DbRuler.Retriever.GetTypeOfMoviesTable(true);
            ddlType4.DisplayMember = "TypeOf";
            ddlType4.ValueMember = "ID";
            ddlType4.DataSource = MyList;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
             this.DialogResult = DialogResult.Cancel;
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (ddlType1.SelectedIndex > 0)
            {
                blnIsMovie = rbtMovie.Checked;
                int intNumber = (blnIsMovie ? 4 : 2);
                TypeOfMovie[] MyTypeList = new TypeOfMovie[intNumber];
                MyTypeList[0] = new TypeOfMovie(Convert.ToInt32(ddlType1.SelectedValue));
                if (ddlType2.SelectedIndex > 0)
                    MyTypeList[1] = new TypeOfMovie(Convert.ToInt32(ddlType2.SelectedValue));
                if ((ddlType3.SelectedIndex > 0) && (intNumber > 2))
                    MyTypeList[2] = new TypeOfMovie(Convert.ToInt32(ddlType3.SelectedValue));
                if ((ddlType4.SelectedIndex > 0) && (intNumber > 2))
                    MyTypeList[3] = new TypeOfMovie(Convert.ToInt32(ddlType4.SelectedValue));
                Produzione frmPro = new Produzione();
                frmPro.IsMovie = blnIsMovie;
                frmPro.ListOfTypes = MyTypeList;
                frmPro.Balance = Balance;
                frmPro.Year = Year;
                frmPro.Month = Month;
                frmPro.Week = Week;
                frmPro.IsAgingOn = IsAgingOn;
                this.Hide();
                DialogResult Res = frmPro.ShowDialog();
                if (Res == DialogResult.OK)
                {
                    if (blnIsMovie)
                        MyMovie = frmPro.MyMovie;
                    else
                        MySerial = frmPro.MySerial;
                    TotalPrice = frmPro.lngTOTALPrice;
                    ListTotalCost = frmPro.ListTotalCost;
                    this.DialogResult = DialogResult.OK;
                }
                else
                    this.DialogResult = DialogResult.Cancel;
                
            }
            else
                MessageBox.Show("Devi selezionare almeno un genere","Errore",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
