using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DbRuler;
using Newtonsoft.Json;

namespace LFM
{
    public partial class FormReport : Form
    {
        public bool IsSimpleDisplayer { get; set; } = false;
        public DataTable tblDatiReport;

        public FormReport()
        {
            InitializeComponent();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            if (!IsSimpleDisplayer)
            {
                List<Movie> MyList = LFMGamePlay.GetMoviesOfPlayer();
                ddlMovieList.ValueMember = "ID";
                ddlMovieList.DisplayMember = "Title";
                ddlMovieList.DataSource = MyList;
            }
            else
                dgReport.DataSource = tblDatiReport;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgReport.DataSource = null;
            tblDatiReport = new DataTable();
            int intSel = (int)ddlMovieList.SelectedValue;
            Movie GenMovie = new Movie(intSel);
            tblDatiReport = LFMReportManager.GetDetailedCostReport(GenMovie);
            dgReport.AutoGenerateColumns = false;
            dgReport.DataSource = tblDatiReport;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (tblDatiReport != null)
            {
                if (tblDatiReport.Rows.Count > 0)
                {
                    DataTableToJSONWithJSONNet(tblDatiReport);
                    // Displays a SaveFileDialog so the user can save the Image  
                    // assigned to Button2.  
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "JSon File|*.json";
                    saveFileDialog1.Title = "Save a JSon File";
                    saveFileDialog1.ShowDialog();

                    // If the file name is not an empty string open it for saving.  
                    if (saveFileDialog1.FileName != "")
                    {
                        richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                    }
                }
            }
        }

        public string DataTableToJSONWithJSONNet(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }
    }
}
