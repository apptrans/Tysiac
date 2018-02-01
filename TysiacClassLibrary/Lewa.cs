using System;
using System.Collections.Generic;
using System.Text;

namespace TysiacClassLibrary
{
    [Serializable]
    public class Lewa : ZbiorKart
    {
        [NonSerialized]
        private Rozgrywka rozgrywka;
        /// <summary>
        /// Wskazuje na obiekt rozgrywki do której należy lewa
        /// </summary>
        public Rozgrywka Rozgrywka
        {
            set { rozgrywka = value; }
        }

        private KoloryKart kolorLewy;
        /// <summary>
        /// Zwraca kolor lewy
        /// </summary>
        public KoloryKart KolorLewy
        {
            get { return kolorLewy; }
        }

        private Gracz graczZbierajacyLewe;
        /// <summary>
        /// Zwraca bądź ustawia gracza zbierającego lewę
        /// </summary>
        public Gracz GraczZbierajacyLewe
        {
            get { return graczZbierajacyLewe; }
            set { graczZbierajacyLewe = value; }
        }

        /// <summary>
        /// Konstruktor lewy
        /// </summary>
        public Lewa(Rozgrywka rozgrywka)
        {
            this.rozgrywka = rozgrywka;
        }

        /// <summary>
        /// Dobiera kartę gracza wykładającego do lewy
        /// </summary>
        internal bool DolozKarteOdGracza(Gracz graczWykladajacy, Karta kartaWylozona)
        {
            if (LiczbaKart == 0)
                kolorLewy = kartaWylozona.KolorKarty;

            if (!PoprawnaKarta(graczWykladajacy, kartaWylozona))
                return false;

            if (NajsilniejszaKartaWLewie(kartaWylozona))
                graczZbierajacyLewe = graczWykladajacy;

            Karta adresKarty = graczWykladajacy.KartyRozdane.AdresKarty(kartaWylozona);

            DodajKarte(adresKarty, false);
            graczWykladajacy.KartyRozdane.UsunKarte(adresKarty);

            if (LiczbaKart == 3)
            {
                foreach (Karta karta in Karty)
                {
                    graczZbierajacyLewe.KartyWygrane.DodajKarte(karta);
                }
            }

            return true;
        }

        /// <summary>
        /// Sprawdza czy podana karta jest najsilniejszą kartą w kolorze lewy
        /// </summary>
        private bool NajsilniejszaKartaWKolorzeLewy(Karta kartaWylozona)
        {
            if (LiczbaKart == 0)
                return true;

            if (kartaWylozona.KolorKarty != kolorLewy)
                return false;
            else
                foreach (Karta karta in Karty)
                {
                    if (karta.KolorKarty == kolorLewy && karta.WagaKarty > kartaWylozona.WagaKarty)
                        return false;
                }

            return true;
        }

        /// <summary>
        /// Sprawdza czy podana karta jest najsilniejszą kartą w kolorze atu
        /// </summary>
        private bool NajsilniejszaKartaWKolorzeAtu(Karta kartaWylozona)
        {
            if (kartaWylozona.KolorKarty != rozgrywka.KolorAtu)
                return false;
            else
                foreach (Karta karta in Karty)
                {
                    if (karta.KolorKarty == rozgrywka.KolorAtu && karta.WagaKarty > kartaWylozona.WagaKarty)
                        return false;
                }

            return true;
        }

        /// <summary>
        /// Sprawdza czy podana karta jest najsilniejszą kartą w lewie
        /// </summary>
        private bool NajsilniejszaKartaWLewie(Karta kartaWylozona)
        {
            if (LiczbaKart == 0)
                return true;

            if (kartaWylozona.KolorKarty == rozgrywka.KolorAtu)
                return NajsilniejszaKartaWKolorzeAtu(kartaWylozona);

            if (KolorAtuWLewie())
                return false;

            if (kartaWylozona.KolorKarty == kolorLewy)
                return NajsilniejszaKartaWKolorzeLewy(kartaWylozona);

            return false;
        }

        /// <summary>
        /// Sprawdza czy w lewie znajduje się karta w kolorze atu
        /// </summary>
        private bool KolorAtuWLewie()
        {
            foreach (Karta karta in Karty)
            {
                if (karta.KolorKarty == rozgrywka.KolorAtu)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Sprawdza czy karta wyłożona przez gracza jest poprawna
        /// </summary>
        public bool PoprawnaKarta(Gracz gracz, Karta wybranaKarta, out string info)
        {
            info = String.Empty;

            if (LiczbaKart == 0)
                return true;

            if (wybranaKarta.KolorKarty == kolorLewy && NajsilniejszaKartaWKolorzeLewy(wybranaKarta))
                return true;

            bool jestKolorLewy = wybranaKarta.KolorKarty == kolorLewy;

            foreach (Karta karta in gracz.KartyRozdane.Karty)
            {
                if (karta.CompareTo(wybranaKarta) == 0)
                    continue;

                if (karta.KolorKarty == kolorLewy)
                {
                    jestKolorLewy = true;

                    if (wybranaKarta.KolorKarty != kolorLewy)
                    {
                        info = "Musisz wyłożyć kartę w kolorze " + kolorLewy;
                        return false;
                    }
                    else
                        if (NajsilniejszaKartaWKolorzeLewy(karta))
                        {
                            info = "Musisz przebić silniejszą kartą w kolorze " + kolorLewy;
                            return false;
                        }
                }
            }

            if (!jestKolorLewy && rozgrywka.KolorAtu != 0)
            {
                if (wybranaKarta.KolorKarty == rozgrywka.KolorAtu && NajsilniejszaKartaWKolorzeAtu(wybranaKarta))
                    return true;

                foreach (Karta karta in gracz.KartyRozdane.Karty)
                {
                    if (karta.CompareTo(wybranaKarta) == 0)
                        continue;

                    if (karta.KolorKarty == rozgrywka.KolorAtu)
                    {
                        if (wybranaKarta.KolorKarty != rozgrywka.KolorAtu)
                        {
                            info = "Musisz wyłożyć kartę w kolorze " + rozgrywka.KolorAtu;
                            return false;
                        }
                        else
                            if (NajsilniejszaKartaWKolorzeAtu(karta))
                            {
                                info = "Musisz przebić silniejszą kartą w kolorze " + rozgrywka.KolorAtu;
                                return false;
                            }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Sprawdza czy karta wyłożona przez gracza jest poprawna
        /// </summary>
        public bool PoprawnaKarta(Gracz gracz, Karta wybranaKarta)
        {
            string info;
            return PoprawnaKarta(gracz, wybranaKarta, out info);
        }
    }
}
