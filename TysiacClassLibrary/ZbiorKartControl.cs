using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TysiacClassLibrary
{
    public partial class ZbiorKartControl : UserControl
    {
        private ZbiorKart zbiorKart;
        public ZbiorKart ZbiorKart
        {
            get { return zbiorKart; }
            set { zbiorKart = value; }
        }

        public string Nazwa_Text
        {
            get { return labelNazwa.Text; }
            set { labelNazwa.Text = value; }
        }

        public bool Nazwa_Visible
        {
            get { return labelNazwa.Visible; }
            set { labelNazwa.Visible = value; }
        }

        public bool Licznik_Visible
        {
            get { return labelLicznik.Visible; }
            set { labelLicznik.Visible = value; }
        }

        internal short StanLicznika
        {
            get { return Int16.Parse(labelLicznik.Text); }
            set { labelLicznik.Text = value.ToString(); }
        }

        public bool Sort_Visible
        {
            get { return buttonSort.Visible; }
            set { buttonSort.Visible = value; }
        }

        public bool Picture_Visible
        {
            get { return pictureBoxKarta.Visible; }
            set { pictureBoxKarta.Visible = value; }
        }

        public ZbiorKartControl()
        {
            InitializeComponent();

            Visible = false;
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            if (zbiorKart != null)
            {
                if (zbiorKart.Posortowany)
                {
                    if (zbiorKart.Porzadek == PorzadekSortowania.Malejący)
                        zbiorKart.Porzadek = PorzadekSortowania.Rosnący;
                    else
                        if (zbiorKart.Porzadek == PorzadekSortowania.Rosnący)
                            zbiorKart.Porzadek = PorzadekSortowania.Malejący;
                }

                zbiorKart.SortujKarty();
            }
        }
    }
}
