using System;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;

using Network;
using TysiacClassLibrary;
using System.Collections;
using System.Collections.Generic;

namespace TysiacServer
{
    public partial class formTysiacServer : Form
    {		
        private NetworkServer networkServer = new NetworkServer();

        private SortedList<string, NetworkClient> polaczenia = new SortedList<string, NetworkClient>();

        private Pokoik pokoik = new Pokoik();

        public formTysiacServer()
        {
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();

            networkServer.OnConnect += new NetworkServer.ConnectHandler(networkServer_OnConnect);
            networkServer.OnCloseConnect += new NetworkServer.CloseConnectHandler(networkServer_OnCloseConnect);
            networkServer.OnEndRead += new NetworkServer.EndReadHandler(networkServer_OnEndRead);

            Stolik stolik;

            stolik = pokoik.DodajStolik();
            stolik = pokoik.DodajStolik();

            StartServer();
        }

        private void networkServer_OnConnect(NetworkClient networkClient)
        {
            AppendToRichEditControl("Połączenie nr " + networkClient.ClientIndex + " zostało nawiązane \n");

            PokoikMessage pokoikMessage =
                new PokoikMessage(pokoik.Info(), "Witaj w grze Tysiąc. Żeby zagrać musisz się zalogować", networkClient.ClientIndex);

            networkClient.Send(pokoikMessage);
        }

        void networkServer_OnCloseConnect(NetworkClient networkClient)
        {
            string nickGracza;
            if (PolaczonyGracz(networkClient, out nickGracza))
            {
                polaczenia.Remove(nickGracza);
            }

            AppendToRichEditControl("Połączenie nr " + networkClient.ClientIndex + " zostało przerwane" + "\n");
        }

        private void networkServer_OnEndRead(NetworkClient networkClient, NetworkMessage networkMessage)
        {
            BaseMessage baseMessage = (BaseMessage)networkMessage;

            MessageType messageType = baseMessage.MessageType;

            if (messageType == MessageType.CzatMessage)
            {
                CzatMessage czatMessage = (CzatMessage)networkMessage;
                
                string nickGracza;
                if (!PolaczonyGracz(networkClient, out nickGracza))
                {
                    nickGracza = "gość nr "+ networkClient.ClientIndex;
                }

                //"Wiadomość od " + 
                string msg = nickGracza + ":" + czatMessage.MessageString;

                czatMessage.MessageString = msg;

                networkServer.Send(czatMessage, networkClient, true);
            }

            if (messageType == MessageType.ZalogujGracza)
            {
                ZalogujGraczaMessage zalogujGraczaMessage = (ZalogujGraczaMessage)networkMessage;

                bool zalogowany = false;
                string serverMessage, clientMessage;

                NetworkClient nc = null;

                if (polaczenia.ContainsKey(zalogujGraczaMessage.NickGracza))
                    nc = polaczenia[zalogujGraczaMessage.NickGracza];

                if (nc == null)
                {
                    try
                    {
                        polaczenia.Add(zalogujGraczaMessage.NickGracza, networkClient);

                        serverMessage = "Gracz " + zalogujGraczaMessage.NickGracza +
                            " zalogował się na połączeniu nr " + networkClient.ClientIndex;

                        clientMessage = "Witaj " + zalogujGraczaMessage.NickGracza +
                            ". Zapraszam do gry przy wybranym stoliku";

                        zalogowany = true;
                    }
                    catch (SystemException ex)
                    {
                        serverMessage = "Nieudana próba zalogowania gracza " +
                            zalogujGraczaMessage.NickGracza + " na połączeniu " +
                            networkClient.ClientIndex + "\n" +
                            ex.Message;

                        clientMessage = "Nieudana próba zalogowania. Ponów próbę";

                        zalogowany = false;
                    }
                }
                else
                    if (nc == networkClient)
                    {
                        serverMessage = "Próba ponownego zalogowania gracza " +
                           zalogujGraczaMessage.NickGracza + " na połączeniu " +
                            networkClient.ClientIndex;

                        clientMessage = "Jesteś już zalogowany.";

                        zalogowany = true;
                    }
                    else
                    {
                        serverMessage = "Próba zalogowania gracza na wykorzystanym wcześniej nick " +
                            zalogujGraczaMessage.NickGracza + " na połączeniu " +
                            networkClient.ClientIndex;

                        clientMessage = "Nick " + zalogujGraczaMessage.NickGracza +
                            " jest już użyty przez innego gracza. Zmień nick i zaloguj się ponownie";

                        zalogowany = false;
                    }

                AppendToRichEditControl(serverMessage + "\n");

                zalogujGraczaMessage.Zalogowany = zalogowany;
                zalogujGraczaMessage.LogonMessage = clientMessage;

                networkClient.Send(zalogujGraczaMessage);
            }

            if (messageType == MessageType.DodajStolik)
            {
                DodajStolikMessage dodajStolikMessage = (DodajStolikMessage)networkMessage;

                string nickGracza;
                if (!PolaczonyGracz(networkClient, out nickGracza))
                {
                    return;
                }

                Gracz gracz = new Gracz(nickGracza, 1);

                Stolik stolik = pokoik.DodajStolik();

                stolik.DolaczDoStolika(gracz);

                dodajStolikMessage.Stolik = stolik;
                WyslijWiadomoscDoStolika(stolik, dodajStolikMessage, networkClient);

                NowyStolikInfoMessage nowyStolikInfoMessage = new NowyStolikInfoMessage(stolik.Info());
                WyslijWiadomoscDoPozostalychGraczy(stolik, nowyStolikInfoMessage);
            }

            if (messageType == MessageType.DolaczDoStolika)
            {
                DolaczDoStolikaMessage dolaczDoStolikaMessage = (DolaczDoStolikaMessage)networkMessage;

                string nickGracza;
                if (!PolaczonyGracz(networkClient, out nickGracza))
                {
                    return;
                }

                Stolik stolik = (Stolik)pokoik.Stoliki[dolaczDoStolikaMessage.ClientNumerStolika];
                Gracz gracz = new Gracz(nickGracza, dolaczDoStolikaMessage.NumerGracza);

                stolik.DolaczDoStolika(gracz);

                dolaczDoStolikaMessage.Stolik = stolik;
                WyslijWiadomoscDoStolika(stolik, dolaczDoStolikaMessage, networkClient);

                GraczPrzyStolikuInfoMessage graczPrzyStolikuInfoMessage = new GraczPrzyStolikuInfoMessage(stolik.Info());
                WyslijWiadomoscDoPozostalychGraczy(stolik, graczPrzyStolikuInfoMessage);
            }

            if (messageType == MessageType.UsunStolik)
            {
                UsunStolikMessage usunStolikMessage = (UsunStolikMessage)networkMessage;

                pokoik.UsunStolik(usunStolikMessage.NumerStolika);

                networkServer.Send(usunStolikMessage, networkClient);
            }

            if (messageType == MessageType.RozdajKarty)
            {
                RozdajKartyMessage rozdajKartyMessage = (RozdajKartyMessage)networkMessage;

                Stolik stolik;
                Gracz graczRozdajacy;
                if (!PolaczonyGracz(networkClient, rozdajKartyMessage.ClientNumerStolika, out stolik, out graczRozdajacy))
                {
                    return;
                }

                stolik.Rozgrywka.RozdajKarty(graczRozdajacy);

                rozdajKartyMessage.Stolik = stolik;

                NetworkClient nc;
                foreach (Gracz gracz in stolik.Gracze.Values)
                {
                    if (polaczenia.ContainsKey(gracz.NickGracza))
                    {
                        nc = polaczenia[gracz.NickGracza];

                        rozdajKartyMessage.KartyRozdane = gracz.KartyRozdane;

                        nc.Send(rozdajKartyMessage);
                    }
                }
            }
            
            if (messageType == MessageType.Licytuj)
            {
                LicytujMessage licytujMessage = (LicytujMessage)networkMessage;

                Stolik stolik;
                Gracz graczLicytujacy;
                if (!PolaczonyGracz(networkClient, licytujMessage.ClientNumerStolika, out stolik, out graczLicytujacy))
                {
                    return;
                }

                if (!stolik.Rozgrywka.Licytuj(graczLicytujacy, licytujMessage.LicytowanaStawka))
                    return;

                licytujMessage.Stolik = stolik;
                WyslijWiadomoscDoStolika(stolik, licytujMessage, networkClient);
            }

            if (messageType == MessageType.Pasuj)
            {
                PasujMessage pasujMessage = (PasujMessage)networkMessage;

                Stolik stolik;
                Gracz graczPasujacy;
                if (!PolaczonyGracz(networkClient, pasujMessage.ClientNumerStolika, out stolik, out graczPasujacy))
                {
                    return;
                }

                if (!stolik.Rozgrywka.Pasuj(graczPasujacy))
                    return;

                if (stolik.Rozgrywka.StanRozgrywki == StanyRozgrywki.PobranieTalonu)
                {
                    pasujMessage.Talon = stolik.Rozgrywka.Talon;
                }

                pasujMessage.Stolik = stolik;
                WyslijWiadomoscDoStolika(stolik, pasujMessage, networkClient);
            }

            if (messageType == MessageType.RozpocznijGre)
            {
                RozpocznijGreMessage rozpocznijGreMessage = (RozpocznijGreMessage)networkMessage;

                Stolik stolik;
                Gracz graczRozgrywajacy;
                if (!PolaczonyGracz(networkClient, rozpocznijGreMessage.ClientNumerStolika, out stolik, out graczRozgrywajacy))
                {
                    return;
                }

                Karta kartaDlaGracza2 = rozpocznijGreMessage.KartaDlaGracza2;
                Karta kartaDlaGracza3 = rozpocznijGreMessage.KartaDlaGracza3;

                if (!stolik.Rozgrywka.RozpocznijGre(graczRozgrywajacy, rozpocznijGreMessage.LicytowanaStawka, kartaDlaGracza2, kartaDlaGracza3))
                    return;

                rozpocznijGreMessage.Stolik = stolik;
                rozpocznijGreMessage.KartaDlaGracza2 = null;
                rozpocznijGreMessage.KartaDlaGracza3 = null;

                NetworkClient nc;
                foreach (Gracz gracz in stolik.Gracze.Values)
                {
                    if (polaczenia.ContainsKey(gracz.NickGracza))
                    {
                        nc = polaczenia[gracz.NickGracza];

                        if (gracz == graczRozgrywajacy)
                        {
                            rozpocznijGreMessage.KartaDlaGracza = null;
                            nc.Send(rozpocznijGreMessage, true);
                        }
                        else
                        {
                            if (gracz == stolik.GraczObok(graczRozgrywajacy, 1))
                                rozpocznijGreMessage.KartaDlaGracza = kartaDlaGracza2;
                            else
                                if (gracz == stolik.GraczObok(graczRozgrywajacy, 2))
                                    rozpocznijGreMessage.KartaDlaGracza = kartaDlaGracza3;

                            nc.Send(rozpocznijGreMessage, false);
                        }
                    }
                }
            }

            if (messageType == MessageType.RezygnujZGry)
            {
                RezygnujZGryMessage rezygnujZGryMessage = (RezygnujZGryMessage)networkMessage;

                Stolik stolik;
                Gracz graczRezygnujacy;
                if (!PolaczonyGracz(networkClient, rezygnujZGryMessage.ClientNumerStolika, out stolik, out graczRezygnujacy))
                {
                    return;
                }

                if (!stolik.Rozgrywka.RezygnujZGry(graczRezygnujacy))
                    return;

                rezygnujZGryMessage.Stolik = stolik;
                WyslijWiadomoscDoStolika(stolik, rezygnujZGryMessage, networkClient);
            }

            if (messageType == MessageType.WylozKarte)
            {
                WylozKarteMessage wylozKarteMessage = (WylozKarteMessage)networkMessage;

                Stolik stolik;
                Gracz graczWykladajacy;
                if (!PolaczonyGracz(networkClient, wylozKarteMessage.ClientNumerStolika, out stolik, out graczWykladajacy))
                {
                    return;
                }

                Karta wylozonaKarta = graczWykladajacy.KartyRozdane.AdresKarty(wylozKarteMessage.WylozonaKarta);
                if (!stolik.Rozgrywka.WylozKarte(graczWykladajacy, wylozonaKarta))
                    return;

                wylozKarteMessage.Stolik = stolik;

                WyslijWiadomoscDoStolika(stolik, wylozKarteMessage, networkClient);
            }

            if (messageType == MessageType.CzatStolikMessage)
            {
                CzatStolikMessage czatStolikMessage = (CzatStolikMessage)networkMessage;

                Stolik stolik;
                Gracz gracz;
                if (!PolaczonyGracz(networkClient, czatStolikMessage.ClientNumerStolika, out stolik, out gracz))
                {
                    return;
                }

                string msg = @" \b " + gracz.NickGracza + ":" + @"\b0 " +
                    czatStolikMessage.MessageString;

                czatStolikMessage.MessageString = msg;

                WyslijWiadomoscDoStolika(stolik, czatStolikMessage, networkClient);
            }
        }

        private void WyslijWiadomoscDoStolika(Stolik stolik, NetworkMessage networkMessage, NetworkClient networkClientSender)
        {
            WyslijWiadomoscDoStolika(stolik, networkMessage, networkClientSender, false);
        }

        private void WyslijWiadomoscDoStolika(Stolik stolik, NetworkMessage networkMessage, NetworkClient networkClientSender, bool exceptSender)
        {
            NetworkClient networkClient;
            foreach (Gracz gracz in stolik.Gracze.Values)
            {
                if (polaczenia.ContainsKey(gracz.NickGracza))
                {
                    networkClient = polaczenia[gracz.NickGracza];
                    bool replayMessage = networkClient == networkClientSender;

                    if (!(replayMessage & exceptSender))
                        networkClient.Send(networkMessage, replayMessage);
                }
            }
        }

        private void WyslijWiadomoscDoPozostalychGraczy(Stolik stolik, NetworkMessage networkMessage)
        {
            ArrayList polaczeniaStolika = new ArrayList();

            foreach (Gracz gracz in stolik.Gracze.Values)
                polaczeniaStolika.Add(polaczenia[gracz.NickGracza]);

            foreach (NetworkClient nc in networkServer.Connections)
            {
                if (polaczeniaStolika.IndexOf(nc) < 0)
                    nc.Send(networkMessage);
            }

        }

        private bool PolaczonyGracz(NetworkClient networkClient, out string nickGracza)
        {
            int clientIndex = polaczenia.IndexOfValue(networkClient);

            if (clientIndex < 0)
            {
                nickGracza = String.Empty;
                return false;
            }

            nickGracza = polaczenia.Keys[clientIndex];
            
            return true;
        }

        private bool PolaczonyGracz(NetworkClient networkClient, long numerStolika, out Stolik stolik, out Gracz gracz)
        {
            stolik = null;
            gracz = null;

            string nickGracza;

            if (!PolaczonyGracz(networkClient, out nickGracza))
            {
                return false;
            }

            if (!pokoik.Stoliki.ContainsKey(numerStolika))
                return false;

            stolik = (Stolik)pokoik.Stoliki[numerStolika];

            if (!stolik.Gracze.ContainsKey(nickGracza))
                return false;

            gracz = (Gracz)stolik.Gracze[nickGracza];

            return true;
        }

        public delegate void UpdateRichEditCallback(string text);

        // This method could be called by either the main thread or any of the
        // worker threads
        private void AppendToRichEditControl(string msg)
        {
            // Check to see if this method is called from a thread 
            // other than the one created the control
            if (InvokeRequired)
            {
                // We cannot update the GUI on this thread.
                // All GUI controls are to be updated by the main (GUI) thread.
                // Hence we will use the invoke method on the control which will
                // be called when the Main thread is free
                // Do UI update on UI thread
                object[] pList = { msg };
                richTextBoxReceivedMsg.BeginInvoke(new UpdateRichEditCallback(OnUpdateRichEdit), pList);
            }
            else
            {
                // This is the main thread which created this control, hence update it
                // directly 
                OnUpdateRichEdit(msg);
            }
        }

        // This UpdateRichEdit will be run back on the UI thread
        // (using System.EventHandler signature
        // so we don't need to define a new
        // delegate type here)
        private void OnUpdateRichEdit(string msg)
        {
            richTextBoxReceivedMsg.AppendText(msg);
        }

        private void ButtonStartListenClick(object sender, System.EventArgs e)
		{
            StartServer();
		}

        private void StartServer()
        {
            // Check the port value
            if (textBoxPort.Text == "")
            {
                MessageBox.Show("Please enter a Port Number");
                return;
            }

            IPAddress localAddress = IPAddress.Parse("127.0.0.1");

            int port = Convert.ToInt32(textBoxPort.Text);

            // Create the listening TcpListener...
            TcpListener tcpListener = new TcpListener(localAddress, port);

            networkServer.Start(tcpListener);

            UpdateControls(true);
        }

		private void UpdateControls(bool listening) 
		{
			buttonStartListen.Enabled = !listening;
			buttonStopListen.Enabled = listening;

            string connectStatus = listening ? "włączony" : "wyłączony";
            textBoxMsg.Text = connectStatus;
		}	

        private void ButtonStopListenClick(object sender, System.EventArgs e)
        {
            networkServer.Stop();

            UpdateControls(false);
        }

        private void ButtonCloseClick(object sender, System.EventArgs e)
		{
            Close();
		}

        private void ButtonSendMsgClick(object sender, System.EventArgs e)
        {
            string msg = "Wiadomość z serwera: " + richTextBoxSendMsg.Text;

            NetworkMessage sm = new CzatMessage(msg);

            networkServer.Send(sm);
        }

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			richTextBoxReceivedMsg.Clear();
		}

        private void formTysiacServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            networkServer.Stop();
        }

    }
}
