using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace SevisMotocyklov.Database.dao_sqls
{
    class ObjednavkaTable
    {
        

        public static String SQL_SELECT_ALL = "select * from \"objednavka\"";
        public static String SQL_SELECT_ID = "select * from \"objednavka\" where ID=@id";
        public static String SQL_INSERT1 = "insert into objednavka(datum_vytvorenia, uhradene, Zakaznik_ID, Zamestnanec_ID, Motocykel_ID) values(@datum_vytvorenia,  @uhradene, @Zakaznik_ID, @Zamestnanec_ID, @Motocykel_ID)";
        public static String SQL_INSERT2 = "insert into objednavka(datum_vytvorenia, uhradene, Zakaznik_ID, Motocykel_ID) values(@datum_vytvorenia,  @uhradene, @Zakaznik_ID, @Motocykel_ID)";
        public static String SQL_PROGRESS = "select distinct(praca.nazov) from \"objednavka\" join oprava on objednavka.ID = oprava.Objednavka_ID join \"oprava_praca\" on oprava.ID = oprava_praca.Oprava_ID join \"praca\" on oprava_praca.Praca_ID = praca.ID where objednavka.Zakaznik_ID = @id";
        public static String SQL_NOT_PAID = "select * from \"objednavka\" where uhradene = 0";
        public static String SQL_SELECT_MORE = "select objednavka.ID, zakaznik.meno, zakaznik.priezvisko, zamestnanec.meno, zamestnanec.priezvisko, motocykel.vyrobca, motocykel.model, count(oprava.ID) as pocet_prav, sum(oprava.cena) as celkova_cena from Objednavka left join zakaznik on Objednavka.Zakaznik_ID = zakaznik.ID left join motocykel on objednavka.Motocykel_ID = motocykel.ID left join oprava on objednavka.ID = oprava.Objednavka_ID left join zamestnanec on objednavka.Zamestnanec_ID = zamestnanec.ID where zakaznik.priezvisko = @param group by objednavka.ID, zakaznik.meno, zakaznik.priezvisko, zamestnanec.meno, zamestnanec.priezvisko, motocykel.vyrobca, motocykel.model";
        public static String SQL_SELECT_MORE2 = "select objednavka.ID, zakaznik.meno, zakaznik.priezvisko, zamestnanec.meno, zamestnanec.priezvisko, motocykel.vyrobca, motocykel.model, count(oprava.ID) as pocet_prav, sum(oprava.cena) as celkova_cena from Objednavka left join zakaznik on Objednavka.Zakaznik_ID = zakaznik.ID left join motocykel on objednavka.Motocykel_ID = motocykel.ID left join oprava on objednavka.ID = oprava.Objednavka_ID left join zamestnanec on objednavka.Zamestnanec_ID = zamestnanec.ID group by objednavka.ID, zakaznik.meno, zakaznik.priezvisko, zamestnanec.meno, zamestnanec.priezvisko, motocykel.vyrobca, motocykel.model";
        public static String SQL_SELECT_ID_FULL = "select objednavka.ID, meno, priezvisko, motocykel.vyrobca, motocykel.model from Objednavka join zakaznik on Objednavka.Zakaznik_ID = zakaznik.ID join motocykel on objednavka.Motocykel_ID = motocykel.ID join oprava on objednavka.ID = oprava.Objednavka_ID where objednavka.ID=@id";
        public static String ExecuteAddEmployee = "exec PriradZamestnanca @id;";
        public static String ExecuteAddToOrder = "exec PridatOpravuDoObjednavky @diel, @praca, @hodiny, @objednavka, @zamestnanec;";
        public static String ExecuteMakeOrder = "exec VytvorenieObjednavky @zakaznik, @motocykel, @zamestnanec, @diel, @praca, @hodiny";
        public static String SQL_SELECT_MORE_WITH_COUNT_FOR_ID = "select objednavka.ID, zakaznik.meno, zakaznik.priezvisko, zamestnanec.meno, zamestnanec.priezvisko, motocykel.vyrobca, motocykel.model, count(oprava.ID) as pocet_prav, sum(oprava.cena) as celkova_cena from Objednavka left join zakaznik on Objednavka.Zakaznik_ID = zakaznik.ID left join motocykel on objednavka.Motocykel_ID = motocykel.ID left join oprava on objednavka.ID = oprava.Objednavka_ID left join zamestnanec on objednavka.Zamestnanec_ID = zamestnanec.ID where objednavka.ID = @id group by objednavka.ID, zakaznik.meno, zakaznik.priezvisko, zamestnanec.meno, zamestnanec.priezvisko, motocykel.vyrobca, motocykel.model";
        public static String SQL_SELECT_WORK = "select praca.nazov from oprava join oprava_praca on oprava.ID = oprava_praca.Oprava_ID join praca on oprava_praca .Praca_ID = praca.ID join objednavka on oprava.Objednavka_ID = objednavka.ID where objednavka.ID = @id";
        public static String SQL_SELECT_MORE2_WITH_ID = "select objednavka.ID, zakaznik.meno, zakaznik.priezvisko, zakaznik.telefon, zakaznik.karta, zamestnanec.meno, zamestnanec.priezvisko, motocykel.vyrobca, motocykel.model, count(oprava.ID) as pocet_prav, sum(oprava.cena) as celkova_cena from Objednavka left join zakaznik on Objednavka.Zakaznik_ID = zakaznik.ID left join motocykel on objednavka.Motocykel_ID = motocykel.ID left join oprava on objednavka.ID = oprava.Objednavka_ID left join zamestnanec on objednavka.Zamestnanec_ID = zamestnanec.ID where objednavka.ID = @param group by objednavka.ID, zakaznik.meno, zakaznik.priezvisko, zakaznik.telefon,zakaznik.karta ,zamestnanec.meno, zamestnanec.priezvisko, motocykel.vyrobca, motocykel.model";


        
       

        public static Collection<string> Job(int id)
        {
            DatabaseClass db = new DatabaseClass();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_WORK);

            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = db.Select(command);

            Collection<string> prace = new Collection<string>();
            string nazov = "";
            while (reader.Read())
            {
                int i = -1;
                nazov = reader.GetString(++i);
                prace.Add(nazov);
            }
            reader.Close();


            db.Close();


            return prace;
        }




        public static Objednavka SelectMoreForID(int id)
        {
            DatabaseClass db = new DatabaseClass();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_MORE_WITH_COUNT_FOR_ID);

            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = db.Select(command);

            Objednavka objednavka = new Objednavka();
            while (reader.Read())
            {
                int i = -1;

                objednavka.ID = reader.GetInt32(++i);
                string meno = reader.GetString(++i);
                string priezvisko = reader.GetString(++i);
                objednavka.ZakaznikMeno = meno + " " + priezvisko;
                string vyrobca = reader.GetString(++i);
                string model = reader.GetString(++i);
                objednavka.NazovMotorky = vyrobca + " " + model;
                //objednavka.PocetOprav = reader.GetInt32(++i);
                //objednavka.Cena= reader.GetInt32(++i);
                Console.WriteLine(i);


            }
            reader.Close();


            db.Close();


            return objednavka;
        }

        public static Collection<Objednavka> SelectFull(string param)
        {
            DatabaseClass db = new DatabaseClass();
            db.Connect();
   
            SqlCommand command = db.CreateCommand(SQL_SELECT_MORE);
            command.Parameters.AddWithValue("@param", param);
            SqlDataReader reader = db.Select(command);

            Collection<Objednavka> objednavka = ReadFull(reader);
            reader.Close();

   
             db.Close();
            

            return objednavka;
        }

        public static Objednavka SelectFullID(int id)
        {
            DatabaseClass db = new DatabaseClass();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID_FULL);

            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = db.Select(command);

            Objednavka objednavka = new Objednavka();
            while (reader.Read())
            {
                int i = -1;
                
                objednavka.ID = reader.GetInt32(++i);
                string meno = reader.GetString(++i);
                string priezvisko = reader.GetString(++i);
                objednavka.ZakaznikMeno = meno + " " + priezvisko;
                string vyrobca = reader.GetString(++i);
                string model = reader.GetString(++i);
                objednavka.NazovMotorky = vyrobca + " " + model;


            }
            reader.Close();


            db.Close();


            return objednavka;
        }

        public static Objednavka SelectFull2_With_ID(int param)
        {
            DatabaseClass db = new DatabaseClass();
            db.Connect();


            SqlCommand command = db.CreateCommand(SQL_SELECT_MORE2_WITH_ID);
            command.Parameters.AddWithValue("@param", param);
            SqlDataReader reader = db.Select(command);
            //Objednavka objednavka = new Objednavka();
            Objednavka objednavka = ReadIt(reader); 
            //ReadIt(reader);
            reader.Close();

            db.Close();


            return objednavka;
        }


        public static Objednavka ReadIt(SqlDataReader reader)
        {
            Objednavka objednavka = new Objednavka();
            while (reader.Read())
            {
                string meno2 = "nepriradene";
                string priezvisko2 = "";
                int i = -1;
                
                objednavka.ID = reader.GetInt32(++i);
                string meno = reader.GetString(++i);
                string priezvisko = reader.GetString(++i);
                objednavka.telefon = reader.GetString(++i);
                if (!reader.IsDBNull(++i))
                {
                    objednavka.karta = reader.GetInt32(i);
                }
                else objednavka.karta = 0;

                objednavka.ZakaznikMeno = meno + " " + priezvisko;
                if (!reader.IsDBNull(++i))
                {
                    meno2 = reader.GetString(i);
                }
                if (!reader.IsDBNull(++i))
                {
                    priezvisko2 = reader.GetString(i);
                }

                objednavka.ZamestnanecMeno = meno2 + " " + priezvisko2;
                string vyrobca = reader.GetString(++i);
                string model = reader.GetString(++i);
                objednavka.NazovMotorky = vyrobca + " " + model;
                objednavka.PocetOprav = reader.GetInt32(++i);
                if (!reader.IsDBNull(++i))
                {
                    objednavka.Cena = reader.GetInt32(i);
                }
            }        
            return objednavka;
        }

        public static Collection<Objednavka> SelectFull2()
        {
            DatabaseClass db = new DatabaseClass();
            db.Connect();


            SqlCommand command = db.CreateCommand(SQL_SELECT_MORE2);
            //command.Parameters.AddWithValue("@param", param);
            SqlDataReader reader = db.Select(command);

            Collection<Objednavka> objednavka = ReadFull(reader);
            reader.Close();

            db.Close();


            return objednavka;
        }


        public static void MakeOrder(int zakaznik, int motocykel, int zamestnanec, int diel, int praca, int hodiny)
        {
            DatabaseClass db = new DatabaseClass();
            db.Connect();
         
            SqlCommand command = db.CreateCommand(ExecuteMakeOrder);
            command.Parameters.AddWithValue("@zakaznik", zakaznik);
            command.Parameters.AddWithValue("@motocykel", motocykel);
            command.Parameters.AddWithValue("@zamestnanec", zamestnanec);
            command.Parameters.AddWithValue("@diel", diel);
            command.Parameters.AddWithValue("@praca", praca);
            command.Parameters.AddWithValue("@hodiny", hodiny);
            db.ExecuteNonQuery(command);

            db.Close();

        }

        public static void AddToOrder(int diel, int praca, int hodiny, int objednavka, int zamestnanec)
        {
            DatabaseClass db = new DatabaseClass();                         
            db.Connect();
         
      
            SqlCommand command = db.CreateCommand(ExecuteAddToOrder);
            command.Parameters.AddWithValue("@diel", diel);
            command.Parameters.AddWithValue("@praca", praca);
            command.Parameters.AddWithValue("@hodiny", hodiny);
            command.Parameters.AddWithValue("@objednavka", objednavka);
            command.Parameters.AddWithValue("@zamestnanec", zamestnanec);
            db.ExecuteNonQuery(command);

            db.Close();

        }

        public static void AddEmployee(int id, DatabaseClass pDb = null)
        {
            DatabaseClass db;
            if (pDb == null)
            {
                db = new DatabaseClass();
                db.Connect();
            }
            else
            {
                db = (DatabaseClass)pDb;
            }
            SqlCommand command = db.CreateCommand(ExecuteAddEmployee);
            command.Parameters.AddWithValue("@id", id);
            db.ExecuteNonQuery(command);

        }

        public static Collection<Objednavka> NotPaid(DatabaseClass pDb = null)
        {
            DatabaseClass db;
            if (pDb == null)
            {
                db = new DatabaseClass();
                db.Connect();
            }
            else
            {
                db = (DatabaseClass)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_NOT_PAID);
            SqlDataReader reader = db.Select(command);

            Collection<Objednavka> objednavka = Read(reader);


            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return objednavka;

        }

        public static Collection<Objednavka> SelectAll(DatabaseClass pDb = null)
        {
            DatabaseClass db = new DatabaseClass();
            db.Connect();      

            SqlCommand command = db.CreateCommand(SQL_SELECT_ALL);
            SqlDataReader reader = db.Select(command);

            Collection<Objednavka> objednavka = Read(reader);
            reader.Close();

     
             db.Close();
           

            return objednavka;
        }

        public static Collection<String> SelectProgress(int id, DatabaseClass pDb = null)
        {
            DatabaseClass db;
            if (pDb == null)
            {
                db = new DatabaseClass();
                db.Connect();
            }
            else
            {
                db = (DatabaseClass)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_PROGRESS);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = db.Select(command);


            Collection<String> objednavka = new Collection<String>();
            while (reader.Read())
            {
                string nazov;
                int i = -1;
                nazov = reader.GetString(++i);
                objednavka.Add(nazov);
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return objednavka;
        }

        public static Objednavka Select(int id)
        {
            DatabaseClass db = new DatabaseClass();
            db.Connect();
       

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = db.Select(command);

            Collection<Objednavka> objednavky = Read(reader);
            Objednavka objednavka = null;
            if (objednavky.Count == 1)
            {
                objednavka = objednavky[0];
            }
            reader.Close();

 
            db.Close();
         

            return objednavka;
        }

        public static int InsertWith(Objednavka objednavka, DatabaseClass pDb = null)
        {
            DatabaseClass db;
            if (pDb == null)
            {
                db = new DatabaseClass();
                db.Connect();
            }
            else
            {
                db = (DatabaseClass)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_INSERT1);
            PrepareCommandWith(command, objednavka);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static int InsertWithout(Objednavka objednavka, DatabaseClass pDb = null)
        {
            DatabaseClass db;
            if (pDb == null)
            {
                db = new DatabaseClass();
                db.Connect();
            }
            else
            {
                db = (DatabaseClass)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_INSERT2);
            PrepareCommandWithout(command, objednavka);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        private static void PrepareCommandWith(SqlCommand command, Objednavka objednavka)
        {
            command.Parameters.AddWithValue("@id", objednavka.ID);
            command.Parameters.AddWithValue("@datum_vytvorenia", objednavka.datum_vytvorenia);
            command.Parameters.AddWithValue("@uhradene", objednavka.uhradene);
            command.Parameters.AddWithValue("@Zakaznik_ID", objednavka.Zakaznik_ID);
            command.Parameters.AddWithValue("@Zamestnanec_ID", objednavka.Zamestnanec_ID);
            command.Parameters.AddWithValue("@Motocykel_ID", objednavka.Motocykel_ID);

        }

        private static void PrepareCommandWithout(SqlCommand command, Objednavka objednavka)
        {
            command.Parameters.AddWithValue("@id", objednavka.ID);
            command.Parameters.AddWithValue("@datum_vytvorenia", objednavka.datum_vytvorenia);
            command.Parameters.AddWithValue("@uhradene", objednavka.uhradene);
            command.Parameters.AddWithValue("@Zakaznik_ID", objednavka.Zakaznik_ID);
            command.Parameters.AddWithValue("@Motocykel_ID", objednavka.Motocykel_ID);

        }



        private static Collection<Objednavka> Read(SqlDataReader reader)
        {
            Collection<Objednavka> objednavky = new Collection<Objednavka>();

            while (reader.Read())
            {
                int i = -1;
                Objednavka objednavka = new Objednavka();
                objednavka.ID = reader.GetInt32(++i);
                objednavka.datum_vytvorenia = reader.GetDateTime(++i);
                if (!reader.IsDBNull(++i))
                {
                    objednavka.datum_uhradenia = reader.GetDateTime(i);
                }
                objednavka.uhradene = reader.GetInt32(++i);
                objednavka.Zakaznik_ID = reader.GetInt32(++i);
                if (!reader.IsDBNull(++i))
                {
                    objednavka.Zamestnanec_ID = reader.GetInt32(i);
                }
                objednavka.Motocykel_ID = reader.GetInt32(++i);
            
                objednavky.Add(objednavka);
            }
            return objednavky;
        }


        private static Collection<Objednavka> ReadFull(SqlDataReader reader)
        {
            Collection<Objednavka> objednavky = new Collection<Objednavka>();

            while (reader.Read())
            {
                string meno2 = "nepriradene";
                string priezvisko2 = "";
                int i = -1;
                Objednavka objednavka = new Objednavka();
                objednavka.ID = reader.GetInt32(++i);
                string meno = reader.GetString(++i);
                string priezvisko = reader.GetString(++i);
                objednavka.ZakaznikMeno = meno + " " + priezvisko;
                if (!reader.IsDBNull(++i))
                {
                    meno2 = reader.GetString(i);
                }
                if (!reader.IsDBNull(++i))
                {
                    priezvisko2 = reader.GetString(i);
                }
                
                objednavka.ZamestnanecMeno = meno2 + " " + priezvisko2;
                string vyrobca = reader.GetString(++i);
                string model = reader.GetString(++i);
                objednavka.NazovMotorky = vyrobca + " " + model;
                objednavka.PocetOprav = reader.GetInt32(++i);
                if (!reader.IsDBNull(++i))
                {
                    objednavka.Cena = reader.GetInt32(i);
                }
           
                objednavky.Add(objednavka);
            }
            return objednavky;
        }


    }
}
