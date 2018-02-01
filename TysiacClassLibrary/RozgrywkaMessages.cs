using System;
using TysiacClassLibrary;

namespace TysiacClassLibrary
{
    public interface IStolikable
    {
        long ClientNumerStolika { get; }
        Stolik Stolik { get; set; }
    }

    [Serializable]
    public class BaseStolikMessage : BaseMessage, IStolikable
    {
        private long clientNumerStolika;
        public long ClientNumerStolika
        {
            get { return clientNumerStolika; }
        }
        
        private Stolik stolik;
        public Stolik Stolik
        {
            get { return stolik; }
            set { stolik = value; }
        }

        public BaseStolikMessage(MessageType messageType, long clientNumerStolika)
            : base(messageType)
        {
            this.clientNumerStolika = clientNumerStolika;
        }
    }

    [Serializable]
    public class CzatStolikMessage : BaseStolikMessage
    {
        private string messageString;

        public string MessageString
        {
            get { return messageString; }
            set { messageString = value; }
        }

        public CzatStolikMessage(long clientNumerStolika, string messageString)
            : base(MessageType.CzatStolikMessage, clientNumerStolika)
        {
            this.messageString = messageString;
        }
    }

    [Serializable]
    public class DodajStolikMessage : BaseStolikMessage
    {
        public DodajStolikMessage()
            : base(MessageType.DodajStolik, 0)
        {
        }
    }

    [Serializable]
    public class DolaczDoStolikaMessage : BaseStolikMessage
    {
        private int numerGracza;
        public int NumerGracza
        {
            get { return numerGracza; }
        }

        public DolaczDoStolikaMessage(long clientNumerStolika, int numerGracza)
            : base(MessageType.DolaczDoStolika, clientNumerStolika)
        {
            this.numerGracza = numerGracza;
        }
    }

    [Serializable]
    public class RozdajKartyMessage : BaseStolikMessage
    {
        private ZbiorKart kartyRozdane;
        public ZbiorKart KartyRozdane
        {
            get { return kartyRozdane; }
            set { kartyRozdane = value; }
        }

        public RozdajKartyMessage(long clientNumerStolika)
            : base(MessageType.RozdajKarty, clientNumerStolika)
        {
        }
    }

    [Serializable]
    public class LicytujMessage : BaseStolikMessage
    {
        private int licytowanaStawka;
        public int LicytowanaStawka
        {
            get { return licytowanaStawka; }
        }

        public LicytujMessage(long clientNumerStolika, int licytowanaStawka)
            : base(MessageType.Licytuj, clientNumerStolika)
        {
            this.licytowanaStawka = licytowanaStawka;
        }
    }

    [Serializable]
    public class PasujMessage : BaseStolikMessage
    {
        private Talon talon;
        public Talon Talon
        {
            get { return talon; }
            set { talon = value; }
        }

        public PasujMessage(long clientNumerStolika)
            : base(MessageType.Pasuj, clientNumerStolika)
        {
        }
    }

    [Serializable]
    public class RozpocznijGreMessage : BaseStolikMessage
    {
        private int licytowanaStawka;
        public int LicytowanaStawka
        {
            get { return licytowanaStawka; }
        }

        private Karta kartaDlaGracza2;
        public Karta KartaDlaGracza2
        {
            get { return kartaDlaGracza2; }
            set { kartaDlaGracza2 = value; }
        }

        private Karta kartaDlaGracza3;
        public Karta KartaDlaGracza3
        {
            get { return kartaDlaGracza3; }
            set { kartaDlaGracza3 = value; }
        }

        private Karta kartaDlaGracza;
        public Karta KartaDlaGracza
        {
            get { return kartaDlaGracza; }
            set { kartaDlaGracza = value; }
        }

        public RozpocznijGreMessage(long clientNumerStolika, int licytowanaStawka, Karta kartaDlaGracza2, Karta kartaDlaGracza3)
            : base(MessageType.RozpocznijGre, clientNumerStolika)
        {
            this.licytowanaStawka = licytowanaStawka;

            this.kartaDlaGracza2 = kartaDlaGracza2;
            this.kartaDlaGracza3 = kartaDlaGracza3;
        }
    }

    [Serializable]
    public class WylozKarteMessage : BaseStolikMessage
    {
        private Karta wylozonaKarta;
        public Karta WylozonaKarta
        {
            get { return wylozonaKarta; }
        }

        private bool zbierzLewe;
        public bool ZbierzLewe
        {
            get { return zbierzLewe; }
            set { zbierzLewe = value; }
        }

        public WylozKarteMessage(long clientNumerStolika, Karta wylozonaKarta)
            : base(MessageType.WylozKarte, clientNumerStolika)
        {
            this.wylozonaKarta = wylozonaKarta;
        }
    }

    [Serializable]
    public class RezygnujZGryMessage : BaseStolikMessage
    {
        public RezygnujZGryMessage(long clientNumerStolika)
            : base(MessageType.RezygnujZGry, clientNumerStolika)
        {
        }
    }
}