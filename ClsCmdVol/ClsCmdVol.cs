using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Globalization;

namespace cmd.vol
{
    [Transaction(TransactionOption.Required), ObjectPooling(5, 10), EventTrackingEnabled(true)]
    public class ClsCmdVol : ServicedComponent
    {
        [AutoComplete]
        public SqlDataReader createClient(String nom, String prenom, String adresse, String ville, String cp, String tel, String pays)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand cmd = new SqlCommand("create_client", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NOM", SqlDbType.VarChar);
            cmd.Parameters["@NOM"].Value = nom;
            cmd.Parameters.Add("@NPREOM", SqlDbType.VarChar);
            cmd.Parameters["@PRENOM"].Value = prenom;
            cmd.Parameters.Add("@ADRESSE", SqlDbType.VarChar);
            cmd.Parameters["@ADRESSE"].Value = adresse;
            cmd.Parameters.Add("@VILLE", SqlDbType.VarChar);
            cmd.Parameters["@VILLE"].Value = ville;
            cmd.Parameters.Add("@CP", SqlDbType.VarChar);
            cmd.Parameters["@CP"].Value = cp;
            cmd.Parameters.Add("@TEL", SqlDbType.VarChar);
            cmd.Parameters["@TEL"].Value = tel;
            cmd.Parameters.Add("@PAYS", SqlDbType.VarChar);
            cmd.Parameters["@PAYS"].Value = pays;

            SqlDataReader reader = cmd.ExecuteReader();
            myConnection.Close();
            return reader;
        }

        [AutoComplete]
        public SqlDataReader getClient()
        {
            SqlConnection myConnection = openConnection();
            SqlCommand cmd = new SqlCommand("list_client", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();
            myConnection.Close();
            return reader;
        }

        [AutoComplete]
        public SqlDataReader getClientById(int clientId)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand cmd = new SqlCommand("liste_client_id", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int);
            cmd.Parameters["@ID"].Value = clientId;

            SqlDataReader reader = cmd.ExecuteReader();
            myConnection.Close();
            return reader;
        }

        [AutoComplete]
        public SqlDataReader createCmdVol(int idVol, int idClient, String dateAchat, int nombrePlaces, float montant)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand cmd = new SqlCommand("create_client", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID_VOL", SqlDbType.VarChar);
            cmd.Parameters["@ID_VOL"].Value = idVol;
            cmd.Parameters.Add("@ID_CLIENT", SqlDbType.VarChar);
            cmd.Parameters["@ID_CLIENT"].Value = idClient;
            cmd.Parameters.Add("@DATE_ACHAT", SqlDbType.DateTimeOffset);
            cmd.Parameters["@DATE_ACHAT"].Value = DateTimeOffset.Parse(dateAchat, CultureInfo.InvariantCulture); ;
            cmd.Parameters.Add("@NOMBàRE_PLACES", SqlDbType.Int);
            cmd.Parameters["@NOMBRE_PLACES"].Value = nombrePlaces;
            cmd.Parameters.Add("@MONTANT", SqlDbType.Float);
            cmd.Parameters["@MONTANT"].Value = montant;

            SqlDataReader reader = cmd.ExecuteReader();
            myConnection.Close();
            return reader;
        }

        [AutoComplete]
        public SqlDataReader getCmdVol()
        {
            SqlConnection myConnection = openConnection();
            SqlCommand cmd = new SqlCommand("liste_cmdvol", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();
            myConnection.Close();
            return reader;
        }

        [AutoComplete]
        public SqlDataReader getCmdVolByClient(int clientId)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand cmd = new SqlCommand("liste_cmdvol_client", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CLIENT_ID", SqlDbType.Int);
            cmd.Parameters["@CLIENT_ID"].Value = clientId;

            SqlDataReader reader = cmd.ExecuteReader();
            myConnection.Close();
            return reader;
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

