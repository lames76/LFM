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
    public partial class CharDisplaySelector: UserControl
    {
        public bool IsMovie { get; set; }
        public int Year { get; set; }
        private CharTypeEnum CharacterTypeInternal;
        public CharTypeEnum CharacterType
        {
            get { return CharacterTypeInternal; }
            set {
                if ((value == CharTypeEnum.Actor) || (value == CharTypeEnum.Actress))
                {
                    ddlSexFilter.Visible = true;
                    ddlActorOrOthers.Visible = true;
                }
                else
                {
                    ddlSexFilter.Visible = false;
                    ddlActorOrOthers.Visible = false;
                }
                CharacterTypeInternal = value;
            }
        }
        public AgeClass AC { get; set; }
        public long Price { get; set; }
        public Movie MyMovie { get; set; }
        public Serial MySerial { get; set; }
        public GenericCharacters Gener { get; set; }
        public TypeOfMovie[] ListOfTypes { get; set; }

        public event EventHandler onCharSelected;

        public CharDisplaySelector()
        {
            InitializeComponent();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            GenericCharacters[] GenLista;
            TypeOfCharacters Typ = new TypeOfCharacters((int)CharacterTypeInternal);
            if (ddlActorOrOthers.Visible == true)
            {
                if (ddlActorOrOthers.Text == "Actors")
                {
                    if (ddlSexFilter.Text == "M")
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
            }
            if (txtFilter.Text.Length > 0)
                GenLista = Retriever.GetCharactersBySurnameLike(txtFilter.Text, Typ);
            else
                GenLista = Retriever.GetCharacters(Typ);
            lblCounter.Text = GenLista.Length.ToString();
            dgChars.DataSource = GenLista;
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
            int selectedrowindex = dgChars.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgChars.Rows[selectedrowindex];
            int intID = Convert.ToInt32(selectedRow.Cells[0].Value);
            LoadDataAfterClick(intID);
        }

        private void LoadDataAfterClick(int intID)
        {
            Gener = new GenericCharacters(intID);
            lblAction.Text = Retriever.GetNameOfValueFromInnerValue(Gener.Inner_Val.Action, "Action", (ddlSex.Text == "F" ? true : false));
            lblSexappeal.Text = Retriever.GetNameOfValueFromInnerValue(Gener.Inner_Val.Sexappeal, "Sexappeal", (ddlSex.Text == "F" ? true : false));
            lblHumor.Text = Retriever.GetNameOfValueFromInnerValue(Gener.Inner_Val.Humor, "Humor", (ddlSex.Text == "F" ? true : false));
            int CalcAge = Gener.Age - Year;
            txtAge.Text = CalcAge.ToString();
            AC = LFMUtils.GetAgeClassFromDate(Gener.Age, Year);
            txtName.Text = Gener.Name;
            txtPopularity.Text = Gener.Popularity.ToString();
            txtSurname.Text = Gener.Surname;
            ddlSex.Text = Gener.Sex;
            txtImDb_Link.Text = Gener.ImDB_Link;
            LoadRightImage();
            //dgFilmografia.AutoGenerateColumns = false;
            //dgFilmografia.DataSource = Retriever.GetMoviesFromPeopleID(intID, true);
            RefreshAssignedSpecials(Gener.ID);
            switch (CharacterTypeInternal)
            {
                case CharTypeEnum.Writer:
                    Price = Calculation.GetCashOfWriter(Gener);
                    break;
                case CharTypeEnum.Director:
                    Price = Calculation.GetCashOfDirector(Gener, MyMovie);
                    break;
                case CharTypeEnum.Actor:
                case CharTypeEnum.Actress:
                    if (IsMovie)
                        Price = Calculation.GetCashOfActor(Gener, MyMovie);
                    else
                        Price = Calculation.GetCashOfActor(Gener, MySerial);
                    break;
                case CharTypeEnum.Showrunner:
                    Price = Calculation.GetCashOfShowrunner(Gener);
                    break;
            }
            txtCost.Text = String.Format("{0:n0}", Price).Replace(",", ".");
        }

        private void RefreshAssignedSpecials(int intID)
        {
            SpecialAbilities[] AsSpec = Retriever.GetSpecialAbilitiesListByIDChar(intID);
            foreach (SpecialAbilities S in AsSpec)
            {
                lstSpecials.Items.Add(S.Name);
            }
        }

        private void LoadRightImage()
        {
            if (Gener != null)
            {
                pictureBox1.Image = null;

                CharImages Img = new CharImages(Gener.ID, AC);
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

        public event EventHandler CharSelected
        {
            add
            {
                onCharSelected += value;
            }
            remove
            {
                onCharSelected -= value;
            }
        }

        protected virtual void OnCharSelected(object sender, EventArgs e)
        {
            EventHandler handler = onCharSelected;
            handler?.Invoke(this, e);
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
            Gener = null;
            lblHumor.Text = "";
            lblAction.Text = "";
            lblSexappeal.Text = "";
            //dgFilmografia.DataSource = null;
            lstSpecials.Clear();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (Gener != null)
            {
                DialogResult Res = MessageBox.Show("Sei sicuro di voler confermare la scelta? \nNon potrai cambiare una volta assegnato.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Res == DialogResult.Yes)
                {
                    this.onCharSelected(this, new EventArgs());
                }
            }
        }

        private void ddlSexFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void ddlActorOrOthers_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }
    }
}
