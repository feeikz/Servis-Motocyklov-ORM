using SevisMotocyklov.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SevisMotocyklov.Database.dao_sqls;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace SevisMotocyklov
{
    public partial class Form2 : Form
    {
        public Form2(ListBox listBox)
        {
            InitializeComponent();
            for (int i = 1; i <= 100; i++)
            {
                ///comboBox6.Items.Add(i);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //vyhladaj zakaznika

            string param = textBox1.Text;
            listBox1.Items.Clear();
            //comboBox1.Items.Clear();
            Collection<Zakaznik> zakaznici = ZakaznikTable.SelectLike(param);
            foreach (Zakaznik item in zakaznici)
            {
                listBox1.Items.Add( item.ID +"   " + item.CeleMeno);
                //comboBox1.Items.Add(item.ID);
                Console.WriteLine(item.CeleMeno);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //motocykel vyhladaj
            string param = textBox5.Text;
            listBox2.Items.Clear();
            comboBox2.Items.Clear();
            Collection<Motocykel> motocykle = MotocykelTable.SelectLike(param);
            foreach (Motocykel item in motocykle)
            {
                listBox2.Items.Add(item.ID + "    " + item.vyrobca + "    " + item.model +  " " + item.obsah_valca + "  "+item.rok_vyroby );
                comboBox2.Items.Add(item.ID);
                Console.WriteLine(item.vyrobca);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //zamestnanec button
            string param = textBox2.Text;
            comboBox2.Items.Clear();
            listBox3.Items.Clear();
            Collection<Zamestnanec> zamestnanci = ZamestnanecTable.SelectLike(param);
            foreach (Zamestnanec item in zamestnanci)
            {
                listBox3.Items.Add(item.ID + "   " + item.CeleMeno);
                //comboBox3.Items.Add(item.ID);
                Console.WriteLine(item.CeleMeno);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //všetko zakaznici
            listBox1.Items.Clear();
           // comboBox1.Items.Clear();
            Collection<Zakaznik> zakaznici = ZakaznikTable.SelectAll();
            foreach (Zakaznik item in zakaznici)
            {
                listBox1.Items.Add(item.ID + "   " + item.CeleMeno);
                //comboBox1.Items.Add(item.ID);
                Console.WriteLine(item.CeleMeno);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            comboBox2.Items.Clear();
            Collection<Motocykel> motocykle = MotocykelTable.SelectAll();
            foreach (Motocykel item in motocykle)
            {
                listBox2.Items.Add(item.ID + "    " + item.vyrobca + "    " + item.model + " " + item.obsah_valca + "  " + item.rok_vyroby);
                comboBox2.Items.Add(item.ID);
                Console.WriteLine(item.vyrobca);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            //comboBox3.Items.Clear();
            Collection<Zamestnanec> zamestnanci = ZamestnanecTable.SelectAll();
            foreach (Zamestnanec item in zamestnanci)
            {
                listBox3.Items.Add(item.ID + "   " + item.CeleMeno);
                //comboBox3.Items.Add(item.ID);
                Console.WriteLine(item.CeleMeno);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            //comboBox4.Items.Clear();
            Collection<Praca> prace = PracaTable.SelectAll();
            foreach (Praca item in prace)
            {
                listBox4.Items.Add(item.ID + "   " + item.nazov);
                //comboBox4.Items.Add(item.ID);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
    
        }

        private void label4_Click(object sender, EventArgs e)
        {
                    }

        private void button3_Click_1(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            //comboBox4.Items.Clear();
            Collection<Praca> prace = PracaTable.SelectAll();
            foreach (Praca item in prace)
            {
                listBox4.Items.Add(item.ID + "   " + item.nazov);
               // comboBox4.Items.Add(item.ID);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox5.Items.Clear();
           // comboBox5.Items.Clear();
            Collection<Nahradny_diel> diely = NahradnyDielTable.SelectAll();
            foreach (Nahradny_diel item in diely)
            {
                listBox5.Items.Add(item.ID + "   " + item.nazov);
                //comboBox5.Items.Add(item.ID);
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            this.Hide();
           /* string Zak = listBox1.GetItemText(listBox1.SelectedItem);
            string Mot = listBox2.GetItemText(listBox2.SelectedItem);
            string Zam = listBox3.GetItemText(listBox3.SelectedItem);
            string Praca = listBox4.GetItemText(listBox4.SelectedItem);
            string Diel = listBox5.GetItemText(listBox5.SelectedItem);
            string Hod = comboBox6.Text;

            int zak = Int16.Parse(Zak);
            int mot = Int16.Parse(Mot);
            int zam = Int16.Parse(Zam);
            int praca = Int16.Parse(Praca);
            int diel = Int16.Parse(Diel);
            int hod = Int16.Parse(Hod);

            MessageBox.Show(zak + " " + mot + " " + zam + " " + praca + " " + diel + " " + hod);*/
        }

        private void button5_Click(object sender, EventArgs e)
        {

            string Zak = listBox1.GetItemText(listBox1.SelectedItem);
            string Mot = listBox2.GetItemText(listBox2.SelectedItem);
            string Zam = listBox3.GetItemText(listBox3.SelectedItem);
            string Praca = listBox4.GetItemText(listBox4.SelectedItem);
            string Diel = listBox5.GetItemText(listBox5.SelectedItem);
            string Hod = comboBox2.Text;

     


            if (Zak == "" || Mot == "" || Zam == "" || Praca == "" || Diel == "" || Hod == "")
            {
                MessageBox.Show("Nevybrali ste si zo všetkých možností !");
            }
            else
            {
                Zak = Zak.Substring(0, 1);
                Mot = Mot.Substring(0, 1);
                Zam = Zam.Substring(0, 1);
                Diel = Diel.Substring(0, 1);
                Praca = Praca.Substring(0, 1);
                int zak = Int16.Parse(Zak);
                int mot = Int16.Parse(Mot);
                int zam = Int16.Parse(Zam);
                int praca = Int16.Parse(Praca);
                int diel = Int16.Parse(Diel);
                int hod = Int16.Parse(Hod);

                try
                {

                    ObjednavkaTable.MakeOrder(zak, mot, zam, diel, praca, hod);
                    MessageBox.Show("Vytváram objednávku !");
                    Collection<Objednavka> objednavky = ObjednavkaTable.SelectFull2();
                    
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Nastala neočakávaná chyba: " + exception.Message);
                }
                   
                this.Hide();
            }
        }
    }
}
