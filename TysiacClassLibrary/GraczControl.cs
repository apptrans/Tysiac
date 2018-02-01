using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TysiacClassLibrary
{
    public partial class GraczControl : UserControl
    {
        private Gracz gracz;
        public Gracz Gracz
        {
            get { return gracz; }
            set { gracz = value; }
        }

        public string Gracz_Text
        {
            get { return labelGracz.Text; }
            set { labelGracz.Text = value; }
        }

        public Image Gracz_Image
        {
            get { return pictureBoxGracz.Image; }
            set
            {
                pictureBoxGracz.Image = value;
                //pictureBoxGracz_MakeTransparent();
            }
        }

        public Label LabelGracz
        {
            get { return labelGracz; }
        }

        public PictureBox PictureBoxGracz
        {
            get { return pictureBoxGracz; }
        }

        public GraczControl()
        {
            InitializeComponent();
        }

        private void pictureBoxGracz_MakeTransparent()
        {
            Bitmap bitmapGracz = (Bitmap)pictureBoxGracz.Image;

            bitmapGracz.MakeTransparent();

            pictureBoxGracz.Image = bitmapGracz;
        }
    }
}
