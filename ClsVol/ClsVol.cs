using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;

namespace voyage.vol
{
    [Transaction(TransactionOption.Required), ObjectPooling(5, 10), EventTrackingEnabled(true)]
    public class ClsVol : ServicedComponent
    {

        [AutoComplete]
        public SqlDataReader liste_vols_aeroport(char[] ad)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand MyCommand = new SqlCommand("vol_ad", myConnection);
            MyCommand.CommandType = CommandType.StoredProcedure;
            MyCommand.Parameters.Add("@aeroport", SqlDbType.Char);
            MyCommand.Parameters["@aeroport"].Value = ad;

            SqlDataReader reader = MyCommand.ExecuteReader();
            myConnection.Close();

            return reader;
        }

        [AutoComplete]
        public SqlDataReader liste_vols_aeroport_aeroport(char[] ad, char[] aa)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand MyCommand = new SqlCommand("liste_vols_aeroport_aeroport", myConnection);
            MyCommand.CommandType = CommandType.StoredProcedure;
            MyCommand.Parameters.Add("@aeroportD", SqlDbType.Char);
            MyCommand.Parameters["@aeroportD"].Value = ad;
            MyCommand.Parameters.Add("@aeroportA", SqlDbType.Char);
            MyCommand.Parameters["@aeroportA"].Value = aa;

            SqlDataReader reader = MyCommand.ExecuteReader();
            myConnection.Close();

            return reader;
        }

        [AutoComplete]
        public SqlDataReader liste_vols_date_aeroport(char[] ad, DateTimeOffset d)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand MyCommand = new SqlCommand("liste_vols_date_aeroport", myConnection);
            MyCommand.CommandType = CommandType.StoredProcedure;
            MyCommand.Parameters.Add("@aeroport", SqlDbType.Char);
            MyCommand.Parameters["@aeroport"].Value = ad;
            MyCommand.Parameters.Add("@date", SqlDbType.DateTimeOffset);
            MyCommand.Parameters["@date"].Value = d;

            SqlDataReader reader = MyCommand.ExecuteReader();
            myConnection.Close();

            return reader;
        }

        [AutoComplete]
        public SqlDataReader liste_vols_aeroport_aeroport_date(char[] ad, char[] aa, DateTimeOffset d)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand MyCommand = new SqlCommand("liste_vols_aeroport_aeroport_date", myConnection);
            MyCommand.CommandType = CommandType.StoredProcedure;
            MyCommand.Parameters.Add("@aeroportD", SqlDbType.Char);
            MyCommand.Parameters["@aeroportD"].Value = ad;
            MyCommand.Parameters.Add("@aeroportA", SqlDbType.Char);
            MyCommand.Parameters["@aeroportA"].Value = aa;
            MyCommand.Parameters.Add("@date", SqlDbType.DateTimeOffset);
            MyCommand.Parameters["@date"].Value = d;

            SqlDataReader reader = MyCommand.ExecuteReader();
            myConnection.Close();

            return reader;
        }

        [AutoComplete]
        public SqlDataReader liste_aeroports()
        {
            SqlConnection myConnection = openConnection();
            SqlCommand MyCommand = new SqlCommand("liste_aeroports", myConnection);
            MyCommand.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = MyCommand.ExecuteReader();
            myConnection.Close();

            return reader;
        }

        private SqlConnection openConnection()
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = "Data Source=PC-PC\\SQLEXPRESS;Initial Catalog=CMDVOLS;Integrated Security=True";
            myConnection.Open();
            return myConnection;
        }
    }
}
