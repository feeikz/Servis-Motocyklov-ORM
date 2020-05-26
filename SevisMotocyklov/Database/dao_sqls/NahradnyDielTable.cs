using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;
namespace SevisMotocyklov.Database.dao_sqls
{
    class NahradnyDielTable
    {
        public static String SQL_SELECT = "SELECT * FROM \"nahradny_diel\"";
        public static String SQL_SELECT_ID = "SELECT * FROM \"nahradny_diel\" WHERE ID=@id";
        public static String SQL_INSERT = "INSERT INTO \"nahradny_diel\" VALUES (@nazov, @vyrobca, @datum_nakupu, @nakupna_cena, @predajna_cena, @Oprava_ID)";
        public static String SQL_INSERT2 = "INSERT INTO \"nahradny_diel\" (nazov, vyrobca, datum_nakupu, nakupna_cena, predajna_cena) VALUES (@nazov, @vyrobca, @datum_nakupu, @nakupna_cena, @predajna_cena)";
        public static String SQL_DELETE_ID = "DELETE FROM \"nahradny_diel\" WHERE ID=@id";
        public static String SQL_UPDATE = "UPDATE nahradny_diel SET nazov=@nazov, vyrobca=@vyrobca, datum_nakupu=@datum_nakupu, nakupna_cena=@nakupna_cena,predajna_cena=@predajna_cena, Oprava_ID=@Oprava_ID WHERE ID=@ID";

        public static Nahradny_diel Select(int id, DatabaseClass pDb = null)
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

            Collection<Nahradny_diel> nahradny_diely = Read(reader);
            Nahradny_diel nahradny_diel = null;
            if (nahradny_diely.Count == 1)
            {
                nahradny_diel = nahradny_diely[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return nahradny_diel;
        }

        public static Collection<Nahradny_diel> SelectAll(DatabaseClass pDb = null)
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

            Collection<Nahradny_diel> nahradne_diely = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return nahradne_diely;
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

        public static int Update(Nahradny_diel nahradny_diel)
        {
            DatabaseClass db = new DatabaseClass();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, nahradny_diel);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static int Insert(Nahradny_diel nahradny_diel, DatabaseClass pDb = null)
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
            PrepareCommand(command, nahradny_diel);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        private static void PrepareCommand(SqlCommand command, Nahradny_diel nahradny_diel)
        {
            command.Parameters.AddWithValue("@id", nahradny_diel.ID);
            command.Parameters.AddWithValue("@nazov", nahradny_diel.nazov);
            command.Parameters.AddWithValue("@vyrobca", nahradny_diel.vyrobca);
            command.Parameters.AddWithValue("@datum_nakupu", nahradny_diel.datum_nakupu);
            command.Parameters.AddWithValue("@nakupna_cena", nahradny_diel.nakupna_cena);
            command.Parameters.AddWithValue("@predajna_cena", nahradny_diel.predajna_cena);
            if (nahradny_diel.OpravaID != null)
                command.Parameters.AddWithValue("@Oprava_ID", nahradny_diel.OpravaID);
        }

        private static Collection<Nahradny_diel> Read(SqlDataReader reader)
        {
            Collection<Nahradny_diel> nahradny_diely = new Collection<Nahradny_diel>();

            while (reader.Read())
            {
                int i = -1;
                Nahradny_diel nahradny_diel = new Nahradny_diel();
                nahradny_diel.ID = reader.GetInt32(++i);
                nahradny_diel.nazov = reader.GetString(++i);
                nahradny_diel.vyrobca = reader.GetString(++i);
                nahradny_diel.datum_nakupu = reader.GetDateTime(++i);
                nahradny_diel.nakupna_cena = reader.GetDecimal(++i);
                nahradny_diel.predajna_cena = reader.GetDecimal(++i);
                if (!reader.IsDBNull(++i))
                {
                    nahradny_diel.OpravaID = reader.GetInt32(i);
                }

                nahradny_diely.Add(nahradny_diel);
            }
            return nahradny_diely;
        }
    }
}
