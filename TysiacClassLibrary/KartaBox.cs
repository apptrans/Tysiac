using System.Windows.Forms;
using System.Drawing;

namespace TysiacClassLibrary
{
    public partial class KartaBox : UserControl
    {
        private Karta karta;
        public Karta Karta
        {
            get { return karta; }
            set { karta = value; }
        }

        public KartaBox()
        {
            InitializeComponent();

            Visible = false;
        }

        internal void Pokaz(Point pozycjaNaEkranie)
        {
            Location = pozycjaNaEkranie;
            BringToFront();

            Visible = true;
        }

        private void KartaBox_DoubleClick(object sender, System.EventArgs e)
        {
            if (Karta != null && Karta.ZbiorKart != null)
                Karta.ZbiorKart.OnDoubleClick(Karta.ZbiorKart, Karta);
        }

        private void KartaBox_MouseDown(object sender, MouseEventArgs e)
        {
            BringToFront();
        }

        private void KartaBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (Karta != null && Karta.ZbiorKart != null)
                Karta.ZbiorKart.Pokaz(Karta);
        }
    }
}
