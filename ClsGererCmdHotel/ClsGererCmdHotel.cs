using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cmd.hotel;
using System.Data.SqlClient;

namespace voyage.cmdHotel
{
    public class ClsGererCmdHotel
    {

        public Client new_client(string nom, string prenom, string adresse, string ville, string cp, string tel, string pays)
        {
            ClsCmdHotel myCmdHotel = new ClsCmdHotel();
            SqlDataReader reader = myCmdHotel.new_client(nom, prenom, adresse, ville, cp, tel, pays);
            return recuperationListClient(reader).First();
        }

        public CmdHotel new_cmdhotel_existing_client(int idChambre, int idClient, String dateAchat, int nombrePersonnes, float montant, string dateDebut, string dateFin)
        {
            ClsCmdHotel myCmdHotel = new ClsCmdHotel();
            SqlDataReader reader = myCmdHotel.new_cmdhotel(idChambre, idClient, dateAchat, nombrePersonnes, montant, dateDebut, dateFin);
            return recuperationListCmdHotel(reader).First();
        }

        public CmdHotel new_cmdHotel_new_client(int idChambre, String dateAchat, int nombrePlaces, float montant, string dateDebut, string dateFin, string nomClient, string prenomClient, string adresseClient, string villeClient, string cpClient, string telClient, string paysClient)
        {
            ClsCmdHotel myCmdHotel = new ClsCmdHotel();
            Client newClient = new_client(nomClient, prenomClient, adresseClient, villeClient, cpClient, telClient, paysClient);
            return new_cmdhotel_existing_client(idChambre, newClient.id, dateAchat, nombrePlaces, montant, dateDebut, dateFin);
        }

        public List<Client> liste_clients()
        {
            ClsCmdHotel myCmdHotel = new ClsCmdHotel();
            SqlDataReader reader = myCmdHotel.liste_clients();
            return recuperationListClient(reader);
        }


        public List<CmdHotel> liste_cmdhotels()
        {
            ClsCmdHotel myCmdHotel = new ClsCmdHotel();
            SqlDataReader reader = myCmdHotel.liste_cmdhotels();
            return recuperationListCmdHotel(reader);
        }

        public List<CmdHotel> liste_cmdhotels_clientId(int id)
        {
            ClsCmdHotel myCmdHotel = new ClsCmdHotel();
            SqlDataReader reader = myCmdHotel.liste_cmdhotels_client(id);
            return recuperationListCmdHotel(reader);
        }

        public Client client_nom_prenom(string nom, string prenom)
        {
            ClsCmdHotel myCmdHotel = new ClsCmdHotel();
            SqlDataReader reader = myCmdHotel.client_nom_prenom( nom,  prenom);
            
            Client c = new Client();
            if (reader.Read())
            {
                Object[] values = new Object[reader.FieldCount];
                reader.GetValues(values);
                c.id = Convert.ToInt16(values[0]);
                c.nom = values[1].ToString();
                c.prenom = values[2].ToString();
                c.adresse = values[3].ToString();
                c.ville = values[4].ToString();
                c.cp = values[5].ToString();
                c.tel = values[6].ToString();
                c.pays = values[7].ToString();
            }
            return c;
            
        }


        public List<Client> recuperationListClient(SqlDataReader reader)
        {
            List<Client> liste = new List<Client>();

            while (reader.Read())
            {
                Object[] values = new Object[reader.FieldCount];
                reader.GetValues(values);
                Client c = new Client();

                c.id = Convert.ToInt16(values[0]);
                c.nom = values[1].ToString();
                c.prenom = values[2].ToString();
                c.adresse = values[3].ToString();
                c.ville = values[4].ToString();
                c.cp = values[5].ToString();
                c.tel = values[6].ToString();
                c.pays = values[7].ToString();
                liste.Add(c);
            }
            return liste;
        }

        public List<CmdHotel> recuperationListCmdHotel(SqlDataReader reader)
        {
            List<CmdHotel> liste = new List<CmdHotel>();

            while (reader.Read())
            {
                Object[] values = new Object[reader.FieldCount];
                reader.GetValues(values);
                CmdHotel c = new CmdHotel();

                c.id = Convert.ToInt16(values[0]);
                c.idHotel = Convert.ToInt16(values[1]);
                c.idClient = Convert.ToInt16(values[2]);
                c.dateAchat = DateTimeOffset.Parse(values[3].ToString());
                c.nbPersonnes = Convert.ToInt16(values[4]);
                c.montant = float.Parse(values[5].ToString());
                c.dateDebut = DateTimeOffset.Parse(values[6].ToString());
                c.dateFin = DateTimeOffset.Parse(values[7].ToString());
                liste.Add(c);
            }
            return liste;
        }
    }


    public class Client
    {
        public int id;
        public string nom;
        public string prenom;
        public string adresse;
        public string ville;
        public string cp;
        public string tel;
        public string pays;
    }

    public class CmdHotel
    {
        public int id;
        public int idHotel;
        public int idClient;
        public DateTimeOffset dateAchat;
        public int nbPersonnes;
        public float montant;
        public DateTimeOffset dateDebut;
        public DateTimeOffset dateFin;
    }
}
