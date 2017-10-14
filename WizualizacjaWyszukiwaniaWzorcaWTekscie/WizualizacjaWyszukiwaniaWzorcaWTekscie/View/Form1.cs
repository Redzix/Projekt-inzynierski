using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjektInzynierski.Controller;

namespace ProjektInzynierski
{
    public partial class Form1 : Form
    {
        bool czyByloSzukane = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void b_Szukaj_Click(object sender, EventArgs e)
        {
            AlgorytmNaive obiekt = new AlgorytmNaive();
            List<int> lista = new List<int>();
            lista = obiekt.SzukajWzorca(tb_wzorzec.Text,rtb_zakres.Text);
            
            foreach(var wynik in lista)
            {
                rtb_zakres.Select(wynik, tb_wzorzec.TextLength);
                rtb_zakres.SelectionBackColor = Color.Red;              
            }

            tb_liczbaWystapien.Text = lista.Count().ToString();
            czyByloSzukane = true;
        }

        private void tb_wzorzec_TextChanged(object sender, EventArgs e)
        {
            rtb_zakres.Select(0, rtb_zakres.TextLength);
            rtb_zakres.SelectionBackColor = Color.White;
        }

        private void rtb_zakres_TextChanged(object sender, EventArgs e)
        {
            if (czyByloSzukane)
            {
                rtb_zakres.Select(0, rtb_zakres.TextLength);
                rtb_zakres.SelectionBackColor = Color.White;
                rtb_zakres.Select(rtb_zakres.TextLength, 0);
                
                czyByloSzukane = false;
            }
        }
    }
}
