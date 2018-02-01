using System;
using System.Windows.Forms;
using System.Drawing;

using Network;
using TysiacClassLibrary;
using System.Collections.Generic;
using Tysiac.Properties;

namespace Tysiac
{
    public partial class FormStolikGracza : Form
    {
        private FormPokoik formPokoik;
        private NetworkClient networkClient;

        private long numerStolika;
        public long NumerStolika
        {
            get { return numerStolika; }
        }

        private string nickGracza;
        public string NickGracza
        {
            get { return nickGracza; }
        }

        private Stolik stolik;
        private Rozgrywka rozgrywka;

        private Lewa lewa;
        private Talon talon;

        private Gracz gracz = null;
        private Gracz gracz2 = null;
        private Gracz gracz3 = null;

        private ZbiorKart kartyRozdane;
        private ZbiorKart kartyWygrane = new ZbiorKart();

        private ZbiorKart kartaGracza2 = new ZbiorKart();
        private ZbiorKart kartaGracza3 = new ZbiorKart();

        private List<WynikRozdania> wyniki = new List<WynikRozdania>();

        public FormStolikGracza(FormPokoik formPokoik, NetworkClient networkClient, long numerStolika, string nickGracza)
        {
            this.formPokoik = formPokoik;
            this.networkClient = networkClient;

            this.numerStolika = numerStolika;
            this.nickGracza = nickGracza;

            InitializeComponent();

            kartyWygrane.LinkujZZbiorKartControl(zbiorKartControlKartyWygrane);
            kartyWygrane.Widoczny = false;

            kartaGracza2.LinkujZZbiorKartControl(zbiorKartControlKartaGracza2);
            kartaGracza2.DoubleClick += new ZbiorKart.DoubleClickHandler(kartaGracza_DoubleClick);

            kartaGracza3.LinkujZZbiorKartControl(zbiorKartControlKartaGracza3);
            kartaGracza3.DoubleClick += new ZbiorKart.DoubleClickHandler(kartaGracza_DoubleClick);

            this.formPokoik.OnStolikMessage += new FormPokoik.StolikMessageHandler(formPokoik_OnStolikMessage);
        }

        private void LinkujKarte(Karta karta)
        {
            switch (karta.KolorKarty)
            {
                case KoloryKart.Kier:
                    switch (karta.WagaKarty)
                    {
                        case WagiKart.As:
                            karta.LinkujZKartaBox(kartaBoxKierAs);
                            break;
                        case WagiKart.Dziesiątka:
                            karta.LinkujZKartaBox(kartaBoxKier10);
                            break;
                        case WagiKart.Król:
                            karta.LinkujZKartaBox(kartaBoxKierKrol);
                            break;
                        case WagiKart.Dama:
                            karta.LinkujZKartaBox(kartaBoxKierDama);
                            break;
                        case WagiKart.Walet:
                            karta.LinkujZKartaBox(kartaBoxKierWalet);
                            break;
                        case WagiKart.Dziewiątka:
                            karta.LinkujZKartaBox(kartaBoxKier9);
                            break;
                    }

                    break;
                case KoloryKart.Karo:
                    switch (karta.WagaKarty)
                    {
                        case WagiKart.As:
                            karta.LinkujZKartaBox(kartaBoxKaroAs);
                            break;
                        case WagiKart.Dziesiątka:
                            karta.LinkujZKartaBox(kartaBoxKaro10);
                            break;
                        case WagiKart.Król:
                            karta.LinkujZKartaBox(kartaBoxKaroKrol);
                            break;
                        case WagiKart.Dama:
                            karta.LinkujZKartaBox(kartaBoxKaroDama);
                            break;
                        case WagiKart.Walet:
                            karta.LinkujZKartaBox(kartaBoxKaroWalet);
                            break;
                        case WagiKart.Dziewiątka:
                            karta.LinkujZKartaBox(kartaBoxKaro9);
                            break;
                    }

                    break;
                case KoloryKart.Trefl:
                    switch (karta.WagaKarty)
                    {
                        case WagiKart.As:
                            karta.LinkujZKartaBox(kartaBoxTreflAs);
                            break;
                        case WagiKart.Dziesiątka:
                            karta.LinkujZKartaBox(kartaBoxTrefl10);
                            break;
                        case WagiKart.Król:
                            karta.LinkujZKartaBox(kartaBoxTreflKrol);
                            break;
                        case WagiKart.Dama:
                            karta.LinkujZKartaBox(kartaBoxTreflDama);
                            break;
                        case WagiKart.Walet:
                            karta.LinkujZKartaBox(kartaBoxTreflWalet);
                            break;
                        case WagiKart.Dziewiątka:
                            karta.LinkujZKartaBox(kartaBoxTrefl9);
                            break;
                    }

                    break;
                case KoloryKart.Pik:
                    switch (karta.WagaKarty)
                    {
                        case WagiKart.As:
                            karta.LinkujZKartaBox(kartaBoxPikAs);
                            break;
                        case WagiKart.Dziesiątka:
                            karta.LinkujZKartaBox(kartaBoxPik10);
                            break;
                        case WagiKart.Król:
                            karta.LinkujZKartaBox(kartaBoxPikKrol);
                            break;
                        case WagiKart.Dama:
                            karta.LinkujZKartaBox(kartaBoxPikDama);
                            break;
                        case WagiKart.Walet:
                            karta.LinkujZKartaBox(kartaBoxPikWalet);
                            break;
                        case WagiKart.Dziewiątka:
                            karta.LinkujZKartaBox(kartaBoxPik9);
                            break;
                    }

                    break;
            }
        }

        private void LinkujZbiorKart(ZbiorKart zbiorKart)
        {
            if (zbiorKart == null)
                return;

            foreach (Karta karta in zbiorKart.Karty)
            {
                karta.ZbiorKart = zbiorKart;
                LinkujKarte(karta);
            }
        }

        private void formPokoik_OnStolikMessage(NetworkClient networkClient, NetworkMessage networkMessage)
        {
            IStolikable isStolikMessage = networkMessage as IStolikable;
            if (isStolikMessage == null)
                return;

            long nrStolika = isStolikMessage.ClientNumerStolika;
            if (isStolikMessage.Stolik != null)
                nrStolika = isStolikMessage.Stolik.NumerStolika;

            if (nrStolika != numerStolika)
                return;

            if (isStolikMessage.Stolik != null)
            {
                //Stolik stolikStanPoprzedni = stolik;
                Rozgrywka rozgrywkaStanPoprzedni = rozgrywka;

                stolik = isStolikMessage.Stolik;

                rozgrywka = stolik.Rozgrywka;
                rozgrywka.Stolik = stolik;
                rozgrywka.Wyniki = wyniki;

                lewa = rozgrywka.Lewa;
                lewa.Rozgrywka = rozgrywka;

                if (lewa != null)
                {
                    lewa.LinkujZZbiorKartControl(zbiorKartControlLewa);
                    LinkujZbiorKart(lewa);
                }

                gracz = (Gracz)stolik.Gracze[nickGracza];
                if (gracz != null)
                {
                    gracz.KartyRozdane = kartyRozdane;
                    gracz.LinkujZGraczControl(graczControl);

                    gracz2 = stolik.GraczObok(gracz);
                    if (gracz2 != null)
                        gracz2.LinkujZGraczControl(graczControl2);

                    gracz3 = stolik.GraczObok(gracz, 2);
                    if (gracz3 != null)
                        gracz3.LinkujZGraczControl(graczControl3);
                }

                rozgrywka.OnKolorAtuChange += new Rozgrywka.OnKolorAtuChangeHandler(rozgrywka_OnKolorAtuChange);
                rozgrywka.Porownaj(rozgrywkaStanPoprzedni);
            }

            BaseMessage baseMessage = (BaseMessage)networkMessage;
            MessageType messageType = baseMessage.MessageType;

            if ((messageType == MessageType.DodajStolik || messageType == MessageType.DolaczDoStolika) && baseMessage.ReplayMessage)
            {
                Location = new Point(((int)numerStolika - 1) * 350 + (gracz.NumerGracza - 1) * 20, (gracz.NumerGracza - 1) * 150);

                Text = stolik + " - Gracz " + gracz;
                graczControl.Gracz_Text = gracz.NickGracza;

                Show();
            }

            if (messageType == MessageType.CzatStolikMessage)
            {
                CzatStolikMessage czatStolikMessage = (CzatStolikMessage)networkMessage;

                string rtf;
                //if (richTextBoxChat.Text == String.Empty)
                //    rtf = @"{\rtf1\ansi" ;
                //else
                {
                    rtf = richTextBoxChat.Rtf;
                    rtf = rtf.Substring(0, rtf.Length - 3);
                }
                
                rtf += czatStolikMessage.MessageString + "}";

                richTextBoxChat.Rtf = rtf;

                return; // bez zmiany interfejsu gry
            }
            
            if (messageType == MessageType.RozdajKarty)
            {
                RozdajKartyMessage rozdajKartyMessage = (RozdajKartyMessage)networkMessage;

                if (rozdajKartyMessage.KartyRozdane != null)
                {
                    kartyRozdane = rozdajKartyMessage.KartyRozdane;

                    kartyRozdane.LinkujZZbiorKartControl(zbiorKartControlKartyRozdane);
                    kartyRozdane.DoubleClick += new ZbiorKart.DoubleClickHandler(kartyRozdane_DoubleClick);
                    LinkujZbiorKart(kartyRozdane);

                    kartyRozdane.StylPrezentacji = StylePrezentacjiKart.WyskakująceKolory;
                }

                kartyWygrane.UsunWszystkieKarty();
                kartyWygrane.Widoczny = false;
            }

            if (messageType == MessageType.Pasuj)
            {
                PasujMessage pasujMessage = (PasujMessage)networkMessage;

                if (pasujMessage.Talon != null)
                {
                    talon = pasujMessage.Talon;

                    talon.LinkujZZbiorKartControl(zbiorKartControlTalon);
                    talon.DoubleClick += new ZbiorKart.DoubleClickHandler(talon_DoubleClick);
                    LinkujZbiorKart(talon);
                }
            }

            if (messageType == MessageType.RozpocznijGre)
            {
                RozpocznijGreMessage rozpocznijGreMessage = (RozpocznijGreMessage)networkMessage;

                Karta nowaKarta = rozpocznijGreMessage.KartaDlaGracza;
                if (nowaKarta != null)
                {
                    LinkujKarte(nowaKarta);

                    kartyRozdane.DodajKarte(nowaKarta, false, true, true);
                }

                PrzygotujKartyDoGry();
            }

            if (messageType == MessageType.RezygnujZGry)
            {
                PrzygotujKartyDoGry();
            }

            if (messageType == MessageType.WylozKarte)
            {
                if (lewa.LiczbaKart == 3)
                {
                    if (gracz == lewa.GraczZbierajacyLewe)
                    {
                        foreach (Karta karta in lewa.Karty)
                        {
                            kartyWygrane.DodajKarte(karta, false);
                        }                        
                    }

                    lewa.UsunWszystkieKarty();
                }
            }

            DostosujInterfejsStolika(messageType);
        }

        void rozgrywka_OnKolorAtuChange(Rozgrywka rozgrywka, Rozgrywka rozgrywkaStanPoprzedni)
        {
            if (rozgrywkaStanPoprzedni != null && rozgrywka.KolorAtu == rozgrywkaStanPoprzedni.KolorAtu)
                return;

            pictureBoxKolorAtu_Pokaz(rozgrywka.KolorAtu);
        }

        private void PrzygotujKartyDoGry()
        {
            kartaGracza2.UsunWszystkieKarty();
            kartaGracza3.UsunWszystkieKarty();

            talon.UsunWszystkieKarty();
        }

        private void DostosujInterfejsStolika(MessageType messageType)
        {
            ZainicjujInterfejs();

            switch (messageType)
            {
                case MessageType.DodajStolik:
                    MonitorujZbieranieGraczy();
                    break;
                case MessageType.DolaczDoStolika:
                    MonitorujZbieranieGraczy();
                    break;
                case MessageType.RozdajKarty:
                    MonitorujRozdanieKart();
                    MonitorujLicytacje();
                    break;
                case MessageType.Licytuj:
                    MonitorujLicytacje();
                    break;
                case MessageType.Pasuj:
                    MonitorujLicytacje();
                    MonitorujPobranieTalonu();
                    break;
                case MessageType.RozpocznijGre:
                    MonitorujRozpoczecieGry();
                    break;
                case MessageType.RezygnujZGry:
                    MonitorujRozygnacjeZGry();
                    break;
                case MessageType.WylozKarte:
                    MonitorujWylozenieKarty();
                    break;
                default:
                    break;
            }

            OdswiezStanGraczy();
        }

        private void OdswiezStanGraczy()
        {
            foreach (Gracz g in stolik.Gracze.Values)
                g.DostosujWyglad(rozgrywka);
        }

        private void ZainicjujInterfejs()
        {
            buttonRozdajKarty.Visible = false;

            buttonRozpocznijGre.Visible = false;
            buttonRezygnujZGry.Visible = false;
            buttonPobierzTalon.Visible = false;

            buttonLicytuj.Visible = false;
            buttonPasuj.Visible = false;
            numericUpDownLicytuj.Visible = false;
        }

        private void MonitorujRozdanieKart()
        {
            kartyRozdane.Widoczny = true;

            buttonRozdajKarty.Enabled = true;

            wyniki.Add(new WynikRozdania(rozgrywka));

            buttonWyniki.Visible = true;
        }

        private void MonitorujZbieranieGraczy()
        {
            if (rozgrywka.StanRozgrywki == StanyRozgrywki.RozdanieKart)
                buttonRozdajKarty.Visible = true;
        }

        private void MonitorujLicytacje()
        {
            buttonLicytuj.Enabled = true;
            buttonPasuj.Enabled = true;

            if (rozgrywka.StanRozgrywki != StanyRozgrywki.Licytacja)
                return;

            if (rozgrywka.GraczRozgrywajacy == gracz)
            {
                buttonLicytuj.Visible = true;
                buttonPasuj.Visible = true;

                int licytowanaStawka = rozgrywka.LicytowanaStawka + 10;

                numericUpDownLicytuj.Minimum = licytowanaStawka;
                numericUpDownLicytuj.Value = licytowanaStawka;

                numericUpDownLicytuj.Visible = true;
            }
        }

        private void MonitorujPobranieTalonu()
        {
            buttonLicytuj.Enabled = true;
            buttonPasuj.Enabled = true;

            if (rozgrywka.StanRozgrywki != StanyRozgrywki.PobranieTalonu)
                return;

            if (talon != null)
            {
                talon.Widoczny = true;
            }

            if (rozgrywka.GraczRozgrywajacy == gracz)
            {
                buttonPobierzTalon.Visible = true;

                buttonRozpocznijGre.Visible = true;
                buttonRezygnujZGry.Visible = true;

                int licytowanaStawka = rozgrywka.LicytowanaStawka;

                numericUpDownLicytuj.Minimum = licytowanaStawka;
                numericUpDownLicytuj.Value = licytowanaStawka;

                numericUpDownLicytuj.Visible = true;
            }
        }

        private void MonitorujRozpoczecieGry()
        {
            buttonRozpocznijGre.Enabled = true;
            buttonRezygnujZGry.Enabled = true;
        }

        private void MonitorujRozygnacjeZGry()
        {
            buttonRozpocznijGre.Enabled = true;
            buttonRezygnujZGry.Enabled = true;

            if (rozgrywka.StanRozgrywki == StanyRozgrywki.RozdanieKart)
            {
                DopiszWyniki();
                PrzejdzDoRozdania();
            }
        }

        private void PrzejdzDoRozdania()
        {
            kartyRozdane.Widoczny = false;
            lewa.Widoczny = false;

            if (gracz == rozgrywka.GraczRozdajacy)
                buttonRozdajKarty.Visible = true;

            if (kartyWygrane.LiczbaKart != 0)
                PokazKartyWygrane();
        }

        private void PokazKartyWygrane()
        {
            kartyWygrane.Widoczny = true;
        }

        private void MonitorujWylozenieKarty()
        {
            lewa.Widoczny = true;

            zbiorKartControlKartyRozdane.Enabled = true;

            if (rozgrywka.StanRozgrywki == StanyRozgrywki.RozdanieKart)
            {
                DopiszWyniki();
                PrzejdzDoRozdania();
            }
        }

        private void DopiszWyniki()
        {
            if (wyniki.Count > 0)
            {
                WynikRozdania ostatniWynik = wyniki[wyniki.Count - 1];

                ostatniWynik.DopiszWyniki(rozgrywka);
            }
        }

        private void buttonRozdajKarty_Click(object sender, EventArgs e)
        {
            if (rozgrywka.StanRozgrywki != StanyRozgrywki.RozdanieKart)
                return;

            if (rozgrywka.GraczRozdajacy != null && gracz != rozgrywka.GraczRozdajacy)
            {
                MessageBox.Show(gracz.NickGracza+" nie jesteś graczem rozdającym karty");

                return;
            }

            RozdajKartyMessage rozdajKartyMessage = new RozdajKartyMessage(stolik.NumerStolika);

            networkClient.Send(rozdajKartyMessage);

            buttonRozdajKarty.Enabled = false;
        }

        private void buttonLicytuj_Click(object sender, EventArgs e)
        {
            int licytowanaStawka = (int)numericUpDownLicytuj.Value;

            string info;
            if (!rozgrywka.MozeLicytowac(gracz, licytowanaStawka, out info))
            {
                MessageBox.Show(info);
                return;
            }

            LicytujMessage licytujMessage = new LicytujMessage(stolik.NumerStolika, licytowanaStawka);

            networkClient.Send(licytujMessage);

            buttonLicytuj.Enabled = false;
            buttonPasuj.Enabled = false;
        }

        private void buttonPasuj_Click(object sender, EventArgs e)
        {
            if (rozgrywka.StanRozgrywki != StanyRozgrywki.Licytacja)
                return;
            if (gracz != rozgrywka.GraczRozgrywajacy)
                return;

            PasujMessage pasujMessage = new PasujMessage(stolik.NumerStolika);

            networkClient.Send(pasujMessage);

            buttonLicytuj.Enabled = false;
            buttonPasuj.Enabled = false;
        }

        private void talon_DoubleClick(ZbiorKart zbiorKart, Karta wybranaKarta)
        {
            if (wybranaKarta == null)
                return;

            if (zbiorKart.LiczbaKart == 0)
                return;

            if (rozgrywka.StanRozgrywki != StanyRozgrywki.PobranieTalonu)
                return;

            if (gracz != rozgrywka.GraczRozgrywajacy)
                return;

            zbiorKart.UsunKarte(wybranaKarta);
            kartyRozdane.DodajKarte(wybranaKarta);

            if (zbiorKart.LiczbaKart == 0)
            {
                zbiorKart.ZbiorKartControl.Visible = false;
                buttonPobierzTalon.Visible = false;
            }
        }

        private void kartyRozdane_DoubleClick(ZbiorKart zbiorKart, Karta wybranaKarta)
        {
            if (rozgrywka.StanRozgrywki == StanyRozgrywki.PobranieTalonu)
                PodzialTalonu(zbiorKart, wybranaKarta);
            if (rozgrywka.StanRozgrywki == StanyRozgrywki.WykladanieKart)
                WylozKarte(zbiorKart, wybranaKarta);
        }

        private void PodzialTalonu(ZbiorKart zbiorKart, Karta wybranaKarta)
        {
            if (wybranaKarta == null)
                return;

            if (zbiorKart.LiczbaKart == 0)
                return;

            if (gracz != rozgrywka.GraczRozgrywajacy)
                return;

            if (kartaGracza2.LiczbaKart > 0 && kartaGracza3.LiczbaKart > 0)
            {
                MessageBox.Show("Wybrałeś już karty dla graczy. Jeżeli chcesz zmienić wybór kliknij na kartę wybranego gracza");
                return;
            }

            if (kartaGracza2.LiczbaKart == 0)
            {
                kartaGracza2.DodajKarte(wybranaKarta);
            }
            else
                if (kartaGracza3.LiczbaKart == 0)
                {
                    kartaGracza3.DodajKarte(wybranaKarta);
                }
                else
                    return;

            zbiorKart.UsunKarte(wybranaKarta);
        }

        private void WylozKarte(ZbiorKart zbiorKart, Karta wybranaKarta)
        {
            if (!zbiorKartControlKartyRozdane.Enabled)
                return;

            if (wybranaKarta == null)
                return;

            if (zbiorKart.LiczbaKart == 0)
                return;

            if (gracz != rozgrywka.GraczRozgrywajacy)
                return;

            string info;
            if (!lewa.PoprawnaKarta(gracz, wybranaKarta, out info))
            {
                MessageBox.Show(info);
                return;
            }

            zbiorKart.UsunKarte(wybranaKarta);

            WylozKarteMessage wylozKarteMessage = new WylozKarteMessage(stolik.NumerStolika, wybranaKarta);

            networkClient.Send(wylozKarteMessage);

            zbiorKartControlKartyRozdane.Enabled = false;
        }

        private void kartaGracza_DoubleClick(ZbiorKart zbiorKart, Karta wybranaKarta)
        {
            if (wybranaKarta == null)
                return;

            if (zbiorKart.LiczbaKart == 0)
                return;

            if (rozgrywka.StanRozgrywki != StanyRozgrywki.PobranieTalonu)
                return;

            if (gracz != rozgrywka.GraczRozgrywajacy)
                return;

            zbiorKart.UsunKarte(wybranaKarta);

            kartyRozdane.DodajKarte(wybranaKarta);
        }

        private void buttonPobierzTalon_Click(object sender, EventArgs e)
        {
            if (talon.LiczbaKart == 0)
                return;

            if (rozgrywka.StanRozgrywki != StanyRozgrywki.PobranieTalonu)
                return;

            if (gracz != rozgrywka.GraczRozgrywajacy)
                return;

            PobierzTalon();

            buttonPobierzTalon.Visible = false;
        }

        private void PobierzTalon()
        {
            if (talon.LiczbaKart == 0)
                return;

            foreach (Karta wybranaKarta in talon.Karty)
            {
                kartyRozdane.DodajKarte(wybranaKarta, false);
            }

            kartyRozdane.SortujKarty();

            talon.UsunWszystkieKarty();
        }

        private void buttonRozpocznijGre_Click(object sender, EventArgs e)
        {
            if (rozgrywka.StanRozgrywki != StanyRozgrywki.PobranieTalonu)
                return;
            if (gracz != rozgrywka.GraczRozgrywajacy)
                return;

            if (kartaGracza2.LiczbaKart != 1 || kartaGracza3.LiczbaKart != 1)
            {
                MessageBox.Show("Przed rozpoczęciem gry wybierz po jednej karcie dla pozostałych graczy przy stoliku");
                return;
            }

            if (talon.LiczbaKart > 0)
            {
                PobierzTalon();
            }

            int licytowanaStawka = (int)numericUpDownLicytuj.Value;

            RozpocznijGreMessage rozpocznijGreMessage = new RozpocznijGreMessage(stolik.NumerStolika, licytowanaStawka, kartaGracza2[0], kartaGracza3[0]);

            networkClient.Send(rozpocznijGreMessage);

            buttonRozpocznijGre.Enabled = false;
            buttonRezygnujZGry.Enabled = false;
        }

        private void numericUpDownLicytuj_ValueChanged(object sender, EventArgs e)
        {
            if ((int)numericUpDownLicytuj.Value % 10 != 0)
                numericUpDownLicytuj.Value = Decimal.Round(numericUpDownLicytuj.Value/10, MidpointRounding.AwayFromZero)*10;
        }

        private void buttonRezygnujZGry_Click(object sender, EventArgs e)
        {
            if (rozgrywka.StanRozgrywki != StanyRozgrywki.PobranieTalonu)
                return;
            if (gracz != rozgrywka.GraczRozgrywajacy)
                return;

            RezygnujZGryMessage rezygnujZGryMessage = new RezygnujZGryMessage(stolik.NumerStolika);

            networkClient.Send(rezygnujZGryMessage);

            buttonRozpocznijGre.Enabled = false;
            buttonRezygnujZGry.Enabled = false;
        }

        private void buttonWyniki_Click(object sender, EventArgs e)
        {
            FormTabelaWynikow formTabelaWynikow = new FormTabelaWynikow(rozgrywka);

            formTabelaWynikow.ShowDialog();
        }

        private void pictureBoxKolorAtu_Pokaz(KoloryKart kolorAtu)
        {
            if (kolorAtu == 0)
            {
                pictureBoxKolorAtu.Visible = false;
                return;
            }

            Bitmap bitmapKolorAtu = null;

            switch (kolorAtu)
            {
                case KoloryKart.Kier:
                    bitmapKolorAtu = Resources.he;
                    break;
                case KoloryKart.Karo:
                    bitmapKolorAtu = Resources.di;
                    break;
                case KoloryKart.Trefl:
                    bitmapKolorAtu = Resources.cl;
                    break;
                case KoloryKart.Pik:
                    bitmapKolorAtu = Resources.sp;
                    break;
            }

            if (bitmapKolorAtu != null)
            {
                bitmapKolorAtu.MakeTransparent();
                pictureBoxKolorAtu.Image = bitmapKolorAtu;
            }

            pictureBoxKolorAtu.Visible = true;
        }

        private void buttonSendMessage_Click(object sender, EventArgs e)
        {
            string msg = richTextBoxMessage.Text;
            if (msg == String.Empty)
                return;

            CzatStolikMessage cm = new CzatStolikMessage(stolik.NumerStolika, msg);
            networkClient.Send(cm);

            richTextBoxMessage.Clear();
        }
    }
}
