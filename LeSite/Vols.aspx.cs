using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReferenceWSVol;

public partial class recherche_vol : System.Web.UI.Page
{
     public vol[] volAllee;
     public vol[] volRetour;

    protected void Page_Load(object sender, EventArgs e)
    {
        WSVol myWS = new WSVol();
        aeroport[] myTabAero = myWS.Liste_Aeroports();
        string ch;
        // Remplissage des deux listes d'aeroport
        if (aeroportDepart.Text == "")
        {
            for (int i = 0; i < myTabAero.Length; i++)
            {
                ch = myTabAero[i].code + " " + myTabAero[i].ville + " " + myTabAero[i].pays;
                aeroportDepart.Items.Add(ch);
                aeroportArrivee.Items.Add(ch);
            }
        }
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        WSVol myWS = new WSVol();
        String depart = aeroportDepart.Text.Substring(0,3);
        String arrivee = aeroportArrivee.Text.Substring(0, 3);
        String dateD = dateDepart.Text;
        String dateR = dateRetour.Text;
        volAllee = myWS.Liste_Vols(depart, arrivee, dateD);
        volRetour= myWS.Liste_Vols(arrivee, depart, dateR);
    }
}