using System;
using System.Collections.Generic;
using System.Text;

namespace TysiacClassLibrary
{
    [Serializable]
    public class WynikRozdania
    {
        private int numerRozdania;
        public int NumerRozdania
        {
            get { return numerRozdania; }
        }

        private Gracz graczRozdajacy;
        public Gracz GraczRozdajacy
        {
            get { return graczRozdajacy; }
        }

        private bool saWyniki = false;
        public bool SaWyniki
        {
            get { return saWyniki; }
        }

        private int[] wyniki = new int[3];
        public int[] Wyniki
        {
            get { return wyniki; }
        }

        public WynikRozdania()
        {
        }

        public WynikRozdania(Rozgrywka rozgrywka)
        {
            this.numerRozdania = rozgrywka.NumerRozdania;
            this.graczRozdajacy = rozgrywka.GraczRozdajacy;

            this.saWyniki = false;
        }

        public void DopiszWyniki(Rozgrywka rozgrywka)
        {
            foreach (Gracz gracz in rozgrywka.Stolik.Gracze.Values)
                wyniki[gracz.NumerGracza - 1] = gracz.WynikRozdania;

            this.saWyniki = true;
        }
    }
}
