using System;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Net.Sockets;

using Network;
using TysiacClassLibrary;

namespace Tysiac
{
    public partial class FormPokoik : Form
    {
        private NetworkClient networkClient = new NetworkClient();
        long clientIndex;

        private PokoikInfo pokoikInfo;
        private string nickGracza;
        private bool zalogowany = false;

        public delegate void StolikMessageHandler(NetworkClient networkClient, NetworkMessage networkMessage);
        public event StolikMessageHandler OnStolikMessage;

        public FormPokoik()
        {
            InitializeComponent();

            nickGracza = textBoxNickGracza.Text;

            networkClient.OnEndRead += new NetworkClient.EndReadHandler(networkClient_OnEndRead);

            StartClient();
        }

        private bool ZalogujGracza()
        {
            if (textBoxNickGracza.Text == String.Empty)
            {
                MessageBox.Show("Uzupełnij nick gracza");
                textBoxNickGracza.Focus();

                return false;
            }

            ZalogujGraczaMessage zalogujGraczaMessage = new ZalogujGraczaMessage(nickGracza);

            networkClient.Send(zalogujGraczaMessage);

            buttonLogon.Enabled = false;
            textBoxNickGracza.Enabled = false;

            return true;
        }

        public delegate void OnServerMessageCallback(NetworkClient networkClient, NetworkMessage networkMessage);

        private void networkClient_OnEndRead(NetworkClient networkClient, NetworkMessage networkMessage)
        {
            if (InvokeRequired)
            {
                object[] pList = { networkClient, networkMessage };
                labelNickGracza.BeginInvoke(new OnServerMessageCallback(OnServerMessage), pList);
            }
            else
            {
                OnServerMessage(networkClient, networkMessage);
            }
        }

        private void OnServerMessage(NetworkClient networkClient, NetworkMessage networkMessage)
        {
            BaseMessage baseMessage = (BaseMessage)networkMessage;

            MessageType messageType = baseMessage.MessageType;

            if (messageType == MessageType.CzatMessage)
            {
                CzatMessage czatMessage = (CzatMessage)networkMessage;

                richTextRxMessage.Text += czatMessage.MessageString + "\n";
            }

            if (messageType == MessageType.ZalogujGracza)
            {
                ZalogujGraczaMessage zalogujGraczaMessage = (ZalogujGraczaMessage)networkMessage;

                richTextRxMessage.Text += zalogujGraczaMessage.LogonMessage + "\n";

                if (zalogujGraczaMessage.Zalogowany)
                {
                    zalogowany = true;

                    buttonLogon.Enabled = false;
                    textBoxNickGracza.Enabled = false;
                    buttonNowyStolik.Enabled = true;

                    listBoxStoliki_SelectedIndexChanged();
                }
                else
                {
                    buttonLogon.Enabled = true;
                    textBoxNickGracza.Enabled = true;
                }

                int numerGracza = ((int)clientIndex - 1) % 3 + 1;

                DolaczDoStolika(numerGracza);
            }

            if (messageType == MessageType.PokoikInfo)
            {
                PokoikMessage pokoikMessage = (PokoikMessage)networkMessage;

                clientIndex = pokoikMessage.ClientIndex;

                int numerGracza = ((int)clientIndex - 1) % 3 + 1;

                string[] imiona = new string[3];
                imiona[0] = "Ola";
                imiona[1] = "Mati";
                imiona[2] = "Szymek";

                if (clientIndex < 4)
                    textBoxNickGracza.Text = imiona[clientIndex-1];
                else
                    textBoxNickGracza.Text += " " + clientIndex;

                Location = new Point(Location.X, 240 * (numerGracza - 1));

                if (pokoikMessage.Powitanie != String.Empty)
                    richTextRxMessage.Text += pokoikMessage.Powitanie + "\n";

                pokoikInfo = pokoikMessage.PokoikInfo;

                listBoxStoliki.Items.Clear();
                foreach (StolikInfo stolikInfo in pokoikInfo.StolikiInfo.Values)
                    listBoxStoliki.Items.Add(stolikInfo);

                if (listBoxStoliki.Items.Count > 0)
                    listBoxStoliki.SelectedIndex = 0;

                ZalogujGracza();
            }

            if (messageType == MessageType.NowyStolikInfo)
            {
                NowyStolikInfoMessage nowyStolikInfoMessage = (NowyStolikInfoMessage)networkMessage;

                StolikInfo stolikInfo = nowyStolikInfoMessage.StolikInfo;

                NowyStolik(stolikInfo);

                if (listBoxStoliki.Items.Count == 1)
                    listBoxStoliki.SelectedIndex = 0;
            }

            if (messageType == MessageType.DodajStolik)
            {
                DodajStolikMessage dodajStolikMessage = (DodajStolikMessage)networkMessage;

                StolikInfo stolikInfo = dodajStolikMessage.Stolik.Info();

                NowyStolik(stolikInfo);

                if (dodajStolikMessage.ReplayMessage)
                {
                    listBoxStoliki.SelectedIndex = listBoxStoliki.Items.Count - 1;

                    FormStolikGracza formStolikGracza = new FormStolikGracza(this, this.networkClient, stolikInfo.NumerStolika, nickGracza);

                    buttonNowyStolik.Enabled = true;
                }
            }

            if (messageType == MessageType.GraczPrzyStolikuInfo)
            {
                GraczPrzyStolikuInfoMessage graczPrzyStolikuInfoMessage = (GraczPrzyStolikuInfoMessage)networkMessage;

                StolikInfo stolikInfo = graczPrzyStolikuInfoMessage.StolikInfo;

                GraczPrzyStoliku(stolikInfo);
            }

            if (messageType == MessageType.DolaczDoStolika)
            {
                DolaczDoStolikaMessage dolaczDoStolikaMessage = (DolaczDoStolikaMessage)networkMessage;

                StolikInfo stolikInfo = dolaczDoStolikaMessage.Stolik.Info();

                GraczPrzyStoliku(stolikInfo);

                if (dolaczDoStolikaMessage.ReplayMessage)
                {
                    FormStolikGracza formStolikGracza = new FormStolikGracza(this, this.networkClient, stolikInfo.NumerStolika, nickGracza);
                }
            }

            if (messageType == MessageType.UsunStolik)
            {
                UsunStolikMessage usunStolikMessage = (UsunStolikMessage)networkMessage;

                if (pokoikInfo.StolikiInfo.Count == 0)
                    return;

                pokoikInfo.StolikiInfo.Remove(usunStolikMessage.NumerStolika);

                int selectedIndex = listBoxStoliki.SelectedIndex;

                listBoxStoliki.Items.Clear();
                foreach (StolikInfo stolikInfo in pokoikInfo.StolikiInfo.Values)
                    listBoxStoliki.Items.Add(stolikInfo);

                if (listBoxStoliki.Items.Count == 0)
                    listBoxStoliki_SelectedIndexChanged();
                else
                {
                    if (listBoxStoliki.Items.Count - 1 < selectedIndex)
                        selectedIndex = listBoxStoliki.Items.Count - 1;

                    listBoxStoliki.SelectedIndex = selectedIndex;
                }

                //if (usunStolikMessage.ReplayMessage)
                //    buttonUsunStolik.Enabled = true;
            }

            IStolikable isStolikMessage = networkMessage as IStolikable;
            if (OnStolikMessage != null & isStolikMessage != null)
                foreach (StolikMessageHandler smh in OnStolikMessage.GetInvocationList())
                {
                    long nrStolika = isStolikMessage.ClientNumerStolika;
                    if (isStolikMessage.Stolik != null)
                        nrStolika = isStolikMessage.Stolik.NumerStolika;

                    if (((FormStolikGracza)smh.Target).NumerStolika == nrStolika)
                        smh(this.networkClient, networkMessage);
                }
        }

        private void NowyStolik(StolikInfo stolikInfo)
        {
            long numerStolika = stolikInfo.NumerStolika;

            pokoikInfo.StolikiInfo.Add(numerStolika, stolikInfo);

            listBoxStoliki.Items.Add(stolikInfo);
        }

        private void GraczPrzyStoliku(StolikInfo stolikInfo)
        {
            long numerStolika = stolikInfo.NumerStolika;

            pokoikInfo.StolikiInfo[numerStolika] = stolikInfo;

            int selectedIndex = listBoxStoliki.SelectedIndex;

            foreach (StolikInfo s in listBoxStoliki.Items)
            {
                if (s.NumerStolika == numerStolika)
                {
                    listBoxStoliki.Items[listBoxStoliki.Items.IndexOf(s)] = stolikInfo;

                    break;
                }
            }

            listBoxStoliki.SelectedIndex = selectedIndex;
        }

        private void buttonNowyStolik_Click(object sender, EventArgs e)
        {
            if (DodajStolik())
                buttonNowyStolik.Enabled = false;
        }

        private bool DodajStolik()
        {
            if (!GraczZalogowany())
                return false;

            DodajStolikMessage dodajStolikMessage = new DodajStolikMessage();

            networkClient.Send(dodajStolikMessage);

            return true;
        }

        private bool DolaczDoStolika(int numerGracza)
        {
            if (!GraczZalogowany())
                return false;

            StolikInfo stolikInfo = (StolikInfo)listBoxStoliki.SelectedItem;

            if (nickGracza == stolikInfo.NickGracza1 ||
                nickGracza == stolikInfo.NickGracza2 ||
                nickGracza == stolikInfo.NickGracza2 )
            {
                //DialogResult dr = MessageBox.Show("Chcesz zagrać sam ze sobą?", "Gra w tysiąca",
                //    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                //if (dr == DialogResult.No)
                //    return false;

                MessageBox.Show("Nie możesz zagrać sam ze sobą", "Gra w tysiąca",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
                return false;
            }

            DolaczDoStolikaMessage dolaczDoStolikaMessage = new DolaczDoStolikaMessage(stolikInfo.NumerStolika, numerGracza);

            networkClient.Send(dolaczDoStolikaMessage);

            return true;
        }

        private bool GraczZalogowany()
        {
            if (!zalogowany)
            {
                MessageBox.Show("Przed rozpoczęciem gry musisz się zalogować");
                textBoxNickGracza.Focus();
            }

            return zalogowany;
        }

        private void buttonGracz1_Click(object sender, EventArgs e)
        {
            if (DolaczDoStolika(1))
                buttonGracz1.Enabled = false;
        }

        private void buttonGracz2_Click(object sender, EventArgs e)
        {
            if (DolaczDoStolika(2))
                buttonGracz2.Enabled = false;
        }

        private void buttonGracz3_Click(object sender, EventArgs e)
        {
            if (DolaczDoStolika(3))
                buttonGracz3.Enabled = false;
        }

        void ButtonConnectClick(object sender, System.EventArgs e)
        {
            StartClient();
        }

        private void StartClient()
        {
            // Check the port value
            if (textBoxPort.Text == "")
            {
                MessageBox.Show("Please enter a Port Number");
                return;
            }

            try
            {
                int port = Convert.ToInt32(textBoxPort.Text);

                TcpClient tcpClient = new TcpClient("localhost", port);

                networkClient.Start(tcpClient);

                UpdateControls(true);
            }
            catch (SocketException se)
            {
                string str = "\nConnection failed, is the server running?\n" + se.Message;
                MessageBox.Show(str);
                UpdateControls(false);
            }
        }

        void ButtonSendMessageClick(object sender, System.EventArgs e)
        {
            string msg = richTextTxMessage.Text;

            CzatMessage cm = new CzatMessage(msg);
            networkClient.Send(cm);
        }

        private void UpdateControls(bool connected)
        {
            buttonConnect.Enabled = !connected;
            buttonDisconnect.Enabled = connected;
            string connectStatus = connected ? "połączony" : "rozłączony";
            textBoxConnectStatus.Text = connectStatus;

            buttonLogon.Enabled = connected;
            textBoxNickGracza.Enabled = connected;
        }

        void ButtonDisconnectClick(object sender, System.EventArgs e)
        {
            networkClient.Stop();

            UpdateControls(false);
        }

        void ButtonCloseClick(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            richTextRxMessage.Clear();
        }

        private void FormPokoik_FormClosed(object sender, FormClosedEventArgs e)
        {
            networkClient.Stop();
        }

        private void listBoxStoliki_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxStoliki_SelectedIndexChanged();
        }

        private void listBoxStoliki_SelectedIndexChanged()
        {
            if (listBoxStoliki.Items.Count == 0)
            {
                buttonUsunStolik.Enabled = false;

                buttonGracz1.Text = "Dołącz";
                buttonGracz2.Text = "Dołącz";
                buttonGracz3.Text = "Dołącz";

                buttonGracz1.Enabled = false;
                buttonGracz2.Enabled = false;
                buttonGracz3.Enabled = false;

                return;
            }
            else
                if (zalogowany)
                    buttonUsunStolik.Enabled = true;

            StolikInfo stolikInfo = (StolikInfo)listBoxStoliki.SelectedItem;

            if (stolikInfo == null)
                return;

            OdswiezPrzyciskGracza(stolikInfo.NickGracza1, buttonGracz1);
            OdswiezPrzyciskGracza(stolikInfo.NickGracza2, buttonGracz2);
            OdswiezPrzyciskGracza(stolikInfo.NickGracza3, buttonGracz3);
        }

        private void OdswiezPrzyciskGracza(string nickGracza, Button buttonGracz)
        {
            buttonGracz.Enabled = (nickGracza == null & zalogowany);
            buttonGracz.Text = (nickGracza == null ? "Dołącz" : nickGracza);
        }

        private void buttonUsunStolik_Click(object sender, EventArgs e)
        {
            if (UsunStolik())
                buttonUsunStolik.Enabled = false;
        }

        private bool UsunStolik()
        {
            if (listBoxStoliki.Items.Count == 0)
                return true;

            StolikInfo stolikInfo = (StolikInfo)listBoxStoliki.SelectedItem;

            UsunStolikMessage usunStolikMessage = new UsunStolikMessage(stolikInfo.NumerStolika);

            networkClient.Send(usunStolikMessage);

            return true;
        }

        private void textBoxNickGracza_TextChanged(object sender, EventArgs e)
        {
            nickGracza = textBoxNickGracza.Text;
        }

        private void buttonLogon_Click(object sender, EventArgs e)
        {
            ZalogujGracza();
        }
    }
}
