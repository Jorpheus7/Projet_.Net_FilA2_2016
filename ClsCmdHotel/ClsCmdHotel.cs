using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Globalization;

namespace cmd.hotel
{
    [Transaction(TransactionOption.Required), ObjectPooling(5, 10), EventTrackingEnabled(true)]
    public class ClsCmdHotel
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
        public SqlDataReader createCmdHotel(int idChambre, int idClient, String dateAchat, int nombrePersonnes, float montant, String dateDebut, String dateFin)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand cmd = new SqlCommand("create_cdmhotel", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id_chambre", SqlDbType.VarChar);
            cmd.Parameters["@id_chambre"].Value = idChambre;
            cmd.Parameters.Add("@id_client", SqlDbType.VarChar);
            cmd.Parameters["@id_client"].Value = idClient;
            cmd.Parameters.Add("@date_achat", SqlDbType.DateTimeOffset);
            cmd.Parameters["@date_achat"].Value = DateTimeOffset.Parse(dateAchat, CultureInfo.InvariantCulture);
            cmd.Parameters.Add("@nombre_personnes", SqlDbType.Int);
            cmd.Parameters["@nombre_personnes"].Value = nombrePersonnes;
            cmd.Parameters.Add("@montant", SqlDbType.Float);
            cmd.Parameters["@montant"].Value = montant;
            cmd.Parameters.Add("@date_debut", SqlDbType.DateTimeOffset);
            cmd.Parameters["@date_debut"].Value = DateTimeOffset.Parse(dateDebut, CultureInfo.InvariantCulture);
            cmd.Parameters.Add("@date_fin", SqlDbType.DateTimeOffset);
            cmd.Parameters["@date_fin"].Value = DateTimeOffset.Parse(dateFin, CultureInfo.InvariantCulture);

            SqlDataReader reader = cmd.ExecuteReader();
            myConnection.Close();
            return reader;
        }

        [AutoComplete]
        public SqlDataReader getCmdHotel()
        {
            SqlConnection myConnection = openConnection();
            SqlCommand cmd = new SqlCommand("liste_cmdhotel", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();
            myConnection.Close();
            return reader;
        }

        [AutoComplete]
        public SqlDataReader getCmdHotelByClient(int clientId)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand cmd = new SqlCommand("liste_cmdhotel_client", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@client_id", SqlDbType.Int);
            cmd.Parameters["@client_id"].Value = clientId;

            SqlDataReader reader = cmd.ExecuteReader();
            myConnection.Close();
            return reader;
        }

        private SqlConnection openConnection()
        {
            SqlConnection myConnection = new SqlConnection();
            // TODO Set the right Data Source value
            myConnection.ConnectionString = "Data Source=Jorpheus-PC\\SQLEXPRESS;Initial Catalog=CMDHOTELS;Integrated Security=True";
            myConnection.Open();
            return myConnection;
        }
    }
}

