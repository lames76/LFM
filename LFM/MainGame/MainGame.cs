using DbRuler;
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
                }
                else
                {
                    LastExpenseDone.TypeOfMovement = TypeOfObject.Serial;
                    LastExpenseDone.ID_Movement = frmOp.MySerial.ID;
                    intTimeOfProduction = frmOp.MySerial.Episodes;
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
    }
}
