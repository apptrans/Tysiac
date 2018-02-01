using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;

namespace TysiacClassLibrary
{
    public enum PorzadekSortowania
    {
        Malejący, Rosnący
    }

    public enum StylePrezentacjiKart
    {
        Wyrównane, WyskakująceKolory
    }

    [Serializable]
    public class ZbiorKart
    {
        // Zbiór kart gracza
        //private List<Karta> karty = new List<Karta>();
        private ArrayList karty = new ArrayList();
        /// <summary>
        /// Kolekcja obiektów klasy Karta skojarzonych z obiektem klasy ZbiorKart
        /// </summary>
        public ArrayList Karty
        {
            get { return karty; }
        }

        public delegate void DoubleClickHandler(ZbiorKart zbiorKart, Karta karta);
        public event DoubleClickHandler DoubleClick;

        [NonSerialized]
        private ZbiorKartControl zbiorKartControl;
        /// <summary>
        /// Wskaźnik obiektu klasy ZbiorKartControl, reprezentującego graficznie zbiór kart
        /// </summary>
        public ZbiorKartControl ZbiorKartControl
        {
            get { return zbiorKartControl; }
        }

        [NonSerialized]
        private bool widoczny = true;
        /// <summary>
        /// Zwraca bądź ustawia widoczność zbioru kart
        /// </summary>
        public bool Widoczny
        {
            get { return widoczny; }
            set
            {
                widoczny = value;

                if (value)
                    Pokaz();
                else
                    Ukryj();
            }
        }

        private bool posortowany = false;
        /// <summary>
        /// Znacznik informujący czy zbiór kart jest posortowany
        /// </summary>
        public bool Posortowany
        {
            get { return posortowany; }
        }

        [NonSerialized]
        private PorzadekSortowania porzadek = PorzadekSortowania.Malejący;
        /// <summary>
        /// Zwraca bądź ustawia porządek sortowania
        /// </summary>
        public PorzadekSortowania Porzadek
        {
            get { return porzadek; }
            set { porzadek = value; }
        }

        [NonSerialized]
        private StylePrezentacjiKart stylPrezentacji = StylePrezentacjiKart.Wyrównane;
        /// <summary>
        /// Zwraca bądź ustawia styl prezentacji zbioru kart
        /// </summary>
        public StylePrezentacjiKart StylPrezentacji
        {
            get { return stylPrezentacji; }
            set { stylPrezentacji = value; }
        }

        [NonSerialized]
        private bool zadokujOstatniaKarte = false;

        //public virtual void Synchronizuj(ZbiorKart zbiorKart)
        //{
        //}

        /// <summary>
        /// Liczba kart przecowywanych w zbiorze kart
        /// </summary>
        public int LiczbaKart { get { return karty.Count; } }

        /// <summary>
        /// Zwraca kartę ostatnio dodaną do zbioru
        /// </summary>
        public Karta OstatniaDodanaKarta
        {
            get
            {
                if (LiczbaKart > 0)
                    return (Karta)karty[LiczbaKart - 1];
                else
                    return null;
            }
        }

        // Zwraca kartę ze wskazanej pozycji w zbiorze
        public Karta this[int pozycja] { get { return (Karta)karty[pozycja]; } }

        /// <summary>
        /// Zwraca sumę punktów w zbiorze kart
        /// </summary>
        /// <returns>int</returns>
        public short LiczbaPunktow
        {
            get
            {
                short val = 0;

                foreach (Karta c in karty)
                {
                    val += (short)c.WagaKarty;
                }

                decimal decimalVal = Decimal.Round(val / 10, MidpointRounding.ToEven) * 10;
                return (short)decimalVal;
            }
        }

        /// <summary>
        /// Zwraca adres karty o podanych parametrach
        /// </summary>
        public Karta AdresKarty(Karta nominalKarty)
        {
            foreach (Karta karta in karty)
                if (karta.CompareTo(nominalKarty) == 0)
                    return karta;

            return null;
        }

        /// <summary>
        /// Dodaje kartę do zbioru kart
        /// </summary>
        public void DodajKarte(Karta nowaKarta)
        {
            DodajKarte(nowaKarta, true, true, false);
        }

        /// <summary>
        /// Dodaje kartę do zbioru kart
        /// </summary>
        public void DodajKarte(Karta nowaKarta, bool sortujKarty)
        {
            DodajKarte(nowaKarta, sortujKarty, true, false);
        }

        /// <summary>
        /// Dodaje kartę do zbioru kart
        /// </summary>
        public void DodajKarte(Karta nowaKarta, bool sortujKarty, bool pokazZmiany, bool zadokujKarte)
        {
            karty.Add(nowaKarta);
            nowaKarta.ZbiorKart = this;

            posortowany = false;

            zadokujOstatniaKarte = zadokujKarte;

            if (sortujKarty)
                SortujKarty();

            if (!widoczny)
                nowaKarta.Ukryj();

            if (pokazZmiany)
                Pokaz();
        }

        /// <summary>
        /// Usuwa kartę ze zbioru kart
        /// </summary>
        public void UsunKarte(Karta usuwanaKarta)
        {
            UsunKarte(usuwanaKarta, true);
        }

        /// <summary>
        /// Usuwa kartę ze zbioru kart
        /// </summary>
        public void UsunKarte(Karta usuwanaKarta, bool pokazZmiany)
        {
            if (usuwanaKarta.ZbiorKart == this)
            {
                usuwanaKarta.Ukryj();
                usuwanaKarta.ZbiorKart = null;
            }

            if (zadokujOstatniaKarte && usuwanaKarta == OstatniaDodanaKarta)
                zadokujOstatniaKarte = false;

            karty.Remove(AdresKarty(usuwanaKarta));

            if (pokazZmiany)
                Pokaz();
        }

        /// <summary>
        /// Usuwa wszystkie karty ze zbioru kart
        /// </summary>
        public void UsunWszystkieKarty()
        {
            if (LiczbaKart == 0)
                return;

            while (LiczbaKart > 0)
            {
                UsunKarte((Karta)karty[0], false);                
            }

            Pokaz();
        }

        /// <summary>
        /// Sortuje karty
        /// </summary>
        public void SortujKarty()
        {
            karty.Sort();

            if (porzadek == PorzadekSortowania.Malejący)
                karty.Reverse();

            posortowany = true;
            zadokujOstatniaKarte = false;

            Pokaz();
        }

        /// <summary>
        /// Wiąże zbiór kart z obiektem klasy ZbioKartControl reprezentującym karty na ekranie
        /// </summary>
        public void LinkujZZbiorKartControl(ZbiorKartControl zbiorKartControl)
        {
            this.zbiorKartControl = zbiorKartControl;
            zbiorKartControl.ZbiorKart = this;
        }

        /// <summary>
        /// Rysuje zbiór kart na ekranie
        /// </summary>
        internal void Pokaz()
        {
            Pokaz(null);
        }

        /// <summary>
        /// Rysuje zbiór kart na ekranie
        /// </summary>
        internal void Pokaz(Karta poczatkowaKarta)
        {
            if (!widoczny)
                return;

            if (zbiorKartControl == null)
                return;

            zbiorKartControl.StanLicznika = LiczbaPunktow;
            zbiorKartControl.Picture_Visible = false;

            if (LiczbaKart == 0)
            {
                zbiorKartControl.Visible = false;

                return;
            }

            int pierwszaKarta = 0;
            if (poczatkowaKarta != null)
            {
                pierwszaKarta = karty.IndexOf(poczatkowaKarta) + 1;
                if (pierwszaKarta == LiczbaKart)
                    return;
            }
            else
                zbiorKartControl.Visible = true;

            KoloryKart kolorKarty = 0;
            int startLocationX = 25;
            int startLocationY = 20;
            
            int locationX, locationY;
            locationX = startLocationX;
            locationY = startLocationY;

            for (int k = 0; k < LiczbaKart; k++)
            {
                Karta karta = (Karta)karty[k];

                if (StylPrezentacji == StylePrezentacjiKart.WyskakująceKolory)
                {
                    if (karta.KolorKarty != kolorKarty)
                    {
                        if (kolorKarty != 0)
                            if (locationY == startLocationY)
                                locationY = startLocationY - 20;
                            else
                                locationY = startLocationY;

                        kolorKarty = karta.KolorKarty;
                    }
                }

                if (k < pierwszaKarta)
                    continue;

                locationX = startLocationX + k * 20;

                if (zadokujOstatniaKarte && k == LiczbaKart - 1)
                {
                    locationX += 75;
                    locationY = startLocationY;
                }

                Point pozycjaKarty = new Point(zbiorKartControl.Left + locationX, zbiorKartControl.Top + locationY);

                karta.Pokaz(pozycjaKarty);
            }
        }

        /// <summary>
        /// Ukrywa zbiór kart
        /// </summary>
        internal void Ukryj()
        {
            if (zbiorKartControl == null)
                return;

            foreach (Karta karta in karty)
                karta.Ukryj();

            zbiorKartControl.Visible = false;
        }

        /// <summary>
        /// Zdarzenie generowane podwójnymn kliknięciem na obszarze zbioru kart
        /// </summary>
        internal void OnDoubleClick(ZbiorKart zbiorKart, Karta karta)
        {
            if (zadokujOstatniaKarte && karta == OstatniaDodanaKarta)
            {
                SortujKarty();
                return;
            }

            if (DoubleClick != null)
                DoubleClick(zbiorKart, karta);
        }
    }
}
