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
    public class ClsCmdHotel : ServicedComponent
    {
        [AutoComplete]
        public SqlDataReader new_client(String nom, String prenom, String adresse, String ville, String cp, String tel, String pays)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand cmd = new SqlCommand("new_client", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nom", SqlDbType.NChar);
            cmd.Parameters["@nom"].Value = nom;
            cmd.Parameters.Add("@prenom", SqlDbType.NChar);
            cmd.Parameters["@prenom"].Value = prenom;
            cmd.Parameters.Add("@adresse", SqlDbType.VarChar);
            cmd.Parameters["@adresse"].Value = adresse;
            cmd.Parameters.Add("@ville", SqlDbType.NChar);
            cmd.Parameters["@ville"].Value = ville;
            cmd.Parameters.Add("@cp", SqlDbType.NChar);
            cmd.Parameters["@cp"].Value = cp;
            cmd.Parameters.Add("@tel", SqlDbType.VarChar);
            cmd.Parameters["@tel"].Value = tel;
            cmd.Parameters.Add("@pays", SqlDbType.NChar);
            cmd.Parameters["@pays"].Value = pays;
            
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        [AutoComplete]
        public SqlDataReader liste_clients()
        {
            SqlConnection myConnection = openConnection();
            SqlCommand cmd = new SqlCommand("liste_clients", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        [AutoComplete]
        public SqlDataReader liste_clients_nom_prenom(String nom, String prenom)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand cmd = new SqlCommand("liste_clients_nom_prenom", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nom", SqlDbType.Int);
            cmd.Parameters["@nom"].Value = nom;
            cmd.Parameters.Add("@prenom", SqlDbType.Int);
            cmd.Parameters["@prenom"].Value = nom;

            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        [AutoComplete]
        public SqlDataReader new_cmdhotel(int idChambre, int idClient, String dateAchat, int nombrePersonnes, float montant, String dateDebut, String dateFin)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand cmd = new SqlCommand("new_cmdhotel", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idChambre", SqlDbType.VarChar);
            cmd.Parameters["@idChambre"].Value = idChambre;
            cmd.Parameters.Add("@idClient", SqlDbType.VarChar);
            cmd.Parameters["@idClient"].Value = idClient;
            cmd.Parameters.Add("@dateAchat", SqlDbType.DateTimeOffset);
            cmd.Parameters["@dateAchat"].Value = DateTimeOffset.Parse(dateAchat, CultureInfo.InvariantCulture);
            cmd.Parameters.Add("@nbPersonne", SqlDbType.Int);
            cmd.Parameters["@nbPersonne"].Value = nombrePersonnes;
            cmd.Parameters.Add("@montant", SqlDbType.Float);
            cmd.Parameters["@montant"].Value = montant;
            cmd.Parameters.Add("@dateDepart", SqlDbType.DateTimeOffset);
            cmd.Parameters["@dateDepart"].Value = DateTimeOffset.Parse(dateDebut, CultureInfo.InvariantCulture);
            cmd.Parameters.Add("@dateFin", SqlDbType.DateTimeOffset);
            cmd.Parameters["@dateFin"].Value = DateTimeOffset.Parse(dateFin, CultureInfo.InvariantCulture);

            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        [AutoComplete]
        public SqlDataReader liste_cmdhotels()
        {
            SqlConnection myConnection = openConnection();
            SqlCommand cmd = new SqlCommand("liste_cmdhotels", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        [AutoComplete]
        public SqlDataReader liste_cmdhotels_client(int clientId)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand cmd = new SqlCommand("liste_cmdhotels_client", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idClient", SqlDbType.Int);
            cmd.Parameters["@idClient"].Value = clientId;

            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        [AutoComplete]
        public SqlDataReader client_nom_prenom(string nom, string prenom)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand cmd = new SqlCommand("liste_clients_nom_prenom", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nom", SqlDbType.Int);
            cmd.Parameters["@nom"].Value = nom;
            cmd.Parameters.Add("@prenom", SqlDbType.Int);
            cmd.Parameters["@prenom"].Value = prenom;


            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        private SqlConnection openConnection()
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = "Data Source=PC-PC\\SQLEXPRESS;Initial Catalog=CMDHOTELS;Integrated Security=True";
            myConnection.Open();
            return myConnection;
        }
    }
}

