using System;
using System.Collections.Generic;
using System.Drawing;

namespace TysiacClassLibrary
{
    /// <summary>
    /// Kolory kart
    /// </summary>
    public enum KoloryKart
    {
        Kier = 100, Karo = 80, Trefl = 60, Pik = 40
    }

    /// <summary>
    /// Wartość i starszeństwo kart
    /// </summary>
    public enum WagiKart
    {
        As = 11, Dziesiątka = 10, Król = 4, Dama = 3, Walet = 2, Dziewiątka = 0
    }

    [Serializable]
    public class Karta : IComparable
    {
        // Cechy karty
        private readonly KoloryKart kolorKarty;
        private readonly WagiKart wagaKarty;
        private bool kartaWidoczna;

        /// <summary>
        /// Kolor karty
        /// </summary>
        public KoloryKart KolorKarty { get { return kolorKarty; } }
        /// <summary>
        /// Waga karty
        /// </summary>
        public WagiKart WagaKarty { get { return wagaKarty; } }
        /// <summary>
        /// Znacznik informujący czy karta jest widoczna, czy odwrócona (zakryta przed pozostałymi graczami)
        /// </summary>
        public bool KartaWidoczna { get { return kartaWidoczna; } set { kartaWidoczna = value; } }

        [NonSerialized]
        private ZbiorKart zbiorKart;
        /// <summary>
        /// Wskaźnik obiektu ZbiorKart - zbioru kart do którego należy karta
        /// </summary>
        public ZbiorKart ZbiorKart
        {
            get { return zbiorKart; }
            set { zbiorKart = value; }
        }

        [NonSerialized]
        private KartaBox kartaBox;
        /// <summary>
        /// Wskaźnik obiektu KartaBox reprezentującego kartę graficznie
        /// </summary>
        public KartaBox KartaBox
        {
            get { return kartaBox; }
        }

        /// <summary>
        /// Konstruktor nowej karty
        /// </summary>
        /// <param name="kolorKarty"></param>
        /// <param name="wagaKarty"></param>
        /// <param name="kartaWidoczna"></param>
        public Karta(KoloryKart kolorKarty, WagiKart wagaKarty, bool kartaWidoczna)
        {
            this.kolorKarty = kolorKarty;
            this.wagaKarty = wagaKarty;
            this.kartaWidoczna = kartaWidoczna;
        }

        /// <summary>
        /// Konstruktor nowej karty
        /// </summary>
        public Karta(KoloryKart kolorKarty, WagiKart wagaKarty)
            : this(kolorKarty, wagaKarty, false)
        {
        }

        /// <summary>
        /// Wiąże obiekt karty z obiektem KartaBox reprezentującym kartę graficznie w interfejsie użytkownika
        /// </summary>
        public void LinkujZKartaBox(KartaBox kartaBox)
        {
            if (kartaBox != null && kartaBox.Karta != null)
                kartaBox.Karta.kartaBox = null;

            this.kartaBox = kartaBox;
            kartaBox.Karta = this;
        }

        /// <summary>
        /// Rysuje kartę na ekranie
        /// </summary>
        public void Pokaz(Point pozycjaNaEkranie)
        {
            if (kartaBox == null)
                return;

            kartaBox.Pokaz(pozycjaNaEkranie);
        }

        /// <summary>
        /// Ukrywa kartę
        /// </summary>
        public void Ukryj()
        {
            if (kartaBox == null)
                return;

            kartaBox.Visible = false;
        }

        /// <summary>
        /// Zwraca nazwę karty
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return wagaKarty.ToString() + " " + kolorKarty.ToString();
        }

        //public int CompareTo(Karta drugaKarta)
        //{
        //    int porownajKolory = kolorKarty.CompareTo(drugaKarta.kolorKarty);

        //    if (porownajKolory != 0)
        //        return porownajKolory;
        //    else
        //        return wagaKarty.CompareTo(drugaKarta.wagaKarty);
        //}

        #region IComparable Members

        /// <summary>
        /// Informuje, która z dwóch kart jest silniejsza
        /// </summary>
        public int CompareTo(object obj)
        {
            Karta drugaKarta = (Karta)obj;

            int porownajKolory = kolorKarty.CompareTo(drugaKarta.kolorKarty);

            if (porownajKolory != 0)
                return porownajKolory;
            else
                return wagaKarty.CompareTo(drugaKarta.wagaKarty);
        }

        #endregion
    }
}