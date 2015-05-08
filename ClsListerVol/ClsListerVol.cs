using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using voyage.vol;
using System.EnterpriseServices;
using System.Data.SqlClient;

namespace voyage.listerVol
{
    [Transaction(TransactionOption.Required), ObjectPooling(5, 10), EventTrackingEnabled(true)]
    public class ClsListerVol: ServicedComponent
    {
        [AutoComplete]
        public List<vol> liste_vols_aeroport(char[] ad)
        {
            ClsVol myVol = new ClsVol();
            SqlDataReader reader = myVol.liste_vols_aeroport(ad);
            return recuperationListVol(reader);
        }
         [AutoComplete]
        public List<vol> liste_vols_aeroport_aeroport(char[] ad, char[] aa)
        {
            ClsVol myVol = new ClsVol();
            SqlDataReader reader = myVol.liste_vols_aeroport_aeroport(ad,aa);
            return recuperationListVol(reader);
        }
         [AutoComplete]
        public List<vol> liste_vols_date_aeroport(char[] ad, DateTimeOffset d)
        {
            ClsVol myVol = new ClsVol();
            SqlDataReader reader = myVol.liste_vols_date_aeroport(ad,d);
            return recuperationListVol(reader);
        }
         [AutoComplete]
        public List<vol> liste_vols_aeroport_aeroport_date(char[] ad, char[] aa, DateTimeOffset d)
        {
            ClsVol myVol = new ClsVol();
            SqlDataReader reader = myVol.liste_vols_aeroport_aeroport_date(ad,aa, d);
            return recuperationListVol(reader);
        }
         [AutoComplete]
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
        [AutoComplete]
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
                v.dateDepart = Convert.ToDateTime(values[3]);
                v.duree = values[4].ToString();
                v.compagnie = values[5].ToString();
                v.capacite = Convert.ToInt16(values[6]);
                liste.Add(v);
            }
            return liste;
        }
    }


    public class aeroport : ServicedComponent
    {
        public string code;
        public string ville;
        public string pays;
    }

    public class vol : ServicedComponent
    {
        public int id;
        public string aeroportDepart;
        public string aeroportArrive;
        public DateTimeOffset dateDepart;
        public string duree;
        public string compagnie;
        public float prix;
        public int capacite;
    }
}
