using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;

namespace voyage.vol
{
    [Transaction(TransactionOption.Required), ObjectPooling(5, 10), EventTrackingEnabled(true), ApplicationName("Voyage 2015")]
    public class ClsVol : ServicedComponent
    {

        [AutoComplete]
        public void vol_ad(char[] ad)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand MyCommand = new SqlCommand("vol_ad", myConnection);
            MyCommand.CommandType = CommandType.StoredProcedure;
            MyCommand.Parameters.Add("@AD", SqlDbType.Char);
            MyCommand.Parameters["@AD"].Value = ad;

            myConnection.Close();
        }

        [AutoComplete]
        public void vol_ad_aa(char[] ad, char[] aa)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand MyCommand = new SqlCommand("vol_ad_aa", myConnection);
            MyCommand.CommandType = CommandType.StoredProcedure;
            MyCommand.Parameters.Add("@AD", SqlDbType.Char);
            MyCommand.Parameters["@AD"].Value = ad;
            MyCommand.Parameters.Add("@AA", SqlDbType.Char);
            MyCommand.Parameters["@AA"].Value = aa;

            myConnection.Close();
        }

        [AutoComplete]
        public void vol_ad_d(char[] ad, DateTimeOffset d)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand MyCommand = new SqlCommand("vol_ad_d", myConnection);
            MyCommand.CommandType = CommandType.StoredProcedure;
            MyCommand.Parameters.Add("@AD", SqlDbType.Char);
            MyCommand.Parameters["@AD"].Value = ad;
            MyCommand.Parameters.Add("@D", SqlDbType.DateTimeOffset);
            MyCommand.Parameters["@D"].Value = d;

            myConnection.Close();
        }

        [AutoComplete]
        public void vol_ad_aa_d(char[] ad, char[] aa, DateTimeOffset d)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand MyCommand = new SqlCommand("vol_ad_aa_d", myConnection);
            MyCommand.CommandType = CommandType.StoredProcedure;
            MyCommand.Parameters.Add("@AD", SqlDbType.Char);
            MyCommand.Parameters["@AD"].Value = ad;
            MyCommand.Parameters.Add("@AA", SqlDbType.Char);
            MyCommand.Parameters["@AA"].Value = aa;
            MyCommand.Parameters.Add("@D", SqlDbType.DateTimeOffset);
            MyCommand.Parameters["@D"].Value = d;

            myConnection.Close();
        }

        [AutoComplete]
        public void aeroport()
        {
            SqlConnection myConnection = openConnection();
            SqlCommand MyCommand = new SqlCommand("aeroport", myConnection);
            MyCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Close();
        }

        private SqlConnection openConnection()
        {
            SqlConnection myConnection = new SqlConnection();
            // TODO Set the right Data Source value
            myConnection.ConnectionString = "Data Source=Jorpheus-PC\\SQLEXPRESS;Initial Catalog=VOLS;Integrated Security=True";
            myConnection.Open();
            return myConnection;
        }
    }
}
