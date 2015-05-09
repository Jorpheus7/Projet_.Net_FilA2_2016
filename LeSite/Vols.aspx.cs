using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReferenceWSVol;

public partial class recherche_vol : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WSVol myWS = new WSVol();
        aeroport[] myTabAero = myWS.Liste_Aeroports();
        // LIgne de test pour ROROMANMAN
        Label1.Text = myTabAero[0].ville;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}