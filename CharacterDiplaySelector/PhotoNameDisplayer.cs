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
    public partial class PhotoNameDisplayer : UserControl
    {
        public GenericCharacters MyChar  { get; set; }
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public AgeClass AC { get; set; }

        public PhotoNameDisplayer()
        {
            InitializeComponent();
        }

        private void PhotoNameDisplayer_Load(object sender, EventArgs e)
        {
            if (X > 0)
            {
                this.Width = X;
                this.Height = CalculateY();
            }
            if (Y > 0)
            {
                this.Height = Y;
                this.Width = CalculateX();
            }
            LoadRightImage();
        }

        private int CalculateY()
        {
            double dblApp = X * 1.10;
            return (int)dblApp;
        }

        private void LoadRightImage()
        {
            if (MyChar != null)
            {
                pictureBox1.Image = null;

                CharImages Img = new CharImages(MyChar.ID, AC);
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


        private int CalculateX()
        {
            double dblApp = Y / 1.10;
            return (int)dblApp;
        }


        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox1, MyChar.Name + " " + MyChar.Surname);
        }
    }
}
