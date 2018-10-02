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
        public TypeOfMovie[] ListOfTypes;
        private int Age;
        private bool blnTdP = false;
        private bool blnFX = false;
        private bool blnShR = false;
        private bool blnDir = false;
        private bool blnWri = false;
        private bool blnCast = false;

        private AgeClass AC = AgeClass.NoValue;
        private long lngPrice = 0;
        private GenericCharacters Actor;

        private GenericCharacters Director;
        private GenericCharacters Writer;
        private GenericCharacters Showrunner;
        private GenericCharacters[] Cast;
        private Script MyScript;
        private Movie MyMovie;
        private Serial MySerial;

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
        }

        #region Showrunner
        // blnShR = true;
        #endregion

        #region Production
        private void btnSelectScript_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Sei sicuro di voler utilizzare questo Script? \nNon potrai cambiare una volta scelto.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.Yes)
            {
                //gbxDirector_Details.Enabled = false;
                //gbxDirector_List.Enabled = false;
                EnableTab(1, false);
                EnableTab(2, true);
                MessageBox.Show("Lo script base del film è stato creato!");
                MyMovie = Calculation.CreateMovieFromScript(null, ListOfTypes, Age);
                blnWri = true;
            }
        }

        private void btnSelectWriter_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Sei sicuro di voler assegnare questo Sceneggiatore? \nNon potrai cambiare una volta assegnato.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.Yes)
            {
                //gbxDirector_Details.Enabled = false;
                //gbxDirector_List.Enabled = false;
                EnableTab(1, false);
                EnableTab(2, true);
                MessageBox.Show("Lo script base del film è stato creato!");
                MyMovie = Calculation.CreateMovieFromWriter(Writer, ListOfTypes, Age, out lngPrice);
                blnWri = true;
            }
        }

        protected void GenerateMovie()
        {            
            MyMovie = Calculation.CreateMovieFromWriter(Writer, ListOfTypes, Age, out lngPrice);
            MyMovie = Calculation.CreateMovieFromScript(MyScript, ListOfTypes, Age);
        }
        #endregion

        #region Director
        private void btnFilter_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            /*
            DataTable tblRet = new DataTable();
            if (txtFilter.Text.Length > 0)
                tblRet = null;
            else
                tblRet = DbRuler.Retriever.GetCharactersTable();
            lblCounter.Text = tblRet.Rows.Count.ToString();
            dgChars.DataSource = tblRet;
            */
            GenericCharacters[] GenLista;
            TypeOfCharacters Typ = new TypeOfCharacters(2);
            if (txtFilter.Text.Length > 0)
                GenLista = Retriever.GetCharactersBySurnameLike(txtFilter.Text, Typ);
            else
                GenLista = Retriever.GetCharacters(Typ);
            lblCounter.Text = GenLista.Length.ToString();
            dgChars.DataSource = GenLista;
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";
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
            int selectedrowindex = dgChars.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgChars.Rows[selectedrowindex];
            int intID = Convert.ToInt32(selectedRow.Cells[0].Value);
            LoadDataAfterClick(intID);
        }

        private void LoadDataAfterClick(int intID)
        {
            Director = new GenericCharacters(intID);
            lblActionName.Text = Retriever.GetNameOfValueFromInnerValue(Director.Inner_Val.Action, "Action", (ddlSex.Text == "F" ? true : false));
            lblSexappealName.Text = Retriever.GetNameOfValueFromInnerValue(Director.Inner_Val.Sexappeal, "Sexappeal", (ddlSex.Text == "F" ? true : false)); 
            lblHumorName.Text = Retriever.GetNameOfValueFromInnerValue(Director.Inner_Val.Humor, "Humor", (ddlSex.Text == "F" ? true : false)); 
            txtAge.Text = Director.Age.ToString();
            txtName.Text = Director.Name;
            txtPopularity.Text = Director.Popularity.ToString();
            txtSurname.Text = Director.Surname;
            ddlSex.Text = Director.Sex;
            txtImDb_Link.Text = Director.ImDB_Link;
            LoadRightImage();
            //dgFilmografia.AutoGenerateColumns = false;
            //dgFilmografia.DataSource = Retriever.GetMoviesFromPeopleID(intID, true);
            RefreshAssignedSpecials(Director.ID);
            long Price = Calculation.GetCashOfDirector(Director, MyMovie);
            txtDirPrice.Text = txtCosto.Text = String.Format("{0:n0}", Price).Replace(",", "."); 
        }

        private void RefreshAssignedSpecials(int intID)
        {
            SpecialAbilities[] AsSpec = Retriever.GetSpecialAbilitiesListByIDChar(intID);
            foreach (SpecialAbilities S in AsSpec)
            {
                lstSpecials.Items.Add(S.Name);
            }
        }        

        private int GetIndexOfText(string strText, DataTable tblinput)
        {
            int RetVal = -1;
            for (int i = 0; i < tblinput.Rows.Count; i++)
            {
                if (tblinput.Rows[i]["Name"].ToString() == strText)
                {
                    RetVal = i;
                    break;
                }
            }
            return RetVal;
        }

        private void LoadRightImage()
        {
            if (Director != null)
            {
                pictureBox1.Image = null;

                CharImages Img = new CharImages(Director.ID, AC);
                if (Img.Image != null)
                {
                    pictureBox1.Image = ByteToImage(Img.Image);
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Sei sicuro di voler assegnare questo Regista? \nNon potrai cambiare una volta assegnato.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.Yes)
            {
                //gbxDirector_Details.Enabled = false;
                //gbxDirector_List.Enabled = false;
                EnableTab(2, false);
                EnableTab(3, true);
                MessageBox.Show("Il regista ha modificato lo script per adattarlo al suo stile");
                Calculation.DirectorStyleChangeMovie(Director, MyMovie);
                blnDir = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            txtImDb_Link.Text = "";
            txtAge.Text = "";
            txtName.Text = "";
            txtPopularity.Text = "";
            txtSurname.Text = "";
            ddlSex.SelectedIndex = -1;
            pictureBox1.Image = null;
            Director = null;
            lblHumorName.Text = "";
            lblActionName.Text = "";
            lblSexappealName.Text = "";
            //dgFilmografia.DataSource = null;
            lstSpecials.Clear();
        }
        #endregion

        #region TdP e FX
        private void btnSelezionaFX_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Sei sicuro di voler selezionare questo Set? \nNon potrai cambiare una volta scelto.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.Yes)
            {
                if (IsMovie)
                    MyMovie.fkTdP = new Theatre(Convert.ToInt32(ddlTheatre.SelectedValue));
                else
                    MySerial.fkTdP = new Theatre(Convert.ToInt32(ddlTheatre.SelectedValue));

                blnTdP = true;
                if (blnTdP && blnFX)
                {
                    EnableTab(4, false);
                }
                else
                    gbxTdP.Enabled = false;
            }            
        }

        private void btnSelectTdP_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Sei sicuro di voler selezionare questi effetti speciali? \nNon potrai cambiare una volta scelto.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.Yes)
            {
                if (IsMovie)
                    MyMovie.fkFX = new SpecialEffectCompany(Convert.ToInt32(ddlSpecialEffect.SelectedValue));
                else
                    MySerial.fkFX = new SpecialEffectCompany(Convert.ToInt32(ddlSpecialEffect.SelectedValue));

                blnFX = true;
                if (blnTdP && blnFX)
                {
                    EnableTab(4, false);
                }
                else
                    gbxFX.Enabled = false;
            }            
        }
        #endregion

        #region Riassunto
        private void RefreshMovieDataSoFar()
        {
            if (IsMovie)
            {
                txtTitle.Text = MyMovie.Title;
                txtDescription.Text = MyMovie.Description;
                txtCitation.Text = MyMovie.Citation;
                ddlType1.Text = MyMovie.fkType[0].TypeOf;
                if (MyMovie.fkType.Length > 1)
                    ddlType2.Text = MyMovie.fkType[1].TypeOf;
                if (MyMovie.fkType.Length > 2)
                    ddlType3.Text = MyMovie.fkType[2].TypeOf;
                if (MyMovie.fkType.Length > 3)
                    ddlType4.Text = MyMovie.fkType[3].TypeOf;
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
                    lstASpecials.Items.Add(gen.Name + " " + gen.Surname);
                ddlMTheatre.Text = MyMovie.fkTdP.Name;
                ddlMSpecialEffect.Text = MyMovie.fkFX.Name;
                long Price = Calculation.GetTotalMovieCost(MyMovie);
                txtCosto.Text = String.Format("{0:n0}", Price).Replace(",", ".");
                lblEpisode.Text = "Cit:";
                txtEpisode.Visible = false;
            }
            else
            {
                if (IsMovie)
                {
                    txtTitle.Text = MySerial.Title;
                    txtDescription.Text = MySerial.Description;
                    txtCitation.Visible = false;
                    lblEpisode.Text = "Ep:";
                    txtEpisode.Text = MySerial.Episodes.ToString();
                    ddlType1.Text = MySerial.fkMainType.TypeOf;
                    if (MySerial.fkSubType != null)
                        ddlType2.Text = MySerial.fkSubType.TypeOf;
                    ddlType3.SelectedIndex = -1;
                    ddlType4.SelectedIndex = -1;
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
                            lstASpecials.Items.Add(gen.Name + " " + gen.Surname);
                    ddlMTheatre.Text = MySerial.fkTdP.Name;
                    ddlMSpecialEffect.Text = MySerial.fkFX.Name;
                    long Price = Calculation.GetSerialTotalCost(MySerial);
                    txtCosto.Text = String.Format("{0:n0}", Price).Replace(",", ".");
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
                    MyMovie.Title = txtTitle.Text;
                if (txtDescription.Text.Length > 0)
                    MyMovie.Description = txtDescription.Text;
                int intEpis = 12;
                int.TryParse(txtEpisode.Text, out intEpis);
                MySerial.Episodes = intEpis;
                MySerial.WriteOnDb();
            }
        }
        #endregion
        
        #region Cast
        private void btnAFilter_Click(object sender, EventArgs e)
        {
            RefreshAGrid();
        }

        private void RefreshAGrid()
        {
            /*
            DataTable tblRet = new DataTable();
            if (txtFilter.Text.Length > 0)
                tblRet = null;
            else
                tblRet = DbRuler.Retriever.GetCharactersTable();
            lblCounter.Text = tblRet.Rows.Count.ToString();
            dgChars.DataSource = tblRet;
            */
            GenericCharacters[] GenLista;
            TypeOfCharacters Typ;
            if (ddlActorOrOthers.Text == "Actors")
            {
                if (ddlASex.Text == "M")
                    Typ = new TypeOfCharacters(3);
                else
                    Typ = new TypeOfCharacters(4);
            }
            else
            {
                if (ddlActorOrOthers.Text == "Singer")
                    Typ = new TypeOfCharacters(6);
                else
                    Typ = new TypeOfCharacters(7);
            }
            if (txtFilter.Text.Length > 0)
                GenLista = Retriever.GetCharactersBySurnameLike(txtFilter.Text, Typ);
            else
                GenLista = Retriever.GetCharacters(Typ);
            lblCounter.Text = GenLista.Length.ToString();
            dgAChars.DataSource = GenLista;
        }

        private void btnAClearFilter_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            RefreshAGrid();
        }

        private void txtAFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RefreshAGrid();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int selectedrowindex = dgAChars.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgAChars.Rows[selectedrowindex];
            int intID = Convert.ToInt32(selectedRow.Cells[0].Value);
            LoadDataAfterClickA(intID);
        }

        private void LoadDataAfterClickA(int intID)
        {
            Actor = new GenericCharacters(intID);
            lblAActionName.Text = Actor.Inner_Val.Action.ToString();
            lblASexappealName.Text = Actor.Inner_Val.Sexappeal.ToString();
            lblAHumorName.Text = Actor.Inner_Val.Humor.ToString();
            PopolateDropDownInnerValuesA(Actor);
            txtAAge.Text = Actor.Age.ToString();
            txtAName.Text = Actor.Name;
            txtAPopularity.Text = Actor.Popularity.ToString();
            txtASkill.Text = Actor.Skills.ToString();
            txtASurname.Text = Actor.Surname;
            txtATalent.Text = Actor.Talent.ToString();
            ddlASex.Text = Actor.Sex;
            txtAImDb_Link.Text = Actor.ImDB_Link;

            LoadRightImageA();

            //dgFilmografia.AutoGenerateColumns = false;
            //dgFilmografia.DataSource = Retriever.GetMoviesFromPeopleID(intID, true);
            RefreshAssignedSpecialsA(Actor.ID);
        }

        private void RefreshAssignedSpecialsA(int intID)
        {
            SpecialAbilities[] AsSpec = Retriever.GetSpecialAbilitiesListByIDChar(intID);
            foreach (SpecialAbilities S in AsSpec)
            {
                lstASpecials.Items.Add(S.Name);
            }
        }

        private void PopolateDropDownInnerValuesA(GenericCharacters Gen)
        {
            string strSex = "";
            if (Gen != null)
            {
                strSex = Gen.Sex;
            }
            else
            {
                strSex = "F";
            }
            DataTable tblAppo = Retriever.GetNameOfValue("Action", (strSex == "F" ? true : false));
            ddlActionA.DataSource = tblAppo;
            ddlActionA.DisplayMember = "Name";
            ddlActionA.ValueMember = "MaxValue";
            int intValue = (Gen != null ? Convert.ToInt32(Gen.Inner_Val.Action) : 0);
            ddlActionA.SelectedIndex = GetIndexOfText(Retriever.GetNameOfValueFromInnerValue(intValue, "Action", (strSex == "F" ? true : false)), tblAppo);
            tblAppo = Retriever.GetNameOfValue("Humor", (strSex == "F" ? true : false));
            ddlHumorA.DataSource = tblAppo;
            ddlHumorA.DisplayMember = "Name";
            ddlHumorA.ValueMember = "MaxValue";
            intValue = (Gen != null ? Convert.ToInt32(Gen.Inner_Val.Humor) : 0);
            ddlHumorA.SelectedIndex = GetIndexOfText(Retriever.GetNameOfValueFromInnerValue(intValue, "Humor", (strSex == "F" ? true : false)), tblAppo);
            tblAppo = Retriever.GetNameOfValue("Sexappeal", (strSex == "F" ? true : false));
            ddlSexappealA.DataSource = tblAppo;
            ddlSexappealA.DisplayMember = "Name";
            ddlSexappealA.ValueMember = "MaxValue";
            intValue = (Gen != null ? Convert.ToInt32(Gen.Inner_Val.Sexappeal) : 0);
            ddlSexappealA.SelectedIndex = GetIndexOfText(Retriever.GetNameOfValueFromInnerValue(intValue, "Sexappeal", (strSex == "F" ? true : false)), tblAppo);
        }

        private void LoadRightImageA()
        {
            if (Actor != null)
            {
                pictureBoxA.Image = null;

                CharImages Img = new CharImages(Actor.ID, AC);
                if (Img.Image != null)
                {
                    pictureBoxA.Image = ByteToImage(Img.Image);
                }
            }
        }

        private void btnAClear_Click(object sender, EventArgs e)
        {
            ClearAllA();
        }

        private void btnASelect_Click(object sender, EventArgs e)
        {            
            L_CharsMovies Link = new L_CharsMovies(Actor.ID, MyMovie.ID, "Actor");
            if (Link.L_CharsMovies_InsertDb())
            {
                lstListOfCastSel.Items.Add(txtAName.Text + " " + txtASurname.Text);
                MessageBox.Show("Actor Added");
            }
        }

        private void ClearAllA()
        {
            txtAImDb_Link.Text = "";
            txtAAction.Text = "";
            txtAAge.Text = "";
            txtAHumor.Text = "";
            txtAName.Text = "";
            txtAPopularity.Text = "";
            txtASexappeal.Text = "";
            txtASkill.Text = "";
            txtASurname.Text = "";
            txtATalent.Text = "";
            ddlASex.SelectedIndex = -1;
            pictureBoxA.Image = null;
            Actor = null;
            lblAHumorName.Text = "";
            lblAActionName.Text = "";
            lblASexappealName.Text = "";
            //dgFilmografia.DataSource = null;
            ddlActionA.DataSource = null;
            ddlHumorA.DataSource = null;
            ddlSexappealA.DataSource = null;
            lstASpecials.Clear();
        }

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
                            L_CharsMovies Link = new L_CharsMovies(Gen1[0].ID, MyMovie.ID, "Actor");
                            if (Link.L_CharsMovies_Delete())
                                MessageBox.Show("Actor Removed");
                            lstListOfCastSel.Items.RemoveAt(lstListOfCastSel.SelectedIndices[0]);
                        }
                }
            }
        }

        private void btnAFinishSelect_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Sei sicuro di voler finire con l'assegnazione del Cast? \nNon potrai cambiare una volta finito.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.Yes)
            {
                //gbxDirector_Details.Enabled = false;
                //gbxDirector_List.Enabled = false;
                EnableTab(3, false);
                EnableTab(4, true);
                blnCast = true;
            }
        }

        private void ddlSexFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshAGrid();
        }

        private void ddlActorOrOthers_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshAGrid();
        }
        #endregion

        private void Produzione_Load(object sender, EventArgs e)
        {
            ddlASex.SelectedIndex = 0;
            ddlActorOrOthers.SelectedIndex = 0;

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
            EnableTab(3, false);
            EnableTab(4, false);
            EnableTab(5, true);
        }

        private void tabControlMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((tabControlMovie.SelectedIndex == 4) || ((tabControlMovie.TabCount == 4) && (tabControlMovie.SelectedIndex == 3)))
                RefreshMovieDataSoFar();
        }

        private void btnProduce_Click(object sender, EventArgs e)
        {
            if (IsMovie)
            {
                if (blnWri && blnDir && blnFX && blnTdP && blnCast)
                    MessageBox.Show("Not yet implemented!");
                else
                    MessageBox.Show("Manca ancora qualcosa");
            }
            else
            {
                if (blnShR && blnFX && blnTdP && blnCast)
                    MessageBox.Show("Not yet implemented!");
                else
                    MessageBox.Show("Manca ancora qualcosa");
            }
        }
    }
}