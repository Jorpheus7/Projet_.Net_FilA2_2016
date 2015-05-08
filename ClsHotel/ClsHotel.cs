using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;

namespace voyage.hotel
{
    [Transaction(TransactionOption.Required), ObjectPooling(5, 10), EventTrackingEnabled(true), ApplicationName("Voyage 2015")]
    public class ClsHotel : ServicedComponent
    {
        [AutoComplete]
        public void hotel_cp(char[] cp)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand MyCommand = new SqlCommand("hotel_cp", myConnection);
            MyCommand.CommandType = CommandType.StoredProcedure;
            MyCommand.Parameters.Add("@CP", SqlDbType.VarChar);
            MyCommand.Parameters["@CP"].Value = cp;

            myConnection.Close();
        }

        [AutoComplete]
        public void chambres_hotel(int hotelId)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand MyCommand = new SqlCommand("chambres_hotel", myConnection);
            MyCommand.CommandType = CommandType.StoredProcedure;
            MyCommand.Parameters.Add("@HOTEL", SqlDbType.Int);
            MyCommand.Parameters["@HOTEL"].Value = hotelId;

            myConnection.Close();
        }

        private SqlConnection openConnection()
        {
            SqlConnection myConnection = new SqlConnection();
            // TODO Set the right Data Source value
            myConnection.ConnectionString = "Data Source=Jorpheus-PC\\SQLEXPRESS;Initial Catalog=HOTELS;Integrated Security=True";
            myConnection.Open();
            return myConnection;
        }
    }
}
