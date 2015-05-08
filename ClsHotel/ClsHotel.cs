using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;

namespace voyage.hotel
{
    [Transaction(TransactionOption.Required), ObjectPooling(5, 10), EventTrackingEnabled(true)]
    public class ClsHotel : ServicedComponent
    {
        [AutoComplete]
        public SqlDataReader liste_hotels_ville(char[] cp)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand MyCommand = new SqlCommand("liste_hotels_ville", myConnection);
            MyCommand.CommandType = CommandType.StoredProcedure;
            MyCommand.Parameters.Add("@codePostal", SqlDbType.VarChar);
            MyCommand.Parameters["@codePostal"].Value = cp;

            SqlDataReader reader = MyCommand.ExecuteReader();
            myConnection.Close();

            return reader;

        }

        [AutoComplete]
        public SqlDataReader chambres_hotel(int hotelId)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand MyCommand = new SqlCommand("liste_chambres_hotel", myConnection);
            MyCommand.CommandType = CommandType.StoredProcedure;
            MyCommand.Parameters.Add("@id", SqlDbType.Int);
            MyCommand.Parameters["@id"].Value = hotelId;

            SqlDataReader reader = MyCommand.ExecuteReader();
            myConnection.Close();

            return reader;
        }

        [AutoComplete]
        public SqlDataReader liste_villes()
        {
            SqlConnection myConnection = openConnection();
            SqlCommand MyCommand = new SqlCommand("liste_villes", myConnection);
            MyCommand.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = MyCommand.ExecuteReader();
            myConnection.Close();

            return reader;
        }

        private SqlConnection openConnection()
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = "Data Source=PC-PC\\SQLEXPRESS;Initial Catalog=HOTELS;Integrated Security=True";
            myConnection.Open();
            return myConnection;
        }
    }
}
