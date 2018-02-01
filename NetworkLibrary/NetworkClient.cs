using System;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Soap;

namespace Network
{
    public class NetworkClient
    {
        private long clientIndex = 0;
        public long ClientIndex
        {
            get { return clientIndex; }
        }

        private TcpClient tcpClient;

        private byte[] buffer = new byte[4096];
        string stringMessage = String.Empty;
        private NetworkStream networkStream;
        private MemoryStream memoryStream = new MemoryStream();
        private SoapFormatter soapFormatter = new SoapFormatter();

        private AsyncCallback callbackRead;

        public delegate void EndReadHandler(NetworkClient networkClient, NetworkMessage networkMessage);
        public event EndReadHandler OnEndRead;
        public delegate void CloseConnectHandler(NetworkClient networkClient);
        public event CloseConnectHandler OnCloseConnect;

        public NetworkClient()
        {
        }

        public NetworkClient(long clientIndex) : this()
        {
            this.clientIndex = clientIndex;
        }

        public override string ToString()
        {
            return "Client "+clientIndex;
        }

        public void Start(TcpClient tcpClient)
        {
            Stop();

            this.tcpClient = tcpClient;
            networkStream = tcpClient.GetStream();

            callbackRead = new AsyncCallback(OnReadComplete);

            BeginRead();
        }

        private void BeginRead()
        {
            networkStream.BeginRead(buffer, 0, buffer.Length, callbackRead, this);
        }

        public void Stop()
        {
            if (tcpClient != null)
            {
                tcpClient.Close();
            }
        }

        public void Send(NetworkMessage networkMessage, bool replayMessage)
        {
            networkMessage.ReplayMessage = replayMessage;

            try
            {
                soapFormatter.Serialize(networkStream, networkMessage);
                networkStream.Flush();
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        public void Send(NetworkMessage networkMessage)
        {
            Send(networkMessage, false);
        }

        private void OnReadComplete(IAsyncResult ar)
        {
            try
            {
                int bytesRead = networkStream.EndRead(ar);

                if (bytesRead > 0)
                {
                    memoryStream.Write(buffer, 0, bytesRead);

                    string s = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    stringMessage = String.Concat(stringMessage, s);

                    //MessageBox.Show(stringMessage);
                    
                    //if (!networkStream.DataAvailable)
                    if (stringMessage.IndexOf("</SOAP-ENV:Envelope>") > -1)
                    {
                        memoryStream.Seek(0, SeekOrigin.Begin);

                        NetworkMessage networkMessage = (NetworkMessage)soapFormatter.Deserialize(memoryStream);

                        //string testString = Encoding.ASCII.GetString(memoryStream.GetBuffer(), 0, (int)memoryStream.Position);
                        //MessageBox.Show(stringMessage);

                        memoryStream.Close();
                        memoryStream = new MemoryStream();
                        
                        stringMessage = String.Empty;

                        if (OnEndRead != null)
                            OnEndRead(this, networkMessage);
                    }

                    BeginRead();
                }
                else
                {
                    Stop();

                    if (OnCloseConnect != null)
                        OnCloseConnect(this);
                }
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\n OnConnectComplete: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }
    }
}
