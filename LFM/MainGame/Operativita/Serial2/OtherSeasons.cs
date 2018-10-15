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

namespace LFM.MainGame.Operativita.Serial2
{
    public partial class OtherSeasons : Form
    {
        public int MySerialID { get; set; }
        public long Balance { get; set; }
        public List<LastCashMovement> ListTotalCost { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Week { get; set; }
        public bool IsAgingOn { get; set; }
        public long lngTOTALPrice { get; set; } = 0;

        private  TypeOfMovie[] ListOfTypes { get; set; }
        private Serial MySerial;
        private GenericCharacters Showrunner;
        private GenericCharacters[] Cast;
        private GenericCharacters Actor;
        private bool blnShR = false;
        private bool blnTdP = false;
        private bool blnFX = false;
        private bool blnCast = false;
        private int BaseAudienceOld = 0;
        private List<GenericCharacters> CastList = new List<GenericCharacters>();

        #region Rollback variable
        private string strTitle = "";
        private int intFX = -1;
        private int intTdP = -1;
        private bool bolNewSR = false;
        private GenericCharacters OldShorwunner;
        private List<L_CharsSerials> CastChange = new List<L_CharsSerials>();
        #endregion

        public OtherSeasons()
        {
            InitializeComponent();
            charDisplaySelector1.onCharSelected += new EventHandler(OnCharSelectedShowRunner);
            charDisplaySelectorActor.onCharSelected += new EventHandler(OnCharSelectedActor);
        }

        private void AssignInitialCast()
        {
            CastList = Retriever.GetGenericCastFromSerial_List(MySerial.ID, 1);
            foreach(GenericCharacters G in CastList)
            {
                if (G.TypeOf.ID == 8)
                    Showrunner = new GenericCharacters(G.ID);
                else
                {
                    lstListOfCastSel.Items.Add(G.Name + " " + G.Surname);
                }
            }
        }

        private void GetAndSetSeasonNumber()
        {
            strTitle = MySerial.Title;
            int intSeasonNumber = -1;
            string[] strTit = MySerial.Title.Split('-');
            strTit[strTit.Length - 1] = strTit[strTit.Length - 1].Replace("S", "");
            int.TryParse(strTit[strTit.Length - 1], out intSeasonNumber);
            if (intSeasonNumber > 0)
            {
                MySerial.Title = MySerial.Title.Replace(" - S" + intSeasonNumber.ToString(),"");
                intSeasonNumber++;
            }
            else
                intSeasonNumber = 2;
            MySerial.Title += " - S" + intSeasonNumber.ToString();
        }


        private void OtherSeasons_Load(object sender, EventArgs e)
        {
            MySerial = new Serial(MySerialID);

            GetAndSetSeasonNumber();

            BaseAudienceOld = MySerial.Base_Audience * 30 / 100;
            MySerial.Base_Audience = 0;

            if (MySerial.fkSubType != null)
                ListOfTypes = new TypeOfMovie[2];
            else
                ListOfTypes = new TypeOfMovie[1];
            ListOfTypes[0] = new TypeOfMovie(MySerial.fkMainType.ID);
            if (MySerial.fkSubType != null)
                ListOfTypes[1] = new TypeOfMovie(MySerial.fkSubType.ID);

            AssignInitialCast();

            ListTotalCost = new List<LastCashMovement>();
            txtBudget.Text = String.Format("{0:n0}", Balance).Replace(",", ".");
            txtCostoTotale.Text = "0";
            txtDifference.Text = "0";
            charDisplaySelector1.Year = Year;
            charDisplaySelector1.ListOfTypes = ListOfTypes;
            charDisplaySelector1.IsMovie = false;
            charDisplaySelector1.IsAgingOn = IsAgingOn;
            charDisplaySelector1.SetInitialSelection(Showrunner.ID);
            charDisplaySelectorActor.Year = Year;
            charDisplaySelectorActor.ListOfTypes = ListOfTypes;
            charDisplaySelectorActor.IsMovie = false;
            charDisplaySelectorActor.IsAgingOn = IsAgingOn;
            charDisplaySelector1.HideBusy = true;
            charDisplaySelectorActor.HideBusy = true;
            charDisplaySelectorActor.MySerial = MySerial;

            DataTable MyList = new DataTable();
            MyList = DbRuler.Retriever.GetTheatreListTable();
            ddlTheatre.DisplayMember = "Name";
            ddlTheatre.ValueMember = "ID";
            ddlTheatre.DataSource = MyList;

            ddlTheatre.Text = MySerial.fkTdP.Name;

            MyList = new DataTable();
            MyList = DbRuler.Retriever.GetFXCompanyListTable();
            ddlSpecialEffect.DisplayMember = "Name";
            ddlSpecialEffect.ValueMember = "ID";
            ddlSpecialEffect.DataSource = MyList;

            ddlSpecialEffect.Text = MySerial.fkFX.Name;

            EnableTab(1, false);
            EnableTab(2, false);
            EnableTab(3, true);
            EnableTab(0, true);     
                        
        }

        /// <summary>
        /// 0 Showrunner, 1 Script/Writer, 2 Director, 3 Cast, 4 TdP e FX, 5 Riassunto
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="enable"></param>
        private void EnableTab(int Index, bool enable)
        {
            tabControlMovie.TabPages[Index].Enabled = enable;
        }

        #region Showrunner
        protected void OnCharSelectedShowRunner(object sender, EventArgs e)
        {
            GenericCharacters NewShowrunner = new GenericCharacters(charDisplaySelector1.Gener.ID);
            // Se cambia lo showrunner si abbassa l'audience di 100
            if (NewShowrunner != Showrunner)
            {
                #region SpecialAbilities (Alpha)
                int intBonusAudience = 0;
                int intBonusSuccess = 0;
                int intBonusAction = 0;
                int intBonusHumor = 0;
                int intBonusSexappeal = 0;
                Retriever.GetBonusFromSkills(NewShowrunner, out intBonusAudience, out intBonusSuccess, out intBonusAction, out intBonusHumor, out intBonusSexappeal);
                #endregion
                bolNewSR = true;
                OldShorwunner = new GenericCharacters(Showrunner.ID);
                BaseAudienceOld -= 100;
                MySerial.Base_Audience += BaseAudienceOld + NewShowrunner.Talent + NewShowrunner.Skills + intBonusAudience;
                Showrunner = new GenericCharacters(NewShowrunner.ID);
                // Set old Showrunner to inactive
                L_CharsSerials Link = new L_CharsSerials(OldShorwunner.ID, MySerial.ID, "Showrunner");
                Link.UpdateActive(0);
                CastChange.Add(Link);
                Link = new L_CharsSerials(Showrunner.ID, MySerial.ID, "Showrunner");
                Link.InsertDb();
                CastChange.Add(Link);
            }
            else
            {
                MySerial.Base_Audience += BaseAudienceOld;
            }
            MessageBox.Show("Lo Showrunner ha pensato alla nuova stagione del serial.");
            // Add Showrunner to expense List
            LastCashMovement Mov = new LastCashMovement();
            Mov.ID_Target = MySerial.ID;
            Mov.Target = TypeOfObject.Serial;
            Mov.ID_Movement = Showrunner.ID;
            Mov.MovementValue = charDisplaySelector1.Price;
            Mov.TypeOfMovement = TypeOfObject.Showrunner;
            Mov.Year = Year;
            Mov.Month = Month;
            Mov.Week = Week;
            ListTotalCost.Add(Mov);

            blnShR = true;
            EnableTab(0, false);
            EnableTab(1, true);
        }
        #endregion

        #region TdP e FX
        private void btnSelezionaFX_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Sei sicuro di voler selezionare questi effetti speciali? \nNon potrai cambiare una volta scelti.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.Yes)
            {
                // Add FX to expense List
                LastCashMovement Mov = new LastCashMovement();
                intFX = MySerial.fkFX.ID;
                MySerial.fkFX = new SpecialEffectCompany(Convert.ToInt32(ddlSpecialEffect.SelectedValue));
                Mov.ID_Target = MySerial.ID;
                Mov.Target = TypeOfObject.Serial;
                Mov.MovementValue = Calculation.GetFXCostFromMovie(MySerial);

                blnFX = true;
                if (blnTdP && blnFX)
                {
                    EnableTab(1, false);
                }
                gbxFX.Enabled = false;
                Mov.ID_Movement = Convert.ToInt32(ddlSpecialEffect.SelectedValue);
                Mov.TypeOfMovement = TypeOfObject.FX;
                Mov.Year = Year;
                Mov.Month = Month;
                Mov.Week = Week;
                ListTotalCost.Add(Mov);
            }
        }

        private void btnSelectTdP_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Sei sicuro di voler selezionare questo questo Set? \nNon potrai cambiare una volta scelto.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.Yes)
            {
                // Add TdP to expense List
                LastCashMovement Mov = new LastCashMovement();
                intTdP = MySerial.fkTdP.ID;
                MySerial.fkTdP = new Theatre(Convert.ToInt32(ddlTheatre.SelectedValue));
                    Mov.ID_Target = MySerial.ID;
                    Mov.Target = TypeOfObject.Serial;
                    Mov.MovementValue = Calculation.GetTdPCostFromMovie(MySerial);

                blnTdP = true;
                if (blnTdP && blnFX)
                {
                    EnableTab(1, false);
                }
                gbxTdP.Enabled = false;
                Mov.ID_Movement = Convert.ToInt32(ddlTheatre.SelectedValue);
                Mov.TypeOfMovement = TypeOfObject.TdP;
                Mov.Year = Year;
                Mov.Month = Month;
                Mov.Week = Week;
                ListTotalCost.Add(Mov);
            }
        }

        private void ddlTheatre_SelectedIndexChanged(object sender, EventArgs e)
        {
            Theatre T = new Theatre(Convert.ToInt32(ddlTheatre.SelectedValue));
            lblTdPCost.Text = String.Format("{0:n0}", Calculation.GetPriceOfTheatre(T)).Replace(",", ".");
        }

        private void ddlSpecialEffect_SelectedIndexChanged(object sender, EventArgs e)
        {
            SpecialEffectCompany SP = new SpecialEffectCompany(Convert.ToInt32(ddlSpecialEffect.SelectedValue));
            lblFXCost.Text = String.Format("{0:n0}", Calculation.GetPriceOfFX(SP)).Replace(",", ".");
        }
        #endregion


        private void tabControlMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshMovieDataSoFar();
            long lngDiff = Balance - Convert.ToInt64(txtCostoTotale.Text.Replace(".", ""));
            txtDifference.Text = String.Format("{0:n0}", lngDiff).Replace(",", ".");
            if (lngDiff > 0)
                txtDifference.BackColor = Color.PaleGreen;
            else
                txtDifference.BackColor = Color.LightPink;
        }

        #region Cast
        private bool WasInPreviousSeason(int CharID)
        {
            foreach (GenericCharacters G in CastList)
            {
                if (G.ID == CharID)
                    return true;
            }
            return false;
        }

        private void btnRemoveActor_Click(object sender, EventArgs e)
        {
            if (lstListOfCastSel.SelectedIndices.Count == 1)
            {
                DialogResult Res = MessageBox.Show("Vuoi davvero eliminare questo elemento? Se la rimuovi non potrai reinserirla.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                            L_CharsSerials Link = new L_CharsSerials(Gen1[0].ID, MySerial.ID, "Actor");
                            if (WasInPreviousSeason(Gen1[0].ID))
                            {                                
                                if (Link.UpdateActive(0))
                                    MessageBox.Show("Actor Removed");
                                // Lower the audience for each actor removed
                                MySerial.Base_Audience -= 50;
                                CastChange.Add(Link);
                            }
                            else
                            {
                                if (Link.L_CharsMovies_Delete())
                                    MessageBox.Show("Actor Removed");
                            }
                            lstListOfCastSel.Items.RemoveAt(lstListOfCastSel.SelectedIndices[0]);                            
                        }
                }
            }
        }

        private void btnAFinishSelect_Click(object sender, EventArgs e)
        {
            Cast = Retriever.GetGenericCastFromSerial(MySerial.ID, 1);
            if (Cast.Length > 0)
            {
                DialogResult Res = MessageBox.Show("Sei sicuro di voler finire con l'assegnazione del Cast? \nNon potrai cambiare una volta finito.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Res == DialogResult.Yes)
                {
                    foreach (GenericCharacters Gen in Cast)
                    {
                        // Add Actor to expense List
                        LastCashMovement Mov = new LastCashMovement();
                        Mov.ID_Movement = Gen.ID;
                        Mov.ID_Target = MySerial.ID;
                            Mov.Target = TypeOfObject.Serial;
                            Mov.MovementValue = Calculation.GetCashOfActor(Gen, MySerial);
                        
                        switch (Gen.TypeOf.TypeOf)
                        {
                            case "Actor":
                            case "Actress":
                                Mov.TypeOfMovement = TypeOfObject.Actor;
                                break;
                            case "Singer":
                                Mov.TypeOfMovement = TypeOfObject.Singer;
                                break;
                            case "Sport Star":
                                Mov.TypeOfMovement = TypeOfObject.Sport;
                                break;
                        }
                        Mov.Year = Year;
                        Mov.Month = Month;
                        Mov.Week = Week;
                        ListTotalCost.Add(Mov);
                    }

                    EnableTab(1, false);
                        EnableTab(2, true);
                    
                    blnCast = true;

                }
            }
        }

        protected void OnCharSelectedActor(object sender, EventArgs e)
        {
            Actor = new GenericCharacters(charDisplaySelectorActor.Gener.ID);

            L_CharsSerials Link = new L_CharsSerials(Actor.ID, MySerial.ID, "Actor");
            if (Link.InsertDb())
            {
                CastChange.Add(Link);
                lstListOfCastSel.Items.Add(Actor.Name + " " + Actor.Surname);
                MessageBox.Show("Actor Added");
            }            
        }
        #endregion

        #region Riassunto
        private void RefreshMovieDataSoFar()
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

        private void btnUpdateMov_Click(object sender, EventArgs e)
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
        #endregion

        private void btnProduce_Click(object sender, EventArgs e)
        {
            if (blnShR && blnFX && blnTdP && blnCast)
            {
                int Prod = 48 - MySerial.Episodes;
                MySerial.Status = MySerial.Episodes + Prod; // 1 year total
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Manca ancora qualcosa");
        }

        private void OtherSeasons_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Se ho fatto cancel devo cancellare tutto quello che ho creato finora
            if (this.DialogResult != DialogResult.OK)
            {
                if (MySerial != null)
                {
                    MySerial.Title = strTitle;
                    MySerial.fkFX = new SpecialEffectCompany(intFX);
                    MySerial.fkTdP = new Theatre(intTdP);
                    foreach (L_CharsSerials Link in CastChange)
                    {
                        if (Link.Active == 0)
                            Link.UpdateActive(1);
                        else
                        {
                            Link.L_CharsMovies_Delete();
                        }
                    }
                }                
                // Tolgo tutte le spese
                lngTOTALPrice = 0;
                ListTotalCost = new List<LastCashMovement>();
            }
        }
    }
}
