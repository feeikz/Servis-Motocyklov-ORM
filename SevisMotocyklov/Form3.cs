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
    public partial class Form3 : Form
    {
        public Form3(int ID, ListBox listBox)
        {
            InitializeComponent();

            cislo.Text = ID.ToString();
            for (int i = 1; i <= 100; i++)
            {
                comboBox2.Items.Add(i);
            }

            Objednavka ob = ObjednavkaTable.Select(ID);
            label3.Text = ob.Zamestnanec_ID.ToString();
            //skontrolovať či ma objednavka zamestnanca
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //objednavka všetko


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            listBox5.Items.Clear();
            //comboBox5.Items.Clear();
            Collection<Nahradny_diel> diely = NahradnyDielTable.SelectAll();
            foreach (Nahradny_diel item in diely)
            {
                listBox5.Items.Add(item.ID + "   " + item.nazov);
                //comboBox5.Items.Add(item.ID);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //zamestnanec všetko
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

        private void button2_Click(object sender, EventArgs e)
        {
            string param = textBox2.Text;
            listBox3.Items.Clear();
            //comboBox3.Items.Clear();
            Collection<Zamestnanec> zamestnanci = ZamestnanecTable.SelectLike(param);
            foreach (Zamestnanec item in zamestnanci)
            {
                listBox3.Items.Add(item.ID + "   " + item.CeleMeno);
                //comboBox3.Items.Add(item.ID);
                Console.WriteLine(item.CeleMeno);
                //}
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //objednavka vyhladať
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //hladať
    
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Objednavka
            // uložiť
            //string tmpzamestannec = comboBox3.Text;    
            //string tmppraca = comboBox4.Text;     
            // string tmpdiel = comboBox5.Text;
            string text = listBox4.GetItemText(listBox4.SelectedItem);
            string text2 = listBox5.GetItemText(listBox5.SelectedItem);
            string text3 = listBox3.GetItemText(listBox3.SelectedItem);
            int ID_prace = 0;
            int ID_dielu = 0;
            int ID_zamestnanca = 0;

            string hodiny = comboBox2.Text;

            if (text == "" || text2 == "" || text3 == "" || hodiny == "")
            {
                MessageBox.Show("Nevyplnili ste polia !");
               // MessageBox.Show(ID_prace + "  " + ID_dielu + "  " + ID_zamestnanca + "  " + hod);
            }
            else 
            {
                
                int IDob = Int16.Parse(cislo.Text);
                int hod = Int16.Parse(hodiny);
                string tmppraca = text.Substring(0, 1);
                ID_prace = Int16.Parse(tmppraca);

                string tmpdiel = text2.Substring(0, 1);
                ID_dielu = Int16.Parse(tmpdiel);

                string tmpzamestannec = text3.Substring(0, 1);
                ID_zamestnanca = Int16.Parse(tmpzamestannec);

                int zamestnanec = 0;
                string tmp = label3.Text;
                if (tmp == "")
                {
                    zamestnanec = 0;
                }
                else
                {
                     zamestnanec = Int16.Parse(tmp);
                }
             

             

                if (zamestnanec > 0 && ID_zamestnanca != zamestnanec )
                {
                    MessageBox.Show("Zvoľte zamestnanca, ktorý je priradený k objednávke");
                }
                else 
                {

                    try
                    {
                        ObjednavkaTable.AddToOrder(ID_dielu, ID_prace, hod, IDob, ID_zamestnanca);
                        //MessageBox.Show("Diel: " + ID_dielu + "Praca" + ID_prace + " hodiny: " + hod + " Objednavka: " + IDob + " Zamestnanec: " + ID_zamestnanca);
                        
                        MessageBox.Show("Pridáva sa do objednávky");
                        this.Hide();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Nastala neočakávaná chyba: " + exception.Message);
                    }
                }

 
              
            }


           
      
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //this.Hide();
            string text = listBox4.GetItemText(listBox4.SelectedItem);
            string text2 = listBox5.GetItemText(listBox5.SelectedItem);
            string text3 = listBox3.GetItemText(listBox3.SelectedItem);
            int ID_prace = 0;
            int ID_dielu = 0;
            int ID_zamestnanca = 0;

            string hodiny = comboBox2.Text;
            int hod = Int16.Parse(hodiny);

            if (text != "")
            {
                string tmppraca = text.Substring(0, 2);
                ID_prace = Int16.Parse(tmppraca);
            }

            if (text2 != "")
            {
                string tmpdiel = text2.Substring(0, 2);
                ID_dielu = Int16.Parse(tmpdiel);
            }

            if (text3 != "")
            {
                string tmpzamestannec = text3.Substring(0, 2);
                ID_zamestnanca = Int16.Parse(tmpzamestannec);
            }

            if (ID_prace < 0 || ID_dielu < 0 || ID_zamestnanca < 0 || hod < 0)
            {
                MessageBox.Show("Nevyplnili ste polia !");
                MessageBox.Show(ID_prace + "  " + ID_dielu + "  " + ID_zamestnanca + "  " + hod);
            }
            else
            {
                if (ID_prace == 1) MessageBox.Show("pasuje");
            }

    


                //this.Hide();
            

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
    
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            string text = listBox4.GetItemText(listBox4.SelectedItem);
            string text2 = listBox5.GetItemText(listBox5.SelectedItem);
            string text3 = listBox3.GetItemText(listBox3.SelectedItem);
            int ID  = 0;
            int ID2 = 0;
            int ID3 = 0;
            if (text != "")
            {
                string tmppraca = text.Substring(0, 2);
                 ID = Int16.Parse(tmppraca);
            }

            if (text2 != "")
            {
                string tmpdiel = text2.Substring(0, 2);
                 ID2 = Int16.Parse(tmpdiel);
            }

            if (text3 != "")
            {
                string tmpzamestannec = text3.Substring(0, 2);
                 ID3 = Int16.Parse(tmpzamestannec);
            }

            string hodiny = comboBox2.Text;
            MessageBox.Show("Zamestnanec ID: " + ID3 + " Počet hodin: " + hodiny + " Praca: " + ID + " ID dielu: " + ID2 );
            //MessageBox.Show("Zamestnanec ID: " + text3 + " Počet hodin: " + hodiny + " Praca: " + text + " ID dielu: " + text2);

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
