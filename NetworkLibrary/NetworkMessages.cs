using System;

namespace Network
{
    [Serializable]
    public class NetworkMessage
    {
        private bool replayMessage = false;

        public bool ReplayMessage
        {
            get { return replayMessage; }
            internal set { replayMessage = value; }
        }

        public NetworkMessage()
        {
        }
    }

    [Serializable]
    public class StringMessage : NetworkMessage
    {
        private string messageString;

        public StringMessage(string messageString)
        {
            this.messageString = messageString;
        }

        public override string ToString()
        {
            return messageString;
        }
    }
}
