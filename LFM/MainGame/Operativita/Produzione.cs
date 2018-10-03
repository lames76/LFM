using DbRuler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LFM.MainGame.Operativita
{
    public partial class Produzione : Form
    {
        public bool IsMovie { get; set; }
        public TypeOfMovie[] ListOfTypes { get; set; }
        public long Balance { get; set; }
        public Movie MyMovie { get; set; }
        public Serial MySerial { get; set; }
        public long lngTOTALPrice { get; set; } = 0;

        public int Age { get; set; }
        private bool blnTdP = false;
        private bool blnFX = false;
        private bool blnShR = false;
        private bool blnDir = false;
        private bool blnWri = false;
        private bool blnCast = false;
        private AgeClass AC = AgeClass.NoValue;        
        private GenericCharacters Actor;
        private GenericCharacters Director;
        private GenericCharacters Writer;
        private GenericCharacters Showrunner;
        private GenericCharacters[] Cast;
        private Script MyScript;                

        /// <summary>
        /// 0 Showrunner, 1 Script/Writer, 2 Director, 3 Cast, 4 TdP e FX, 5 Riassunto
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="enable"></param>
        private void EnableTab(int Index, bool enable)
        {
            tabControlMovie.TabPages[Index].Enabled = enable;
        }

        public Produzione()
        {
            InitializeComponent();
            charDisplaySelector1.onCharSelected += new EventHandler(OnCharSelectedShowRunner);
            charDisplaySelectorDir.onCharSelected  += new EventHandler(OnCharSelectedDirector);
            charDisplaySelectorActor.onCharSelected += new EventHandler(OnCharSelectedActor);
        }

        #region Showrunner
        protected void OnCharSelectedShowRunner(object sender, EventArgs e)
        {
            Showrunner = new GenericCharacters(charDisplaySelector1.Gener.ID);             
            lngTOTALPrice = charDisplaySelector1.Price;
            long PriceCalc = 0;
            MySerial = Calculation.CreateSerialFromShowrunner(Showrunner, ListOfTypes, Age, out PriceCalc);
            MessageBox.Show("Lo Showrunner ha creato il nuovo serial.");
            blnShR = true;
            EnableTab(0, false);
            EnableTab(1, true);
        }
        #endregion

        #region Production
        private void dgScriptsList_DoubleClick(object sender, EventArgs e)
        {
            int selectedrowindex = dgScriptsList.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgScriptsList.Rows[selectedrowindex];
            int intID = Convert.ToInt32(selectedRow.Cells[0].Value);
        }

        private void btnSelectScript_Click(object sender, EventArgs e)
        {
            if (dgScriptsList.SelectedCells.Count > 0)
            {
                DialogResult Res = MessageBox.Show("Sei sicuro di voler utilizzare questo Script? \nNon potrai cambiare una volta scelto.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Res == DialogResult.Yes)
                {
                    //gbxDirector_Details.Enabled = false;
                    //gbxDirector_List.Enabled = false;
                    EnableTab(1, false);
                    EnableTab(2, true);
                    MessageBox.Show("Lo script base del film è stato creato!");
                    int selectedrowindex = dgScriptsList.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgScriptsList.Rows[selectedrowindex];
                    int intID = Convert.ToInt32(selectedRow.Cells[0].Value);
                    MyScript = new Script(intID);
                    MyMovie = Calculation.CreateMovieFromScript(null, ListOfTypes, Age);
                    lngTOTALPrice += 0;
                    blnWri = true;
                }
            }
        }

        private void dgWritersList_DoubleClick(object sender, EventArgs e)
        {
            int selectedrowindex = dgWritersList.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgWritersList.Rows[selectedrowindex];
            int intID = Convert.ToInt32(selectedRow.Cells[0].Value);
            LoadDataAfterClickW(intID);
        }

        private void LoadDataAfterClickW(int intID)
        {
            Writer = new GenericCharacters(intID);
            lblWAction.Text = Retriever.GetNameOfValueFromInnerValue(Writer.Inner_Val.Action, "Action", (ddlWSex.Text == "F" ? true : false));
            lblWSexappeal.Text = Retriever.GetNameOfValueFromInnerValue(Writer.Inner_Val.Sexappeal, "Sexappeal", (ddlWSex.Text == "F" ? true : false));
            lblWHumor.Text = Retriever.GetNameOfValueFromInnerValue(Writer.Inner_Val.Humor, "Humor", (ddlWSex.Text == "F" ? true : false));           
            txtWName.Text = Writer.Name;
            txtWSurname.Text = Writer.Surname;
            ddlWSex.Text = Writer.Sex;
            LoadRightImageW();
            long Price = Calculation.GetCashOfWriter(Writer);
            txtWCost.Text = String.Format("{0:n0}", Price).Replace(",", ".");
        }

        private void LoadRightImageW()
        {
            if (Writer != null)
            {
                pictureBoxW.Image = null;

                CharImages Img = new CharImages(Writer.ID, AC);
                if (Img.Image != null)
                {
                    pictureBoxW.Image = ByteToImage(Img.Image);
                }
            }
        }

        public Image ByteToImage(byte[] imageBytes)
        {
            // Convert byte[] to Image
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);
            return image;
        }
        
        private void RefreshGridW()
        {
            GenericCharacters[] GenLista;
            TypeOfCharacters Typ = new TypeOfCharacters(1);
            if (txtWFilter.Text.Length > 0)
                GenLista = Retriever.GetCharactersBySurnameLike(txtWFilter.Text, Typ);
            else
                GenLista = Retriever.GetCharacters(Typ);
            lblWCounter.Text = GenLista.Length.ToString();
            dgWritersList.DataSource = GenLista;
        }
        
        private void btnSelectWriter_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Sei sicuro di voler assegnare questo Sceneggiatore? \nNon potrai cambiare una volta assegnato.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.Yes)
            {
                EnableTab(0, false);
                EnableTab(1, true);
                MessageBox.Show("Lo script base del film è stato creato!");
                long Price = Convert.ToInt64(txtWCost.Text.Replace(".",""));
                MyMovie = Calculation.CreateMovieFromWriter(Writer, ListOfTypes, Age, out Price);
                lngTOTALPrice += Price;
                blnWri = true;
                charDisplaySelectorDir.MyMovie = MyMovie;
            }
        }

        private void btnWClearFilter_Click(object sender, EventArgs e)
        {
            txtWFilter.Text = "";
            RefreshGridW();
        }

        private void btnWFilter_Click(object sender, EventArgs e)
        {
            RefreshGridW();
        }

        private void txtWFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                RefreshGridW();
        }
        #endregion

        #region Director
        protected void OnCharSelectedDirector(object sender, EventArgs e)
        {
            Director = charDisplaySelectorDir.Gener;
            lngTOTALPrice += charDisplaySelectorDir.Price;
            MessageBox.Show("Il regista ha modificato lo script per adattarlo al suo stile.");
            Calculation.DirectorStyleChangeMovie(Director, MyMovie);
            EnableTab(1, false);
            EnableTab(2, true);
            blnDir = true;
            charDisplaySelectorActor.MyMovie = MyMovie;
        }
        #endregion

        #region TdP e FX
        private void btnSelezionaFX_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Sei sicuro di voler selezionare questi effetti speciali? \nNon potrai cambiare una volta scelti.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.Yes)
            {
                if (IsMovie)
                    MyMovie.fkTdP = new Theatre(Convert.ToInt32(ddlTheatre.SelectedValue));
                else
                    MySerial.fkTdP = new Theatre(Convert.ToInt32(ddlTheatre.SelectedValue));

                blnFX = true;
                if (blnTdP && blnFX)
                {
                    if (IsMovie)
                        EnableTab(3, false);
                    else
                        EnableTab(1, false);
                    if (IsMovie)
                        lngTOTALPrice += Calculation.GetStructureCostFromMovie(MyMovie);
                    else
                        lngTOTALPrice += Calculation.GetStructureCostFromMovie(MySerial);
                }
                else
                    gbxFX.Enabled = false;
            }            
        }

        private void btnSelectTdP_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Sei sicuro di voler selezionare questo questo Set? \nNon potrai cambiare una volta scelto.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.Yes)
            {
                if (IsMovie)
                    MyMovie.fkFX = new SpecialEffectCompany(Convert.ToInt32(ddlSpecialEffect.SelectedValue));
                else
                    MySerial.fkFX = new SpecialEffectCompany(Convert.ToInt32(ddlSpecialEffect.SelectedValue));

                blnTdP = true;
                if (blnTdP && blnFX)
                {
                    if (IsMovie)
                        EnableTab(3, false);
                    else
                        EnableTab(1, false);
                    if (IsMovie)
                        lngTOTALPrice += Calculation.GetStructureCostFromMovie(MyMovie);
                    else
                        lngTOTALPrice += Calculation.GetStructureCostFromMovie(MySerial);
                }
                else
                    gbxTdP.Enabled = false;
            }            
        }
        #endregion

        #region Riassunto
        private void RefreshMovieDataSoFar()
        {
            if (IsMovie)
            {
                if (MyMovie != null)
                {
                    txtTitle.Text = MyMovie.Title;
                    txtDescription.Text = MyMovie.Description;
                    txtCitation.Text = MyMovie.Citation;
                    txtType1.Text = MyMovie.fkType[0].TypeOf;
                    if (MyMovie.fkType[1] != null)
                        txtType2.Text = MyMovie.fkType[1].TypeOf;
                    if (MyMovie.fkType[2] != null)
                        txtType3.Text = MyMovie.fkType[2].TypeOf;
                    if (MyMovie.fkType[3] != null)
                        txtType4.Text = MyMovie.fkType[3].TypeOf;
                    txtMovieAge.Text = MyMovie.Age.ToString();
                    txtMAction.Text = Retriever.GetNameOfValueFromInnerValue(MyMovie.Inner_Val.Action, "Action", false);
                    txtMSex.Text = Retriever.GetNameOfValueFromInnerValue(MyMovie.Inner_Val.Sexappeal, "Sexappeal", false);
                    txtMHumor.Text = Retriever.GetNameOfValueFromInnerValue(MyMovie.Inner_Val.Humor, "Humor", false);
                    if (Writer != null)
                        txtWriter.Text = Writer.Name + " " + Writer.Surname;
                    if (Director != null)
                        txtDirector.Text = Director.Name + " " + Director.Surname;
                    lstMActors.Items.Clear();
                    Cast = Retriever.GetGenericCastFromMovie(MyMovie.ID);
                    foreach (GenericCharacters gen in Cast)
                        lstMActors.Items.Add(gen.Name + " " + gen.Surname);
                    if (MyMovie.fkTdP != null)
                        txtMTheatre.Text = MyMovie.fkTdP.Name;
                    if (MyMovie.fkFX != null)
                        txtMSpecialEffect.Text = MyMovie.fkFX.Name;
                    txtCosto.Text = String.Format("{0:n0}", lngTOTALPrice).Replace(",", ".");
                    txtCostoTotale.Text = String.Format("{0:n0}", lngTOTALPrice).Replace(",", ".");
                    lblEpisode.Text = "Cit:";
                    txtEpisode.Visible = false;
                }
            }
            else
            {
                if (MySerial != null)
                {
                    txtTitle.Text = MySerial.Title;
                    txtDescription.Text = MySerial.Description;
                    txtCitation.Visible = false;
                    lblEpisode.Text = "Ep:";
                    txtEpisode.Text = MySerial.Episodes.ToString();
                    txtType1.Text = MySerial.fkMainType.TypeOf;
                    if (MySerial.fkSubType != null)
                        txtType2.Text = MySerial.fkSubType.TypeOf;
                    txtType3.Text = "";
                    txtType4.Text = "";
                    txtMovieAge.Text = MySerial.Age.ToString();
                    txtMAction.Text = Retriever.GetNameOfValueFromInnerValue(MySerial.Inner_Val.Action, "Action", false);
                    txtMSex.Text = Retriever.GetNameOfValueFromInnerValue(MySerial.Inner_Val.Sexappeal, "Sexappeal", false);
                    txtMHumor.Text = Retriever.GetNameOfValueFromInnerValue(MySerial.Inner_Val.Humor, "Humor", false);
                    txtWriter.Visible = false;
                    lblDir.Text = "SR:";
                    if (Showrunner != null)
                        txtDirector.Text = Showrunner.Name + " " + Showrunner.Surname;
                    lstMActors.Items.Clear();
                    Cast = Retriever.GetGenericCastFromSerial(MySerial.ID, 1);
                    foreach (GenericCharacters gen in Cast)
                        if (gen.TypeOf.TypeOf != "Showrunner")
                            lstMActors.Items.Add(gen.Name + " " + gen.Surname);
                    if (MySerial.fkTdP != null)
                        txtMTheatre.Text = MySerial.fkTdP.Name;
                    if (MySerial.fkFX != null)
                        txtMSpecialEffect.Text = MySerial.fkFX.Name;
                    txtCosto.Text = String.Format("{0:n0}", lngTOTALPrice).Replace(",", ".");
                    txtCostoTotale.Text = String.Format("{0:n0}", lngTOTALPrice).Replace(",", ".");
                }
            }
        }

        private void btnUpdateMov_Click(object sender, EventArgs e)
        {
            if (IsMovie)
            {
                if (txtTitle.Text.Length > 0)
                    MyMovie.Title = txtTitle.Text;
                if (txtDescription.Text.Length > 0)
                    MyMovie.Description = txtDescription.Text;
                if (txtCitation.Text.Length > 0)
                    MyMovie.Citation = txtCitation.Text;
                MyMovie.Movie_WriteOnDb();
            }
            else
            {
                if (txtTitle.Text.Length > 0)
                    MySerial.Title = txtTitle.Text;
                if (txtDescription.Text.Length > 0)
                    MySerial.Description = txtDescription.Text;
                int intEpis = 12;
                int.TryParse(txtEpisode.Text, out intEpis);
                MySerial.Episodes = intEpis;
                MySerial.WriteOnDb();
            }
        }
        #endregion
        
        #region Cast
        private void btnRemoveActor_Click(object sender, EventArgs e)
        {
            if (lstListOfCastSel.SelectedIndices.Count == 1)
            {
                DialogResult Res = MessageBox.Show("Vuoi davvero eliminare questo elemento?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Res == DialogResult.Yes)
                {
                    string[] strNameSurname = lstListOfCastSel.Items[lstListOfCastSel.SelectedIndices[0]].Text.Split(' ');
                    string strSurname = string.Empty;
                    if (strNameSurname[strNameSurname.Length - 1].ToUpper() != "JR.")
                        strSurname = strNameSurname[strNameSurname.Length - 1];
                    else
                        strSurname = strNameSurname[strNameSurname.Length - 2] + " " + strNameSurname[strNameSurname.Length - 1];
                    string strName = "";
                    for (int i = 0; i < strNameSurname.Length - 1; i++)
                    {
                        strName += strNameSurname[i] + " ";
                    }
                    GenericCharacters[] Gen1 = Retriever.GetCharactersByNameAndSurnameLike(strName.TrimEnd(), strSurname);
                    if (Gen1 != null)
                        if (Gen1.Length == 1)
                        {
                            if (IsMovie)
                            {
                                L_CharsMovies Link = new L_CharsMovies(Gen1[0].ID, MyMovie.ID, "Actor");
                                if (Link.L_CharsMovies_Delete())
                                    MessageBox.Show("Actor Removed");
                                lstListOfCastSel.Items.RemoveAt(lstListOfCastSel.SelectedIndices[0]);
                            }
                            else
                            {
                                L_CharsSerials Link = new L_CharsSerials(Gen1[0].ID, MySerial.ID, "Actor");
                                if (Link.L_CharsMovies_Delete())
                                    MessageBox.Show("Actor Removed");
                                lstListOfCastSel.Items.RemoveAt(lstListOfCastSel.SelectedIndices[0]);
                            }
                        }
                }
            }
        }

        private void btnAFinishSelect_Click(object sender, EventArgs e)
        {
            if (IsMovie)
                Cast = Retriever.GetGenericCastFromMovie(MyMovie.ID);
            else
                Cast = Retriever.GetGenericCastFromSerial(MySerial.ID, 1);
            if (Cast.Length > 0)
            {
                DialogResult Res = MessageBox.Show("Sei sicuro di voler finire con l'assegnazione del Cast? \nNon potrai cambiare una volta finito.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Res == DialogResult.Yes)
                {
                    if (IsMovie)
                    {
                        EnableTab(2, false);
                        EnableTab(3, true);
                        lngTOTALPrice += Calculation.GetCastCostFromMovie(MyMovie);
                    }
                    else
                    {
                        EnableTab(1, false);
                        EnableTab(2, true);
                        foreach (GenericCharacters Gen in Cast)
                            lngTOTALPrice += Calculation.GetCashOfActor(Gen, MySerial);
                    }
                    blnCast = true;
                    
                }
            }
        }

        protected void OnCharSelectedActor(object sender, EventArgs e)
        {
            Actor = new GenericCharacters(charDisplaySelectorActor.Gener.ID);

            if (IsMovie)
            {
                L_CharsMovies Link = new L_CharsMovies(Actor.ID, MyMovie.ID, "Actor");
                if (Link.L_CharsMovies_InsertDb())
                {
                    lstListOfCastSel.Items.Add(Actor.Name + " " + Actor.Surname);
                    MessageBox.Show("Actor Added");
                }
            }
            else
            {
                L_CharsSerials Link = new L_CharsSerials(Actor.ID, MySerial.ID, "Actor");
                if (Link.InsertDb())
                {
                    lstListOfCastSel.Items.Add(Actor.Name + " " + Actor.Surname);
                    MessageBox.Show("Actor Added");
                }
            }
        }
        #endregion

        private void Produzione_Load(object sender, EventArgs e)
        {            
            txtBudget.Text = String.Format("{0:n0}", Balance).Replace(",", ".");
            txtCostoTotale.Text = "0";
            txtDifference.Text = "0";
            charDisplaySelector1.Year = Age;
            charDisplaySelector1.ListOfTypes = ListOfTypes;
            charDisplaySelector1.IsMovie = IsMovie;
            charDisplaySelectorDir.Year = Age;
            charDisplaySelectorDir.ListOfTypes = ListOfTypes;
            charDisplaySelectorDir.IsMovie = IsMovie;
            charDisplaySelectorDir.MyMovie = MyMovie;
            charDisplaySelectorActor.Year = Age;
            charDisplaySelectorActor.ListOfTypes = ListOfTypes;
            charDisplaySelectorActor.IsMovie = IsMovie;
            if (IsMovie)
                charDisplaySelectorActor.MyMovie = MyMovie;
            else
                charDisplaySelectorActor.MySerial = MySerial;

            DataTable MyList = new DataTable();
            MyList = DbRuler.Retriever.GetTheatreListTable();
            ddlTheatre.DisplayMember = "Name";
            ddlTheatre.ValueMember = "ID";
            ddlTheatre.DataSource = MyList;

            MyList = new DataTable();
            MyList = DbRuler.Retriever.GetFXCompanyListTable();
            ddlSpecialEffect.DisplayMember = "Name";
            ddlSpecialEffect.ValueMember = "ID";
            ddlSpecialEffect.DataSource = MyList;

            EnableTab(3, false);
            EnableTab(4, false);
            EnableTab(5, true);
            if (IsMovie)
            {
                tabControlMovie.TabPages.RemoveAt(0);
                EnableTab(1, true);
                EnableTab(2, false);
            }
            else
            {
                tabControlMovie.TabPages.RemoveAt(2);
                tabControlMovie.TabPages.RemoveAt(1);
                EnableTab(0, true);
            }
            
        }

        private void tabControlMovie_SelectedIndexChanged(object sender, EventArgs e)
        {            
            RefreshMovieDataSoFar();
            long lngDiff = Balance - Convert.ToInt64(txtCostoTotale.Text.Replace(".",""));
            txtDifference.Text = String.Format("{0:n0}", lngDiff).Replace(",", ".");
            if (lngDiff > 0)
                txtDifference.BackColor = Color.PaleGreen;
            else
                txtDifference.BackColor = Color.LightPink;
        }

        private void btnProduce_Click(object sender, EventArgs e)
        {
            if (IsMovie)
            {
                if (blnWri && blnDir && blnFX && blnTdP && blnCast)
                {
                    if ((Balance - lngTOTALPrice) < 0)
                    {
                        DialogResult Res = MessageBox.Show("Questo film ti porterà in rosso, sei sicuro di volerlo produrre?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Res == DialogResult.Yes)
                        {
                            //this.DialogResult = DialogResult.OK;
                            MessageBox.Show("Not yet implemented!");
                        }
                    }
                }
                else
                    MessageBox.Show("Manca ancora qualcosa");
            }
            else
            {
                if (blnShR && blnFX && blnTdP && blnCast)
                {
                    //this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Not yet implemented!");
                }
                else
                    MessageBox.Show("Manca ancora qualcosa");
            }
        }
        
    }
}