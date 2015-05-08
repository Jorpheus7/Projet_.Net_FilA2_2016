using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using voyage.listerVol;


[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
// [System.Web.Script.Services.ScriptService]

public class WSVol : System.Web.Services.WebService
{
    public WSVol () {

        //Supprimez les marques de commentaire dans la ligne suivante si vous utilisez des composants conçus 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<vol> Liste_Vols(string ad, string aa, string d) {
        List<vol> liste = new List<vol>();
        ClsListerVol myVol = new ClsListerVol();

        if (!ad.Equals(null) && !ad.Equals(" "))
        {
            if (!aa.Equals(null) && !ad.Equals(" "))
            {
                if (!d.Equals(null) && !d.Equals(" "))
                {
                    liste=myVol.liste_vols_aeroport_aeroport_date(ad,aa,d);
                }
                else
                {
                    liste=myVol.liste_vols_aeroport_aeroport(ad, aa);
                }
            }
            else
            {
                liste=myVol.liste_vols_aeroport(ad);
                if (!d.Equals(null) && !d.Equals(" "))
                {
                    liste=myVol.liste_vols_date_aeroport(ad, d);
                }
            }
        }

        return liste;    
    }

    public List<aeroport> Liste_Aeroports()
    {
        ClsListerVol myVol = new ClsListerVol();
        return myVol.liste_aeroports();
    }
    
}