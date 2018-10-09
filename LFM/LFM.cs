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
    public partial class LFM : Form
    {
        //private bool blnThereAreGames = false;

        public LFM()
        {
            InitializeComponent();
        }

        #region Test Area

        private void button1_Click(object sender, EventArgs e)
        {
            CreateC frmCreateC = new CreateC();
            frmCreateC.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateM frmCreateM = new CreateM();
            frmCreateM.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Vuoi randomizzare?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.Yes)
            {
                GenericCharacters[] GenList = Retriever.GetCharacters();
                foreach (GenericCharacters Gen in GenList)
                {
                    if (Gen.Skills > 0)
                    {
                        Gen.Inner_Val.Action = Randomize(Gen.Inner_Val.Action);
                        Gen.Inner_Val.Humor = Randomize(Gen.Inner_Val.Humor);
                        Gen.Inner_Val.Sexappeal = Randomize(Gen.Inner_Val.Sexappeal);
                        Gen.Skills = Randomize(Gen.Skills);
                        Gen.Talent = Randomize(Gen.Talent);
                        Gen.GenericCharacters_WriteOnDb();
                    }
                }
                MessageBox.Show("Finito!");
            }
        }

        private int Randomize(int action)
        {
            Random rndCasuale = new Random();
            action += rndCasuale.Next(-5, 5);
            if (action > 100)
                action = 100;
            else
                if (action < 0)
                    action = 0;
            return action;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TestMC frmM = new TestMC();
            frmM.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GenericCharacters G = Creator.CreateNewCharacter(2018, "F", new TypeOfCharacters(5));
            MessageBox.Show("Fatto!\nCreata " + G.Name + " " + G.Surname);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Movie[] MYMovies = Retriever.GetMovies();
            DialogResult Res = MessageBox.Show("Ricalcolo per tutti i film Success ed Audience?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Res == DialogResult.Yes)
            {
                foreach (Movie m in MYMovies)
                {
                    m.Base_Audience = 0;
                    m.Success = 0;
                    m.Movie_WriteOnDb();
                    // Calcolo base
                    TypeOfMovie[] MyTypeList = m.fkType;
                    L_CharsMovies[] WriterLink = Retriever.GetWriterFromMovie(m.ID);
                    if (WriterLink.Length > 0)
                    {
                        GenericCharacters Gen = new GenericCharacters(WriterLink[0].ID_Char);
                        if (cbxMsgBx.Checked)
                            MessageBox.Show("Inizio a calcolare i valori", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        long lngPrice = 0;
                        Movie AppoMovie = Calculation.CreateMovieFromWriter(Gen, MyTypeList, 2018, out lngPrice);
                        m.Base_Audience = AppoMovie.Base_Audience;
                        m.Success = AppoMovie.Success;
                        m.Inner_Val.Action = AppoMovie.Inner_Val.Action;
                        m.Inner_Val.Humor = AppoMovie.Inner_Val.Humor;
                        m.Inner_Val.Sexappeal = AppoMovie.Inner_Val.Sexappeal;
                        if (cbxMsgBx.Checked)
                            MessageBox.Show("After Writer write the script:" +
                                "\nAction: " + m.Inner_Val.Action.ToString() +
                                "\nHumor: " + m.Inner_Val.Humor.ToString() +
                                "\nSex: " + m.Inner_Val.Sexappeal.ToString() +
                                "\nSuccess: " + m.Success.ToString() +
                                "\nAudience: " + m.Base_Audience.ToString());
                        L_CharsMovies[] DirectorLink = Retriever.GetDirectorFromMovie(m.ID);
                        if (DirectorLink.Length > 0)
                        {
                            GenericCharacters Dir = new GenericCharacters(DirectorLink[0].ID_Char);
                            Calculation.DirectorStyleChangeMovie(Dir, m);
                            if (cbxMsgBx.Checked)
                                MessageBox.Show("After Director apply is competence:" +
                               "\nAction: " + m.Inner_Val.Action.ToString() +
                               "\nHumor: " + m.Inner_Val.Humor.ToString() +
                               "\nSex: " + m.Inner_Val.Sexappeal.ToString() +
                                "\nSuccess: " + m.Success.ToString() +
                                "\nAudience: " + m.Base_Audience.ToString());
                        }
                        m.Movie_WriteOnDb();
                        // Calcolo 
                        GenericCharacters[] Gens = Retriever.GetGenericCastFromMovie(m.ID);
                        Calculation.CalculateFilming(m, Gens, 5);
                    }
                }
                MessageBox.Show("Finito!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CreateSe frmSerial = new CreateSe();
            frmSerial.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LFMUtils.PrepareNewGame("ciao");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            double? dblUno = 1;
            double? dblDue = 2;
            double? dblTre = null;
            double? dblSum = 
                (dblUno.HasValue ? dblUno : 0) + 
                (dblDue.HasValue ?  dblDue : 0) + 
                (dblTre.HasValue ? dblTre : 0);
            MessageBox.Show(dblSum.HasValue ? dblSum.ToString() : "NINTE");
        }
        #endregion

        private void btnEsci_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Sei sicuro di voler uscire?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (Res == DialogResult.Yes)
            this.Close();
        }

        private void btnOpzioni_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented", "Opzioni Game");
        }

        private void btnCarica_Click(object sender, EventArgs e)
        {
            MainMenu.frmDirectorySelect frmDir = new MainMenu.frmDirectorySelect();
            DialogResult Res = frmDir.ShowDialog();
            if (Res == DialogResult.OK)
            {
                string strGameName = frmDir.strSelected;
                LFMUtils.PrepareConnectionString(strGameName);
                CaricaPartita(strGameName,true);
            }
        }

        private void CaricaPartita(string strGameName, bool IsLoading)
        {
            MainGame.MainGame frmMainGame = new MainGame.MainGame();
            frmMainGame.GameName = strGameName;
            frmMainGame.IsLoading = IsLoading;
            this.Hide();
            frmMainGame.ShowDialog();
            this.Show();
        }

        private void btnContinueNew_Click(object sender, EventArgs e)
        {            
            frmInputBox ibGameName = new frmInputBox();
            ibGameName.strTesto = "Inserisci il nome della partita";
            DialogResult Res = ibGameName.ShowDialog();
            if (Res == DialogResult.OK)
            {
                string strGameName = LFMUtils.NormalizeGameName(ibGameName.strOutPut, true);
                LFMUtils.PrepareNewGame(strGameName);
                ibGameName = new frmInputBox();
                ibGameName.strTesto = "Inserisci il nome del tuo avatar in gioco";
                Res = ibGameName.ShowDialog();
                if (Res == DialogResult.OK)
                {
                    string strPlayerName = LFMUtils.NormalizeGameName(ibGameName.strOutPut, false);
                    ibGameName = new frmInputBox();
                    ibGameName.strTesto = "Inserisci il nome della tua casa di produzione";
                    Res = ibGameName.ShowDialog();
                    if (Res == DialogResult.OK)
                    {
                        string strStudiosName = LFMUtils.NormalizeGameName(ibGameName.strOutPut, false);
                        ibGameName = new frmInputBox();
                        ibGameName.IsNumeric = true;
                        ibGameName.strTesto = "Inserisci l'anno di partenza";
                        Res = ibGameName.ShowDialog();
                        if (Res == DialogResult.OK)
                        {
                            int intSelectedYear = Convert.ToInt32(ibGameName.strOutPut);
                            bool blnAgingOn = false;
                            Res = MessageBox.Show("Vuoi che i vari personaggi invecchino?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                            if (Res == DialogResult.Yes)
                                blnAgingOn = true;

                            LG_MainGameData oMainGame = new LG_MainGameData(strGameName);
                            oMainGame.Name = strPlayerName;
                            oMainGame.StudiosName = strStudiosName;
                            oMainGame.Year = intSelectedYear;
                            oMainGame.Week = 1;
                            oMainGame.Month = 1;
                            oMainGame.AgingOn = blnAgingOn;
                            if (oMainGame.InsertInDb())
                            {
                                CaricaPartita(strGameName, false);
                            }

                        }
                    }
                    else
                        return;
                }
                else
                    return;
            }
        }

        private void LFM_Load(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Test.AggiustatoreFoto frmo = new Test.AggiustatoreFoto();
            frmo.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            LFMUtils.RestoreOriginalDb();
            MessageBox.Show("Fatto!");
        }
    }
}
