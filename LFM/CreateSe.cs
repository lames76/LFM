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
    public partial class CreateSe : Form
    {
        private List<string> ActorsImDb = new List<string>();
        private TypeOfMovie[] Typo;
        private GenericCharacters Gen;
        private Serial newSer;


        public CreateSe()
        {
            InitializeComponent();
        }

        private void CreateSe_Load(object sender, EventArgs e)
        {
            lblCost.Text = "0";
            dgWriters.DataSource = Retriever.GetCharactersByType("Showrunner");
            ddlType1.DataSource = DbRuler.Retriever.GetTypeOfMovies();
            ddlType1.DisplayMember = "TypeOf";
            ddlType1.ValueMember = "ID";
            TypeOfMovie[] tmRet = DbRuler.Retriever.GetTypeOfMovies();
            ddlType2.DataSource = tmRet;
            ddlType2.DisplayMember = "TypeOf";
            ddlType2.ValueMember = "ID";
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
        }

        private void btnGenScriptMovie_Click(object sender, EventArgs e)
        {
            long Price = 0;
            newSer = Calculation.CreateSerialFromShowrunner(Gen, Typo, 2018, out Price);
            lblCost.Text = Price.ToString();
            txtTitle.Text = newSer.Title;
            txtAction.Text = newSer.Inner_Val.Action.ToString();
            txtHumor.Text = newSer.Inner_Val.Humor.ToString();
            txtSex.Text = newSer.Inner_Val.Sexappeal.ToString();
            txtSerialType1.Text = newSer.fkMainType.TypeOf;
            txtSerialType2.Text = newSer.fkSubType.TypeOf;
            txtDescription.Text = newSer.Description;
            txtAge.Text = newSer.Age.ToString();
            txtImDb_Link.Text = newSer.ImDB_Link;
            txtBaseAudience.Text = newSer.Base_Audience.ToString();
            txtEpisodes.Text = newSer.Episodes.ToString();
            lblUniverse.Text = "0";
            //CalculateFilming
        }

        private void dgWriters_DoubleClick(object sender, EventArgs e)
        {
            int selectedrowindex = dgWriters.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgWriters.Rows[selectedrowindex];
            int intIDWri = Convert.ToInt32(selectedRow.Cells[0].Value);
            Gen = new GenericCharacters(intIDWri);
            lblWriter.Text = Gen.Name + " " + Gen.Surname;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            newSer.Title = txtTitle.Text;
            newSer.Description = txtDescription.Text;
            newSer.ImDB_Link = txtImDb_Link.Text;
            newSer.Episodes = Convert.ToInt32(txtEpisodes.Text);
            newSer.fkUniverse = Convert.ToInt32(lblUniverse.Text);
            newSer.fkTdP = new Theatre(Convert.ToInt32(ddlTheatre.SelectedValue));
            newSer.fkFX = new SpecialEffectCompany(Convert.ToInt32(ddlSpecialEffect.SelectedValue));
            newSer.WriteOnDb();
            
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
                            L_CharsSerials Link = new L_CharsSerials(Gen1[0].ID, newSer.ID, "Actor");
                            if (Link.L_CharsMovies_Delete())
                                MessageBox.Show("Actor Removed");
                            ActorsImDb.RemoveAt(lstActors.SelectedIndices[0]);
                            lstActors.Items.RemoveAt(lstActors.SelectedIndices[0]);
                        }
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
                    GenericCharacters G = new GenericCharacters(intAppo);
                    Calculation.RemoveCastFromSerial(G, newSer, "Actor");
                }
                lstActors.Items[lstActors.SelectedIndices[0]].Remove();
            }
        }

        private void lstActors_DoubleClick(object sender, EventArgs e)
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
                        lstActors.Items[lstActors.SelectedIndices[0]].BackColor = Color.Azure;
                        ActorsImDb[lstActors.SelectedIndices[0]] = frmC.IDChar.ToString();
                        GenericCharacters G = new GenericCharacters(frmC.IDChar);
                        Calculation.AddCastToSerial(G, newSer, "Actor");
                    }
                    blnSuccess = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtBaseAudience.Text = Calculation.GetAudienceFromCast(newSer).ToString();
        }
    }
}
