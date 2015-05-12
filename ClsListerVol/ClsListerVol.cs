using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using voyage.vol;
using System.Data.SqlClient;
using System.Globalization;

namespace voyage.listerVol
{
  
    public class ClsListerVol
    {
        public List<vol> liste_vols_aeroport(string ad)
        {
            ClsVol myVol = new ClsVol();
            SqlDataReader reader = myVol.liste_vols_aeroport(ad.ToCharArray());
            return recuperationListVol(reader);
        }
        public List<vol> liste_vols_aeroport_aeroport(string ad, string aa)
        {
            ClsVol myVol = new ClsVol();
            SqlDataReader reader = myVol.liste_vols_aeroport_aeroport(ad.ToCharArray(), aa.ToCharArray());
            return recuperationListVol(reader);
        }
         public List<vol> liste_vols_date_aeroport(string ad, string d)
        {
            ClsVol myVol = new ClsVol();
            SqlDataReader reader = myVol.liste_vols_date_aeroport(ad.ToCharArray(), DateTimeOffset.Parse(d));
            return recuperationListVol(reader);
        }
         public List<vol> liste_vols_aeroport_aeroport_date(string ad, string aa, string d)
        {
            ClsVol myVol = new ClsVol();
            SqlDataReader reader = myVol.liste_vols_aeroport_aeroport_date(ad.ToCharArray(),aa.ToCharArray(),DateTimeOffset.Parse(d));
            return recuperationListVol(reader);
        }

         public vol vol_id(int id)
         {
             ClsVol myVol = new ClsVol();
             SqlDataReader reader = myVol.vol_id(id);
             vol v = new vol();
             if (reader.Read())
             {
                 Object[] values = new Object[reader.FieldCount];
                 reader.GetValues(values);
                 

                 v.id = Convert.ToInt16(values[0]);
                 v.aeroportDepart = values[1].ToString();
                 v.aeroportArrive = values[2].ToString();
                 v.dateDepart = values[3].ToString();
                 v.duree = values[4].ToString();
                 v.compagnie = values[5].ToString();
                 v.prix = Single.Parse(values[6].ToString());
                 v.capacite = Convert.ToInt16(values[7]);

                 return v;
             }
             return null;
         }

        public List <aeroport> liste_aeroports()
        {
            ClsVol myVol = new ClsVol();
            SqlDataReader reader = myVol.liste_aeroports();
            List<aeroport> liste = new List<aeroport>();

            while (reader.Read())
            {
                Object[] values = new Object[reader.FieldCount];
                reader.GetValues(values);
                aeroport a = new aeroport();

                a.code = values[0].ToString();
                a.ville = values[1].ToString();
                a.pays = values[2].ToString();
                liste.Add(a);
            }
            return liste;
        }
        public List<vol> recuperationListVol(SqlDataReader reader)
        {
            List<vol> liste = new List<vol>();

            while (reader.Read())
            {
                Object[] values = new Object[reader.FieldCount];
                reader.GetValues(values);
                vol v = new vol();

                v.id = Convert.ToInt16(values[0]);
                v.aeroportDepart = values[1].ToString();
                v.aeroportArrive = values[2].ToString();
                v.dateDepart = values[3].ToString();
                v.duree = values[4].ToString();
                v.compagnie = values[5].ToString();
                v.prix = Single.Parse(values[6].ToString());
                v.capacite = Convert.ToInt16(values[7]);
                liste.Add(v);
            }
            return liste;
        }
    }


    public class aeroport 
    {
        public string code;
        public string ville;
        public string pays;
    }

    public class vol
    {
        public int id;
        public string aeroportDepart;
        public string aeroportArrive;
        public string dateDepart;
        public string duree;
        public string compagnie;
        public float prix;
        public int capacite;
    }
}
