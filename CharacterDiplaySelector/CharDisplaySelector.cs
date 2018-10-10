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
        public bool HideBusy { get; set; }
        public bool IsAgingOn { get; set; }
        public bool IsMovie { get; set; }
        public int Year { get; set; }
        public CharTypeEnum CharacterTypeInternal;
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
                GenLista = Retriever.GetCharactersBySurnameLike(txtFilter.Text, Typ, 1, HideBusy);
            else
                GenLista = Retriever.GetCharacters(Typ, 1, HideBusy);
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
            ClearAll();
            int selectedrowindex = dgChars.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgChars.Rows[selectedrowindex];
            int intID = Convert.ToInt32(selectedRow.Cells[0].Value);
            LoadDataAfterClick(intID);
        }

        private void LoadDataAfterClick(int intID)
        {
            Gener = new GenericCharacters(intID);
            charDisplayer1.Gener = Gener;
            charDisplayer1.IsMovie = IsMovie;
            charDisplayer1.MyMovie = MyMovie;
            charDisplayer1.MySerial = MySerial;
            charDisplayer1.AC = AC;
            charDisplayer1.IsAgingOn = IsAgingOn;
            charDisplayer1.Year = Year;
            charDisplayer1.Price = Price;
            charDisplayer1.CharacterTypeInternal = CharacterTypeInternal;
            charDisplayer1.LoadDataAfterClick(intID);
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
            Gener = null;
            charDisplayer1.ClearAll();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (Gener != null)
            {
                if (LFMUtils.CheckIfCharacterIsFree(Gener.ID))
                {
                    DialogResult Res = MessageBox.Show("Sei sicuro di voler confermare la scelta? \nNon potrai cambiare una volta assegnato.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Res == DialogResult.Yes)
                    {
                        this.onCharSelected(this, new EventArgs());
                    }
                }
                else
                    MessageBox.Show("Questo personaggio è occupato in un altro lavoro.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
