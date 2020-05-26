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
    public partial class Form1 : Form
    {


        public Form1(string login)
        {
            
            InitializeComponent();

            label8.Text = login;
            Collection<Objednavka> objednavky = ObjednavkaTable.SelectFull2();
            foreach (Objednavka item in objednavky)
            {

                listBox1.Items.Add(item.ID + "         " + item.ZakaznikMeno + "            " + item.NazovMotorky + "        " + item.PocetOprav + "              " + item.Cena + "           " + item.ZamestnanecMeno);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string param = textBox1.Text;
            listBox1.Items.Clear();
            string username = textBox1.Text;
            Collection<Objednavka> objednavky = ObjednavkaTable.SelectFull(username);
            foreach (Objednavka item in objednavky)
            { 
                listBox1.Items.Add(item.ID + "         " + item.ZakaznikMeno + "            " + item.NazovMotorky + "        " + item.PocetOprav + "              " + item.Cena + "           " + item.ZamestnanecMeno);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(listBox1);
            f2.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {


        }

        private void button6_Click(object sender, EventArgs e)
        {
            // pridat do objednavky podla zvolenej
            //prirad zamestnanca
            string text = listBox1.GetItemText(listBox1.SelectedItem);
            if (text == "")
            {
                MessageBox.Show("Nezvolili ste objednávku !");
            }
            else
            {
                string ID = text.Substring(0, 1);
                int tmp = Int16.Parse(ID);
                Form3 f3 = new Form3(tmp, listBox1);
                f3.Show();
            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            string text = listBox1.GetItemText(listBox1.SelectedItem);
            //detaily objednavky
            if (text == "")
            {
                MessageBox.Show("Nezvolili ste objednávku !");
            }
            else
            {
                string ID = text.Substring(0, 1);
                int tmp = Int16.Parse(ID);
                Objednavka ob = ObjednavkaTable.SelectFull2_With_ID(tmp);
                //MessageBox.Show("ID: " + ob.ID+ " Meno: " + ob.ZakaznikMeno + " telefon: " + ob.telefon + " Karta " + ob.karta + " " + ob.ZamestnanecMeno + "  Motorka: " + ob.NazovMotorky +" Pocet oprav: " +ob.PocetOprav + " cena: " + ob.Cena);
                //MessageBox.Show(" ID: " + tmp);
                //MessageBox.Show(ob.ZakaznikMeno + " " + ob.telefon + " Karta: " + ob.karta + " " + ob.ZamestnanecMeno + " " + ob.NazovMotorky + " Opravy: " + ob.PocetOprav + " " + ob.Cena); ;
                Form4 f4 = new Form4(ob);
                f4.Show();

            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Collection<Objednavka> objednavky = ObjednavkaTable.SelectFull2();
            foreach (Objednavka item in objednavky)
            {
                listBox1.Items.Add(item.ID + "         " + item.ZakaznikMeno + "            " + item.NazovMotorky + "        " + item.PocetOprav + "              " + item.Cena + "           " + item.ZamestnanecMeno);
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //prirad zamestnanca
            string text = listBox1.GetItemText(listBox1.SelectedItem);
            if (text == "")
            {
                MessageBox.Show("Nezvolili ste objednávku !");
            }
            else 
            {
                string ID = text.Substring(0, 1);
                int tmp = Int16.Parse(ID);
                try
                {

                    ObjednavkaTable.AddEmployee(tmp);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Nastala neočakávaná chyba: " + exception.Message);
                }

                
                listBox1.Items.Clear();
                Collection<Objednavka> objednavky = ObjednavkaTable.SelectFull2();
                foreach (Objednavka item in objednavky)
                {

                    listBox1.Items.Add(item.ID + "         " + item.ZakaznikMeno + "            " + item.NazovMotorky + "        " + item.PocetOprav + "              " + item.Cena + "           " + item.ZamestnanecMeno);
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            login l = new login();
            l.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Collection<Objednavka> objednavky = ObjednavkaTable.SelectFull2();
            foreach (Objednavka item in objednavky)
            {

                listBox1.Items.Add(item.ID + "         " + item.ZakaznikMeno + "            " + item.NazovMotorky + "        " + item.PocetOprav + "              " + item.Cena + "           " + item.ZamestnanecMeno);
            }

        }
    }
}

