using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using voyage.listerhotel;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
// [System.Web.Script.Services.ScriptService]

public class WSHotel : System.Web.Services.WebService
{
    public WSHotel () {

        //Supprimez les marques de commentaire dans la ligne suivante si vous utilisez des composants conçus 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<string[]> liste_villes()
    {
        ClsListerHotel myCls = new ClsListerHotel();
        return myCls.liste_villes();
    }

    [WebMethod]
    public List<Hotel> liste_hotels_ville(String cp)
    {
        ClsListerHotel myCls = new ClsListerHotel();
        Char[] mycp = cp.ToCharArray();
        return myCls.liste_hotels_ville(mycp);
    }

    [WebMethod]
    public List<Chambre> liste_chambres_hotels(String id)
    {
        ClsListerHotel myCls = new ClsListerHotel();
        return myCls.liste_chambres_hotels(Convert.ToInt16(id));
    }
}