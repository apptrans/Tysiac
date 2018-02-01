using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TysiacClassLibrary
{
    [Serializable]
    public class Stolik
    {
        //public delegate void GraczeChangeHandler();
        //public event GraczeChangeHandler OnGraczeChange;

        private long numerStolika;

        /// <summary>
        /// Unikalny numer stolika
        /// </summary>
        public long NumerStolika
        {
            get { return numerStolika; }
        }

        private SortedList gracze = new SortedList();
        /// <summary>
        /// Lista graczy zasiadających przy stoliku
        /// </summary>
        public SortedList Gracze
        {
            get { return gracze; }
        }

        private Rozgrywka rozgrywka;
        /// <summary>
        /// Wskaźnik do obiektu rozgrywki
        /// </summary>
        public Rozgrywka Rozgrywka
        {
            get { return rozgrywka; }
        }

        /// <summary>
        /// Konstruktor nowego stolika
        /// </summary>
        public Stolik(long numerStolika)
        {
            this.numerStolika = numerStolika;

            rozgrywka = new Rozgrywka(this);
        }

        /// <summary>
        /// Zwraca nazwę stolika
        /// </summary>
        public override string ToString()
        {
            return "Stolik nr " + numerStolika;
        }

        /// <summary>
        /// Dołącza do stolika kolejnego gracza
        /// </summary>
        public bool DolaczDoStolika(Gracz gracz)
        {
            if (gracze.Count < 3)
            {
                gracze.Add(gracz.NickGracza, gracz);

                if (gracze.Count == 3)
                    rozgrywka.StanRozgrywki = StanyRozgrywki.RozdanieKart;

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Zwraca sąsiedniego gracza
        /// </summary>
        public Gracz GraczObok(Gracz gracz, int miejsceObok)
        {
            int numerGracza = gracz.NumerGracza - 1;
            numerGracza += miejsceObok;
            numerGracza = (numerGracza % 3) + 1;

            Gracz graczObok = null;

            foreach (Gracz g in Gracze.Values)
            {
                if (g.NumerGracza == numerGracza)
                {
                    graczObok = g;
                    break;
                }
            }
            
            return graczObok;
        }

        /// <summary>
        /// Zwraca sąsiedniego gracza
        /// </summary>
        public Gracz GraczObok(Gracz gracz)
        {
            return GraczObok(gracz, 1);
        }

        /// <summary>
        /// Zwraca sąsiedniego gracza
        /// </summary>
        public Gracz GraczObok(Gracz gracz, bool licytujacy)
        {
            Gracz graczObok;

            for (int miejsceObok = 1; miejsceObok < gracze.Count; miejsceObok++)
            {
                graczObok = GraczObok(gracz, miejsceObok);
                if (graczObok.Licytujacy)
                    return graczObok;
            }

            return null;
        }

        /// <summary>
        /// Zwraca obiekt klasy StolikInfo zawierający podstawowe informacje o stoliku
        /// </summary>
        public StolikInfo Info()
        {
            return new StolikInfo(this);
        }
    }

    [Serializable]
    public class StolikInfo
    {
        private long numerStolika;

        /// <summary>
        /// Unikalny numer stolika
        /// </summary>
        public long NumerStolika
        {
            get { return numerStolika; }
        }

        private string nickGracza1;
        /// <summary>
        /// Nick 1-go gracza przy stoliku
        /// </summary>
        public string NickGracza1
        {
            get { return nickGracza1; }
        }

        private string nickGracza2;
        /// <summary>
        /// Nick 2-go gracza przy stoliku
        /// </summary>
        public string NickGracza2
        {
            get { return nickGracza2; }
        }

        private string nickGracza3;
        /// <summary>
        /// Nick 3-go gracza przy stoliku
        /// </summary>
        public string NickGracza3
        {
            get { return nickGracza3; }
        }

        /// <summary>
        /// Konstruktor nowego obiektu StolikInfo
        /// </summary>
        public StolikInfo(Stolik stolik)
        {
            this.numerStolika = stolik.NumerStolika;

            foreach (Gracz gracz in stolik.Gracze.Values)
            {
                
                switch (gracz.NumerGracza)
                {
                    case 1:
                        nickGracza1 = gracz.NickGracza;
                        break;
                    case 2:
                        nickGracza2 = gracz.NickGracza;
                        break;
                    default:
                        nickGracza3 = gracz.NickGracza;
                        break;
                }
            }
        }

        /// <summary>
        /// Zwraca nazwę stolika
        /// </summary>
        public override string ToString()
        {
            return "Stolik nr " + numerStolika;
        }
    }
}
