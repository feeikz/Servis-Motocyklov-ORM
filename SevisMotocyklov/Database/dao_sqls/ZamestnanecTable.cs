using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace SevisMotocyklov.Database.dao_sqls
{
    public class ZamestnanecTable
    {
        public static String SQL_SELECT = "SELECT * FROM \"Zamestnanec\"";
        public static String SQL_SELECT_ID = "SELECT * FROM \"Zamestnanec\" WHERE ID=@id";
        public static String SQL_SELECT_LIKE = "SELECT * FROM \"Zamestnanec\" WHERE priezvisko like @param";
        public static String SQL_INSERT = "INSERT INTO \"Zamestnanec\" VALUES (@meno, @priezvisko, @telefon,@cena_prace, @pristup)";
        public static String SQL_DELETE_ID = "DELETE FROM \"Zamestnanec\" WHERE ID=@id";
        public static String SQL_UPDATE = "UPDATE Zamestnanec SET meno=@meno, priezvisko=@priezvisko, telefon=@telefon, cena_prace=@cena_prace, pristup=@pristup, WHERE ID=@ID";
        public static String ExecMakeCustomer = "execute VytvorenieZakaznikaZoZamestnanca @id";
        public static String SQL_SELECT_LOG = "SELECT login, heslo FROM \"Zamestnanec\" where login = @login";




        public static Zamestnanec SelectLogin(string login)
        {
            DatabaseClass db = new DatabaseClass();
            db.Connect();


            SqlCommand command = db.CreateCommand(SQL_SELECT_LOG);

            command.Parameters.AddWithValue("@login", login);
            SqlDataReader reader = db.Select(command);
            Zamestnanec zam = new Zamestnanec();
            while (reader.Read())
            {
                int i = -1;
                zam.login = reader.GetString(++i);
                zam.heslo = reader.GetString(++i);
            }
            reader.Close();
            db.Close();


            return zam;
        }
        public static Collection<Zamestnanec> SelectLike(string param)
        {
            DatabaseClass db = new DatabaseClass();
            db.Connect();


            SqlCommand command = db.CreateCommand(SQL_SELECT_LIKE);
            command.Parameters.AddWithValue("@param", param);
            SqlDataReader reader = db.Select(command);

            Collection<Zamestnanec> zamestnanci = Read(reader);
            reader.Close();


            db.Close();


            return zamestnanci;
        }
        public static void MakeCustomer(int zamestnanec, DatabaseClass pDb = null)
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
            SqlCommand command = db.CreateCommand(ExecMakeCustomer);
            command.Parameters.AddWithValue("@id", zamestnanec);

            db.ExecuteNonQuery(command);

        }


        public static Zamestnanec Select(int id)
        {
            DatabaseClass db = new DatabaseClass();
            db.Connect();
          

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = db.Select(command);

            Collection<Zamestnanec> zamestnanci = Read(reader);
            Zamestnanec zamestnanec = null;
            if (zamestnanci.Count == 1)
            {
                zamestnanec = zamestnanci[0];
            }
            reader.Close();

             db.Close();
          

            return zamestnanec;
        }

        public static Collection<Zamestnanec> SelectAll(DatabaseClass pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Zamestnanec> zamestnanci = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zamestnanci;
        }

        public static int Delete(int ID, DatabaseClass pDb = null)
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
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@id", ID);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static int Update(Zamestnanec zamestnanec)
        {
            DatabaseClass db = new DatabaseClass();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, zamestnanec);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static int Insert(Zamestnanec zamestnanec, DatabaseClass pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, zamestnanec);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        private static void PrepareCommand(SqlCommand command, Zamestnanec zamestnanec)
        {
            command.Parameters.AddWithValue("@id", zamestnanec.ID);
            command.Parameters.AddWithValue("@meno", zamestnanec.meno);
            command.Parameters.AddWithValue("@priezvisko", zamestnanec.priezvisko);
            command.Parameters.AddWithValue("@telefon", zamestnanec.telefon);
            command.Parameters.AddWithValue("@cena_prace", zamestnanec.cena_prace);
            command.Parameters.AddWithValue("@pristup", zamestnanec.pristup);
        }

        private static Collection<Zamestnanec> Read(SqlDataReader reader)
        {
            Collection<Zamestnanec> zamestnanci = new Collection<Zamestnanec>();

            while (reader.Read())
            {
                int i = -1;
                Zamestnanec zamestnanec = new Zamestnanec();
                zamestnanec.ID = reader.GetInt32(++i);
                zamestnanec.meno = reader.GetString(++i);
                zamestnanec.priezvisko = reader.GetString(++i);
                zamestnanec.telefon = reader.GetString(++i);
                zamestnanec.cena_prace = reader.GetInt32(++i);
                zamestnanec.pristup = reader.GetInt32(++i);

                zamestnanci.Add(zamestnanec);
            }
            return zamestnanci;
        }

    }
}
