using System;
using System.Collections.Generic;
using System.Drawing;

namespace TysiacClassLibrary
{
    [Serializable]
    public class Gracz
    {
        private string nickGracza;
        /// <summary>
        /// Unikalny, znakowy identyfikator gracza
        /// </summary>
        public string NickGracza { get { return nickGracza; } }

        private int numerGracza;
        /// <summary>
        /// Numer gracza przy stoliku
        /// </summary>
        public int NumerGracza
        {
            get { return numerGracza; }
        }

        [NonSerialized]
        private GraczControl graczControl;
        /// <summary>
        /// Zwraca powiązany obiekt klasy GraczControl, reprezentujący gracza na ekranie
        /// </summary>
        public GraczControl GraczControl
        {
            get { return graczControl; }
        }

        [NonSerialized]
        private ZbiorKart kartyRozdane = new ZbiorKart();
        /// <summary>
        /// Zwraca bądź ustawia zbiór kart rozdanych
        /// </summary>
        public ZbiorKart KartyRozdane
        {
            get { return kartyRozdane; }
            set { kartyRozdane = value; } // możliwość przypisania kart w FormStolikGracza
        }

        [NonSerialized]
        private ZbiorKart kartyWygrane = new ZbiorKart();
        /// <summary>
        /// Zwraca zbiór kart wygranych przez gracza w bieżącej rozgrywce
        /// </summary>
        public ZbiorKart KartyWygrane
        {
            get { return kartyWygrane; }
        }

        bool licytujacy = true;
        /// <summary>
        /// Zwraca bądź ustawia informację, czy gracz bierze udział w licytacji
        /// </summary>
        public bool Licytujacy
        {
            get { return licytujacy; }
            set { licytujacy = value; }
        }

        private int liczbaPunktowZAtu;

        private int wynikRozdania;
        /// <summary>
        /// Liczba punktów w ostatnim rozdaniu
        /// </summary>
        public int WynikRozdania
        {
            get { return wynikRozdania; }
        }

        int stanKontaGry = 0;
        /// <summary>
        /// Bieżąca liczba zdobytych punktów
        /// </summary>
        public int StanKontaGry
        {
            get { return stanKontaGry; }
            set { stanKontaGry = value; }
        }

        /// <summary>
        /// Konstruktor obiektu gracza
        /// </summary>
        public Gracz(string nickGracza, int numerGracza)
        {
            this.nickGracza = nickGracza;
            this.numerGracza = numerGracza;

            UstawPoczatekRundy();
        }

        /// <summary>
        /// Konstruktor obiektu gracza
        /// </summary>
        public Gracz(string nickGracza)
            : this(nickGracza, 0)
        {
        }

        /// <summary>
        /// Konstruktor obiektu gracza
        /// </summary>
        public Gracz(Gracz gracz)
            : this(gracz.NickGracza, gracz.NumerGracza)
        {
        }

        /// <summary>
        /// Wiąże obiekt gracza z obiektem klasy GraczControl reprezentującym gracza w interfejsie użytkownika
        /// </summary>
        public void LinkujZGraczControl(GraczControl graczControl)
        {
            this.graczControl = graczControl;
            graczControl.Gracz = this;
        }

        /// <summary>
        /// Ustawia parametry gracza na początku rundy
        /// </summary>
        internal void UstawPoczatekRundy()
        {
            kartyRozdane.UsunWszystkieKarty();
            kartyWygrane.UsunWszystkieKarty();

            Licytujacy = true;

            liczbaPunktowZAtu = 0;
            wynikRozdania = 0;
        }

        /// <summary>
        /// Zwraca napis reprezentujący gracza
        /// </summary>
        public override string ToString()
        {
            return nickGracza;
        }

        /// <summary>
        /// Informuje, czy gracz posiada parę kart Dama i Król w jednym kolorze
        /// </summary>
        internal bool MaPare()
        {
            foreach (KoloryKart kolorKarty in Enum.GetValues(typeof(KoloryKart)))
            {
                Karta krol = new Karta(kolorKarty, WagiKart.Król);
                Karta dama = new Karta(kolorKarty, WagiKart.Dama);

                if (kartyRozdane.AdresKarty(krol) != null && kartyRozdane.AdresKarty(dama) != null)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Zwiększa liczbę punktów gracza na podstawie meldunku
        /// </summary>
        internal void ZwiekszLiczbePunktowZAtu(KoloryKart kolorAtu)
        {
            liczbaPunktowZAtu += (int)kolorAtu;
        }

        /// <summary>
        /// Aktualizuje liczbę punktów gracza
        /// </summary>
        internal void ZaktualizujLiczbePunktow(int licytowanaStawka, bool rezygnacja)
        {
            int liczbaPunktow;

            if (rezygnacja)
                liczbaPunktow = 60;
            else
                liczbaPunktow = kartyWygrane.LiczbaPunktow + liczbaPunktowZAtu;

            if (!licytujacy)
                if (stanKontaGry < 800)
                    wynikRozdania = liczbaPunktow;
                else
                    wynikRozdania = 0;
            else
                if (rezygnacja)
                    wynikRozdania = -licytowanaStawka;
                else
                    if (liczbaPunktow >= licytowanaStawka)
                        wynikRozdania = licytowanaStawka;
                    else
                        wynikRozdania = -licytowanaStawka;

            stanKontaGry += wynikRozdania;
        }

        /// <summary>
        /// Dostosowuje wygląd obiektu do stany rozgrywki
        /// </summary>
        public void DostosujWyglad(Rozgrywka rozgrywka)
        {
            if (graczControl == null)
                return;

            if (rozgrywka.StanRozgrywki == StanyRozgrywki.Licytacja && !licytujacy)
                graczControl.LabelGracz.BackColor = Color.DarkGray;
            else
                if (rozgrywka.GraczRozgrywajacy == this)
                    graczControl.LabelGracz.BackColor = Color.LightBlue;
                else
                    graczControl.LabelGracz.BackColor = Color.Transparent;

            if (!graczControl.Visible)
            {
                graczControl.Gracz_Text = nickGracza;
                graczControl.Visible = true;
            }
        }
    }
}