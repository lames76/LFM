﻿using DbRuler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LFM.MainGame
{
    public partial class MainGame : Form
    {
        /// <summary>
        /// This is the balance of the player
        /// </summary>
        public string GameName { get; set; }
        private LG_CashMovement Bank;
        public LastCashMovement LastExpenseDone { get; set; }

        private LG_MainGameData MainGameData;
        private Dictionary<int, int> MovieAudience= new Dictionary<int, int>();
        private List<int> MovieInProduction = new List<int>();
        private List<int> SerialInProduction = new List<int>();
        private List<int> SerialEndSeason = new List<int>();
        private Dictionary<int, int> MovieInTheatre = new Dictionary<int, int>();

        public MainGame()
        {
            InitializeComponent();
        }

        private void btnOperatività_Click(object sender, EventArgs e)
        {
            Operativita.Operativita frmOp = new Operativita.Operativita();
            frmOp.Balance = Bank.Balance();
            frmOp.Year = MainGameData.Year;
            frmOp.Month = MainGameData.Month;
            frmOp.Week = MainGameData.Week;
            frmOp.IsAgingOn = MainGameData.AgingOn;
            DialogResult Res = frmOp.ShowDialog();
            int intTimeOfProduction = 0;
            if (Res == DialogResult.OK)
            {
                LastExpenseDone = new LastCashMovement();
                LastExpenseDone.MovementValue = -frmOp.TotalPrice;
                LastExpenseDone.Year = MainGameData.Year;
                LastExpenseDone.Month = MainGameData.Month;
                LastExpenseDone.Week = MainGameData.Week;
                LastExpenseDone.Target = 0;
                LastExpenseDone.ID_Target = -1;
                List<LastCashMovement> ListLastTotalCost = frmOp.ListTotalCost;
                if (frmOp.IsMovie)
                {
                    LastExpenseDone.TypeOfMovement = TypeOfObject.Movie;
                    LastExpenseDone.ID_Movement = frmOp.MyMovie.ID;
                    intTimeOfProduction = frmOp.MyMovie.GetTotalProductionTime();
                    MovieInProduction.Add(frmOp.MyMovie.ID);
                }
                else
                {
                    LastExpenseDone.TypeOfMovement = TypeOfObject.Serial;
                    LastExpenseDone.ID_Movement = frmOp.MySerial.ID;
                    intTimeOfProduction = frmOp.MySerial.Episodes;
                    SerialInProduction.Add(frmOp.MySerial.ID);
                }
                // Aggiungo tutte le linee di spesa del film/serial
                Bank.AddLineBulk(ListLastTotalCost);
                // Totale Spesa del Film/Serial
                Bank.AddLine(LastExpenseDone);
                
                MessageBox.Show(intTimeOfProduction.ToString());
                SetEverything();
            }            
        }

        private void btnGestione_Click(object sender, EventArgs e)
        {
            Gestione.Gestione frmGest = new Gestione.Gestione();
            frmGest.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Report.Report frmRep = new Report.Report();
            frmRep.ShowDialog();
        }

        private void MainGame_Load(object sender, EventArgs e)
        {
            MainGameData = new LG_MainGameData(GameName);
            Bank = new LG_CashMovement();
            SetEverything();
        }

        /// <summary>
        /// This method set the Top menu with right value
        /// </summary>
        private void SetEverything()
        {
            txtPlayerName.Text = MainGameData.Name;
            txtStudiosName.Text = MainGameData.StudiosName;
            txtBalance.Text = String.Format("{0:n0}", Bank.Balance()).Replace(",", ".");
            if (Bank.Balance()< 0)
                txtBalance.BackColor = Color.LightPink;
            else
                txtBalance.BackColor = Color.PaleGreen;
            txtYear.Text = MainGameData.Year.ToString();
            txtMonth.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(MainGameData.Month);
            txtWeek.Text = MainGameData.Week.ToString();            
        }

        private void MainGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close the game?", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        private void btnNextWeek_Click(object sender, EventArgs e)
        {
            int Year = MainGameData.Year;
            int Month = MainGameData.Month;
            int Week = MainGameData.Week;
            Week++;
            // Change of Month?
            if (Week == 5)
            {
                Week = 1;
                Month++;
                // Change of Year?
                if (Month == 13)
                {
                    Month = 1;
                    Year++;
                    // Controllare se si ritira qualcuno (Se AgingOn = true)
                    int NumberOfNewCharPerYear = 0;
                    if (MainGameData.AgingOn)
                        NumberOfNewCharPerYear = 8;
                    LFMGamePlay.AnotherYearPassed(Year, MainGameData.AgingOn, NumberOfNewCharPerYear);
                }
            }
            MainGameData.Year = Year;
            MainGameData.Month = Month;
            MainGameData.Week = Week;           

            // Calcolare le spese di questa settimana
            
            MainGameData.UpdateDb();          

            NewWeekCalculation();
            SetEverything();
        }

        /// <summary>
        /// This method should be run every week start
        /// </summary>
        private void NewWeekCalculation()
        {
            #region Produzione
            List<int> ToBeRemoved = new List<int>();
            // For each producing movie remove 1 week
            foreach (int i in MovieInProduction)
            {
                Movie MyMovie = new Movie(i);
                if (LFMGamePlay.AnotherWeekPassed(MyMovie))
                {
                    // Add to the "remove from production" list
                    ToBeRemoved.Add(MyMovie.ID);
                    // Calculate all advancement
                    GenericCharacters[] GenArray = Retriever.GetGenericCastFromMovie(MyMovie.ID);
                    for (int l = 0; l < GenArray.Length; l++)
                    {                        
                        if (GenArray[l].TypeOf.TypeOf == "Director")
                            LFMGRule.DirectorAdvancement(GenArray[l], MyMovie.Inner_Val); 
                        else
                            if ((GenArray[l].TypeOf.TypeOf == "Actor") || (GenArray[l].TypeOf.TypeOf == "Actress"))
                            LFMGRule.ActorAdvancement(GenArray[l], MyMovie.Inner_Val);
                        long lngCash = LFMGRule.CalculateMoney(MovieAudience[MyMovie.ID]);
                        int Change = LFMGRule.GetPopularityChange(lngCash, MyMovie.Price(Bank));
                        LFMGRule.PopularityChange(GenArray[l], Change);
                        LFMGRule.AffinityChange(GenArray[l], Change);
                    }
                }
            }
            // If some Movie end production add it to the "on theatre" list
            if (ToBeRemoved.Count > 0)
            {
                foreach (int j in ToBeRemoved)
                {
                    MovieInProduction.Remove(j);
                    MovieInTheatre.Add(j, 1);
                }
            }
            #endregion
            #region Serial
            ToBeRemoved = new List<int>();
            // For each serial producing/on air remove 1 week
            foreach (int k in SerialInProduction)
            {
                Serial MySerial = new Serial(k);
                if (LFMGamePlay.AnotherWeekPassed(MySerial))
                {
                    // Add to "producing/on air removing" list
                    ToBeRemoved.Add(MySerial.ID);
                    // Calculate advancement
                    GenericCharacters[] GenArray = Retriever.GetGenericCastFromSerial(MySerial.ID, 1);
                    int Change = LFMGRule.GetPopularityChange(MySerial);
                    for (int n = 0; n < GenArray.Length; n++)
                    {                        
                        LFMGRule.ActorAdvancementForSerial(GenArray[n], MySerial.Inner_Val, MySerial.Episodes);                        
                        LFMGRule.PopularityChange(GenArray[n], Change);
                        LFMGRule.AffinityChange(GenArray[n], Change);
                    }
                    long Price = MySerial.Price(Bank);
                    int Perc = (Math.Abs(Change) == 10 ? 25 : 15);
                    long GainLoss = (Change > 0 ? 1 : -1) * (Price * Perc / 100);
                    long TotalSerial = Price + GainLoss;
                    // Aggiungo a Bilancio
                    LastCashMovement Mov = new LastCashMovement();
                    Mov.ID_Movement = MySerial.ID;
                    Mov.ID_Target = -1;
                    Mov.MovementValue = TotalSerial;
                    Mov.TypeOfMovement = TypeOfObject.Serial;
                    Mov.Month = MainGameData.Month;
                    Mov.Target = TypeOfObject.Balance;
                    Mov.Week = MainGameData.Week;
                    Mov.Year = MainGameData.Year;
                    Bank.AddLine(Mov);
                }
            }
            // If some Serial end production/on air add it to the "end of season" list
            if (ToBeRemoved.Count > 0)
            {
                foreach (int j in ToBeRemoved)
                {
                    SerialInProduction.Remove(j);
                    SerialEndSeason.Add(j);
                }
            }
            #endregion
            #region Money
            // Calcolare i film al cinema (incassi)            
            for (int i=0;i<MovieInTheatre.Count;i++)
            {
                // Recupero l'ID del film attuale dal primo dictionary, quello dei film in cinema
                int CurrentMovieID = MovieInTheatre.Keys.ElementAt(i);
                // Recupero l'audience del film da quelli in elenco
                int CurrentAudience = MovieAudience[CurrentMovieID];
                // Calcolo l'incasso settimanale ed aggiungo una riga nelle finanze
                long lngIncasso = LFMGRule.CalculateMoneyByWeeks(CurrentAudience, MovieInTheatre[i]);
                // Aggiungo a Bilancio
                LastCashMovement Mov = new LastCashMovement();
                Mov.ID_Movement = CurrentMovieID;
                Mov.ID_Target = -1;
                Mov.MovementValue = lngIncasso;
                Mov.TypeOfMovement = TypeOfObject.Movie;
                Mov.Month = MainGameData.Month;
                Mov.Target = TypeOfObject.Balance;
                Mov.Week = MainGameData.Week;
                Mov.Year = MainGameData.Year;
                Bank.AddLine(Mov);
                // Avanzo le settimane di quel film
                MovieInTheatre[i]++;                
            }
            // Recupero tutti gli ID di film che sono alla 7 settimana (e quindi da togliere dal cinema)
            List<int> itemsToRemove = LFMUtils.RemoveByValue(MovieInTheatre, 7);
            // Rimuovo anche gli stessi film dalla lista degli audience.
            foreach (int item in itemsToRemove)
            {
                MovieAudience.Remove(item);
            }
            #endregion
        }
    }
}
