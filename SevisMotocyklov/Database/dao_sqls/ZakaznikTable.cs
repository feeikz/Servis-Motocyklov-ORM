using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace SevisMotocyklov.Database.dao_sqls
{
    public class ZakaznikTable
    {
        public static String SQL_SELECT = "SELECT * FROM \"Zakaznik\"";
        public static String SQL_SELECT_ID = "SELECT * FROM \"Zakaznik\" WHERE ID=@id";
        public static String SQL_SELECT_LIKE = "SELECT * FROM \"Zakaznik\" WHERE priezvisko like @param";
        public static String SQL_INSERT_WITH = "INSERT INTO \"Zakaznik\" VALUES (@meno, @priezvisko, @telefon, @pristup, @karta)";
        public static String SQL_INSERT_WITHOUT = "INSERT INTO \"Zakaznik\" VALUES (@meno, @priezvisko, @telefon, @pristup)";
        public static String SQL_DELETE_ID = "DELETE FROM \"Zakaznik\" WHERE ID=@id";
        public static String SQL_UPDATE = "UPDATE Zakaznik SET meno=@meno, priezvisko=@priezvisko, telefon=@telefon, pristup=@pristup, karta=@karta WHERE ID=@ID";
        public static String ExecCarts = "Execute UdelenieVernostnychKariet";
        public static String SQL_SELECT_LOG = "SELECT login, heslo FROM \"Zakaznik\" where login = @login";



        public static Zakaznik SelectLogin(string login)
        {
            DatabaseClass db = new DatabaseClass();
            db.Connect();


            SqlCommand command = db.CreateCommand(SQL_SELECT_LOG);

            command.Parameters.AddWithValue("@login", login);
            SqlDataReader reader = db.Select(command);
            Zakaznik zak = new Zakaznik();
            while (reader.Read())
            {               
                int i = -1;
                zak.login = reader.GetString(++i);
                zak.heslo = reader.GetString(++i);
            }
            reader.Close();
            db.Close();


            return zak;
        }

        public static void ExecuteCarts(DatabaseClass pDb = null)
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
            SqlCommand command = db.CreateCommand(ExecCarts);
            db.ExecuteNonQuery(command);

        }

        public static Collection<Zakaznik> SelectLike(string param, DatabaseClass pDb = null)
        {
            DatabaseClass db = new DatabaseClass();
            db.Connect();


            SqlCommand command = db.CreateCommand(SQL_SELECT_LIKE);
            command.Parameters.AddWithValue("@param", param);
            SqlDataReader reader = db.Select(command);

            Collection<Zakaznik> zakaznici = Read(reader);
            reader.Close();

          
            db.Close();
            

            return zakaznici;
        }



        public static Zakaznik Select(int id)
        {
            DatabaseClass db = new DatabaseClass();
            db.Connect();
       

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = db.Select(command);

            Collection<Zakaznik> zakaznici = Read(reader);
            Zakaznik zakaznik = null;
            if (zakaznici.Count == 1)
            {
                zakaznik = zakaznici[0];
            }
            reader.Close();

             db.Close();
            

            return zakaznik;
        }

        public static Collection<Zakaznik> SelectAll(DatabaseClass pDb = null)
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

            Collection<Zakaznik> zakaznici = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zakaznici;
        }

        public static int Update(Zakaznik zakaznik)
        {
            DatabaseClass db = new DatabaseClass();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, zakaznik);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static int Insert(Zakaznik zakaznik, DatabaseClass pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_INSERT_WITH);
            PrepareCommand(command, zakaznik);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
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


        private static Collection<Zakaznik> Read(SqlDataReader reader)
        {
            Collection<Zakaznik> zakaznici = new Collection<Zakaznik>();

            while (reader.Read())
            {
                int i = -1;
                Zakaznik zakaznik = new Zakaznik();
                zakaznik.ID = reader.GetInt32(++i);
                zakaznik.meno = reader.GetString(++i);
                zakaznik.priezvisko = reader.GetString(++i);
                zakaznik.telefon = reader.GetString(++i);
                zakaznik.pristup = reader.GetInt32(++i);
                if (!reader.IsDBNull(++i))
                {
                    zakaznik.karta = reader.GetInt32(i);
                }

                zakaznici.Add(zakaznik);
            }
            return zakaznici;
        }

        private static void PrepareCommand(SqlCommand command, Zakaznik zakaznik)
        {
            command.Parameters.AddWithValue("@id", zakaznik.ID);
            command.Parameters.AddWithValue("@meno", zakaznik.meno);
            command.Parameters.AddWithValue("@priezvisko", zakaznik.priezvisko);
            command.Parameters.AddWithValue("@telefon", zakaznik.telefon);
            command.Parameters.AddWithValue("@pristup", zakaznik.pristup);
            command.Parameters.AddWithValue("@karta", zakaznik.karta == null ? DBNull.Value : (object)zakaznik.karta);
        }


    }
}
