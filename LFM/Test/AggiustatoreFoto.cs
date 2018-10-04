using DbRuler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LFM.Test
{
    public partial class AggiustatoreFoto : Form
    {
        AgeClass AC;
        int intIndex = 0;
        GenericCharacters[] Genes;

        public AggiustatoreFoto()
        {
            InitializeComponent();
        }

        private void AggiustatoreFoto_Load(object sender, EventArgs e)
        {
            Genes = Retriever.GetCharacters();
            AC = AgeClass.Average;
            LoadChar();           
        }

        void LoadChar()
        {
            GenericCharacters Gene = new GenericCharacters(Genes[intIndex].ID);
            txtName.Text = Gene.Name;
            txtSurname.Text = Gene.Surname;
            lblYear.Text  = Gene.Age.ToString();
            lblClass.Text = LFMUtils.GetAgeClassFromDate(Gene.Age, 2018).ToString();
            LoadRightImage(Gene);
        }

        private void LoadRightImage(GenericCharacters Gen)
        {
            if (Gen != null)
            {
                pictureBox1.Image = null;

                CharImages Img = new CharImages(Gen.ID, AC);
                if (Img.Image != null)
                {
                    pictureBox1.Image = ByteToImage(Img.Image);
                }
            }
        }

        public Image ByteToImage(byte[] imageBytes)
        {
            // Convert byte[] to Image
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);
            return image;
        }
        /*
        NoValue = 0,
        Timelord = 10,
        Child = 1,
        Teen = 2,
        Average = 3,
        Mature = 4,
        Old = 5,
        Elf = 11
        */

        private void button2_Click(object sender, EventArgs e)
        {
            AC++;
            if (AC > AgeClass.Old)
                AC = AgeClass.Child;
            lblAC.Text = AC.ToString();
            LoadChar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AC--;
            if (AC < AgeClass.Child)
                AC = AgeClass.Old;
            lblAC.Text = AC.ToString();
            LoadChar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            intIndex--;
            if (intIndex < 0)
                intIndex = Genes.Count() - 1;
            LoadChar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            intIndex++;
            if (intIndex >= Genes.Count())
                intIndex =  0;
            LoadChar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int Value = ddlAgeClass.SelectedIndex;
            DbRuler.CharImages Img = new CharImages(Genes[intIndex].ID, (AgeClass)Value);
            if (Img.Image != null)
            {
                //pictureBox1.Image = ByteToImage(Img.Image);
                if (pictureBox1.Image != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                        Img.Image = ms.ToArray();
                    }
                    Img.CharImages_UpdateImage();
                }
            }
            else
            {
                Img.IDChar = Genes[intIndex].ID;
                Img.AgeValue = (AgeClass)Value; 
                if (pictureBox1.Image != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        DbRuler.Creator.ResizeImage(pictureBox1.Image, 100, 130).Save(ms, pictureBox1.Image.RawFormat);
                        Img.Image = ms.ToArray();
                    }
                    Img.CharImages_Create();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CharImages Img = new CharImages(Genes[intIndex].ID, AC);
            Img.CharImages_DeleteImage();
        }
    }
}
