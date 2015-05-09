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
        // Remplissage des deux listes d'aeroport
        aeroportDepart.DataSource = myTabAero;
        aeroportArrivee.DataSource = myTabAero;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        WSVol myWS = new WSVol();
        String depart = aeroportDepart.Text;
        String arrivee = aeroportArrivee.Text;
        String dateD = dateDepart.Text;
        String dateR = dateRetour.Text;
        //Recuperation de la liste des vols disponibles
        vol[] volAllee = myWS.Liste_Vols(depart, arrivee, dateD);
        vol[] volRetour= myWS.Liste_Vols(arrivee, depart, dateR);
    }
}