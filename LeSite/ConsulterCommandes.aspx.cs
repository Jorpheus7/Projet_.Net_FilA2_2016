using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using voyage.cmdVol;
using voyage.cmdHotel;

public partial class ConsulterCommandes : System.Web.UI.Page
{
    public List<CmdVol> cmdsVol;
    public List<CmdHotel> cmdsHotel;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Consulter_Click(object sender, EventArgs e)
    {
        if (nomClient.Text != "" && prenomClient.Text != "")
        {
            ClsGererCmdVol myClsCmdVol = new ClsGererCmdVol();
            ClsGererCmdHotel myClsCmdHotel = new ClsGererCmdHotel();
            cmdsVol = myClsCmdVol.liste_cmdvol_nom_prenom(nomClient.Text, prenomClient.Text);
            cmdsHotel = myClsCmdHotel.liste_cmdhotel_nom_prenom(nomClient.Text, prenomClient.Text);
        }
    }
}