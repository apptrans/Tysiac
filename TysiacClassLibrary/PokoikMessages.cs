using System;
using TysiacClassLibrary;

namespace TysiacClassLibrary
{
    [Serializable]
    public class PokoikMessage : BaseMessage
    {
        private PokoikInfo pokoikInfo;
        public PokoikInfo PokoikInfo
        {
            get { return pokoikInfo; }
        }

        string powitanie;
        public string Powitanie
        {
            get { return powitanie; }
        }

        long clientIndex;
        public long ClientIndex
        {
            get { return clientIndex; }
        }

        public PokoikMessage(PokoikInfo pokoikInfo, string powitanie, long clientIndex)
            : base(MessageType.PokoikInfo)
        {
            this.pokoikInfo = pokoikInfo;
            this.powitanie = powitanie;
            this.clientIndex = clientIndex;
        }
    }

    [Serializable]
    public class ZalogujGraczaMessage : BaseMessage
    {
        private string nickGracza;
        public string NickGracza
        {
            get { return nickGracza; }
        }

        private bool zalogowany = false;
        public bool Zalogowany
        {
            get { return zalogowany; }
            set { zalogowany = value; }
        }

        string logonMessage;
        public string LogonMessage
        {
            get { return logonMessage; }
            set { logonMessage = value; }
        }

        public ZalogujGraczaMessage(string nickGracza)
            : base(MessageType.ZalogujGracza)
        {
            this.nickGracza = nickGracza;
        }
    }

    [Serializable]
    public class StolikInfoMessage : BaseMessage
    {
        private StolikInfo stolikInfo;
        public StolikInfo StolikInfo
        {
            get { return stolikInfo; }
        }

        public StolikInfoMessage(MessageType messageType, StolikInfo stolikInfo)
            : base(messageType)
        {
            this.stolikInfo = stolikInfo;
        }
    }

    [Serializable]
    public class NowyStolikInfoMessage : StolikInfoMessage
    {
        public NowyStolikInfoMessage(StolikInfo stolikInfo)
            : base(MessageType.NowyStolikInfo, stolikInfo)
        {
        }
    }

    [Serializable]
    public class GraczPrzyStolikuInfoMessage : StolikInfoMessage
    {
        public GraczPrzyStolikuInfoMessage(StolikInfo stolikInfo)
            : base(MessageType.GraczPrzyStolikuInfo, stolikInfo)
        {
        }
    }

    [Serializable]
    public class UsunStolikMessage : BaseMessage
    {
        private long numerStolika;

        public long NumerStolika
        {
            get { return numerStolika; }
        }

        public UsunStolikMessage(long numerStolika)
            : base(MessageType.UsunStolik)
        {
            this.numerStolika = numerStolika;
        }
    }
}
