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
        public SqlDataReader new_client(String nom, String prenom, String adresse, String ville, String cp, String tel, String pays)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand cmd = new SqlCommand("new_client", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nom", SqlDbType.VarChar);
            cmd.Parameters["@nom"].Value = nom;
            cmd.Parameters.Add("@prenom", SqlDbType.VarChar);
            cmd.Parameters["@prenom"].Value = prenom;
            cmd.Parameters.Add("@adresse", SqlDbType.VarChar);
            cmd.Parameters["@adresse"].Value = adresse;
            cmd.Parameters.Add("@ville", SqlDbType.VarChar);
            cmd.Parameters["@ville"].Value = ville;
            cmd.Parameters.Add("@cp", SqlDbType.VarChar);
            cmd.Parameters["@cp"].Value = cp;
            cmd.Parameters.Add("@tel", SqlDbType.VarChar);
            cmd.Parameters["@tel"].Value = tel;
            cmd.Parameters.Add("@pays", SqlDbType.VarChar);
            cmd.Parameters["@pays"].Value = pays;

            SqlDataReader reader = cmd.ExecuteReader();
            myConnection.Close();
            return reader;
        }

        [AutoComplete]
        public SqlDataReader liste_clients()
        {
            SqlConnection myConnection = openConnection();
            SqlCommand cmd = new SqlCommand("liste_clients", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();
            myConnection.Close();
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
            cmd.Parameters["@prenom"].Value = prenom;

            SqlDataReader reader = cmd.ExecuteReader();
            myConnection.Close();
            return reader;
        }

        [AutoComplete]
        public SqlDataReader new_cmdvol(int idVol, int idClient, String dateAchat, int nombrePlaces, float montant)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand cmd = new SqlCommand("new_cmdvol", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idVol", SqlDbType.VarChar);
            cmd.Parameters["@idVol"].Value = idVol;
            cmd.Parameters.Add("@idClient", SqlDbType.VarChar);
            cmd.Parameters["@idClient"].Value = idClient;
            cmd.Parameters.Add("@dateAchat", SqlDbType.DateTimeOffset);
            cmd.Parameters["@dateAchat"].Value = DateTimeOffset.Parse(dateAchat, CultureInfo.InvariantCulture); ;
            cmd.Parameters.Add("@nbPlace", SqlDbType.Int);
            cmd.Parameters["@nbPlace"].Value = nombrePlaces;
            cmd.Parameters.Add("@montant", SqlDbType.Float);
            cmd.Parameters["@montant"].Value = montant;

            SqlDataReader reader = cmd.ExecuteReader();
            myConnection.Close();
            return reader;
        }

        [AutoComplete]
        public SqlDataReader liste_cmdvol()
        {
            SqlConnection myConnection = openConnection();
            SqlCommand cmd = new SqlCommand("liste_cmdvol", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            SqlDataReader reader = cmd.ExecuteReader();
            myConnection.Close();
            return reader;
        }

        [AutoComplete]
        public SqlDataReader liste_cmdvol_client(String nom, String prenom)
        {
            SqlConnection myConnection = openConnection();
            SqlCommand cmd = new SqlCommand("liste_cmdvol_client", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nom", SqlDbType.Int);
            cmd.Parameters["@nom"].Value = nom;
            cmd.Parameters.Add("@prenom", SqlDbType.Int);
            cmd.Parameters["@prenom"].Value = prenom;

            SqlDataReader reader = cmd.ExecuteReader();
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

