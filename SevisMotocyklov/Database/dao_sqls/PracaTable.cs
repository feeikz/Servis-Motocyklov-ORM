using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;
namespace SevisMotocyklov.Database.dao_sqls
{
    public class PracaTable
    {
        public static String SQL_SELECT = "SELECT * FROM \"Praca\"";
        public static String SQL_SELECT_ID = "SELECT * FROM \"Praca\" WHERE ID=@id";
        public static String SQL_SELECT_LIKE = "SELECT * FROM \"Praca\" WHERE nazov=@param";
        public static String SQL_INSERT = "INSERT INTO \"Praca\" VALUES (@nazov, @cena)";
        public static String SQL_DELETE_ID = "DELETE FROM \"Praca\" WHERE ID=@id";
        public static String SQL_UPDATE = "UPDATE Praca SET nazov=@nazov, cena=@cena WHERE ID=@id";


        public static Collection<Praca> SelectLike(string param)
        {
            DatabaseClass db = new DatabaseClass();
            db.Connect();


            SqlCommand command = db.CreateCommand(SQL_SELECT_LIKE);
            command.Parameters.AddWithValue("@param", param);
            SqlDataReader reader = db.Select(command);

            Collection<Praca> prace = Read(reader);
            reader.Close();

            db.Close();


            return prace;
        }

        public static Collection<Praca> SelectAll()
        {
            DatabaseClass db = new DatabaseClass();
            db.Connect();
  

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Praca> prace = Read(reader);
            reader.Close();
   
             db.Close();


            return prace;
        }

        public static Praca Select(int id, DatabaseClass pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = db.Select(command);

            Collection<Praca> prace = Read(reader);
            Praca praca = null;
            if (prace.Count == 1)
            {
                praca = prace[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return praca;
        }


        public static int Update(Praca praca)
        {
            DatabaseClass db = new DatabaseClass();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, praca);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static int Insert(Praca praca, DatabaseClass pDb = null)
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
            PrepareCommand(command, praca);
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


        private static Collection<Praca> Read(SqlDataReader reader)
        {
            Collection<Praca> prace = new Collection<Praca>();

            while (reader.Read())
            {
                int i = -1;
                Praca praca = new Praca();
                praca.ID = reader.GetInt32(++i);
                praca.nazov = reader.GetString(++i);
                praca.cena = reader.GetDecimal(++i);

                prace.Add(praca);
            }
            return prace;
        }

        private static void PrepareCommand(SqlCommand command, Praca praca)
        {
            command.Parameters.AddWithValue("@id", praca.ID);
            command.Parameters.AddWithValue("@nazov", praca.nazov);
            command.Parameters.AddWithValue("@cena", praca.cena);

        }
    }
}
