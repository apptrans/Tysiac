using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TysiacClassLibrary
{
    /// <summary>
    /// Stan rozgrywki
    /// </summary>
    public enum StanyRozgrywki
    {
        ZbieranieGraczy, RozdanieKart, Licytacja, PobranieTalonu, WykladanieKart
    }

    [Serializable]
    public class Rozgrywka
    {
        private StanyRozgrywki stanRozgrywki;
        /// <summary>
        /// Faza rozgrywki
        /// </summary>
        public StanyRozgrywki StanRozgrywki
        {
            get { return stanRozgrywki; }
            set
            {
                stanRozgrywki = value;
            }
        }

        [NonSerialized]
        private Stolik stolik;
        /// <summary>
        /// Stolik przy którym toczy się rozgrywka
        /// </summary>
        public Stolik Stolik
        {
            get { return stolik; }
            set { stolik = value; } // możliwość przypisania w FormStolikGracza
        }

        private int numerRozdania = 0;
        /// <summary>
        /// Numer rozdania
        /// </summary>
        public int NumerRozdania
        {
            get { return numerRozdania; }
        }

        private Gracz graczRozdajacy;
        /// <summary>
        /// Gracz rozdający
        /// </summary>
        public Gracz GraczRozdajacy
        {
            get { return graczRozdajacy; }
        }

        private Gracz graczRozgrywajacy;
        /// <summary>
        /// Gracz rozgrywający
        /// </summary>
        public Gracz GraczRozgrywajacy
        {
            get { return graczRozgrywajacy; }
        }

        private int licytowanaStawka = 100;
        /// <summary>
        /// Licytowana stawka
        /// </summary>
        public int LicytowanaStawka
        {
            get { return licytowanaStawka; }
        }

        [NonSerialized]
        private Talia talia = new Talia();

        [NonSerialized]
        private Talon talon = new Talon();
        /// <summary>
        /// Talon używany w rozgrywce
        /// </summary>
        public Talon Talon
        {
            get { return talon; }
        }

        private KoloryKart kolorAtu;
        /// <summary>
        /// Bieżący kolor atu
        /// </summary>
        public KoloryKart KolorAtu
        {
            get { return kolorAtu; }
        }

        private Lewa lewa;
        /// <summary>
        /// Bieżąca lewa
        /// </summary>
        public Lewa Lewa
        {
            get { return lewa; }
        }

        [NonSerialized]
        private WynikRozdania ostatniWynik;
        /// <summary>
        /// Dane ostatniej rundy
        /// </summary>
        public WynikRozdania OstatniWynik
        {
            get { return ostatniWynik; }
            set { ostatniWynik = value; }
        }

        [NonSerialized]
        private List<WynikRozdania> wyniki = new List<WynikRozdania>();
        /// <summary>
        /// Lista wyników całej gry
        /// </summary>
        public List<WynikRozdania> Wyniki
        {
            get { return wyniki; }
            set { wyniki = value; }
        }

        /// <summary>
        /// Generuje obiekt rozgrywki
        /// </summary>
        public Rozgrywka(Stolik stolik)
        {
            this.stolik = stolik;
            lewa = new Lewa(this);

            stanRozgrywki = StanyRozgrywki.ZbieranieGraczy;
        }

        public delegate void OnKolorAtuChangeHandler(Rozgrywka rozgrywka, Rozgrywka rozgrywkaStanPoprzedni);
        public event OnKolorAtuChangeHandler OnKolorAtuChange;

        /// <summary>
        /// Metoda porównująca stan obiektów przed i po zdarzeniu i wywołująca odpowiednie zdarzenia
        /// </summary>
        public virtual void Porownaj(Rozgrywka rozgrywkaStanPoprzedni)
        {
            if (rozgrywkaStanPoprzedni == null || kolorAtu != rozgrywkaStanPoprzedni.kolorAtu)
                if (OnKolorAtuChange != null)
                    OnKolorAtuChange(this, rozgrywkaStanPoprzedni);

            if (graczRozgrywajacy != null && graczRozgrywajacy.GraczControl != null)
                graczRozgrywajacy.GraczControl.LabelGracz.BackColor = Color.LightBlue;
        }

        /// <summary>
        /// Rozdaje karty graczom przy stoliku
        /// </summary>
        public void RozdajKarty(Gracz graczRozdajacy)
        {
            if (StanRozgrywki != StanyRozgrywki.RozdanieKart)
            {
                return;
            }

            if (this.graczRozdajacy == null)
                this.graczRozdajacy = graczRozdajacy;
            else
                if (this.graczRozdajacy != graczRozdajacy)
                    return;

            PrzygotowanieGraczy();
            PrzygotowanieIRozdanieKart();

            graczRozgrywajacy = stolik.GraczObok(graczRozdajacy, 2);

            stanRozgrywki = StanyRozgrywki.Licytacja;
            licytowanaStawka = 100;

            ++numerRozdania;

            ostatniWynik = new WynikRozdania(this);

            wyniki.Add(ostatniWynik);
        }

        /// <summary>
        /// Przygotowuje obiekty graczy do gry
        /// </summary>
        private void PrzygotowanieGraczy()
        {
            foreach (Gracz gracz in stolik.Gracze.Values)
                gracz.UstawPoczatekRundy();
        }

        /// <summary>
        /// Przygotowuje obiekt rozgrywki i rozdaje karty
        /// </summary>
        private void PrzygotowanieIRozdanieKart()
        {
            // Wyczyść zbiory kart graczy, talon i przygotuj talię do gry;
            PrzygotujKarty();

            Karta karta;

            // Karty są rozdzielane równo po 7 pomiędzy graczy
            // 3 karty idą na talon
            for (int i = 0; i < 7; i++)
            {
                foreach (Gracz gracz in stolik.Gracze.Values)
                {
                    karta = talia.PobierzKarte();
                    gracz.KartyRozdane.DodajKarte(karta, false);
                }

                if (i < 3)
                {
                    karta = talia.PobierzKarte();
                    talon.DodajKarte(karta, false);
                }
            }

            foreach (Gracz gracz in stolik.Gracze.Values)
            {
                gracz.KartyRozdane.SortujKarty();
            }

            talon.SortujKarty();
        }

        /// <summary>
        /// Przygotowuje karty do gry
        /// </summary>
        private void PrzygotujKarty()
        {
            kolorAtu = 0;

            talon.UsunWszystkieKarty();
            lewa.UsunWszystkieKarty();

            talia.PrzygotujTalie();
        }

        /// <summary>
        /// Przyjmuje zgłoszenie licytacji przez danego gracza
        /// </summary>
        public bool Licytuj(Gracz gracz, int licytowanaStawka)
        {
            if (!MozeLicytowac(gracz, licytowanaStawka))
                return false;

            this.licytowanaStawka = licytowanaStawka;

            graczRozgrywajacy = stolik.GraczObok(gracz, true);

            return true;
        }

        /// <summary>
        /// Sprawdza możliwość licytacji przez gracza danej ilości punktów
        /// </summary>
        public bool MozeLicytowac(Gracz gracz, int licytowanaStawka, out string info)
        {
            info = String.Empty;

            if (stanRozgrywki != StanyRozgrywki.Licytacja)
            {
                info = "Licytacja nie jest możliwa w tej fazie rozgrywki";
                return false;
            }

            if (gracz != graczRozgrywajacy)
            {
                info = gracz.NickGracza+" nie jesteś graczem rozgrywającym";
                return false;
            }

            if (!gracz.Licytujacy)
            {
                info = "Zakończyłeś licytację wcześniej";
                return false;
            }

            Gracz graczObok = stolik.GraczObok(gracz, true);

            if (graczObok == null)
            {
                info = "Licytacja jest już zakończona";
                return false;
            }

            if (licytowanaStawka <= this.licytowanaStawka)
            {
                info = "Licytowana stawka jest niższa od wymaganej";
                return false;
            }

            if (licytowanaStawka > 120 && !gracz.MaPare())
            {
                info = gracz.NickGracza + " nie możesz licytować więcej niż 120 bez pary";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Sprawdza możliwość licytacji przez gracza danej ilości punktów
        /// </summary>
        public bool MozeLicytowac(Gracz gracz, int licytowanaStawka)
        {
            string info;
            return MozeLicytowac(gracz, licytowanaStawka, out info);
        }

        /// <summary>
        /// Przyjmuje rezygnację z dalszej licytacji przez danego gracza
        /// </summary>
        public bool Pasuj(Gracz gracz)
        {
            if (stanRozgrywki != StanyRozgrywki.Licytacja)
                return false;

            if (gracz != graczRozgrywajacy)
                return false;

            Gracz graczObok = stolik.GraczObok(gracz, true);

            if (graczObok == null)
                return false;

            gracz.Licytujacy = false;

            graczRozgrywajacy = graczObok;

            if (stolik.GraczObok(graczRozgrywajacy, true) == null)
                stanRozgrywki = StanyRozgrywki.PobranieTalonu;

            return true;
        }

        /// <summary>
        /// Rozpoczyna grę
        /// </summary>
        public bool RozpocznijGre(Gracz gracz, int licytowanaStawka, Karta kartaDlaGracza2, Karta kartaDlaGracza3)
        {
            if (stanRozgrywki != StanyRozgrywki.PobranieTalonu)
                return false;

            if (gracz != graczRozgrywajacy)
                return false;

            if (licytowanaStawka < this.licytowanaStawka)
                return false;

            if (kartaDlaGracza2 == null || kartaDlaGracza3 == null)
                return false;

            this.licytowanaStawka = licytowanaStawka;

            foreach (Karta wybranaKarta in talon.Karty)
            {
                gracz.KartyRozdane.DodajKarte(wybranaKarta, false);
            }
            
            gracz.KartyRozdane.SortujKarty();

            talon.UsunWszystkieKarty();

            if (!PrzekazKarteGraczowi(kartaDlaGracza2, gracz, stolik.GraczObok(gracz)))
                return false;
            if (!PrzekazKarteGraczowi(kartaDlaGracza3, gracz, stolik.GraczObok(gracz, 2)))
                return false;

            stanRozgrywki = StanyRozgrywki.WykladanieKart;

            return true;
        }

        /// <summary>
        /// Pozwala na rezygnację z gry połączone z przekazaniem 60pkt na konta pozostałych graczy
        /// </summary>
        public bool RezygnujZGry(Gracz gracz)
        {
            if (stanRozgrywki != StanyRozgrywki.PobranieTalonu)
                return false;

            UzupelnijKontaGraczy(true);

            PrzejdzDoRozdania();

            return true;
        }

        /// <summary>
        /// Przekazuje kartę graczowi
        /// </summary>
        private bool PrzekazKarteGraczowi(Karta kartaDlaGracza, Gracz gracz, Gracz graczObok)
        {
            Karta adresKarty = gracz.KartyRozdane.AdresKarty(kartaDlaGracza);

            graczObok.KartyRozdane.DodajKarte(adresKarty);
            gracz.KartyRozdane.UsunKarte(adresKarty);

            return true;
        }

        /// <summary>
        /// Sprawdza poprawność wyłożenia karty przez gracza
        /// </summary>
        public bool WylozKarte(Gracz graczWykladajacy, Karta kartaWylozona)
        {
            if (lewa.LiczbaKart == 3)
                lewa.UsunWszystkieKarty();

            if (lewa.LiczbaKart == 0)
                SprawdzKolorAtu(graczWykladajacy, kartaWylozona);

            if (!lewa.DolozKarteOdGracza(graczWykladajacy, kartaWylozona))
                return false;

            if (lewa.LiczbaKart == 3)
            {
                graczRozgrywajacy = lewa.GraczZbierajacyLewe;
            }
            else
                graczRozgrywajacy = stolik.GraczObok(graczWykladajacy);

            if (lewa.LiczbaKart == 3 && graczRozgrywajacy.KartyRozdane.LiczbaKart == 0)
            {
                UzupelnijKontaGraczy();

                PrzejdzDoRozdania();
            }

            return true;
        }

        /// <summary>
        /// Przechodzi w stan gry Rozdaniekart
        /// </summary>
        private void PrzejdzDoRozdania()
        {
            stanRozgrywki = StanyRozgrywki.RozdanieKart;

            graczRozdajacy = stolik.GraczObok(graczRozdajacy);

            graczRozgrywajacy = graczRozdajacy;
        }

        /// <summary>
        /// Sprawdza czy gracz zmienia kolor atu
        /// </summary>
        private void SprawdzKolorAtu(Gracz graczWykladajacy, Karta kartaWylozona)
        {
            if (lewa.LiczbaKart != 0)
                return;

            WagiKart figuraDoPary;
            switch (kartaWylozona.WagaKarty)
            {
                case WagiKart.Król:
                    figuraDoPary = WagiKart.Dama;
                    break;
                case WagiKart.Dama:
                    figuraDoPary = WagiKart.Król;
                    break;
                default:
                    return;
            }

            Karta kartaDoPary = new Karta(kartaWylozona.KolorKarty, figuraDoPary);

            if (graczWykladajacy.KartyRozdane.AdresKarty(kartaDoPary) != null)
            {
                kolorAtu = kartaWylozona.KolorKarty;
                graczWykladajacy.ZwiekszLiczbePunktowZAtu(kolorAtu);
            }
        }

        /// <summary>
        /// Uzupełnia konta graczy po zakończonej rundzie
        /// </summary>
        private void UzupelnijKontaGraczy()
        {
            UzupelnijKontaGraczy(false);
        }

        /// <summary>
        /// Uzupełnia konta graczy po zakończonej rundzie
        /// </summary>
        private void UzupelnijKontaGraczy(bool rezygnacja)
        {
            foreach (Gracz gracz in stolik.Gracze.Values)
                gracz.ZaktualizujLiczbePunktow(licytowanaStawka, rezygnacja);

            if (ostatniWynik != null)
                ostatniWynik.DopiszWyniki(this);

            //foreach (Gracz gracz in stolik.Gracze.Values)
            //    if (gracz.StanKontaGry >= 1000)
            //        PrzejdzDoRozdania();
        }
    }
}
