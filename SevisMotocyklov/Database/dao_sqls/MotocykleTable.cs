using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace SevisMotocyklov.Database.dao_sqls
{
    class MotocykelTable
    {
        public static String SQL_SELECT = "SELECT * FROM \"Motocykel\"";
        public static String SQL_SELECT_ID = "SELECT * FROM \"Motocykel\" WHERE ID=@id";
        public static String SQL_SELECT_LIKE = "SELECT * FROM \"Motocykel\" WHERE vyrobca like @param";


        public static Collection<Motocykel> SelectLike(string param)
        {
            DatabaseClass db = new DatabaseClass();
            db.Connect();


            SqlCommand command = db.CreateCommand(SQL_SELECT_LIKE);
            command.Parameters.AddWithValue("@param", param);
            SqlDataReader reader = db.Select(command);

            Collection<Motocykel> motocykle = Read(reader);
            reader.Close();


            db.Close();


            return motocykle;
        }


        public static Collection<Motocykel> SelectAll(DatabaseClass pDb = null)
        {
            DatabaseClass db = new DatabaseClass();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Motocykel> motocykle = Read(reader);
            reader.Close();

      
             db.Close();
            

            return motocykle;
        }

        public static Motocykel Select(int id, DatabaseClass pDb = null)
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

            Collection<Motocykel> motocykle = Read(reader);
            Motocykel motocykel = null;
            if (motocykle.Count == 1)
            {
                motocykel = motocykle[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return motocykel;
        }


        private static Collection<Motocykel> Read(SqlDataReader reader)
        {
            Collection<Motocykel> motocykle = new Collection<Motocykel>();

            while (reader.Read())
            {
                int i = -1;
                Motocykel motocykel = new Motocykel();
                motocykel.ID = reader.GetInt32(++i);
                motocykel.vyrobca = reader.GetString(++i);
                motocykel.model = reader.GetString(++i);
                motocykel.typ = reader.GetString(++i);
                motocykel.obsah_valca = reader.GetInt32(++i);
                motocykel.rok_vyroby = reader.GetInt32(++i);
                Console.WriteLine("som tu");

                motocykle.Add(motocykel);
            }
            return motocykle;
        }

    }
}
