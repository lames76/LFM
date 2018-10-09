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

namespace LFM.MainGame.Report
{
    public partial class FormCharAffinity : Form
    {
        public List<GenericCharacters> ListGen { get; set; }
        public FormCharAffinity()
        {
            InitializeComponent();
        }
    }
}
