using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Network
{
    public class NetworkServer
    {
        private TcpListener tcpListener;

        private List<NetworkClient> connections = new List<NetworkClient>();
        public List<NetworkClient> Connections
        {
            get { return connections; }
        }

        private long connectionsCount = 0;

        private AsyncCallback callbackConnect;

        public delegate void EndReadHandler(NetworkClient networkClient, NetworkMessage networkMessage);
        public event EndReadHandler OnEndRead;
        public delegate void CloseConnectHandler(NetworkClient networkClient);
        public event CloseConnectHandler OnCloseConnect;

        public delegate void ConnectHandler(NetworkClient networkClient);
        public event ConnectHandler OnConnect;

        public void Start(TcpListener tcpListener)
        {
            Stop();

            this.tcpListener = tcpListener;

            callbackConnect = new AsyncCallback(OnConnectComplete);

            this.tcpListener.Start();
            this.tcpListener.BeginAcceptTcpClient(callbackConnect, null);
        }

        public void Stop()
        {
            if (tcpListener != null)
            {
                tcpListener.Stop();
                tcpListener.Server.Close();
            }

            foreach (NetworkClient networkClient in connections)
            {
                networkClient.Stop();
            }

            connections.Clear();
        }

        public void Send(NetworkMessage networkMessage, NetworkClient networkClientSender, bool exceptSender)
        {
            foreach (NetworkClient networkClient in connections)
            {
                if (networkClient == networkClientSender & exceptSender)
                    continue;

                bool replayMessage = networkClient == networkClientSender;
                
                networkClient.Send(networkMessage, replayMessage);
            }
        }

        public void Send(NetworkMessage networkMessage, NetworkClient networkClientSender)
        {
            Send(networkMessage, networkClientSender, false);
        }

        public void Send(NetworkMessage networkMessage)
        {
            Send(networkMessage, null, false);
        }

        private void OnConnectComplete(IAsyncResult ar)
        {
            try
            {
                TcpClient tcpClient = tcpListener.EndAcceptTcpClient(ar);

                NetworkClient networkClient = new NetworkClient(++connectionsCount);
                networkClient.OnEndRead += new NetworkClient.EndReadHandler(networkClient_OnEndRead);
                networkClient.OnCloseConnect += new NetworkClient.CloseConnectHandler(networkClient_OnCloseConnect);

                connections.Add(networkClient);

                // Let the networkClient do the further processing for the 
                // just connected client
                networkClient.Start(tcpClient);

                // Since the tcpListener is now free, it can go back and wait for
                // other clients who are attempting to connect
                tcpListener.BeginAcceptTcpClient(callbackConnect, null);

                if (OnConnect != null)
                    OnConnect(networkClient);
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

        private void networkClient_OnEndRead(NetworkClient networkClient, NetworkMessage networkMessage)
        {
            if (OnEndRead != null)
                OnEndRead(networkClient, networkMessage);
        }

        private void networkClient_OnCloseConnect(NetworkClient networkClient)
        {
            connections.Remove(networkClient);

            if (OnCloseConnect != null)
                OnCloseConnect(networkClient);
        }
    }
}
