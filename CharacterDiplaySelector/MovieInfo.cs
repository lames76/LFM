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

namespace CharacterDiplaySelector
{
    public partial class MovieInfo : UserControl
    {
        public Movie MyMovie { get; set; }
        public Serial MySerial { get; set; }
        public bool IsAMovie { get; set; }

        public MovieInfo()
        {
            InitializeComponent();
        }

        private void MovieInfo_Load(object sender, EventArgs e)
        {
            List<GenericCharacters> CastList;
            if (IsAMovie)
            {
                txtTitle.Text = MyMovie.Title;
                CastList = Retriever.GetGenericCastFromMovie_List(MyMovie.ID);
            }
            else
            {
                txtTitle.Text = MySerial.Title;
                CastList = Retriever.GetGenericCastFromSerial_List(MySerial.ID, 1);
            }
            foreach (GenericCharacters G in CastList)
            {
                PhotoNameDisplayer ctrlPND = new PhotoNameDisplayer();
                ctrlPND.AC = AgeClass.Average;
                ctrlPND.MyChar = G;
                ctrlPND.Y = this.Height / 3;
                lstControls.Controls.Add(ctrlPND);
            }
        }
    }
}
