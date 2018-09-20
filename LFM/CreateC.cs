using DbRuler;
using MyImDbParser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LFM
{
    public partial class CreateC : Form
    {
        public string ExternalName = "";
        public string ExternalLink = "";
        private DbRuler.GenericCharacters Gen;
        private bool blnIsEdit = false;
        private SpecialAbilities[] Specials;
        private List<int> AssignedAbilities = new List<int>();
        private bool blnIsBinding = false;

        public bool IsCreated { get; set; }
        public string FullName { get; set; }
        public int IDChar { get; set; }

        public CreateC()
        {
            InitializeComponent();
        }

        private void CreateC_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            blnIsBinding = true;
            ddlTypeOfCharacter.DataSource = DbRuler.Retriever.GetTypeOfCharactersTable();
            ddlTypeOfCharacter.DisplayMember = "TypeOf";
            ddlTypeOfCharacter.ValueMember = "ID";
            ddlTypeOfCharacter.SelectedIndex = -1;
            blnIsBinding = false;
            ddlAction.DataSource = null;            
            // If I call the form from the Movie form
            if (ExternalName.Length > 0)
            {                
                string[] strNameSurname = ExternalName.Split(' ');
                string strSurname = string.Empty;
                int intLastIndex = strNameSurname.Length - 1;
                if (strNameSurname[intLastIndex].ToUpper() != "JR.")
                    strSurname = strNameSurname[intLastIndex];
                else
                {
                    intLastIndex -= 1;
                    strSurname = strNameSurname[strNameSurname.Length - 2] + " " + strNameSurname[strNameSurname.Length - 1];
                }
                string strName = "";
                for (int i = 0; i < intLastIndex; i++)
                {
                    strName += strNameSurname[i] + " ";
                }
                GenericCharacters[] Gen1 = Retriever.GetCharactersByNameAndSurnameLike(strName.TrimEnd(), strSurname);
                if (Gen1 != null)
                    if (Gen1.Length == 1)
                    {
                        IDChar = Gen1[0].ID;
                        LoadDataAfterClick(Gen1[0].ID);
                        IsCreated = true;
                        dgFilmografia.AutoGenerateColumns = false;
                        dgFilmografia.DataSource = Retriever.GetMoviesFromPeopleID(Gen1[0].ID, true);
                        //RefreshAssignedSpecials(IDChar);
                    }
                    else
                        // Set the IMDB link
                        txtImDbLink.Text = "https://www.imdb.com" + ExternalLink;
                else
                    // Set the IMDB link
                    txtImDbLink.Text = "https://www.imdb.com" + ExternalLink;                
            }
        }

        private void RefreshSpecials(int intType)
        {
            lstAllSpecials.Clear();
            Specials = Retriever.GetSpecialAbilitiesListVByType(intType);
            foreach (SpecialAbilities S in Specials)
            {
                lstAllSpecials.Items.Add(S.Name);
            }
        }

        private void RefreshAssignedSpecials(int intID)
        {
            SpecialAbilities[] AsSpec = Retriever.GetSpecialAbilitiesListByIDChar(intID);
            foreach (SpecialAbilities S in AsSpec)
            {
                lstSpecials.Items.Add(S.Name);
                AssignedAbilities.Add(S.ID);
            }
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
            if (txtFilter.Text.Length > 0)
                GenLista = Retriever.GetCharactersBySurnameLike(txtFilter.Text);
            else
                GenLista = Retriever.GetCharacters();
            lblCounter.Text = GenLista.Length.ToString();
            dgChars.DataSource = GenLista;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            txtImDb_Link.Text = "";
            txtImDbLink.Text = "";
            blnIsEdit = false;
            txtAction.Text = "";
            txtAge.Text = "";
            txtHumor.Text = "";
            txtName.Text = "";
            txtPopularity.Text = "";
            txtSexappeal.Text = "";
            txtSkill.Text = "";
            txtSurname.Text = "";
            txtTalent.Text = "";
            ddlSex.SelectedIndex = -1;
            ddlTypeOfCharacter.SelectedIndex = -1;
            pictureBox1.Image = null;
            Gen = null;
            txtImDbLink.Text = "";
            lblHumorName.Text = "";
            lblActionName.Text = "";
            lblSexappealName.Text = "";
            dgFilmografia.DataSource = null;
            ddlAction.DataSource = null;
            ddlHumor.DataSource = null;
            ddlSexappeal.DataSource = null;
            lstSpecials.Clear();
        }

        private int GetRandomInner_Value(int intSelectedValue)
        {
            Random rndCasuale = new Random();
            int RetVal = intSelectedValue + rndCasuale.Next(-5,6);
            if (RetVal > 100)
                RetVal = 100;
            else
                if (RetVal < 0)
                RetVal = 0;
            return RetVal;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Gen == null)
                Gen = new GenericCharacters();
            Gen.Age = Convert.ToInt32(txtAge.Text);
            Gen.Inner_Val = new DbRuler.Inner_Values();
            Gen.Inner_Val.Action = GetRandomInner_Value(Convert.ToInt32(txtAction.Text));
            Gen.Inner_Val.Humor = GetRandomInner_Value(Convert.ToInt32(txtHumor.Text));
            Gen.Inner_Val.Sexappeal = GetRandomInner_Value(Convert.ToInt32(txtSexappeal.Text));
            Gen.Name = txtName.Text;
            Gen.Popularity = Convert.ToInt32(txtPopularity.Text);
            Gen.Sex = ddlSex.Text;
            Gen.Skills = GetRandomInner_Value(Convert.ToInt32(txtSkill.Text));
            Gen.Surname = txtSurname.Text;
            Gen.ImDB_Link = txtImDb_Link.Text;
            Gen.Talent = GetRandomInner_Value(Convert.ToInt32(txtTalent.Text));
            Gen.TypeOf = new DbRuler.TypeOfCharacters(Convert.ToInt32(ddlTypeOfCharacter.SelectedValue));
                       
            if (Gen.ID > 0)
            {
                IDChar = Gen.ID;
                Gen.GenericCharacters_WriteOnDb();
                IsCreated = true;
                DbRuler.CharImages Img = new CharImages(Gen.ID);
                if (Img.Image != null)
                {
                    //pictureBox1.Image = ByteToImage(Img.Image);
                    if (pictureBox1.Image != null)
                    {
                        using (var ms = new MemoryStream())
                        {
                            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                            Img.Image = ms.ToArray();
                        }
                        Img.CharImages_UpdateImage();
                    }
                }
                else
                {
                    Img.IDChar = Gen.ID;
                    if (pictureBox1.Image != null)
                    {
                        using (var ms = new MemoryStream())
                        {
                            DbRuler.Creator.ResizeImage(pictureBox1.Image, 100, 130).Save(ms, pictureBox1.Image.RawFormat);
                            Img.Image = ms.ToArray();
                        }
                        Img.CharImages_Create();
                    }
                }

                if (AssignedAbilities.Count > 0)
                {
                    // Elimino tutte le abilità
                    L_CharsAbilities Link = new L_CharsAbilities(Gen.ID, -1);
                    Link.L_CharsAbilities_Delete();
                    // Le reinserisco da capo così evito gli update
                    foreach (int Ab in AssignedAbilities)
                    {
                        Link = new L_CharsAbilities(Gen.ID, Ab);
                        Link.L_CharsAbilities_InsertDb();
                    }
                }
            }
            else
            {                
                Gen.GenericCharacters_WriteOnDb();
                IsCreated = true;
                int ID = Retriever.GetMaxCharacterID();

                DbRuler.CharImages Img = new CharImages();
                Img.IDChar = ID;
                IDChar = Gen.ID;
                if (pictureBox1.Image != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        DbRuler.Creator.ResizeImage(pictureBox1.Image, 100, 130).Save(ms, pictureBox1.Image.RawFormat);
                        Img.Image = ms.ToArray();
                    }
                    Img.CharImages_Create();
                }

                if (AssignedAbilities.Count > 0)
                {
                    // Elimino tutte le abilità
                    L_CharsAbilities Link = new L_CharsAbilities(Gen.ID, -1);
                    Link.L_CharsAbilities_Delete();
                    // Le reinserisco da capo così evito gli update
                    foreach (int Ab in AssignedAbilities)
                    {
                        Link = new L_CharsAbilities(Gen.ID, Ab);
                        Link.L_CharsAbilities_InsertDb();
                    }
                }
            }

            RefreshGrid();
            ClearAll();
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        //public static Image ResizeImage(Image image, int width, int height)
        //{
        //    var destRect = new Rectangle(0, 0, width, height);
        //    var destImage = new Bitmap(width, height);

        //    destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

        //    using (var graphics = Graphics.FromImage(destImage))
        //    {
        //        graphics.CompositingMode = CompositingMode.SourceCopy;
        //        graphics.CompositingQuality = CompositingQuality.HighQuality;
        //        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //        graphics.SmoothingMode = SmoothingMode.HighQuality;
        //        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

        //        using (var wrapMode = new ImageAttributes())
        //        {
        //            wrapMode.SetWrapMode(WrapMode.TileFlipXY);
        //            graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
        //        }
        //    }

        //    return (Image)destImage;
        //}

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (blnIsEdit)
            {
                // Displays an OpenFileDialog so the user can select a Cursor.
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                openFileDialog1.Title = "Seleziona Foto";

                // Show the Dialog.
                // If the user clicked OK in the dialog and
                // a .CUR file was selected, open it.
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Assign the cursor in the Stream to the Form's Cursor property.
                    string strViso = openFileDialog1.FileName;
                    pictureBox1.Image = Image.FromFile(strViso);                    
                }
            }
        }

        private void LoadDataAfterClick(int intID)
        {
            Gen = new GenericCharacters(intID);            
            lblActionName.Text = Gen.Inner_Val.Action.ToString();
            lblSexappealName.Text = Gen.Inner_Val.Sexappeal.ToString();
            lblHumorName.Text = Gen.Inner_Val.Humor.ToString();
            PopolateDropDownInnerValues(Gen);
            txtAge.Text = Gen.Age.ToString();            
            txtName.Text = Gen.Name;
            txtPopularity.Text = Gen.Popularity.ToString();            
            txtSkill.Text = Gen.Skills.ToString();
            txtSurname.Text = Gen.Surname;
            txtTalent.Text = Gen.Talent.ToString();
            ddlSex.Text = Gen.Sex;
            ddlTypeOfCharacter.SelectedValue = Gen.TypeOf.ID;
            blnIsEdit = true;
            IsCreated = true;
            txtImDb_Link.Text = Gen.ImDB_Link;
            if (Gen.ImDB_Link.Length > 0)
            {
                txtImDbLink.Text = "https://www.imdb.com" + Gen.ImDB_Link;
            }

            CharImages Img = new CharImages(intID);
            if (Img.Image != null)
            {
                pictureBox1.Image = ByteToImage(Img.Image);
            }
            dgFilmografia.AutoGenerateColumns = false;
            dgFilmografia.DataSource = Retriever.GetMoviesFromPeopleID(intID, true);
            RefreshAssignedSpecials(Gen.ID);
        }

        private void PopolateDropDownInnerValues(GenericCharacters Gen)
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
            ddlAction.DataSource = tblAppo;
            ddlAction.DisplayMember = "Name";
            ddlAction.ValueMember = "MaxValue";
            int intValue = (Gen != null ? Convert.ToInt32(Gen.Inner_Val.Action) : 0);
            ddlAction.SelectedIndex = GetIndexOfText(Retriever.GetNameOfValueFromInnerValue(intValue, "Action", (strSex == "F" ? true : false)), tblAppo);
            tblAppo = Retriever.GetNameOfValue("Humor", (strSex == "F" ? true : false));
            ddlHumor.DataSource = tblAppo;
            ddlHumor.DisplayMember = "Name";
            ddlHumor.ValueMember = "MaxValue";
            intValue = (Gen != null ? Convert.ToInt32(Gen.Inner_Val.Humor) : 0);
            ddlHumor.SelectedIndex = GetIndexOfText(Retriever.GetNameOfValueFromInnerValue(intValue, "Humor", (strSex == "F" ? true : false)), tblAppo);
            tblAppo = Retriever.GetNameOfValue("Sexappeal", (strSex == "F" ? true : false));
            ddlSexappeal.DataSource = tblAppo;
            ddlSexappeal.DisplayMember = "Name";
            ddlSexappeal.ValueMember = "MaxValue";
            intValue = (Gen != null ? Convert.ToInt32(Gen.Inner_Val.Sexappeal) : 0);
            ddlSexappeal.SelectedIndex = GetIndexOfText(Retriever.GetNameOfValueFromInnerValue(intValue, "Sexappeal", (strSex == "F" ? true : false)), tblAppo);
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

        //public Image Base64ToImage(string base64String)
        public Image ByteToImage(byte[] imageBytes)
        {
            // Convert byte[] to Image
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);
            return image;
        }

        private void dgChars_DoubleClick(object sender, EventArgs e)
        {
            int selectedrowindex = dgChars.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgChars.Rows[selectedrowindex];
            int intID = Convert.ToInt32(selectedRow.Cells[0].Value);
            LoadDataAfterClick(intID);
        }

        #region ImDb
        private void btnGetFromImdb_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Richiesta invita... attendere conferma");
            //IMDb imdb = new IMDb(txtImDbLink.Text, true);
            var uri = new Uri(txtImDbLink.Text);
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
                MyActor MyObj = new MyActor();
                try
                {
                    MyObj = Newtonsoft.Json.JsonConvert.DeserializeObject<MyActor>(MyImDb.Json);
                }
                catch
                {
                    MyActorSingle MyObj1 = Newtonsoft.Json.JsonConvert.DeserializeObject<MyActorSingle>(MyImDb.Json);
                    MyObj.birthDate = MyObj1.birthDate;
                    MyObj.context = MyObj1.context;
                    MyObj.description = MyObj1.description;
                    MyObj.image = MyObj1.image;
                    MyObj.jobTitle = new List<string>();
                    MyObj.jobTitle.Add(MyObj1.jobTitle);
                    MyObj.name = MyObj1.name;
                    MyObj.type = MyObj1.type;
                    MyObj.url = MyObj1.url;
                }
                string[] NameGet = MyObj.name.Split(' ');
                int LastIndex = 1;
                if (NameGet[NameGet.Length - 1].ToUpper() == "JR.")
                    LastIndex = 2;
                int Max = NameGet.Length - LastIndex;
                for (int i = 0; i < Max; i++)
                    txtName.Text += NameGet[i] + " ";
                txtName.Text = txtName.Text.TrimEnd();
                txtSurname.Text = (LastIndex == 1 ? NameGet[Max] : NameGet[Max - 1] + " Jr.");
                ddlTypeOfCharacter.Text = MyObj.jobTitle[0];
                txtSkill.Text = "0";
                txtAction.Text = "0";
                txtSexappeal.Text = "0";
                txtHumor.Text = "0";
                txtPopularity.Text = "0";
                txtTalent.Text = "0";
                if (MyObj.birthDate != null)
                    txtAge.Text = MyObj.birthDate.Substring(0, MyObj.birthDate.IndexOf('-'));
                txtImDb_Link.Text = MyObj.url;
                if (MyObj.image != null)
                    pictureBox1.Load(MyObj.image);
                PopolateDropDownInnerValues(Gen);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (ExternalName.Length > 0)
            {                
                FullName = ExternalName;
            }
        }

        private void dgFilmografia_DoubleClick(object sender, EventArgs e)
        {
            if (dgFilmografia.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgFilmografia.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgFilmografia.Rows[selectedrowindex];
                int intID = Convert.ToInt32(selectedRow.Cells[3].Value);
                CreateM frmMovie = new CreateM();
                frmMovie.IDMovie = intID;
                frmMovie.ShowDialog();
                dgFilmografia.DataSource = Retriever.GetMoviesFromPeopleID(intID, true);
            }
        }
        
        private void ChangeLabelFromValue(string strLabelName, string strValue)
        {
            string strSex = ddlSex.Text;
            int intAppo = -1;
            string strValueTranslated = string.Empty;
            int.TryParse(strValue, out intAppo);
            if (intAppo > 0)
            {
                strValueTranslated = Retriever.GetNameOfValueFromInnerValue(intAppo, strLabelName, (strSex == "F" ? true: false));
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Gen.ID > 0)
            {
                DialogResult Res = MessageBox.Show("ok", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Res == DialogResult.Yes)
                {
                    Gen.GenericCharacters_DeleteFromDb();
                }
            }
            else
                ClearAll();
        }

        private void ddlAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAction.SelectedValue != null)
                txtAction.Text = ddlAction.SelectedValue.ToString();
        }

        private void ddlSexappeal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSexappeal.SelectedValue != null)
                txtSexappeal.Text = ddlSexappeal.SelectedValue.ToString();
        }

        private void ddlHumor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHumor.SelectedValue != null)
                txtHumor.Text = ddlHumor.SelectedValue.ToString();
        }

        private void txtImDbLink_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGetFromImdb_Click(this, new EventArgs());
            }
        }

        private void btnAddSpecials_Click(object sender, EventArgs e)
        {
            if (lstAllSpecials.SelectedIndices.Count == 1)
            {
                int intID = Specials[lstAllSpecials.SelectedIndices[0]].ID;
                if (!AssignedAbilities.Any(item => item == intID))
                {
                    AssignedAbilities.Add(intID);
                    lstSpecials.Items.Add(Specials[lstAllSpecials.SelectedIndices[0]].Name);
                }
            }
        }

        private void btnRemoveSpecials_Click(object sender, EventArgs e)
        {
            if (lstSpecials.SelectedIndices.Count == 1)
            {
                int intID = lstSpecials.SelectedIndices[0];
                lstSpecials.Items.RemoveAt(intID);
                AssignedAbilities.RemoveAt(intID);
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

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            RefreshGrid();
        }

        private void ddlTypeOfCharacter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!blnIsBinding)
            {
                if (ddlTypeOfCharacter.SelectedIndex > -1)
                    if (ddlTypeOfCharacter.SelectedValue != null)
                    {
                        int intApp = -1;
                        int.TryParse(ddlTypeOfCharacter.SelectedValue.ToString(), out intApp);
                        if (intApp > 0)
                            RefreshSpecials(intApp);
                    }
            }
        }
    }
}
