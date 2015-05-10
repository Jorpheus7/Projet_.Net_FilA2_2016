using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReferenceWSHotel;

public partial class Hotels : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WSHotel myWS = new WSHotel();
        villeListe.DataSource = myWS.liste_villes();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        WSHotel myWS = new WSHotel();

        Hotel[] hotels = myWS.liste_hotels_ville(villeListe.Text);
    }
}