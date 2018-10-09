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
    public partial class CharDisplayer : UserControl
    {
        public GenericCharacters Gener { get; set;}
        public bool IsAgingOn { get; set; }
        public int Year { get; set; }
        public AgeClass AC { get; set; }
        public long Price { get; set; }
        public CharTypeEnum CharacterTypeInternal;
        public Movie MyMovie { get; set; }
        public Serial MySerial { get; set; }
        public bool IsMovie { get; set; }

        public CharDisplayer()
        {
            InitializeComponent();
        }

        public void LoadDataAfterClick(int intID)
        {
            Gener = new GenericCharacters(intID);
            lblAction.Text = Retriever.GetNameOfValueFromInnerValue(Gener.Inner_Val.Action, "Action", (ddlSex.Text == "F" ? true : false));
            lblSexappeal.Text = Retriever.GetNameOfValueFromInnerValue(Gener.Inner_Val.Sexappeal, "Sexappeal", (ddlSex.Text == "F" ? true : false));
            lblHumor.Text = Retriever.GetNameOfValueFromInnerValue(Gener.Inner_Val.Humor, "Humor", (ddlSex.Text == "F" ? true : false));
            int CalcAge = Year - Gener.Age;
            txtAge.Text = CalcAge.ToString();
            if (IsAgingOn)
            {
                AC = LFMUtils.GetAgeClassFromDate(Gener.Age, Year);
                ddlAgeClass.SelectedIndex = 0;
            }
            else
                ddlAgeClass.Text = "Average";
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

        private void RefreshAssignedSpecials(int intID)
        {
            SpecialAbilities[] AsSpec = Retriever.GetSpecialAbilitiesListByIDChar(intID);
            foreach (SpecialAbilities S in AsSpec)
            {
                lstSpecials.Items.Add(S.Name);
            }
        }

        public void ClearAll()
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
            lstSpecials.Clear();
        }

        private void ddlAgeClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlAgeClass.Text)
            {
                case "Child": AC = AgeClass.Child;
                    break;
                case "Teen":
                    AC = AgeClass.Teen;
                    break;
                case "Average":
                    AC = AgeClass.Average;
                    break;
                case "Mature":
                    AC = AgeClass.Mature;
                    break;
                case "Old":
                    AC = AgeClass.Old;
                    break;
                case "Elf":
                    AC = AgeClass.Elf;
                    break;
                case "Timelord":
                    AC = AgeClass.Timelord;
                    break;
            }
            LoadRightImage();
        }
    }
}
