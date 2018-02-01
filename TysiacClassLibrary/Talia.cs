using System;
using System.Collections.Generic;

namespace TysiacClassLibrary
{
    public class Talia : ZbiorKart
    {
        /// <summary>
        /// Konstruktor talii kart
        /// </summary>
        public Talia()
        {
            PrzygotujTalie();
        }

        /// <summary>
        /// Generuje wszystkie karty talii
        /// </summary>
        public void PrzygotujTalie()
        {
            if (LiczbaKart != 24)
            {
                UsunWszystkieKarty();

                foreach (KoloryKart kolorKarty in Enum.GetValues(typeof(KoloryKart)))
                {
                    foreach (WagiKart wagaKarty in Enum.GetValues(typeof(WagiKart)))
                    {
                        Karty.Add(new Karta(kolorKarty, wagaKarty, false));
                    }
                }
            }

            Tasuj();
        }

        /// <summary>
        /// Tasuje karty w talii
        /// </summary>
        private void Tasuj()
        {
            Random random = new Random();

            for (int i = 0; i < Karty.Count; i++)
            {
                int karta1 = i;
                int karta2 = random.Next(Karty.Count);
                ZamienKarty(karta1, karta2);
            }
        }

        /// <summary>
        /// Zamienia karty miejscami
        /// </summary>
        /// <param name="karta1"></param>
        /// <param name="karta2"></param>
        private void ZamienKarty(int karta1, int karta2)
        {
            Karta karta = (Karta)Karty[karta1];
            Karty[karta1] = Karty[karta2];
            Karty[karta2] = karta;
        }

        /// <summary>
        /// Pobiera i zwraca pierwszą kartę z talii i usuwa ją z talii
        /// </summary>
        /// <returns></returns>
        public Karta PobierzKarte()
        {
            Karta karta = (Karta)Karty[0];
            Karty.RemoveAt(0);
            return karta;
        }

    }
}