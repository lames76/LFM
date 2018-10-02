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
    public partial class TestMC : Form
    {
        private TypeOfMovie[] Typo;
        private GenericCharacters Gen;
        public TestMC()
        {
            InitializeComponent();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int selectedrowindex = dgWriters.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgWriters.Rows[selectedrowindex];
            int intIDWri = Convert.ToInt32(selectedRow.Cells[0].Value);
            Gen = new GenericCharacters(intIDWri);
            lblWriter.Text = Gen.Name + " " + Gen.Surname;
        }

        private void btnSetType_Click(object sender, EventArgs e)
        {
            Typo = new TypeOfMovie[3];
            int intTypeID = Convert.ToInt32(ddlType1.SelectedValue);
            lblType.Text = ddlType1.Text;
            Typo[0] = new TypeOfMovie(intTypeID);
            intTypeID = Convert.ToInt32(ddlType2.SelectedValue);
            lblType.Text += " " + ddlType2.Text;
            Typo[1] = new TypeOfMovie(intTypeID);
            intTypeID = Convert.ToInt32(ddlType3.SelectedValue);
            lblType.Text += " " + ddlType3.Text;
            Typo[2] = new TypeOfMovie(intTypeID);
        }

        private void btnGenScriptMovie_Click(object sender, EventArgs e)
        {
            long Price = 0;
            Movie newMov = Calculation.CreateMovieFromWriter(Gen, Typo, 2018, out Price);
            lblCost.Text = Price.ToString();
            List<Movie> MyList = new List<Movie>();
            MyList.Add(newMov);
            dgGenMovie.DataSource = MyList;
            //CalculateFilming
        }

        private void TestMC_Load(object sender, EventArgs e)
        {
            lblCost.Text = "0";
            dgWriters.DataSource = Retriever.GetCharactersByType("Writer");
            ddlType1.DataSource = DbRuler.Retriever.GetTypeOfMovies();
            ddlType1.DisplayMember = "TypeOf";
            ddlType1.ValueMember = "ID";
        }
    }
}
