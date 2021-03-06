﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cmd.vol;
using System.Data.SqlClient;

namespace voyage.cmdVol
{
    public class ClsGererCmdVol
    {

        public Client new_client(string nom, string prenom, string adresse, string ville, string cp, string tel, string pays)
        {
            ClsCmdVol myCmdVol = new ClsCmdVol();
            SqlDataReader reader = myCmdVol.new_client(nom, prenom, adresse, ville, cp, tel, pays);
            return recuperationListClient(reader).First();
        }

        public CmdVol new_cmdvol_existing_client(int idVol, int idClient, String dateAchat, int nombrePlaces, float montant)
        {
            ClsCmdVol myCmdVol = new ClsCmdVol();
            SqlDataReader reader = myCmdVol.new_cmdvol(idVol, idClient, dateAchat, nombrePlaces, montant);
            return recuperationListCmdVol(reader).First();
        }

        public CmdVol new_cmdvol_new_client(int idVol, String dateAchat, int nombrePlaces, float montant, string nomClient, string prenomClient, string adresseClient, string villeClient, string cpClient, string telClient, string paysClient)
        {
            ClsCmdVol myCmdVol = new ClsCmdVol();
            Client newClient = new_client(nomClient, prenomClient, adresseClient, villeClient, cpClient, telClient, paysClient);
            SqlDataReader reader = myCmdVol.new_cmdvol(idVol, newClient.id, dateAchat, nombrePlaces, montant);
            return recuperationListCmdVol(reader).First();
        }

        public List<Client> liste_clients()
        {
            ClsCmdVol myCmdVol = new ClsCmdVol();
            SqlDataReader reader = myCmdVol.liste_clients();
            return recuperationListClient(reader);
        }

        public List<Client> liste_clients_nom_prenom(string nom, string prenom)
        {
            ClsCmdVol myCmdVol = new ClsCmdVol();
            SqlDataReader reader = myCmdVol.liste_clients_nom_prenom(nom, prenom);
            return recuperationListClient(reader);
        }

        public List<CmdVol> liste_cmd()
        {
            ClsCmdVol myCmdVol = new ClsCmdVol();
            SqlDataReader reader = myCmdVol.liste_cmdvol();
            return recuperationListCmdVol(reader);
        }

        public List<CmdVol> liste_cmdvol_clientId(int id)
        {
            ClsCmdVol myCmdVol = new ClsCmdVol();
            SqlDataReader reader = myCmdVol.liste_cmdvol_client(id);
            return recuperationListCmdVol(reader);
        }

        public Client client_nom_prenom(string nom, string prenom)
        {
            ClsCmdVol myCmdVol = new ClsCmdVol();
            SqlDataReader reader = myCmdVol.client_nom_prenom(nom,prenom);
            
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

        public List<CmdVol> recuperationListCmdVol(SqlDataReader reader)
        {
            List<CmdVol> liste = new List<CmdVol>();

            while (reader.Read())
            {
                Object[] values = new Object[reader.FieldCount];
                reader.GetValues(values);
                CmdVol c = new CmdVol();

                c.id = Convert.ToInt16(values[0]);
                c.idVol = Convert.ToInt16(values[1]);
                c.idClient = Convert.ToInt16(values[2]);
                c.dateAchat = DateTimeOffset.Parse(values[3].ToString()); ;
                c.nbPlaces = Convert.ToInt16(values[4]);
                c.montant = float.Parse(values[5].ToString());
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

    public class CmdVol 
    {
        public int id;
        public int idVol;
        public int idClient;
        public DateTimeOffset dateAchat;
        public int nbPlaces;
        public float montant;
    }
}
