using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace TysiacClassLibrary
{
    public class Pokoik
    {
        private SortedList stoliki = new SortedList();
        /// <summary>
        /// Lista stolików w grze
        /// </summary>
        public SortedList Stoliki
        {
            get { return stoliki; }
        }

        private long iloscStolikow = 0;

        /// <summary>
        /// Konstruktor nowego pokoiku
        /// </summary>
        public Pokoik()
        {
        }

        /// <summary>
        /// Dodaje nowy stolik do gry do listy Stoliki
        /// </summary>
        public Stolik DodajStolik(long numerStolika)
        {
            Stolik stolik = new Stolik(numerStolika);
            stoliki.Add(numerStolika, stolik);

            return stolik;
        }

        /// <summary>
        /// Dodaje nowy stolik do gry do listy Stoliki
        /// </summary>
        public Stolik DodajStolik()
        {
            return DodajStolik(++iloscStolikow);
        }

        /// <summary>
        /// Usuwa wskazany stolik z gry
        /// </summary>
        public void UsunStolik(long numerStolika)
        {
            stoliki.Remove(numerStolika);
        }

        /// <summary>
        /// Zwraca podstawowe informacje o pokoiku gry dla nowych graczy
        /// </summary>
        public PokoikInfo Info()
        {
            return new PokoikInfo(this);
        }
    }

    [Serializable]
    public class PokoikInfo
    {
        private SortedList stolikiInfo = new SortedList();
        public SortedList StolikiInfo
        {
            get { return stolikiInfo; }
        }

        public PokoikInfo(Pokoik pokoik)
        {
            foreach (Stolik stolik in pokoik.Stoliki.Values)
            {
                stolikiInfo.Add(stolik.NumerStolika, stolik.Info());
            }
        }
   }
}