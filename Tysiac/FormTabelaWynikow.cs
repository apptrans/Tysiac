using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TysiacClassLibrary;

namespace Tysiac
{
    public partial class FormTabelaWynikow : Form
    {
        private Rozgrywka rozgrywka;

        public FormTabelaWynikow(Rozgrywka rozgrywka)
        {
            InitializeComponent();

            this.rozgrywka = rozgrywka;

            PrzepiszWyniki();
        }

        private void PrzepiszWyniki()
        {
            int liczbaZakonczonychRozdan = 0;

            foreach (Gracz gracz in rozgrywka.Stolik.Gracze.Values)
            {
                listViewWyniki.Columns[2 + gracz.NumerGracza - 1].Text = gracz.ToString();
                listViewWyniki.Columns[2 + gracz.NumerGracza - 1].TextAlign = HorizontalAlignment.Left;
            }

            foreach (WynikRozdania wynik in rozgrywka.Wyniki)
            {
                ListViewItem listViewItemWynik;

                if (wynik.SaWyniki)
                {
                    listViewItemWynik = new ListViewItem(new string[] {
                        wynik.NumerRozdania.ToString(),
                        wynik.GraczRozdajacy.ToString(),
                        wynik.Wyniki[0].ToString(),
                        wynik.Wyniki[1].ToString(),
                        wynik.Wyniki[2].ToString()}, -1);

                    ++liczbaZakonczonychRozdan;
                }
                else
                {
                    listViewItemWynik = new ListViewItem(new string[] {
                        wynik.NumerRozdania.ToString(),
                        wynik.GraczRozdajacy.ToString()}, -1);
                }

                listViewWyniki.Items.Add(listViewItemWynik);
            }

            if (liczbaZakonczonychRozdan < 2)
                return;

            WynikRozdania podsumowanie = new WynikRozdania();

            foreach (Gracz gracz in rozgrywka.Stolik.Gracze.Values)
                podsumowanie.Wyniki[gracz.NumerGracza - 1] = gracz.StanKontaGry;

            ListViewItem listViewItemPodsumowanie = new ListViewItem(new string[] {
                    "",
                    "razem",
                    podsumowanie.Wyniki[0].ToString(),
                    podsumowanie.Wyniki[1].ToString(),
                    podsumowanie.Wyniki[2].ToString()}, -1);

            listViewItemPodsumowanie.BackColor = Color.AliceBlue;

            listViewWyniki.Items.Add(listViewItemPodsumowanie);
        }

        private void buttonWyniki_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
