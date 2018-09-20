using DbRuler;
using ImDbReader;
using MyImDbParser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LFM
{
    public partial class CreateM : Form
    {
        private Movie GenMovie;
        private string DirectorImDb = "";
        private bool IsDirectorSet = false;
        private string WriterImDb = "";
        private bool IsWriterSet = false;
        private List<string> ActorsImDb = new List<string>();
        private bool IsActorsSet = false;
        private bool IsDataBinding = false;
        public int IDMovie = -1;

        public CreateM()
        {
            InitializeComponent();
        }

        private void btnGetFromImdb_Click(object sender, EventArgs e)
        {
            string strAppoLing = txtImDbLink.Text;
            DialogResult Res = MessageBox.Show("Pulisco tutto prima di continuare?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Res == DialogResult.Yes)
            {                
                ClearAll();
            }
            //IMDb imdb = new IMDb(txtImDbLink.Text, true);
            var uri = new Uri(strAppoLing);
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Navigate(uri);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                if (e.Url != webBrowser1.Url)
                    return;
                string strContent = webBrowser1.DocumentText;
                ImDbDataRetriever MyImDb = new ImDbDataRetriever();
                MyImDb.strPageCode = strContent;
                MyImDb.ParseCode();
                //MessageBox.Show("Page Loaded.\nStart Parsing.");
                MyMovie MyObj = new MyMovie();
                string strMJson = DbRuler.Creator.CheckJsonAndNormalizeGenre(MyImDb.Json);
                MyObj = Newtonsoft.Json.JsonConvert.DeserializeObject<MyMovie>(strMJson);
                txtTitle.Text = MyObj.name;
                ddlType1.Text = MyObj.genre[0];
                if (MyObj.genre.Count > 1)
                    ddlType2.Text = MyObj.genre[1];
                if (MyObj.genre.Count > 2)
                    ddlType3.Text = MyObj.genre[2];
                if (MyObj.genre.Count > 3)
                    ddlType4.Text = MyObj.genre[3];
                txtAction.Text = "0";
                txtSex.Text = "0";
                txtHumor.Text = "0";
                lblUniverse.Text = "0";
                txtDescription.Text = MyObj.description;
                txtCitation.Text = MyObj.keywords;
                txtAge.Text = MyObj.datePublished.Substring(0, MyObj.datePublished.IndexOf('-'));
                pictureBox1.Load(MyObj.image);
                txtImDb_Link.Text = MyObj.url;
                lstActors.Enabled = true;
                foreach (Actor a in MyObj.actor)
                {
                    lstActors.Items.Add(a.name);
                    ActorsImDb.Add(a.url);
                }
                txtDirector.Text = MyObj.director[0].name;
                DirectorImDb = MyObj.director[0].url;
                txtDirector.BackColor = Color.White;
                btnGoToDirector.Enabled = true;
                txtWriter.Text = MyObj.creator[0].name;
                txtWriter.BackColor = Color.White;
                WriterImDb = MyObj.creator[0].url;
                btnGotoWriter.Enabled = true;
                btnRemoveDirector.Enabled = true;
                btnRemoveWriter.Enabled = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (GenMovie == null)
                GenMovie = new Movie();
            if (GenMovie.ID > 0)
            {
                GenMovie.Age = Convert.ToInt32(txtAge.Text);
                GenMovie.Inner_Val = new DbRuler.Inner_Values();
                GenMovie.Inner_Val.Action = Convert.ToInt32(txtAction.Text);
                GenMovie.Inner_Val.Humor = Convert.ToInt32(txtHumor.Text);
                GenMovie.Inner_Val.Sexappeal = Convert.ToInt32(txtSex.Text);
                GenMovie.Title = txtTitle.Text;
                GenMovie.Citation = txtCitation.Text;
                GenMovie.Description = txtDescription.Text;
                int intNumberOfType = 0;
                if (ddlType1.SelectedIndex > 0)
                    intNumberOfType = 1;
                if (ddlType2.SelectedIndex > 0)
                    intNumberOfType = 2;
                if (ddlType3.SelectedIndex > 0)
                    intNumberOfType = 3;
                if (ddlType4.SelectedIndex > 0)
                    intNumberOfType = 4;
                TypeOfMovie[] MyTypeList = new TypeOfMovie[intNumberOfType];
                MyTypeList[0] = new TypeOfMovie(Convert.ToInt32(ddlType1.SelectedValue));
                if (ddlType2.SelectedIndex > 0)
                    MyTypeList[1] = new TypeOfMovie(Convert.ToInt32(ddlType2.SelectedValue));
                if (ddlType3.SelectedIndex > 0)
                    MyTypeList[2] = new TypeOfMovie(Convert.ToInt32(ddlType3.SelectedValue));
                if (ddlType4.SelectedIndex > 0)
                    MyTypeList[3] = new TypeOfMovie(Convert.ToInt32(ddlType4.SelectedValue));
                GenMovie.fkTdP = new Theatre(Convert.ToInt32(ddlTheatre.SelectedValue));
                GenMovie.fkFX = new SpecialEffectCompany(Convert.ToInt32(ddlSpecialEffect.SelectedValue));
                GenMovie.fkType = new TypeOfMovie[MyTypeList.Length];
                GenMovie.fkType = MyTypeList; 
                GenMovie.fkUniverse = Convert.ToInt32(lblUniverse.Text);                
                GenMovie.ImDB_Link = txtImDb_Link.Text;
                if (txtSuccess.Text.Length > 0)
                    GenMovie.Success = Convert.ToInt32(txtSuccess.Text);
                DialogResult Res = MessageBox.Show("Modificare Base_Audience e Success?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
                if (Res == DialogResult.Yes)
                {
                    GenMovie.Base_Audience = Convert.ToInt32(txtBase_Audience.Text);
                    GenMovie.Success = Convert.ToInt32(txtSuccess.Text);
                }
                GenMovie.Movie_WriteOnDb();
                if (IsWriterSet)
                    DbRuler.Creator.AddCharToMovie(GenMovie.ID, Convert.ToInt32(WriterImDb), "Writer");
                if (IsDirectorSet)
                    DbRuler.Creator.AddCharToMovie(GenMovie.ID, Convert.ToInt32(DirectorImDb), "Director");
                if (IsActorsSet)
                {
                    foreach (string s in ActorsImDb)
                    {
                        int intAppoID = -1;
                        int.TryParse(s, out intAppoID);
                        if (intAppoID > 0)
                            DbRuler.Creator.AddCharToMovie(GenMovie.ID, intAppoID, "Actor");
                    }
                }                
            }
            else
            {
                GenMovie.Age = Convert.ToInt32(txtAge.Text);
                GenMovie.Inner_Val = new DbRuler.Inner_Values();
                GenMovie.Inner_Val.Action = Convert.ToInt32(txtAction.Text);
                GenMovie.Inner_Val.Humor = Convert.ToInt32(txtHumor.Text);
                GenMovie.Inner_Val.Sexappeal = Convert.ToInt32(txtSex.Text);
                GenMovie.Title = txtTitle.Text;
                GenMovie.Citation = txtCitation.Text;
                GenMovie.Description = txtDescription.Text;
                int intNumberOfType = 0;
                if (ddlType1.SelectedIndex > 0)
                    intNumberOfType = 1;
                if (ddlType2.SelectedIndex > 0)
                    intNumberOfType = 2;
                if (ddlType3.SelectedIndex > 0)
                    intNumberOfType = 3;
                if (ddlType4.SelectedIndex > 0)
                    intNumberOfType = 4;
                TypeOfMovie[] MyTypeList = new TypeOfMovie[intNumberOfType];
                MyTypeList[0] = new TypeOfMovie(Convert.ToInt32(ddlType1.SelectedValue));
                if (ddlType2.SelectedIndex > 0)
                    MyTypeList[2] = new TypeOfMovie(Convert.ToInt32(ddlType2.SelectedValue));
                if (ddlType3.SelectedIndex > 0)
                    MyTypeList[3] = new TypeOfMovie(Convert.ToInt32(ddlType3.SelectedValue));
                if (ddlType4.SelectedIndex > 0)
                    MyTypeList[4] = new TypeOfMovie(Convert.ToInt32(ddlType4.SelectedValue));
                GenMovie.fkType = MyTypeList;
                GenMovie.fkTdP = new Theatre(Convert.ToInt32(ddlTheatre.SelectedValue));
                GenMovie.fkFX = new SpecialEffectCompany(Convert.ToInt32(ddlSpecialEffect.SelectedValue));
                GenMovie.fkUniverse = Convert.ToInt32(lblUniverse.Text);
                GenMovie.ImDB_Link = txtImDb_Link.Text;
                if (txtSuccess.Text.Length > 0)
                    GenMovie.Success = Convert.ToInt32(txtSuccess.Text);
                GenMovie.Movie_WriteOnDb();
                GenMovie.ID = Retriever.GetMaxMovieID();
                if (IsWriterSet)
                    DbRuler.Creator.AddCharToMovie(GenMovie.ID, Convert.ToInt32(WriterImDb), "Writer");                    
                if (IsDirectorSet)
                    DbRuler.Creator.AddCharToMovie(GenMovie.ID, Convert.ToInt32(DirectorImDb), "Director");
                if (IsActorsSet)
                {
                    foreach (string s in ActorsImDb)
                    {
                        int intAppoID = -1;
                        int.TryParse(s, out intAppoID);
                        if (intAppoID > 0)
                            DbRuler.Creator.AddCharToMovie(GenMovie.ID, intAppoID, "Actor");
                    }
                }
            }
            RefreshGrid();
            ClearAll();
        }

        private void ClearAll()
        {
            txtPrice.Text = "";
            txtBase_Audience.Text = "";
            txtSuccess.Text = "";
            txtAction.Text = "";
            txtAge.Text = "";
            txtCitation.Text = "";
            txtDescription.Text = "";
            txtHumor.Text = "";
            txtImDbLink.Text = "";
            txtImDb_Link.Text = "";
            txtSex.Text = "";
            txtTitle.Text = "";
            lblUniverse.Text = "";
            txtUniverse.Text = "";
            ddlType4.SelectedIndex = -1;
            ddlType3.SelectedIndex = -1;
            ddlType2.SelectedIndex = -1;
            ddlType1.SelectedIndex = -1;
            pictureBox1.Image = null;
            GenMovie = null;
            txtDirector.Text = "";
            txtWriter.Text = "";
            lstActors.Items.Clear();
            btnGotoWriter.Enabled = false;
            btnGoToDirector.Enabled = false;
            btnRemoveDirector.Enabled = false;
            btnRemoveWriter.Enabled = false;
            lstActors.Enabled = false;
            txtWriter.BackColor = Color.White;
            txtDirector.BackColor = Color.White;
            DirectorImDb = "";
            WriterImDb = "";
            ActorsImDb = new List<string>();
            IsActorsSet = false;
            IsDirectorSet = false;
            IsWriterSet = false;              
    }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void dbMovie_DoubleClick(object sender, EventArgs e)
        {
            int selectedrowindex = dgMovie.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgMovie.Rows[selectedrowindex];
            int intID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
            LoadDataAfterClick(intID);
        }

        private void LoadDataAfterClick(int intID)
        {
            GenMovie = new Movie(intID);
            txtTitle.Text = GenMovie.Title;
            txtSex.Text = GenMovie.Inner_Val.Sexappeal.ToString();
            txtAction.Text = GenMovie.Inner_Val.Action.ToString();
            txtAge.Text = GenMovie.Age.ToString();
            txtHumor.Text = GenMovie.Inner_Val.Humor.ToString();
            txtImDbLink.Text = GenMovie.Title;
            ddlType1.Text = GenMovie.fkType1.TypeOf;
            if (GenMovie.fkType != null)
            {
                if (GenMovie.fkType.Length > 0)
                {
                    ddlType1.Text = GenMovie.fkType[0].TypeOf;
                    if (GenMovie.fkType.Length > 1)
                        ddlType2.Text = GenMovie.fkType[1].TypeOf;
                    if (GenMovie.fkType.Length > 2)
                        ddlType3.Text = GenMovie.fkType[2].TypeOf;
                    if (GenMovie.fkType.Length > 3)
                        ddlType4.Text = GenMovie.fkType[3].TypeOf;
                }
            }
            ddlSpecialEffect.Text = GenMovie.fkFX.Name;
            ddlTheatre.Text = GenMovie.fkTdP.Name;
            txtDescription.Text = GenMovie.Description;
            txtCitation.Text = GenMovie.Citation;
            lblUniverse.Text = GenMovie.fkUniverse.ToString();
            txtImDb_Link.Text = GenMovie.ImDB_Link;
            txtSuccess.Text = GenMovie.Success.ToString();
            txtBase_Audience.Text = GenMovie.Base_Audience.ToString();
            if (GenMovie.ImDB_Link.Length > 0)
            {
                txtImDbLink.Text = "https://www.imdb.com" + GenMovie.ImDB_Link;
            }
            L_CharsMovies[] Cast = Retriever.GetCastFromMovie(intID);
            lstActors.Items.Clear();
            ActorsImDb.Clear();
            btnGoToDirector.Enabled = true;
            btnGotoWriter.Enabled = true;
            lstActors.Enabled = true;
            btnRemoveDirector.Enabled = true;
            btnRemoveWriter.Enabled = true;
            foreach (L_CharsMovies L in Cast)
            {
                GenericCharacters Gen;
                if (L.Char_Name == "Director")
                {
                    Gen = new GenericCharacters(L.ID_Char);
                    txtDirector.Text = Gen.Name + " " + Gen.Surname;
                    txtDirector.BackColor = Color.Azure;
                    IsDirectorSet = true;
                    DirectorImDb = L.ID_Char.ToString();
                }
                else
                {
                    if (L.Char_Name == "Writer")
                    {
                        Gen = new GenericCharacters(L.ID_Char);
                        txtWriter.Text = Gen.Name + " " + Gen.Surname;
                        txtWriter.BackColor = Color.Azure;
                        IsWriterSet = true;
                        WriterImDb = L.ID_Char.ToString();
                    }
                    else
                    {
                        Gen = new GenericCharacters(L.ID_Char);
                        lstActors.Items.Add(Gen.Name + " " + Gen.Surname);
                        ActorsImDb.Add(Gen.ID.ToString());
                        lstActors.Items[lstActors.Items.Count-1].BackColor = Color.Azure;
                        IsActorsSet = true;
                    }
                }
            }
        }

        private void CreateM_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            DataTable MyList = DbRuler.Retriever.GetTypeOfMoviesTable(true);
            IsDataBinding = true;

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

            MyList = new DataTable();
            MyList = DbRuler.Retriever.GetTheatreListTable();
            ddlTheatre.DisplayMember = "Name";
            ddlTheatre.ValueMember = "ID";
            ddlTheatre.DataSource = MyList;

            MyList = new DataTable();
            MyList = DbRuler.Retriever.GetFXCompanyListTable();
            ddlSpecialEffect.DisplayMember = "Name";
            ddlSpecialEffect.ValueMember = "ID";
            ddlSpecialEffect.DataSource = MyList;

            IsDataBinding = false;
            btnGotoWriter.Enabled = false;
            btnGoToDirector.Enabled = false;
            btnRemoveDirector.Enabled = false;
            btnRemoveWriter.Enabled = false;
            lstActors.Enabled = false;
            if (IDMovie > 0)
            {
                LoadDataAfterClick(IDMovie);
            }
        }

        private void RefreshGrid()
        {
            dgMovie.AutoGenerateColumns = false;
            if (txtFilter.Text.Length > 0)
                dgMovie.DataSource = Retriever.GetMoviesFromTitleLike(txtFilter.Text);
            else               
                dgMovie.DataSource = DbRuler.Retriever.GetMovies(); 
            lblCounter.Text = dgMovie.Rows.Count.ToString();
        }

        private void btnGotoWriter_Click(object sender, EventArgs e)
        {
            CreateC frmC = new CreateC();
            frmC.ExternalName = txtWriter.Text;
            frmC.ExternalLink = WriterImDb;
            DialogResult result = frmC.ShowDialog();
            if (result == DialogResult.OK)
            {
                bool blnSuccess = frmC.IsCreated;
                if (blnSuccess)
                {
                    txtWriter.Text = frmC.FullName;
                    txtWriter.BackColor = Color.Azure;
                    IsWriterSet = true;
                    WriterImDb = frmC.IDChar.ToString();
                }
                else
                {
                    txtWriter.BackColor = Color.Red;
                }
                blnSuccess = false;
            }
        }

        private void btnGoToDirector_Click(object sender, EventArgs e)
        {
            CreateC frmC = new CreateC();
            frmC.ExternalName = txtDirector.Text;
            frmC.ExternalLink = DirectorImDb;
            DialogResult result = frmC.ShowDialog();
            if (result == DialogResult.OK)
            {
                bool blnSuccess = frmC.IsCreated;
                if (blnSuccess)
                {
                    txtDirector.Text = frmC.FullName;
                    txtDirector.BackColor = Color.Azure;
                    IsDirectorSet = true;
                    DirectorImDb = frmC.IDChar.ToString();
                }
                else
                {
                    txtDirector.BackColor = Color.Red;
                }
                blnSuccess = false;
            }
        }
        
        private void lstActors_DoubleClick_1(object sender, EventArgs e)
        {
            if (lstActors.SelectedIndices.Count == 1)
            {
                CreateC frmC = new CreateC();
                frmC.ExternalName = lstActors.Items[lstActors.SelectedIndices[0]].Text;
                frmC.ExternalLink = ActorsImDb[lstActors.SelectedIndices[0]];
                DialogResult result = frmC.ShowDialog();
                if (result == DialogResult.OK)
                {
                    bool blnSuccess = frmC.IsCreated;
                    if (blnSuccess)
                    {
                        IsActorsSet = true;
                        lstActors.Items[lstActors.SelectedIndices[0]].BackColor = Color.Azure;
                        ActorsImDb[lstActors.SelectedIndices[0]] = frmC.IDChar.ToString();
                    }
                    blnSuccess = false;
                }
            }
        }

        private void lstActors_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Delete == e.KeyCode)
            {
                string sel = ActorsImDb[lstActors.SelectedIndices[0]];
                int intAppo = -1;
                int.TryParse(sel, out intAppo);
                if (intAppo > 0)
                {
                    L_CharsMovies Link = new L_CharsMovies(GenMovie.ID, intAppo);
                    Link.L_CharsMovies_Delete();
                }
                lstActors.Items[lstActors.SelectedIndices[0]].Remove();
            }
        }

        private void btnAddActor_Click(object sender, EventArgs e)
        {
            lstActors.Items.Add(txtActor.Text);
            ActorsImDb.Add("NONE");
            txtActor.Text = "";            
        }

        private void btnRemoveActor_Click(object sender, EventArgs e)
        {
            if (lstActors.SelectedIndices.Count == 1)
            {
                DialogResult Res = MessageBox.Show("Vuoi davvero eliminare questo elemento?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Res == DialogResult.Yes)
                {
                    string[] strNameSurname = lstActors.Items[lstActors.SelectedIndices[0]].Text.Split(' ');
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
                            L_CharsMovies Link = new L_CharsMovies(Gen1[0].ID, GenMovie.ID, "Actor");
                            if (Link.L_CharsMovies_Delete())
                                MessageBox.Show("Actor Removed");
                            ActorsImDb.RemoveAt(lstActors.SelectedIndices[0]);
                            lstActors.Items.RemoveAt(lstActors.SelectedIndices[0]);
                        }
                }
            }
        }

        private void dgMovie_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgMovie.Rows[e.RowIndex].DataBoundItem != null) &&
                (dgMovie.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(
                              dgMovie.Rows[e.RowIndex].DataBoundItem,
                              dgMovie.Columns[e.ColumnIndex].DataPropertyName
                            );
            }
            if (dgMovie.Columns[e.ColumnIndex].DataPropertyName == "")
            {
                e.Value = Convert.ToInt32(dgMovie.Rows[e.RowIndex].Cells["Success"].Value) + Convert.ToInt32( dgMovie.Rows[e.RowIndex].Cells["Base_Audience"].Value);
            }
        }

        private string BindProperty(object property, string propertyName)
        {
            string retValue = "";

            if (propertyName.Contains("."))
            {
                string rightPropertyName = propertyName.Substring(propertyName.LastIndexOf(".")+1);
                Movie arrayProperties = (Movie) property;

                switch (rightPropertyName)
                {
                    case "Action":
                        retValue = arrayProperties.Inner_Val.Action.ToString();
                        break;
                    case "Humor":
                        retValue = arrayProperties.Inner_Val.Humor.ToString();
                        break;
                    case "Sexappeal":
                        retValue = arrayProperties.Inner_Val.Sexappeal.ToString();
                        break;
                }
            }
            else
            {
                Type propertyType;
                PropertyInfo propertyInfo;

                propertyType = property.GetType();
                propertyInfo = propertyType.GetProperty(propertyName);
                retValue = propertyInfo.GetValue(property, null).ToString();
            }

            return retValue;
        }

        private void txtAction_TextChanged(object sender, EventArgs e)
        {
            ChangeLabelFromValue("Action", txtAction.Text);
        }

        private void txtSex_TextChanged(object sender, EventArgs e)
        {
            ChangeLabelFromValue("Sexappeal", txtSex.Text);
        }

        private void txtHumor_TextChanged(object sender, EventArgs e)
        {
            ChangeLabelFromValue("Humor", txtHumor.Text);
        }

        private void ChangeLabelFromValue(string strLabelName, string strValue)
        {
            int intAppo = -1;
            string strValueTranslated = string.Empty;
            int.TryParse(strValue, out intAppo);
            if (intAppo > 0)
            {
                strValueTranslated = Retriever.GetNameOfValueFromInnerValue(intAppo, strLabelName, false);
            }
            switch (strLabelName)
            {
                case "Action":
                    lblActionName.Text = strValueTranslated;
                    break;
                case "Humor":
                    lblHumorName.Text = strValueTranslated;
                    break;
                case "Sexappeal":
                    lblSexappealName.Text = strValueTranslated;
                    break;
            }

        }

        private void btnCalculateSuccess_Click(object sender, EventArgs e)
        {
            GenericCharacters[] Gens = Retriever.GetGenericCastFromMovie(GenMovie.ID);
            Calculation.CalculateFilming(GenMovie, Gens, 5);            
            txtSuccess.Text = GenMovie.Success.ToString();
            txtBase_Audience.Text = GenMovie.Base_Audience.ToString();
            MessageBox.Show("Finito!");
        }

        private void btnCalculatePrice_Click(object sender, EventArgs e)
        {
            long Price = 0;
            Price = Calculation.GetTotalMovieCost(GenMovie);
            txtPrice.Text = String.Format("{0:n0}", Price).Replace(",",".") + " $";
            if (cbxShowReport.Checked)
            {
                FormReport frm = new FormReport();
                frm.tblDatiReport = LFMReportManager.GetDetailedCostReport(GenMovie);
                frm.ShowDialog();
            }
        }

        private void txtImDbLink_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGetFromImdb_Click(this, new EventArgs());
            }
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RefreshGrid();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            RefreshGrid();
        }

        private void ddlType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((ddlType1.SelectedIndex <= 0) && (!IsDataBinding))
            {
                MessageBox.Show("Non puoi selezionare un secondo genere prima di aver selezionato il primo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ddlType2.SelectedIndex = -1;
            }
        }

        private void ddlType3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((ddlType2.SelectedIndex <= 0) && (!IsDataBinding))
            {
                MessageBox.Show("Non puoi selezionare un terzo genere prima di aver selezionato il secondo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ddlType3.SelectedIndex = -1;
            }
        }

        private void ddlType4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((ddlType3.SelectedIndex <= 0) && (!IsDataBinding))
            {
                MessageBox.Show("Non puoi selezionare un quarto genere prima di aver selezionato il terzo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ddlType4.SelectedIndex = -1;
            }
        }

        private void btnCalcInnerValuesFromWriter_Click(object sender, EventArgs e)
        {
            int intNumberOfType = 0;
            if (ddlType1.SelectedIndex > 0)
                intNumberOfType = 1;
            if (ddlType2.SelectedIndex > 0)
                intNumberOfType = 2;
            if (ddlType3.SelectedIndex > 0)
                intNumberOfType = 3;
            if (ddlType4.SelectedIndex > 0)
                intNumberOfType = 4;
            TypeOfMovie[] MyTypeList = new TypeOfMovie[intNumberOfType];
            MyTypeList[0] = new TypeOfMovie(Convert.ToInt32(ddlType1.SelectedValue));
            if (ddlType2.SelectedIndex > 0)
                MyTypeList[1] = new TypeOfMovie(Convert.ToInt32(ddlType2.SelectedValue));
            if (ddlType3.SelectedIndex > 0)
                MyTypeList[2] = new TypeOfMovie(Convert.ToInt32(ddlType3.SelectedValue));
            if (ddlType4.SelectedIndex > 0)
                MyTypeList[3] = new TypeOfMovie(Convert.ToInt32(ddlType4.SelectedValue));
            L_CharsMovies[] WriterLink = Retriever.GetWriterFromMovie(GenMovie.ID);
            if (WriterLink.Length > 0)
            {
                GenericCharacters Gen = new GenericCharacters(WriterLink[0].ID_Char);
                MessageBox.Show("Inizio a calcolare i valori", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                long lngPrice = 0;
                Movie AppoMovie = Calculation.CreateMovieFromWriter(Gen, MyTypeList, 2018, out lngPrice);
                MessageBox.Show("After Writer write the script:" +
                    "\nAction: " + AppoMovie.Inner_Val.Action.ToString() + 
                    "\nHumor: " + AppoMovie.Inner_Val.Humor.ToString() +
                    "\nSex: " + AppoMovie.Inner_Val.Sexappeal.ToString() +
                    "\nSuccess: " + AppoMovie.Success.ToString() +
                    "\nAudience: " + AppoMovie.Base_Audience.ToString());
                L_CharsMovies[] DirectorLink = Retriever.GetDirectorFromMovie(GenMovie.ID);
                if (DirectorLink.Length > 0)
                {
                    GenericCharacters Dir = new GenericCharacters(DirectorLink[0].ID_Char);
                    Calculation.DirectorStyleChangeMovie(Dir, AppoMovie);
                    MessageBox.Show("After Director apply is competence:" +
                   "\nAction: " + AppoMovie.Inner_Val.Action.ToString() +
                   "\nHumor: " + AppoMovie.Inner_Val.Humor.ToString() +
                   "\nSex: " + AppoMovie.Inner_Val.Sexappeal.ToString() +
                    "\nSuccess: " + AppoMovie.Success.ToString() +
                    "\nAudience: " + AppoMovie.Base_Audience.ToString());
                }
                txtAction.Text = AppoMovie.Inner_Val.Action.ToString();
                txtHumor.Text = AppoMovie.Inner_Val.Humor.ToString();
                txtSex.Text = AppoMovie.Inner_Val.Sexappeal.ToString();
                txtPrice.Text = lngPrice.ToString();
                txtBase_Audience.Text = AppoMovie.Base_Audience.ToString();
                txtSuccess.Text = AppoMovie.Success.ToString();
            }
            else
                MessageBox.Show("Prima di calcolare i valori devi selezionare uno Sceneggiatore", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnRemoveWriter_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Do you really want to remove the Writer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.Yes)
            {
                if (WriterImDb.Length > 0)
                {
                    int IDWriter = Convert.ToInt32(WriterImDb);
                    L_CharsMovies Link = new L_CharsMovies(IDWriter, GenMovie.ID, "Writer");
                    if (Link.L_CharsMovies_Delete())
                    {
                        txtWriter.BackColor = Color.White;
                        WriterImDb = "";
                        IsWriterSet = false;
                    }
                }
                else
                    MessageBox.Show("No Writer set!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveDirector_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Do you really want to remove the Director?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.Yes)
            {
                if (WriterImDb.Length > 0)
                {
                    int IDDirector = Convert.ToInt32(DirectorImDb);
                    L_CharsMovies Link = new L_CharsMovies(IDDirector, GenMovie.ID, "Director");
                    if (Link.L_CharsMovies_Delete())
                    {
                        txtDirector.BackColor = Color.White;
                        DirectorImDb = "";
                        IsDirectorSet = false;
                    }
                }
                else
                    MessageBox.Show("No Director set!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMngUniv_Click(object sender, EventArgs e)
        {            
            UniverseManager frmU = new UniverseManager();
            frmU.SelectedID = Convert.ToInt32(lblUniverse.Text);
            frmU.NewUniverse = txtUniverse.Text;
            DialogResult result = frmU.ShowDialog();
            if (result == DialogResult.OK)
            {
                int intID = frmU.SelectedID;
                if (intID > 0)
                {
                    Universes Uni = new Universes(intID);
                    txtUniverse.Text = Uni.Name;
                    lblUniverse.Text = Uni.ID.ToString();
                }
            }
            
        }
    }
}