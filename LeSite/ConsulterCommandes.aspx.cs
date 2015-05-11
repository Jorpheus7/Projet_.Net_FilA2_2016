using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using voyage.cmdVol;
using RefWSHotel;
using RefWSVol;
using voyage.cmdHotel;
using System.EnterpriseServices;

public partial class ConsulterCommandes : System.Web.UI.Page
{
    public List<vol> vols;
    public List<Hotel> hotels;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Consulter_Click(object sender, EventArgs e)
    {
        if (nomClient.Text != "" && prenomClient.Text != "")
        {
            List<CmdVol> cmdsVol;
            List<CmdHotel> cmdsHotel;
            voyage.cmdVol.Client cVol;
            voyage.cmdHotel.Client cHotel;
            WSVol myWSVol = new WSVol();
            WSHotel myWSHotel = new WSHotel();
            ClsGererCmdVol myClsCmdVol = new ClsGererCmdVol();
            ClsGererCmdHotel myClsCmdHotel = new ClsGererCmdHotel();

            cVol = myClsCmdVol.client_nom_prenom(nomClient.Text, prenomClient.Text);
            cHotel = myClsCmdHotel.client_nom_prenom(nomClient.Text, prenomClient.Text);
            cmdsVol = myClsCmdVol.liste_cmdvol_clientId(cVol.id);
            cmdsHotel = myClsCmdHotel.liste_cmdhotels_clientId(cHotel.id);


            foreach (var c in cmdsVol)
            {
                vols.Add(myWSVol.vol_id(c.idVol));
            }
            foreach (var h in cmdsHotel)
            {
                hotels.Add(myWSHotel.hotel_id(h.idHotel));
            }
        }
    }
}