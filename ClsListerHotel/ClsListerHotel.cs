using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using voyage.hotel;
using System.Data.SqlClient;

namespace voyage.listerhotel
{
    public class ClsListerHotel 
    {

        public List<Hotel> liste_hotels_ville(char[] cp)
        {
            ClsHotel myHotel = new ClsHotel();
            SqlDataReader reader = myHotel.liste_hotels_ville(cp);
            return recuperationListHotel(reader);
        }

        public List<Chambre> liste_chambres_hotels(int hotelId)
        {
            ClsHotel myHotel = new ClsHotel();
            SqlDataReader reader = myHotel.chambres_hotel(hotelId);
            return recuperationListChambre(reader);
        }

        public List<string[]> liste_villes()
        {
            ClsHotel myHotel = new ClsHotel();
            SqlDataReader reader = myHotel.liste_villes();
            return recuperationListVilles(reader);
        }


        public List<Hotel> recuperationListHotel(SqlDataReader reader)
        {
            List<Hotel> liste = new List<Hotel>();

            while (reader.Read())
            {
                Object[] values = new Object[reader.FieldCount];
                reader.GetValues(values);
                Hotel v = new Hotel();

                v.id = Convert.ToInt16(values[0]);
                v.nomHotel = values[1].ToString();
                v.adresse = values[2].ToString();
                v.ville = values[3].ToString();
                v.cp = values[4].ToString();
                v.tel = values[5].ToString();
                v.pays = values[6].ToString();
                liste.Add(v);
            }
            return liste;
        }

        public List<Chambre> recuperationListChambre(SqlDataReader reader)
        {
            List<Chambre> liste = new List<Chambre>();

            while (reader.Read())
            {
                Object[] values = new Object[reader.FieldCount];
                reader.GetValues(values);
                Chambre c = new Chambre();

                c.id = Convert.ToInt16(values[0]);
                c.hotelId = Convert.ToInt16(values[1]);
                c.capacite = Convert.ToInt16(values[2]);
                c.prix = float.Parse(values[3].ToString());
                c.numero = Convert.ToInt16(values[4]);
                liste.Add(c);
            }
            return liste;
        }

        public List<string[]> recuperationListVilles(SqlDataReader reader)
        {
            List<string[]> liste = new List<string[]>();
            while (reader.Read())
            {
                Object[] values = new Object[reader.FieldCount];
                reader.GetValues(values);
                string[] v = new string[3];
                v[0] = values[0].ToString();
                v[1] = values[1].ToString();
                v[2] = values[2].ToString();
                liste.Add(v);
            }
            return liste;
        }

    }


    public class Chambre 
    {
        public int id;
        public int hotelId;
        public int capacite;
        public float prix;
        public int numero;
    }

    public class Hotel 
    {
        public int id;
        public string nomHotel;
        public string adresse;
        public string ville;
        public string cp;
        public string tel;
        public string pays;
    }


}
