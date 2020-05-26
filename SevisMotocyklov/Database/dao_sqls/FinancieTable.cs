using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace SevisMotocyklov.Database.dao_sqls
{
    public class FinancieTable
    {

        public static String SQL_SELECT_SUM = "SELECT sum(nakupna_cena) FROM \"nahradny_diel\" where MONTH(datum_nakupu) = @datum";
        public static String SQL_SELECT_SALARY = "SELECT sum(pocet_hodin) * zamestnanec.cena_prace FROM \"oprava\"  join \"zamestnanec\" on oprava.Zamestnanec_ID = zamestnanec.ID where Zamestnanec_ID = @id and MONTH(datum) = DATEPART(m, DATEADD(m, -1, getdate())) and YEAR(datum) = YEAR(GETDATE()) group by zamestnanec.cena_prace";
        public static String SQL_FINANCES = "select  ( select sum(nakupna_cena) from nahradny_diel where month(datum_nakupu) = getdate()) as naklady,(select sum(pocet_hodin) * zamestnanec.cena_prace from oprava join zamestnanec on oprava.Zamestnanec_ID = zamestnanec.ID where month(datum) = getdate() group by cena_prace) as vydaje,( select sum(cena) as cena  from oprava where month(datum) = getdate() ) as prijmy";
        public static String SQL_INCOME = "select sum(oprava.cena)from oprava join objednavka on oprava.Objednavka_ID = objednavka.ID where month(objednavka.datum_uhradenia) = @datum and objednavka.uhradene = 1";
        // public static String SQL_NOT_PAID = "select distinct(objednavka.ID) from objednavka join oprava on objednavka.ID = oprava.Objednavka_ID where uhradene = 0";


        public static decimal selectSum(int mesiac, DatabaseClass pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_SUM);
            command.Parameters.AddWithValue("@datum", mesiac);
            SqlDataReader reader = db.Select(command);
            reader.Read();
            decimal pocet = reader.GetDecimal(0);

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return pocet;

        }

        public static int selectSalary(int id, DatabaseClass pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_SALARY);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = db.Select(command);
            reader.Read();
            int pocet = reader.GetInt32(0);

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return pocet;

        }

        public static Financie selectResults(DatabaseClass pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_FINANCES);
            SqlDataReader reader = db.Select(command);
            Financie financie = Read(reader);

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return financie;

        }

        public static int SelectIncome(int datum, DatabaseClass pDb = null)
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
            SqlCommand command = db.CreateCommand(SQL_INCOME);
            command.Parameters.AddWithValue("@datum", datum);
            SqlDataReader reader = db.Select(command);
            reader.Read();
            int pocet = reader.GetInt32(0);

            return pocet;
        }

        private static Financie Read(SqlDataReader reader)
        {
            Financie financie = new Financie();
            while (reader.Read())
            {
                int i = -1;
                if (!reader.IsDBNull(++i))
                {
                    financie.naklady = reader.GetInt32(++i);
                }
                if (!reader.IsDBNull(++i))
                {
                    financie.vydaje = reader.GetInt32(++i);
                }
                if (!reader.IsDBNull(++i))
                {
                    financie.prijmy = reader.GetInt32(++i);
                }

            }
            return financie;
        }





    }
}
