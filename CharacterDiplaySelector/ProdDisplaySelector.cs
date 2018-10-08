using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DbRuler;
using System.IO;

namespace CharacterDiplaySelector
{
    public partial class ProdDisplaySelector: UserControl
    {
        public bool HideBusy { get; set; }
        public bool IsAgingOn { get; set; }
        public bool IsMovie { get; set; }
        public int Year { get; set; }
        public long Price { get; set; }
        public Movie MyMovie { get; set; }
        public Serial MySerial { get; set; }
        public GenericCharacters Gener { get; set; }
        public TypeOfMovie[] ListOfTypes { get; set; }
        public GenericCharacters Director { get; set; }
        public GenericCharacters Writer { get; set; }
        public GenericCharacters Actor { get; set; }

        private List<int> ActorsImDb = new List<int>();

        public event EventHandler onDirectorSelected;
        public event EventHandler onWriterSelected;
        public event EventHandler onActorSelected;
        public event EventHandler onShowrunnerSelected;

        public ProdDisplaySelector()
        {
            InitializeComponent();
            dgMovie.AutoGenerateColumns = false;
            if (!IsMovie)
            {
                txtUniverse.Visible = false;
                lblUniverse.Visible = false;
                txtDirector.Visible = false;
                lblDirector.Visible = false;
                btnGoToDirector.Visible = false;
                lblWriter.Text = "Sw:";
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            if (IsMovie)
            {
                List<Movie> GenLista = LFMGamePlay.GetMoviesOfPlayer(true);
                lblCounter.Text = GenLista.Count.ToString();
                dgMovie.DataSource = GenLista;
            }
            else
            {
                Serial[] GenLista;
                if (txtFilter.Text.Length > 0)
                    GenLista = Retriever.GetSerialsFromTitleLike(txtFilter.Text);
                else
                    GenLista = Retriever.GetSerials();
                lblCounter.Text = GenLista.Length.ToString();
                dgMovie.DataSource = GenLista;
            }            
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RefreshGrid();
            }
        }

        private void dgChars_DoubleClick(object sender, EventArgs e)
        {
            ClearAll();
            int selectedrowindex = dgMovie.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgMovie.Rows[selectedrowindex];
            int intID = Convert.ToInt32(selectedRow.Cells[0].Value);
            LoadDataAfterClick(intID);
        }

        private void LoadDataAfterClick(int intID)
        {
            if (IsMovie)
            {
                MyMovie = new Movie(intID);
                lblAction.Text = Retriever.GetNameOfValueFromInnerValue(MyMovie.Inner_Val.Action, "Action", false);
                lblSexappeal.Text = Retriever.GetNameOfValueFromInnerValue(MyMovie.Inner_Val.Sexappeal, "Sexappeal", false);
                lblHumor.Text = Retriever.GetNameOfValueFromInnerValue(MyMovie.Inner_Val.Humor, "Humor", false);
                txtTitle.Text = MyMovie.Title;               
                txtAge.Text = MyMovie.Age.ToString();
                ddlType1.Text = MyMovie.fkType1.TypeOf;
                if (MyMovie.fkType != null)
                {
                    if (MyMovie.fkType.Length > 0)
                    {
                        ddlType1.Text = MyMovie.fkType[0].TypeOf;
                        if (MyMovie.fkType.Length > 1)
                            ddlType2.Text = MyMovie.fkType[1].TypeOf;
                        if (MyMovie.fkType.Length > 2)
                            ddlType3.Text = MyMovie.fkType[2].TypeOf;
                        if (MyMovie.fkType.Length > 3)
                            ddlType4.Text = MyMovie.fkType[3].TypeOf;
                    }
                }
                ddlSpecialEffect.Text = MyMovie.fkFX.Name;
                ddlTheatre.Text = MyMovie.fkTdP.Name;
                txtDescription.Text = MyMovie.Description;
                txtCitation.Text = MyMovie.Citation;
                if (MyMovie.Universe != null)
                    txtUniverse.Text = MyMovie.Universe.Name;

                L_CharsMovies[] Cast = Retriever.GetCastFromMovie(intID);
                lstActors.Items.Clear();
                ActorsImDb.Clear();
                btnGoToDirector.Enabled = true;
                btnGotoWriter.Enabled = true;
                lstActors.Enabled = true;
                foreach (L_CharsMovies L in Cast)
                {
                    GenericCharacters Gen;
                    if (L.Char_Name == "Director")
                    {
                        Gen = new GenericCharacters(L.ID_Char);
                        txtDirector.Text = Gen.Name + " " + Gen.Surname;
                        Director = new GenericCharacters(L.ID_Char);
                    }
                    else
                    {
                        if (L.Char_Name == "Writer")
                        {
                            Gen = new GenericCharacters(L.ID_Char);
                            txtWriter.Text = Gen.Name + " " + Gen.Surname;
                            Writer = new GenericCharacters(L.ID_Char);
                        }
                        else
                        {
                            Gen = new GenericCharacters(L.ID_Char);
                            lstActors.Items.Add(Gen.Name + " " + Gen.Surname);
                            ActorsImDb.Add(Gen.ID);
                        }
                    }
                }
            }
            else
            {
                MySerial = new Serial(intID);
                lblAction.Text = Retriever.GetNameOfValueFromInnerValue(MySerial.Inner_Val.Action, "Action", false);
                lblSexappeal.Text = Retriever.GetNameOfValueFromInnerValue(MySerial.Inner_Val.Sexappeal, "Sexappeal", false);
                lblHumor.Text = Retriever.GetNameOfValueFromInnerValue(MySerial.Inner_Val.Humor, "Humor", false);
                txtTitle.Text = MySerial.Title;
                txtAge.Text = MySerial.Age.ToString();
                ddlType1.Text = MySerial.fkMainType.TypeOf;
                if (MySerial.fkSubType != null)
                {
                    ddlType2.Text = MySerial.fkSubType.TypeOf;                 
                }
                ddlSpecialEffect.Text = MySerial.fkFX.Name;
                ddlTheatre.Text = MySerial.fkTdP.Name;
                txtDescription.Text = MySerial.Description;
                txtCitation.Text = MySerial.Episodes.ToString();

                L_CharsSerials[] Cast = Retriever.GetCastFromSerial(intID, 1);
                lstActors.Items.Clear();
                ActorsImDb.Clear();
                btnGoToDirector.Enabled = true;
                btnGotoWriter.Enabled = true;
                lstActors.Enabled = true;
                foreach (L_CharsSerials L in Cast)
                {
                    GenericCharacters Gen;
                    if (L.Char_Name == "Showrunner")
                    {
                        Gen = new GenericCharacters(L.ID_Char);
                        txtWriter.Text = Gen.Name + " " + Gen.Surname;
                        Writer = new GenericCharacters(L.ID_Char);
                    }
                    else
                    {
                        Gen = new GenericCharacters(L.ID_Char);
                        lstActors.Items.Add(Gen.Name + " " + Gen.Surname);
                        ActorsImDb.Add(Gen.ID);
                    }                   
                }
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            txtAge.Text = "";
            txtCitation.Text = "";
            txtDescription.Text = "";
            txtTitle.Text = "";
            txtUniverse.Text = "";
            ddlType4.SelectedIndex = -1;
            ddlType3.SelectedIndex = -1;
            ddlType2.SelectedIndex = -1;
            ddlType1.SelectedIndex = -1;
            txtDirector.Text = "";
            txtWriter.Text = "";
            lstActors.Items.Clear();
            btnGotoWriter.Enabled = false;
            btnGoToDirector.Enabled = false;
            lstActors.Enabled = false;
            txtWriter.BackColor = Color.White;
            txtDirector.BackColor = Color.White;
        }

        

        private void lstActors_DoubleClick(object sender, EventArgs e)
        {
            if (lstActors.SelectedIndices.Count == 1)
            {
                Actor = new GenericCharacters(ActorsImDb[lstActors.SelectedIndices[0]]);
                this.onActorSelected(this, new EventArgs());
            }
        }

        private void btnGotoWriter_Click(object sender, EventArgs e)
        {
            this.onWriterSelected(this, new EventArgs());
        }

        private void btnGoToDirector_Click(object sender, EventArgs e)
        {
            this.onDirectorSelected(this, new EventArgs());
        }

        public event EventHandler ActorSelected
        {
            add
            {
                onActorSelected += value;
            }
            remove
            {
                onActorSelected -= value;
            }
        }
        public event EventHandler DirectorSelected
        {
            add
            {
                onDirectorSelected += value;
            }
            remove
            {
                onDirectorSelected -= value;
            }
        }
        public event EventHandler WriterSelected
        {
            add
            {
                onWriterSelected += value;
            }
            remove
            {
                onWriterSelected -= value;
            }
        }
        protected virtual void OnActorSelected(object sender, EventArgs e)
        {
            EventHandler handler = onActorSelected;
            handler?.Invoke(this, e);
        }
        protected virtual void OnDirectorSelected(object sender, EventArgs e)
        {
            EventHandler handler = onDirectorSelected;
            handler?.Invoke(this, e);
        }
        protected virtual void OnWriterSelected(object sender, EventArgs e)
        {
            EventHandler handler = onWriterSelected;
            handler?.Invoke(this, e);
        }

        private void dgMovie_DoubleClick(object sender, EventArgs e)
        {
            ClearAll();
            int selectedrowindex = dgMovie.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgMovie.Rows[selectedrowindex];
            int intID = Convert.ToInt32(selectedRow.Cells[0].Value);
            LoadDataAfterClick(intID);
        }
    }
}
