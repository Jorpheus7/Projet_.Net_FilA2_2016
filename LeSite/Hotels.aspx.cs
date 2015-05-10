using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RefWSHotel;

public partial class Hotels : System.Web.UI.Page
{
    public Hotel[] hotels;

    protected void Page_Load(object sender, EventArgs e)
    {
        WSHotel myWS = new WSHotel();
        string[][] mesVille = myWS.liste_villes();
        string ch;
        // Remplissage des deux listes d'aeroport
        if (villeListe.Text == "")
        {
            for (int i = 0; i < mesVille.Length; i++)
            {
                ch = mesVille[i][1] + " " + mesVille[i][0] + " " + mesVille[i][2];
                villeListe.Items.Add(ch);
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        WSHotel myWS = new WSHotel();

        hotels = myWS.liste_hotels_ville(villeListe.Text.Substring(0,6));
    }
}