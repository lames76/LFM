﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LFM.MainGame.Gestione
{
    public partial class Gestione : Form
    {
        public bool IsAgingOn { get; set; }
        public int Year { get; set; }

        public Gestione()
        {
            InitializeComponent();
        }

        private void btnMoviesInProduction_Click(object sender, EventArgs e)
        {
            MovieProd frmMovieProd = new MovieProd();
            frmMovieProd.IsAgingOn = IsAgingOn;
            frmMovieProd.Year = Year;
            frmMovieProd.IsMovie = true;
            frmMovieProd.ShowDialog();
        }

        private void btnSerialsInProduction_Click(object sender, EventArgs e)
        {
            MovieProd frmMovieProd = new MovieProd();
            frmMovieProd.IsAgingOn = IsAgingOn;
            frmMovieProd.Year = Year;
            frmMovieProd.IsMovie = false;
            frmMovieProd.ShowDialog();
        }
    }
}
