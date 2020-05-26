using SevisMotocyklov.Database;
using SevisMotocyklov.Database.dao_sqls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SevisMotocyklov
{
    public partial class Form4 : Form
    {
        public Form4(Objednavka objednavka)
        {
            InitializeComponent();
            label7.Text = objednavka.ID.ToString();
            Zakaznik zakaznik = ZakaznikTable.Select(objednavka.ID);
            label.Text = objednavka.ZakaznikMeno;
            label4.Text = objednavka.telefon;
            label2.Text = objednavka.NazovMotorky;
            label23.Text = objednavka.Cena.ToString() + "€";
            label26.Text = objednavka.ZamestnanecMeno;
            if (objednavka.karta == 0)
            {
                label28.Text = "Bez karty";
                label22.Text = "0%";
                label24.Text = "Bez zľavy";
            }
            if (objednavka.karta == 1)
            {
                label28.Text = "Strieborná so zľavou 5%";
                label22.Text = "5%";
                label24.Text = objednavka.vypoocitajZlavu(objednavka.Cena, 5).ToString() + "€";
            }
            if (objednavka.karta == 2)
            {
                label28.Text = "Zlatá so zľavou 10%";
                label22.Text = "10%";
                label24.Text = objednavka.vypoocitajZlavu(objednavka.Cena, 10).ToString() + "€";
            }
            if (objednavka.karta == 3)
            {
                label28.Text = "Platinová so zľavou 15%";
                label22.Text = "15%";
                label24.Text = objednavka.vypoocitajZlavu(objednavka.Cena, 15).ToString() +  "€";
            }




            Collection<string> prace = ObjednavkaTable.Job(objednavka.ID);
            for (int i = 0; i < prace.Count; i++)
            {
                Console.WriteLine("I: " + i + " Praca :" + prace[i]);
                if (i == 0)
                {
                    label11.Text = prace[i];
                    label11.Visible = true;
                    label13.Visible = true;
                }
                if (i == 1)
                {
                    label8.Text = prace[i];
                    label8.Visible = true;
                    label9.Visible = true;
                }
                if (i == 2)
                {
                    label10.Text = prace[i];
                    label10.Visible = true;
                    label12.Visible = true;
                }
                if (i == 3)
                {
                    label17.Text = prace[i];
                    label17.Visible = true;
                    label15.Visible = true;
                }
                if (i == 4)
                {
                    label16.Text = prace[i];
                    label16.Visible = true;
                    label18.Visible = true;
                }

                if (i == 5)
                {
                    label19.Text = prace[i];
                    label19.Visible = true;
                    label30.Visible = true;
                }
                if (i == 6)
                {
                    label35.Text = prace[i];
                    label35.Visible = true;
                    label36.Visible = true;
                }
                if (i == 7)
                {
                    label33.Text = prace[i];
                    label33.Visible = true;
                    label34.Visible = true;
                }
                if (i == 8)
                {
                    label31.Text = prace[i];
                    label31.Visible = true;
                    label32.Visible = true;
                }
                if (i > 8) MessageBox.Show("Niektoré opravy sa nedajú zobraziť.");
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }
    }
}
