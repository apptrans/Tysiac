using System;
using Network;

namespace TysiacClassLibrary
{
    public enum MessageType
    {
        CzatMessage, CzatStolikMessage, PokoikInfo, ZalogujGracza, NowyStolikInfo, GraczPrzyStolikuInfo, UsunStolik, DodajStolik, DolaczDoStolika, RozdajKarty, Licytuj, Pasuj, RozpocznijGre, RezygnujZGry, WylozKarte
    }

    [Serializable]
    public class BaseMessage : NetworkMessage
    {
        private MessageType messageType;

        public MessageType MessageType
        {
            get { return messageType; }
        }

        public BaseMessage(MessageType messageType)
        {
            this.messageType = messageType;
        }
    }

    [Serializable]
    public class CzatMessage : BaseMessage
    {
        private string messageString;

        public string MessageString
        {
            get { return messageString; }
            set { messageString = value; }
        }

        public CzatMessage(string messageString)
            : base(MessageType.CzatMessage)
        {
            this.messageString = messageString;
        }

        public override string ToString()
        {
            return messageString;
        }
    }
}
