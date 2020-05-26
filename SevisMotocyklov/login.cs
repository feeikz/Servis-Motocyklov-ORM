using SevisMotocyklov.Database;
using SevisMotocyklov.Database.dao_sqls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SevisMotocyklov
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;


            if (checkBox1.Checked == true)
            {
                if (login != "" || password != "")
                {
                    Zamestnanec zamestnanec = ZamestnanecTable.SelectLogin(login);
                    if (zamestnanec.login == "" || zamestnanec.heslo == "")
                    {
                        MessageBox.Show("Zle prihlasovacie údaje !");
                    }
                    else
                    {
                        if (zamestnanec.heslo == password)
                        {
                            Form1 f1 = new Form1(login);
                            f1.Show();
                            this.Hide();
                        }
                        else MessageBox.Show("Zle prihlasovacie údaje !");
                    }
                }
                else
                {
                    MessageBox.Show("Nezadali ste prihlasovacie údaje !");
                }


            }


            if (checkBox2.Checked == true)
            {
                if (login != "" || password != "")
                {
                    Zakaznik zakaznik = ZakaznikTable.SelectLogin(login);
                    if (zakaznik.login == "" || zakaznik.heslo == "")
                    {
                        MessageBox.Show("Zle prihlasovacie údaje !");
                    }
                    else 
                    {
                        if (zakaznik.heslo == password)
                        {
                            customer c = new customer();
                            c.Show();
                            this.Hide();
                        }
                        else MessageBox.Show("Zle prihlasovacie údaje !");
                    }
                }
                else 
                {
                    MessageBox.Show("Nezadali ste prihlasovacie údaje !");
                }
                
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //zammestnanec check
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
            }
            //zakaznik check
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                label4.Visible = true;
                label5.Visible = true;
                label7.Visible = true;
                label6.Visible = true;
            }
            else
            {
                label4.Visible = false;
                label5.Visible = false;
                label7.Visible = false;
                label6.Visible = false;
            }
        }
    }
}
