using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.EnterpriseServices;
using System.Data.SqlClient;
using voyage.vol;

namespace ClsListeVol
{
    [Transaction(TransactionOption.Required), ObjectPooling(5, 10), EventTrackingEnabled(true)]

    public class ClsListeVol : ServicedComponent
    {
        [AutoComplete]
        public void Liste_vol_aeroport(char[] ad)
        {
            ClsVol myClsVol = new ClsVol();
            SqlDataReader reader = myClsVol.vol_ad(ad);
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

                liste.Add(h);
            }
        
        }
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
